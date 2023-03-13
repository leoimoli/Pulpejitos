using iTextSharp.text.pdf.codec.wmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class Configuracion_EspeciesWF : System.Web.UI.Page
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
                DivAltaEspecie.Visible = false;
                FuncionListarEspecies();
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
                Especies _Especie = CargarEntidad();
                bool RespuestaExitosa = EspecieNeg.InsertarEspecie(_Especie);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro de la nueva Especie.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "ELIMINAR")
            {
                bool RespuestaExitosa = false;
                Especies _Especie = CargarEntidad();

                ////// EstadoCategoria 1 = a Activo; EstadoMarca 0 = a Inactivo
                if (EstadoEspecie == 1)
                {
                    int Valor = 0;
                    RespuestaExitosa = EspecieNeg.EliminarEspecie(_Especie, idEspecieSeleccionada, Valor);
                }
                else
                {
                    int Valor = 1;
                    RespuestaExitosa = EspecieNeg.EliminarEspecie(_Especie, idEspecieSeleccionada, Valor);
                }
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEliminar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición de la Especie.";
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
            string especie = txtBuscarEspecie.Value;

            List<Especies> _listaEspecie = EspecieNeg.BuscarEspeciePorNombre(especie);
            if (_listaEspecie.Count > 0)
            {
                DivGrillaEspecie.Visible = true;
                RepeaterEspecie.DataSource = _listaEspecie;
                RepeaterEspecie.DataBind();
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
            }
            else
            {
                DivGrillaEspecie.Visible = false;
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
    public static int idEspecieSeleccionada = 0;
    protected void btnEliminarEspecie_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "ELIMINAR";
        Especies _especieSeleccionado = new Especies();
        idEspecieSeleccionada = Convert.ToInt32(e.CommandArgument);
        _especieSeleccionado = EspecieNeg.ListarEspeciePorId(idEspecieSeleccionada);
        FuncionEliminar_HabilitarCampos(_especieSeleccionado);
    }
    #endregion

    #region Metodos
    private void FuncionListarEspecies()
    {
        List<Especies> ListaEspecie = EspecieNeg.ListarEspecie();
        RepeaterEspecie.DataSource = ListaEspecie;
        RepeaterEspecie.DataBind();
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
        DivGrillaEspecie.Visible = false;
        DivAltaEspecie.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        txtNombreEspecie.Disabled = false;
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtNombreEspecie.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro la especie exitosamente.";
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
    }
    private Especies CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Especies _especie = new Especies();
            _especie.Nombre = txtNombreEspecie.Value;
            DateTime fechaActual = DateTime.Now;
            _especie.FechaAlta = fechaActual;
            _especie.idUsuario = _usuarioActual.IdUsuario;
            return _especie;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtNombreEspecie.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre especie es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_Cancelar()
    {
        txtNombreEspecie.Value = String.Empty;
        DivGrillaEspecie.Visible = true;
        DivAltaEspecie.Visible = false;
        FuncionListarEspecies();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        divAltaEspecieEncabezado.InnerText = "ALTA ESPECIE";
        txtNombreEspecie.Disabled = false;
    }
    private void LimpiarCampos_ExitoEliminar()
    {
        txtNombreEspecie.Value = String.Empty;
        txtNombreEspecie.Disabled = false;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se modificó el estado de la especie exitosamente.";
        idEspecieSeleccionada = 0;
        FuncionVariable = "NUEVO";
        divAltaEspecieEncabezado.InnerText = "ALTA ESPECIE";
    }
    public static int EstadoEspecie = 0;
    private void FuncionEliminar_HabilitarCampos(Especies especieSeleccionado)
    {
        DivGrillaEspecie.Visible = false;
        DivAltaEspecie.Visible = true;
        txtNombreEspecie.Value = especieSeleccionado.Nombre;
        txtNombreEspecie.Disabled = true;
        string Estado = especieSeleccionado.Estado;
        if (Estado == "Activo")
        { EstadoEspecie = 1; }
        if (Estado == "Inactivo")
        { EstadoEspecie = 0; }
        FuncionVariable = "ELIMINAR";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        if (EstadoEspecie == 1)
            divAltaEspecieEncabezado.InnerText = "ELIMINAR ESPECIE";
        if (EstadoEspecie == 0)
            divAltaEspecieEncabezado.InnerText = "REACTIVAR ESPECIE";
    }
    #endregion
}