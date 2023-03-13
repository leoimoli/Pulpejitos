using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class Configuracion_RazasWF : System.Web.UI.Page
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
                DivAltaRaza.Visible = false;
                FuncionListarRazas();
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
                Razas _Raza = CargarEntidad();
                bool RespuestaExitosa = RazaNeg.InsertarRaza(_Raza);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro de la nueva Raza.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "ELIMINAR")
            {
                bool RespuestaExitosa = false;
                Razas _Raza = CargarEntidad();

                ////// EstadoCategoria 1 = a Activo; EstadoMarca 0 = a Inactivo
                if (EstadoRaza == 1)
                {
                    int Valor = 0;
                    RespuestaExitosa = RazaNeg.EliminarRaza(_Raza, idRazaSeleccionada, Valor);
                }
                else
                {
                    int Valor = 1;
                    RespuestaExitosa = RazaNeg.EliminarRaza(_Raza, idRazaSeleccionada, Valor);
                }
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEliminar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición de la Raza.";
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
            string Raza = txtBuscarRaza.Value;

            List<Razas> _listaRaza = RazaNeg.BuscarRazaPorNombre(Raza);
            if (_listaRaza.Count > 0)
            {
                DivGrillaRaza.Visible = true;
                RepeaterRaza.DataSource = _listaRaza;
                RepeaterRaza.DataBind();
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
            }
            else
            {
                DivGrillaRaza.Visible = false;
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
    public static int idRazaSeleccionada = 0;
    protected void btnEliminarRaza_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "ELIMINAR";
        Razas _RazaSeleccionado = new Razas();
        idRazaSeleccionada = Convert.ToInt32(e.CommandArgument);
        _RazaSeleccionado = RazaNeg.ListarRazaPorId(idRazaSeleccionada);
        FuncionEliminar_HabilitarCampos(_RazaSeleccionado);
    }
    #endregion
    #region Metodos
    private void FuncionListarRazas()
    {
        List<Razas> ListaRaza = RazaNeg.ListarRaza();
        RepeaterRaza.DataSource = ListaRaza;
        RepeaterRaza.DataBind();
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
        DivGrillaRaza.Visible = false;
        DivAltaRaza.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        txtNombreRaza.Disabled = false;
        cmbAlta_Especie.Enabled = true;
        CargarComboEspecies();
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtNombreRaza.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro la Raza exitosamente.";
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
    }
    private Razas CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Razas _Raza = new Razas();
            _Raza.Nombre = txtNombreRaza.Value;
            _Raza.idEspecie = Convert.ToInt32(cmbAlta_Especie.SelectedItem.Value);
            DateTime fechaActual = DateTime.Now;
            _Raza.FechaAlta = fechaActual;
            _Raza.idUsuario = _usuarioActual.IdUsuario;
            return _Raza;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtNombreRaza.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre Raza es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_Cancelar()
    {
        txtNombreRaza.Value = String.Empty;
        DivGrillaRaza.Visible = true;
        DivAltaRaza.Visible = false;
        FuncionListarRazas();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        divAltaRazaEncabezado.InnerText = "ALTA RAZA";
        txtNombreRaza.Disabled = false;
    }
    private void LimpiarCampos_ExitoEliminar()
    {
        txtNombreRaza.Value = String.Empty;
        txtNombreRaza.Disabled = false;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se modificó el estado de la Raza exitosamente.";
        idRazaSeleccionada = 0;
        FuncionVariable = "NUEVO";
        divAltaRazaEncabezado.InnerText = "ALTA RAZA";
    }
    public static int EstadoRaza = 0;
    private void FuncionEliminar_HabilitarCampos(Razas RazaSeleccionado)
    {
        DivGrillaRaza.Visible = false;
        DivAltaRaza.Visible = true;
        txtNombreRaza.Value = RazaSeleccionado.Nombre;
        cmbAlta_Especie.ClearSelection();
        cmbAlta_Especie.Items.Add(new ListItem { Text = RazaSeleccionado.NombreEspecie, Value = Convert.ToString(RazaSeleccionado.idEspecie), Selected = true });
        cmbAlta_Especie.Enabled = false;
        txtNombreRaza.Disabled = true;
        string Estado = RazaSeleccionado.Estado;
        if (Estado == "Activo")
        { EstadoRaza = 1; }
        if (Estado == "Inactivo")
        { EstadoRaza = 0; }
        FuncionVariable = "ELIMINAR";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        if (EstadoRaza == 1)
            divAltaRazaEncabezado.InnerText = "ELIMINAR RAZA";
        if (EstadoRaza == 0)
            divAltaRazaEncabezado.InnerText = "REACTIVAR RAZA";
    }
    private void CargarComboEspecies()
    {
        cmbAlta_Especie.Items.Clear();
        List<Especies> EspecieSeleccionada = new List<Especies>();
        EspecieSeleccionada = EspecieNeg.CargarComboEspecie();
        cmbAlta_Especie.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Especies item in EspecieSeleccionada)
        {
            cmbAlta_Especie.Items.Add(new ListItem { Text = item.Nombre, Value = item.idEspecie.ToString() });
        }
    }
    #endregion
}