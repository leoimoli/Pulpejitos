﻿using BarcodeLib;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;
using Image = System.Drawing.Image;

public partial class _StockWF : Page
{
    private Usuarios _usuarioActual { set; get; }
    private Sucursal _sucursalActual { set; get; }
    public string FuncionVariable { get; set; }
    public int idProductoSeleccionado { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
                _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];
                DivAltaProducto.Visible = false;
                FuncionVariable = string.Empty;
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
            bool RespuestaExitosa = false;
            Productos _producto = CargarEntidad();
            if (FuncionVariable == "NUEVO")
            {
                RespuestaExitosa = ProductoNeg.InsertarProducto(_producto);
            }
            else if (FuncionVariable == "EDITAR")
            {
                RespuestaExitosa = ProductoNeg.EditarProducto(_producto, idProductoSeleccionado);
            }
            if (RespuestaExitosa)
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
            CargarCombos();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnNuevoProducto_Click(object sender, EventArgs e)
    {
        try
        {

            FuncionVariable = "NUEVO";
            DivAltaProducto.Visible = true;
            DivGrillaProductos.Visible = false;
            DivGrillaCargaStock.Visible = false;
            DivAltaStock.Visible = false;
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
            DivAltaStock.Visible = true;
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
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
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
            else
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: No se encontro ningun producto para el código producto ingresado.";
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
            DivAltaStock.Visible = true;
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
            FuncionListarProductos();
            DivGrillaProductos.Visible = true;
            DivAltaProducto.Visible = false;
            DivAltaStock.Visible = false;
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
    protected void btnEditarProducto_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "EDITAR";
        Productos _productoSeleccionado = new Productos();
        idProductoSeleccionado = Convert.ToInt32(e.CommandArgument);
        _productoSeleccionado = ProductoNeg.ListarProductosDisponibles(idProductoSeleccionado);
        FuncionEditar_HabilitarCampos(_productoSeleccionado);
    }
    #endregion
    #region Metodos
    public static List<Stock> StaticListProducto = new List<Stock>();
    public static int idProductoStatic = 0;

    private void FuncionEditar_HabilitarCampos(Productos productoSeleccionado)
    {
        DivAltaProducto.Visible = true;
        DivAltaStock.Visible = false;
        DivGrillaProductos.Visible = false;
        DivGrillaCargaStock.Visible = false;
        txtCodigo.Value = productoSeleccionado.CodigoProducto;
        cmbMarca.ClearSelection();
        cmbCategoria.ClearSelection();
        cmbUnidadesMedicion.ClearSelection();
        cmbMarca.SelectedValue = productoSeleccionado.idMarca.ToString();
        cmbCategoria.SelectedValue = productoSeleccionado.idCategoriaProducto.ToString();
        cmbUnidadesMedicion.SelectedValue = productoSeleccionado.idUnidadDeMedicion.ToString();
        txtDescripción.Value = productoSeleccionado.Descripcion;
        txtPrecio.Value = productoSeleccionado.PrecioDeVenta.ToString();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
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
        _producto.idUsuario = _usuarioActual.IdUsuario;
        _producto.PrecioDeVenta = decimal.Parse(txtPrecio.Value);
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
        try
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

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return StaticListProducto;
    }
    private void ValidarCamposObligatorios()
    {
        try
        {
            if (AltaStock_txtCodigoProducto.Value == String.Empty)
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Código Producto obligatorios.";
                throw new Exception();
            }
            if (AltaStock_Cantidad.Value == String.Empty)
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Cantidad obligatorios.";
                throw new Exception();
            }
            if (AltaStock_ValorUnitario.Value == String.Empty)
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Valor Unitario obligatorios.";
                throw new Exception();
            }
            if (AltaStock_cmbSucursal.SelectedItem.Value == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Sucursal Unitario obligatorios.";
                throw new Exception();
            }
            if (AltaStock_cmbProveedor.SelectedItem.Value == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Proveedor Unitario obligatorios.";
                throw new Exception();
            }

        }
        catch (Exception ex)
        {
            throw ex;
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
        //CargarComboProveedores();
        AltaStock_cmbProveedor.ClearSelection();
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
        //CargarComboProveedores();
        //CargarComboSucursal();
        AltaStock_cmbSucursal.ClearSelection();
        AltaStock_cmbProveedor.ClearSelection();
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
        txtCodigo.Value = string.Empty;
        txtDescripción.Value = string.Empty;
        txtPrecio.Value = string.Empty;
        DivMensajeExito.Visible = true;

        cmbMarca.ClearSelection();
        cmbCategoria.ClearSelection();
        cmbUnidadesMedicion.ClearSelection();
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
                lblMensajeError.Text = "Atención: Para generar un código de barra debe seleccionar un items del campo Categoria.";
                throw new Exception();
            }
            if (cmbMarca.SelectedValue == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: Para generar un código de barra debe seleccionar un items del campo Marca.";
                throw new Exception();
            }
            if (cmbUnidadesMedicion.SelectedValue == "0")
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: Para generar un código de barra debe seleccionar un items del campo Unidad de Medición.";
                throw new Exception();
            }
        }
        catch (Exception ex)
        {
            throw ex;
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
    private void MostrarMensajes(int mensajesVisible)
    {
        ///// NADA
        if (mensajesVisible == 0)
        {
            DivMensajeError.Visible = false;
            DivMensajeExito.Visible = false;
        }
        ///// Hay EXITO
        if (mensajesVisible == 1)
        {
            DivMensajeError.Visible = false;
            DivMensajeExito.Visible = true;
        }
        ///// Hay ERROR
        if (mensajesVisible == 2)
        {
            DivMensajeError.Visible = true;
            DivMensajeExito.Visible = false;
        }
    }
    #endregion
}