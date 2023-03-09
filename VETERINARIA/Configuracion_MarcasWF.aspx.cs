using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;
using Color = iTextSharp.text.Color;

public partial class Configuracion_MarcasWF : System.Web.UI.Page
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
                DivAltaMarca.Visible = false;
                FuncionListarMarcas();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    #region Botones
    protected void btnNuevaMarca_Click(object sender, EventArgs e)
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
                Marcas _marca = CargarEntidad();
                bool RespuestaExitosa = MarcasNeg.InsertarMarca(_marca);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro de la nueva marca.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "ELIMINAR")
            {
                bool RespuestaExitosa = false;
                Marcas _marca = CargarEntidad();
                ////// EstadoMarca 1 = a Activo; EstadoMarca 0 = a Inactivo
                if (EstadoMarca == 1)
                {
                    int Valor = 0;
                    RespuestaExitosa = MarcasNeg.EliminarMarca(_marca, idMarcaSeleccionada, Valor);
                }
                else
                {
                    int Valor = 1;
                    RespuestaExitosa = MarcasNeg.EliminarMarca(_marca, idMarcaSeleccionada, Valor);
                }
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEliminar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición del Cliente.";
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
            string marca = txtBuscarMarca.Value;

            List<Marcas> _listaMarcas = MarcasNeg.BuscarMarcasPorNombre(marca);
            if (_listaMarcas.Count > 0)
            {
                DivGrillaMarcas.Visible = true;
                RepeaterMarcas.DataSource = _listaMarcas;
                RepeaterMarcas.DataBind();
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
            }
            else
            {
                DivGrillaMarcas.Visible = false;
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
    public static int idMarcaSeleccionada = 0;
    protected void btnEliminarMarca_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "ELIMINAR";
        Marcas _marcaSeleccionado = new Marcas();
        idMarcaSeleccionada = Convert.ToInt32(e.CommandArgument);
        _marcaSeleccionado = MarcasNeg.ListarMarcaPorId(idMarcaSeleccionada);
        FuncionEliminar_HabilitarCampos(_marcaSeleccionado);
    }
    #endregion

    #region Metodos
    private void FuncionListarMarcas()
    {
        List<Marcas> ListaMarcas = MarcasNeg.ListarMarcas();
        RepeaterMarcas.DataSource = ListaMarcas;
        RepeaterMarcas.DataBind();
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
        DivGrillaMarcas.Visible = false;
        DivAltaMarca.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        txtNombreMarca.Disabled = false;
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtNombreMarca.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro la marca exitosamente.";
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
    }
    private Marcas CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Marcas _marca = new Marcas();
            _marca.Nombre = txtNombreMarca.Value;
            DateTime fechaActual = DateTime.Now;
            _marca.FechaAlta = fechaActual;
            _marca.idUsuario = _usuarioActual.IdUsuario;
            return _marca;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtNombreMarca.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre Marca es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_Cancelar()
    {
        txtNombreMarca.Value = String.Empty;
        DivGrillaMarcas.Visible = true;
        DivAltaMarca.Visible = false;
        FuncionListarMarcas();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        divAltaMarcaEncabezado.InnerText = "ALTA MARCA";
        txtNombreMarca.Disabled = false;
    }
    private void LimpiarCampos_ExitoEliminar()
    {
        txtNombreMarca.Value = String.Empty;
        txtNombreMarca.Disabled = false;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se modificó el estado de la marca exitosamente.";
        idMarcaSeleccionada = 0;
        FuncionVariable = "NUEVO";
        divAltaMarcaEncabezado.InnerText = "ALTA MARCA";
    }
    public static int EstadoMarca = 0;
    private void FuncionEliminar_HabilitarCampos(Marcas marcaSeleccionado)
    {
        DivGrillaMarcas.Visible = false;
        DivAltaMarca.Visible = true;
        txtNombreMarca.Value = marcaSeleccionado.Nombre;
        txtNombreMarca.Disabled = true;
        string Estado = marcaSeleccionado.Estado;
        if (Estado == "Activo")
        { EstadoMarca = 1; }
        FuncionVariable = "ELIMINAR";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        if (EstadoMarca == 1)
            divAltaMarcaEncabezado.InnerText = "ELIMINAR MARCA";      
        if (EstadoMarca == 0)
            divAltaMarcaEncabezado.InnerText = "REACTIVAR MARCA";
    }
    #endregion
}