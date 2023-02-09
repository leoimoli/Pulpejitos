using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

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
            LimpiarCamposCargaStock();
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
                    bool value = true;
                    HabilitarCampos(value);
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

        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCancelarStock_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string Hola = "Hola Mundo";
    }
    #endregion
    #region Metodos
    public static List<Stock> StaticListProducto = new List<Stock>();
    private void CamposEnableFalse(bool value)
    {
        AltaStock_txtDescripcion.Disabled = !value;
        AltaStock_txtMarca.Disabled = !value;
        AltaStock_Remito.Disabled = !value;
        AltaStock_Cantidad.Disabled = !value;
        AltaStock_ValorUnitario.Disabled = !value;
        AltaStock_FechaFactura.Disabled = !value;
        AltaStock_txtProveedor.Disabled = !value;
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
        _producto.idUsuario = 1;
        return _producto;
    }
    private void LimpiarCampos()
    {
        txtCodigo.Value = String.Empty;
        txtDescripción.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "RESPUESTA EXITOSA.";
    }
    private void FuncionListarProductos()
    {
        List<Productos> ListaProductos = ProductoNeg.ListarProductosDisponibles();
        RepeaterProductos.DataSource = ListaProductos;
        RepeaterProductos.DataBind();
    }
    private void CargarCombos()
    {
        List<Marcas> MarcasSeleccionada = new List<Marcas>();
        MarcasSeleccionada = MarcasNeg.CargarComboMarcas();
        cmbMarca.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Marcas item in MarcasSeleccionada)
        {
            cmbMarca.Items.Add(new ListItem { Text = item.Nombre, Value = item.idMarca.ToString() });
        }

        List<Categorias> CategoriasSeleccionada = new List<Categorias>();
        CategoriasSeleccionada = CategoriasNeg.CargarComboCategoria();
        cmbCategoria.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Categorias item in CategoriasSeleccionada)
        {
            cmbCategoria.Items.Add(new ListItem { Text = item.Nombre, Value = item.idCategoria.ToString() });
        }

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
        //List<Stock> _listaProducto = new List<Stock>();
        Stock _producto = new Stock();
        _producto.idProducto = Convert.ToInt32(AltaStock_txtCodigoProducto.Value);
        _producto.idUsuario = 1;
        _producto.CodigoProducto = AltaStock_txtCodigoProducto.Value;
        _producto.Descripcion = AltaStock_txtDescripcion.Value;
        _producto.idProveedor = 1;
        _producto.Remito = AltaStock_Remito.Value;
        _producto.FechaFactura = Convert.ToDateTime(AltaStock_FechaFactura.Value);
        string Valor = AltaStock_ValorUnitario.Value;
        var temp = Valor.Replace(".", "<TEMP>");
        var temp2 = temp.Replace(",", ",");
        var replaced = temp2.Replace("<TEMP>", ",");
        _producto.ValorUnitario = Convert.ToDecimal(replaced);
        _producto.Cantidad = Convert.ToInt32(AltaStock_Cantidad.Value);
        _producto.MontoTotalPorProducto = _producto.ValorUnitario * _producto.Cantidad;
        StaticListProducto.Add(_producto);
        return StaticListProducto;
    }
    private void HabilitarCampos(bool value)
    {
        AltaStock_Remito.Disabled = !value;
        AltaStock_Cantidad.Disabled = !value;
        AltaStock_ValorUnitario.Disabled = !value;
        AltaStock_FechaFactura.Disabled = !value;
        AltaStock_txtProveedor.Disabled = !value;
    }
    private void LimpiarCamposCargaStock()
    {
        AltaStock_txtCodigoProducto.Value = String.Empty;
        AltaStock_txtMarca.Value = String.Empty;
        AltaStock_txtDescripcion.Value = String.Empty;
        AltaStock_ValorUnitario.Value = String.Empty;
        AltaStock_Cantidad.Value = String.Empty;
        AltaStock_txtProveedor.Disabled = true;
        AltaStock_FechaFactura.Disabled = true;
        AltaStock_Remito.Disabled = true;
    }
    #endregion
}