using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class _ProductoWF : Page
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
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnCargar_Click(object sender, EventArgs e)
    {
        try
        {
          
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
    #endregion
    #region Metodos
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
    #endregion
}