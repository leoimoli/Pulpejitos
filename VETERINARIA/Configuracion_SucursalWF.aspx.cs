using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class Configuracion_SucursalWF : System.Web.UI.Page
{
    private static Usuarios _usuarioActual { set; get; }
    private static Sucursal _sucursalActual { set; get; }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (HttpContext.Current.Session["USUARIO"] == null) Response.Redirect("IngresoWF.aspx");
            _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
            _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];

            if (!IsPostBack)
            {
                DivAltaSucursal.Visible = false;
                FuncionListarSucursal();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    #region Botones
    protected void btnNueva_Click(object sender, EventArgs e)
    {
        try
        {
            Funcion_Alta();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (FuncionVariable == "NUEVO")
            {
                Sucursal _Sucursal = CargarEntidad();
                bool RespuestaExitosa = SucursalesNeg.InsertarSucursal(_Sucursal);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro de la nueva Sucursal.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "ELIMINAR")
            {
                bool RespuestaExitosa = false;
                Sucursal _Sucursal = CargarEntidad();

                ////// EstadoCategoria 1 = a Activo; EstadoMarca 0 = a Inactivo
                if (EstadoSucursal == 1)
                {
                    int Valor = 0;
                    RespuestaExitosa = SucursalesNeg.EliminarSucursal(_Sucursal, idSucursalSeleccionada, Valor);
                }
                else
                {
                    int Valor = 1;
                    RespuestaExitosa = SucursalesNeg.EliminarSucursal(_Sucursal, idSucursalSeleccionada, Valor);
                }
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEliminar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición de la Sucursal.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
        }

        catch (Exception ex)
        {
            DivMensajeError.Visible = true;
            lblMensajeError.Text = ex.Message;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            LimpiarCampos_Cancelar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string Sucursal = txtBuscarSucursal.Value;

            List<Sucursal> _listaSucursal = SucursalesNeg.BuscarSucursalPorNombre(Sucursal);
            if (_listaSucursal.Count > 0)
            {
                DivGrillaSucursal.Visible = true;
                RepeaterSucursal.DataSource = _listaSucursal;
                RepeaterSucursal.DataBind();
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
            }
            else
            {
                DivGrillaSucursal.Visible = false;
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: No se encontraron resultados para la busqueda ingresada.";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static int idSucursalSeleccionada = 0;
    protected void btnEliminarCategoria_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "ELIMINAR";
        Sucursal _SucursalSeleccionado = new Sucursal();
        idSucursalSeleccionada = Convert.ToInt32(e.CommandArgument);
        _SucursalSeleccionado = SucursalesNeg.ListarSucursalPorId(idSucursalSeleccionada);
        FuncionEliminar_HabilitarCampos(_SucursalSeleccionado);
    }
    protected void cmbAlta_Provincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idProvinciaSeleccionada = Convert.ToInt32(cmbAlta_Provincia.SelectedItem.Value);
            CargarComboLocalidades(idProvinciaSeleccionada);
        }
        catch (Exception ex)
        { }
    }
    protected void cmbAlta_Localidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idLocalidadSeleccionada = Convert.ToInt32(cmbAlta_Localidad.SelectedItem.Value);
           txtCódigoPostal.Value = SucursalesNeg.ObtenerCodigoPostalPorLocalidad(idLocalidadSeleccionada);
        }
        catch (Exception ex)
        { }
    }

    #endregion

    #region Metodos
    private void FuncionListarSucursal()
    {
        List<Sucursal> ListaSucursal = SucursalesNeg.ListarSucursal();
        RepeaterSucursal.DataSource = ListaSucursal;
        RepeaterSucursal.DataBind();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
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
    public static string FuncionVariable = "";
    private void Funcion_Alta()
    {
        CargarComboProvincias();
        DivGrillaSucursal.Visible = false;
        DivAltaSucursal.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        txtNombreSucursal.Disabled = false;       
        txtCalle.Disabled = false;
        txtAltura.Disabled = false;
        txtCódigoPostal.Disabled = false;
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtNombreSucursal.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        txtCódigoPostal.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro la Sucursal exitosamente.";
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
    }
    private Sucursal CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Sucursal _Sucursal = new Sucursal();
            _Sucursal.Nombre = txtNombreSucursal.Value;
            _Sucursal.Calle = txtCalle.Value;
            _Sucursal.Altura = txtAltura.Value;
            _Sucursal.CodigoPostal = txtCódigoPostal.Value;
            _Sucursal.idProvincia = Convert.ToInt32(cmbAlta_Provincia.SelectedItem.Value);
            _Sucursal.idLocalidad = Convert.ToInt32(cmbAlta_Localidad.SelectedItem.Value);
            DateTime fechaActual = DateTime.Now;
            _Sucursal.FechaAlta = fechaActual;
            _Sucursal.idUsuario = _usuarioActual.IdUsuario;
            return _Sucursal;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtNombreSucursal.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre Sucursal es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_Cancelar()
    {
        txtNombreSucursal.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        txtCódigoPostal.Value = String.Empty;
        DivGrillaSucursal.Visible = true;
        DivAltaSucursal.Visible = false;
        FuncionListarSucursal();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        divAltaSucursalEncabezado.InnerText = "ALTA SUCURSAL";
        txtNombreSucursal.Disabled = false;
        txtCalle.Disabled = false;
        txtAltura.Disabled = false;
        txtCódigoPostal.Disabled = false;
    }
    private void LimpiarCampos_ExitoEliminar()
    {
        txtNombreSucursal.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        txtCódigoPostal.Value = String.Empty;
        cmbAlta_Provincia.ClearSelection();
        CargarComboProvincias();
        cmbAlta_Localidad.ClearSelection();

        txtNombreSucursal.Disabled = false;
        txtCalle.Disabled = false;
        txtAltura.Disabled = false;
        txtCódigoPostal.Disabled = false;

        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se modificó el estado de la sucursal exitosamente.";
        idSucursalSeleccionada = 0;
        FuncionVariable = "NUEVO";
        divAltaSucursalEncabezado.InnerText = "ALTA SUCURSAL";
    }
    public static int EstadoSucursal = 0;
    private void FuncionEliminar_HabilitarCampos(Sucursal sucursalSeleccionado)
    {
        DivGrillaSucursal.Visible = false;
        DivAltaSucursal.Visible = true;
        txtNombreSucursal.Value = sucursalSeleccionado.Nombre;
        txtCalle.Value = sucursalSeleccionado.Calle;
        txtAltura.Value = sucursalSeleccionado.Altura;
        txtCódigoPostal.Value = sucursalSeleccionado.CodigoPostal;

        txtNombreSucursal.Disabled = true;
        txtCalle.Disabled = true;
        txtAltura.Disabled = true;
        txtCódigoPostal.Disabled = true;


        string Estado = sucursalSeleccionado.Estado;
        if (Estado == "Activo")
        { EstadoSucursal = 1; }
        if (Estado == "Inactivo")
        { EstadoSucursal = 0; }
        FuncionVariable = "ELIMINAR";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        if (EstadoSucursal == 1)
            divAltaSucursalEncabezado.InnerText = "ELIMINAR SUCURSAL";
        if (EstadoSucursal == 0)
            divAltaSucursalEncabezado.InnerText = "REACTIVAR SUCURSAL";
    }
    private void CargarComboProvincias()
    {
        cmbAlta_Provincia.Items.Clear();
        List<Sucursal> ProvinciaSeleccionada = new List<Sucursal>();
        ProvinciaSeleccionada = SucursalesNeg.CargarComboProvincia();
        cmbAlta_Provincia.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Sucursal item in ProvinciaSeleccionada)
        {
            cmbAlta_Provincia.Items.Add(new ListItem { Text = item.NombreProvincia, Value = item.idProvincia.ToString() });
        }
    }
    private void CargarComboLocalidades(int idProvinciaSeleccionada)
    {
        cmbAlta_Localidad.Items.Clear();
        List<Sucursal> LocalidadSeleccionada = new List<Sucursal>();
        LocalidadSeleccionada = SucursalesNeg.CargarComboLocalidad(idProvinciaSeleccionada);
        cmbAlta_Localidad.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Sucursal item in LocalidadSeleccionada)
        {
            cmbAlta_Localidad.Items.Add(new ListItem { Text = item.NombreLocalidad, Value = item.idLocalidad.ToString() });
        }
    }
    #endregion
}