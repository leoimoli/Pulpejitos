using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class Configuracion_CategoriasWF : System.Web.UI.Page
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
                DivAltaCategoria.Visible = false;
                FuncionListarCategorias();
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
                Categorias _categoria = CargarEntidad();
                bool RespuestaExitosa = CategoriasNeg.InsertarCategoria(_categoria);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro de la nueva categoria.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "ELIMINAR")
            {
                bool RespuestaExitosa = false;
                Categorias _categoria = CargarEntidad();

                ////// EstadoCategoria 1 = a Activo; EstadoMarca 0 = a Inactivo
                if (EstadoCategoria == 1)
                {
                    int Valor = 0;
                    RespuestaExitosa = CategoriasNeg.EliminarCategoria(_categoria, idCategoriaSeleccionada, Valor);
                }
                else
                {
                    int Valor = 1;
                    RespuestaExitosa = CategoriasNeg.EliminarCategoria(_categoria, idCategoriaSeleccionada, Valor);
                }
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEliminar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición de la Categoria.";
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
            string categoria = txtBuscarMarca.Value;

            List<Categorias> _listaCategoria = CategoriasNeg.BuscarCategoriaPorNombre(categoria);
            if (_listaCategoria.Count > 0)
            {
                DivGrillaCategoria.Visible = true;
                RepeaterCategoria.DataSource = _listaCategoria;
                RepeaterCategoria.DataBind();
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
            }
            else
            {
                DivGrillaCategoria.Visible = false;
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
    public static int idCategoriaSeleccionada = 0;
    protected void btnEliminarCategoria_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "ELIMINAR";
        Categorias _categoriasSeleccionado = new Categorias();
        idCategoriaSeleccionada = Convert.ToInt32(e.CommandArgument);
        _categoriasSeleccionado = CategoriasNeg.ListarCategoriaPorId(idCategoriaSeleccionada);
        FuncionEliminar_HabilitarCampos(_categoriasSeleccionado);
    }
    #endregion

    #region Metodos
    private void FuncionListarCategorias()
    {
        List<Categorias> ListaCategoria = CategoriasNeg.ListarCategoria();
        RepeaterCategoria.DataSource = ListaCategoria;
        RepeaterCategoria.DataBind();
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
        DivGrillaCategoria.Visible = false;
        DivAltaCategoria.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        txtNombreCategoria.Disabled = false;
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtNombreCategoria.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro la categoria exitosamente.";
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
    }
    private Categorias CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Categorias _categoria = new Categorias();
            _categoria.Nombre = txtNombreCategoria.Value;
            DateTime fechaActual = DateTime.Now;
            _categoria.FechaAlta = fechaActual;
            _categoria.idUsuario = _usuarioActual.IdUsuario;
            return _categoria;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtNombreCategoria.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre categoria es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_Cancelar()
    {
        txtNombreCategoria.Value = String.Empty;
        DivGrillaCategoria.Visible = true;
        DivAltaCategoria.Visible = false;
        FuncionListarCategorias();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        divAltaCategoriaEncabezado.InnerText = "ALTA CATEGORIA";
        txtNombreCategoria.Disabled = false;
    }
    private void LimpiarCampos_ExitoEliminar()
    {
        txtNombreCategoria.Value = String.Empty;
        txtNombreCategoria.Disabled = false;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se modificó el estado de la categoria exitosamente.";
        idCategoriaSeleccionada = 0;
        FuncionVariable = "NUEVO";
        divAltaCategoriaEncabezado.InnerText = "ALTA CATEGORIA";
    }
    public static int EstadoCategoria = 0;
    private void FuncionEliminar_HabilitarCampos(Categorias categoriaSeleccionado)
    {
        DivGrillaCategoria.Visible = false;
        DivAltaCategoria.Visible = true;
        txtNombreCategoria.Value = categoriaSeleccionado.Nombre;
        txtNombreCategoria.Disabled = true;
        string Estado = categoriaSeleccionado.Estado;
        if (Estado == "Activo")
        { EstadoCategoria = 1; }
        if (Estado == "Inactivo")
        { EstadoCategoria = 0; }
        FuncionVariable = "ELIMINAR";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        if (EstadoCategoria == 1)
            divAltaCategoriaEncabezado.InnerText = "ELIMINAR CATEGORIA";
        if (EstadoCategoria == 0)
            divAltaCategoriaEncabezado.InnerText = "REACTIVAR CATEGORIA";
    }
    #endregion
}