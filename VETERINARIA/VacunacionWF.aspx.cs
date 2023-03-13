using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class VacunacionWF : System.Web.UI.Page
{
    private Usuarios _usuarioActual { get; set; }
    private Sucursal _sucursalActual { get; set; }
    private Mascotas _mascotaActual { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (HttpContext.Current.Session["USUARIO"] == null) Response.Redirect("IngresoWF.aspx");
            _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
            _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];
            _mascotaActual = (Mascotas)HttpContext.Current.Session["MASCOTA"];

            if (!IsPostBack)
            {
                txtNombreMascota.Value = _mascotaActual.Nombre;
                txtEspecie.Value = _mascotaActual.NombreEspecie;
                txtRaza.Value = _mascotaActual.NombreRaza;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Botones
    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        try
        {
            Funcion_AltaVacunacion();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            //if (FuncionVariable == "NUEVO")
            //{
            //    Categorias _categoria = CargarEntidad();
            //    bool RespuestaExitosa = CategoriasNeg.InsertarCategoria(_categoria);
            //    if (RespuestaExitosa == true)
            //    {
            //        LimpiarCampos_ExitoInsert();
            //    }
            //    else
            //    {
            //        int MensajesVisible = 2;
            //        MostrarMensajes(MensajesVisible);
            //        lblMensajeError.Text = "Atención: Falló el registro de la nueva categoria.";
            //        throw new Exception(lblMensajeError.Text);
            //    }
            //}
            //if (FuncionVariable == "ELIMINAR")
            //{
            //    bool RespuestaExitosa = false;
            //    Categorias _categoria = CargarEntidad();

            //    ////// EstadoCategoria 1 = a Activo; EstadoMarca 0 = a Inactivo
            //    if (EstadoCategoria == 1)
            //    {
            //        int Valor = 0;
            //        RespuestaExitosa = CategoriasNeg.EliminarCategoria(_categoria, idCategoriaSeleccionada, Valor);
            //    }
            //    else
            //    {
            //        int Valor = 1;
            //        RespuestaExitosa = CategoriasNeg.EliminarCategoria(_categoria, idCategoriaSeleccionada, Valor);
            //    }
            //    if (RespuestaExitosa == true)
            //    {
            //        LimpiarCampos_ExitoEliminar();
            //    }
            //    else
            //    {
            //        int MensajesVisible = 2;
            //        MostrarMensajes(MensajesVisible);
            //        lblMensajeError.Text = "Atención: Falló la edición de la Categoria.";
            //        throw new Exception(lblMensajeError.Text);
            //    }
            //}
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

    private void LimpiarCampos_Cancelar()
    {
        DivAltaVacunacion.Visible = false;
        DivGrillaVacunacion.Visible = true;
        //FuncionListarCategorias();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
    #endregion

    #region Metodos
    public static string FuncionVariable = "";
    private void Funcion_AltaVacunacion()
    {
        DivGrillaVacunacion.Visible = false;
        DivAltaVacunacion.Visible = true;
        FuncionVariable = "NUEVO";
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
    #endregion
}