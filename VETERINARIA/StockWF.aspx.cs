using Antlr.Runtime.Misc;
using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;
using Image = System.Drawing.Image;

public partial class _StockWF : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DivAltaProducto.Visible = false;
                CargarCombos();
                FuncionListarProductos();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Botones
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Productos _producto = CargarEntidad();
            bool RespuestaExitosa = ProductoNeg.InsertarProducto(_producto);
            if (RespuestaExitosa == true)
            {
                LimpiarCampos();
                FuncionListarProductos();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            DivGrillaProductos.Visible = true;
            DivAltaProducto.Visible = false;
            idProductoStatic = 0;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnNuevoProducto_Click(object sender, EventArgs e)
    {
        try
        {
            DivGrillaProductos.Visible = false;
            DivAltaProducto.Visible = true;
            divAltaStock.Visible = false;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnRegistrarStock_Click(object sender, EventArgs e)
    {
        try
        {
            DivGrillaProductos.Visible = false;
            DivAltaProducto.Visible = false;
            divAltaStock.Visible = true;
            bool value = false;
            CamposEnableFalse(value);
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        try
        {
            List<Stock> EntidadStock = CargarEntidadRegistroStock();
            lblTotalFactura.Text = StaticListProducto.Sum(x => x.MontoTotalPorProducto).ToString();
            RepeaterCargaStock.DataSource = StaticListProducto;
            RepeaterCargaStock.DataBind();
            DivGrillaCargaStock.Visible = true;
            LimpiarCamposCargaStockExito();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnBuscarProducto_Click(object sender, EventArgs e)
    {
        try
        {
            string Descripcion = AltaStock_txtCodigoProducto.Value;
            List<Stock> Producto = ProductoNeg.BuscarProductoPorCodigo(Descripcion);
            if (Producto.Count > 0)
            {
                foreach (Stock item in Producto)
                {
                    AltaStock_txtCodigoProducto.Value = Descripcion;
                    AltaStock_txtDescripcion.Value = item.Descripcion;
                    AltaStock_txtMarca.Value = item.NombreMarca;
                    idProductoStatic = item.idProducto;

                    //CargarComboProveedores();
                    bool value = true;
                    if (StaticListProducto.Count > 0)
                    {
                        AltaStock_Remito.Disabled = true;
                        AltaStock_FechaFactura.Disabled = true;
                        //AltaStock_cmbProveedor.Enabled = true;
                        AltaStock_txtMarca.Disabled = true;
                    }
                    else
                    { HabilitarCampos(value); }

                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnGuardarStock_Click(object sender, EventArgs e)
    {
        try
        {
            decimal MontoTotalFactura = Convert.ToDecimal(lblTotalFactura.Text);
            int Respuesta = StockNeg.RegistrarStock(StaticListProducto, MontoTotalFactura);
            if (Respuesta > 0)
            {
                LimpiarCamposGuardarStockExito();
            }
        }
        catch (Exception ex)
        { }

    }
    protected void btnCancelarStock_Click(object sender, EventArgs e)
    {
        try
        {
            DivGrillaProductos.Visible = false;
            DivAltaProducto.Visible = false;
            divAltaStock.Visible = true;
            bool value = false;
            CamposEnableFalse(value);
            LimpiarCamposCargaStockCancelar();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnVolver_Click(object sender, EventArgs e)
    {
        try
        {
            bool value = false;
            CamposEnableFalse(value);
            LimpiarCamposCargaStockCancelar();
            DivGrillaProductos.Visible = true;
            DivAltaProducto.Visible = false;
            divAltaStock.Visible = false;
            DivGrillaCargaStock.Visible = false;
            idProductoStatic = 0;
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnGenerarCodigo_Click(object sender, EventArgs e)
    {
        try
        {
            ValidarCamposNecesarios();
            GenerarCodigoDeBarra();
        }
        catch (Exception ex)
        {

        }
    }
    #endregion
    #region Metodos
    public static List<Stock> StaticListProducto = new List<Stock>();
    public static int idProductoStatic = 0;
    private Productos CargarEntidad()
    {
        Productos _producto = new Productos();
        _producto.CodigoProducto = txtCodigo.Value;
        _producto.idCategoriaProducto = Convert.ToInt32(cmbMarca.SelectedItem.Value);
        _producto.Descripcion = txtDescripción.Value;
        _producto.idMarca = Convert.ToInt32(cmbMarca.SelectedItem.Value);
        _producto.idUnidadDeMedicion = Convert.ToInt32(cmbMarca.SelectedItem.Value);
        DateTime fechaActual = DateTime.Now;
        _producto.FechaDeAlta = fechaActual;
        _producto.idUsuario = 1;
        return _producto;
    }
    private void FuncionListarProductos()
    {
        List<Productos> ListaProductos = ProductoNeg.ListarProductosDisponibles();
        RepeaterProductos.DataSource = ListaProductos;
        RepeaterProductos.DataBind();
    }
    private void CargarCombos()
    {
        cmbMarca.Items.Clear();
        List<Marcas> MarcasSeleccionada = new List<Marcas>();
        MarcasSeleccionada = MarcasNeg.CargarComboMarcas();
        cmbMarca.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Marcas item in MarcasSeleccionada)
        {
            cmbMarca.Items.Add(new ListItem { Text = item.Nombre, Value = item.idMarca.ToString() });
        }
        cmbCategoria.Items.Clear();
        List<Categorias> CategoriasSeleccionada = new List<Categorias>();
        CategoriasSeleccionada = CategoriasNeg.CargarComboCategoria();
        cmbCategoria.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Categorias item in CategoriasSeleccionada)
        {
            cmbCategoria.Items.Add(new ListItem { Text = item.Nombre, Value = item.idCategoria.ToString() });
        }

        cmbUnidadesMedicion.Items.Clear();
        List<UnidadDeMedicion> UnidadesMedicionSeleccionada = new List<UnidadDeMedicion>();
        UnidadesMedicionSeleccionada = UnidadMedicionNeg.CargarComboUnidadDeMedicion();
        cmbUnidadesMedicion.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (UnidadDeMedicion item in UnidadesMedicionSeleccionada)
        {
            cmbUnidadesMedicion.Items.Add(new ListItem { Text = item.Nombre, Value = item.idUnidadDeMedicion.ToString() });
        }
    }
    private List<Stock> CargarEntidadRegistroStock()
    {
        ValidarCamposObligatorios();
        Stock _producto = new Stock();
        _producto.idProducto = idProductoStatic;
        _producto.idUsuario = 1;
        _producto.CodigoProducto = AltaStock_txtCodigoProducto.Value;
        _producto.Descripcion = AltaStock_txtDescripcion.Value;
        _producto.idProveedor = Convert.ToInt32(AltaStock_cmbProveedor.SelectedItem.Value);
        _producto.idSucursal = Convert.ToInt32(AltaStock_cmbSucursal.SelectedItem.Value);
        _producto.Remito = AltaStock_Remito.Value;
        _producto.FechaFactura = Convert.ToDateTime(AltaStock_FechaFactura.Value);
        string Valor = AltaStock_ValorUnitario.Value;
        var temp = Valor.Replace(".", "<TEMP>");
        var temp2 = temp.Replace(",", ",");
        var replaced = temp2.Replace("<TEMP>", ",");
        _producto.ValorUnitario = Convert.ToDecimal(replaced);
        _producto.Cantidad = Convert.ToInt32(AltaStock_Cantidad.Value);
        _producto.MontoTotalPorProducto = _producto.ValorUnitario * _producto.Cantidad;
        _producto.FechaRegistro = DateTime.Now;
        StaticListProducto.Add(_producto);
        return StaticListProducto;
    }
    private void ValidarCamposObligatorios()
    {
        if (AltaStock_txtCodigoProducto.Value == String.Empty || AltaStock_Cantidad.Value == String.Empty || AltaStock_ValorUnitario.Value == String.Empty)
        {
            DivMensajeError.Visible = true;
            lblMensajeError.Text = "Atención: Faltan completar campos obligatorios.";
        }
    }
    private void HabilitarCampos(bool value)
    {
        CargarComboProveedores();
        CargarComboSucursal();
        AltaStock_Remito.Disabled = !value;
        AltaStock_Cantidad.Disabled = !value;
        AltaStock_ValorUnitario.Disabled = !value;
        AltaStock_FechaFactura.Disabled = !value;
        // AltaStock_cmbProveedor.Enabled = !value;
    }
    private void CamposEnableFalse(bool value)
    {
        AltaStock_txtDescripcion.Disabled = !value;
        AltaStock_txtMarca.Disabled = !value;
        AltaStock_Remito.Disabled = !value;
        AltaStock_Cantidad.Disabled = !value;
        AltaStock_ValorUnitario.Disabled = !value;
        AltaStock_FechaFactura.Disabled = !value;
        //AltaStock_cmbProveedor.Enabled = value;       
    }
    private void LimpiarCamposCargaStockExito()
    {
        AltaStock_txtCodigoProducto.Value = String.Empty;
        AltaStock_txtMarca.Value = String.Empty;
        AltaStock_txtDescripcion.Value = String.Empty;
        AltaStock_ValorUnitario.Value = String.Empty;
        AltaStock_Cantidad.Value = String.Empty;
        AltaStock_cmbProveedor.Enabled = true;
        AltaStock_FechaFactura.Disabled = true;
        AltaStock_Remito.Disabled = true;
    }
    private void LimpiarCamposCargaStockCancelar()
    {
        AltaStock_txtCodigoProducto.Value = String.Empty;
        AltaStock_txtMarca.Value = String.Empty;
        AltaStock_txtDescripcion.Value = String.Empty;
        AltaStock_ValorUnitario.Value = String.Empty;
        AltaStock_Cantidad.Value = String.Empty;
        CargarComboProveedores();
        AltaStock_FechaFactura.Value = String.Empty;
        AltaStock_Remito.Value = String.Empty;
        DivGrillaCargaStock.Visible = false;
        RepeaterCargaStock.DataSource = null;
        RepeaterCargaStock.DataBind();
        lblTotalFactura.Text = "0";
        StaticListProducto = new List<Stock>();
    }
    private void LimpiarCamposGuardarStockExito()
    {
        AltaStock_txtCodigoProducto.Value = String.Empty;
        AltaStock_txtMarca.Value = String.Empty;
        AltaStock_txtDescripcion.Value = String.Empty;
        AltaStock_ValorUnitario.Value = String.Empty;
        AltaStock_Cantidad.Value = String.Empty;
        AltaStock_Remito.Value = String.Empty;
        AltaStock_FechaFactura.Value = String.Empty;
        AltaStock_cmbProveedor.Enabled = false;
        AltaStock_FechaFactura.Disabled = false;
        AltaStock_Remito.Disabled = false;
        DivGrillaCargaStock.Visible = false;
        CargarComboProveedores();
        CargarComboSucursal();
        RepeaterCargaStock.DataSource = null;
        RepeaterCargaStock.DataBind();
        lblTotalFactura.Text = "0";
        StaticListProducto = new List<Stock>();
        idProductoStatic = 0;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Se registro el ingreso de Stock exitosamente.";
    }
    private void LimpiarCampos()
    {
        txtCodigo.Value = String.Empty;
        txtDescripción.Value = String.Empty;
        DivMensajeExito.Visible = true;
        CargarCombos();
        lblMensajeExito.Text = "Atención: Se género un nuevo producto exitosamente.";
    }
    private void CargarComboProveedores()
    {
        List<Proveedores> ProveedoresSeleccionada = new List<Proveedores>();
        ProveedoresSeleccionada = ProveedoresNeg.CargarComboProveedores();
        AltaStock_cmbProveedor.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Proveedores item in ProveedoresSeleccionada)
        {
            AltaStock_cmbProveedor.Items.Add(new ListItem { Text = item.NombreEmpresa, Value = item.idProveedor.ToString() });
        }
    }
    private void CargarComboSucursal()
    {
        List<Sucursal> SucursalesSeleccionada = new List<Sucursal>();
        SucursalesSeleccionada = SucursalesNeg.CargarComboSucursal();
        AltaStock_cmbSucursal.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Sucursal item in SucursalesSeleccionada)
        {
            AltaStock_cmbSucursal.Items.Add(new ListItem { Text = item.Nombre, Value = item.idSucursal.ToString() });
        }
    }
    private void ValidarCamposNecesarios()
    {
        try
        {
            if (cmbCategoria.SelectedValue == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: Para generar un código de barra de seleccionar un items del campo Categoria.";
            }
            if (cmbMarca.SelectedValue == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: Para generar un código de barra de seleccionar un items del campo Marca.";
            }
            if (cmbUnidadesMedicion.SelectedValue == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: Para generar un código de barra de seleccionar un items del campo Unidad de Medición.";
            }
        }
        catch (Exception ex)
        {

        }
    }
    private void GenerarCodigoDeBarra()
    {
        string InicioCodigo = "999";
        string ParteCentralCodigo = cmbCategoria.SelectedItem.Value + cmbMarca.SelectedItem.Value + cmbUnidadesMedicion.SelectedItem.Value;
        string Dia = Convert.ToString(DateTime.Now.Date.Day);
        string Mes = Convert.ToString(DateTime.Now.Date.Month);
        string Año = Convert.ToString(DateTime.Now.Date.Year);
        string Hora = Convert.ToString(DateTime.Now.Hour);
        string Minutos = Convert.ToString(DateTime.Now.Minute);
        string Segundos = Convert.ToString(DateTime.Now.Second);
        string ParteFinalCodigo = Dia + Mes + Año;
        string CodigoArmado = InicioCodigo + ParteCentralCodigo + ParteFinalCodigo + Hora + Minutos + Segundos;

        ///// Validamos que el código ya no exista.
        bool CodigoExistente = StockNeg.ValidarCodigoExistente(CodigoArmado);
        if (CodigoExistente == false)
        {
            string Contenido = CodigoArmado;
            Barcode codigo = new Barcode();
            codigo.IncludeLabel = true;
            codigo.Alignment = AlignmentPositions.CENTER;
            codigo.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = codigo.Encode(TYPE.CODE128, Contenido, Color.Black, Color.White, 200, 140);
            codigo.SaveImage(@"C:\Users\Usuario\source\repos\Pulpejitos-Repositorio\VETERINARIA\Img\Codigos_De_Barra\ '" + CodigoArmado + "' .jpg", SaveTypes.JPG);
            DivMensajeExito.Visible = true;
            lblMensajeExito.Text = "Atención: Se género un nuevo código de barra exitosamente";
            txtCodigo.Value = CodigoArmado;
        }
        else
        {
            CodigoArmado = InicioCodigo + ParteCentralCodigo + ParteFinalCodigo + Hora + Minutos + Segundos + 1;
            string Contenido = CodigoArmado;
            Barcode codigo = new Barcode();
            codigo.IncludeLabel = true;
            codigo.Alignment = AlignmentPositions.CENTER;
            codigo.LabelFont = new Font(FontFamily.GenericMonospace, 14, FontStyle.Regular);
            Image img = codigo.Encode(TYPE.CODE128, Contenido, Color.Black, Color.White, 200, 140);
            codigo.SaveImage(@"C:\Users\Usuario\source\repos\Pulpejitos-Repositorio\VETERINARIA\Img\Codigos_De_Barra\ '" + CodigoArmado + "' .jpg", SaveTypes.JPG);
            DivMensajeExito.Visible = true;
            lblMensajeExito.Text = "Atención: Se género un nuevo código de barra exitosamente";
            txtCodigo.Value = CodigoArmado;
        }
    }
    #endregion
}