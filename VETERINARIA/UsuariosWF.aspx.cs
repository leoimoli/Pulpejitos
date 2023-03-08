using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class UsuariosWF : System.Web.UI.Page
{
    private static Usuarios _usuarioActual { get; set; }
    private static Sucursal _sucursalActual { get; set; }
    public static int idUsuarioSeleccionado = 0;
    public static string FuncionVariable = string.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (HttpContext.Current.Session["USUARIO"] == null) Response.Redirect("IngresoWF.aspx");
            _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
            _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];

            if (!IsPostBack)
            {
                CargarCombos();
                FuncionListarUsuarios();
                DivAltaUsuario.Visible = false;
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Botones
    protected void btnNuevoUsuario_Click(object sender, EventArgs e)
    {
        try
        {
            Funcion_AltaUsuario();
        }
        catch (Exception ex)
        {
            MostrarMensajeError(ex.Message);
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Usuarios _usuario = CargarEntidad();
            if (FuncionVariable == "NUEVO")
            {
                UsuariosNeg.InsertarUsuario(_usuario);
                LimpiarCampos_ExitoInsert();
                MonstrarMensajeExito("El usuario fue registrador correctamente.");
            }
            if (FuncionVariable == "EDITAR")
            {
                UsuariosNeg.EditarUsuario(_usuario, idUsuarioSeleccionado);
                LimpiarCampos_ExitoEditar();
                MonstrarMensajeExito("El usuario fue editado correctamente.");
            }
        }
        catch (Exception ex)
        {
            MostrarMensajeError(ex.Message);
        }
    }

    protected void btnEditarCliente_Command(object sender, CommandEventArgs e)
    {
        try
        {
            FuncionVariable = "EDITAR";
            Usuarios _usuarioSeleccionado = new Usuarios();
            idUsuarioSeleccionado = Convert.ToInt32(e.CommandArgument);
            _usuarioSeleccionado = UsuariosNeg.ListarUsuariosPorId(idUsuarioSeleccionado);
            FuncionEditar_HabilitarCampos(_usuarioSeleccionado);
        }
        catch (Exception ex)
        {
            MostrarMensajeError(ex.Message);
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
            MostrarMensajeError(ex.Message);
        }
    }
    #endregion

    #region Metodos
    private void FuncionListarUsuarios()
    {
        List<Usuarios> listaUsuarios = UsuariosNeg.ListarUsuarios();
        RepeaterUsuarios.DataSource = listaUsuarios;
        RepeaterUsuarios.DataBind();
    }

    private void Funcion_AltaUsuario()
    {
        OcultarGrillas();
        OcultarMensajes();
        FuncionVariable = "NUEVO";
        DivAltaUsuario.Visible = true;
    }

    private Usuarios CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Usuarios _usuario = new Usuarios();
            _usuario.Dni = txtDni.Value;
            _usuario.Apellido = txtApellido.Value;
            _usuario.Nombre = txtNombre.Value;
            _usuario.Contraseña = txtContraseña.Value;
            _usuario.idUsuarioAlta = _usuarioActual.IdUsuario;
            DateTime fechaActual = DateTime.Now;
            _usuario.FechaDeAlta = fechaActual;
            _usuario.FechaUltimaConexion = fechaActual;
            return _usuario;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            OcultarMensajes();
            if (String.IsNullOrEmpty(txtDni.Value))
            {
                throw new Exception("Atención: El campo Dni es un dato obligatorio.");
            }
            if (String.IsNullOrEmpty(txtApellido.Value))
            {
                throw new Exception("Atención: El campo Apellido es un dato obligatorio.");
            }
            if (String.IsNullOrEmpty(txtNombre.Value))
            {
                throw new Exception("Atención: El campo Nombre es un dato obligatorio.");
            }
            if (String.IsNullOrEmpty(txtContraseña.Value))
            {
                throw new Exception("Atención: El campo Contraseña es un dato obligatorio.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void LimpiarCampos_ExitoInsert()
    {
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtContraseña.Value = String.Empty;
        DeseleccionarCombos();
    }

    private void LimpiarCampos_ExitoEditar()
    {
        txtDni.Disabled = false;
        LimpiarCamposTexto();
        DeseleccionarCombos();
        SeleccionarCombosDefecto();
        FuncionVariable = "NUEVO";
    }

    private void LimpiarCampos_Cancelar()
    {
        OcultarMensajes();
        LimpiarCamposTexto();
        OcultarFormularios();
        FuncionListarUsuarios();
        SeleccionarCombosDefecto();
        DivGrillaUsuarios.Visible = true;
    }

    private void MonstrarMensajeExito(string mensaje)
    {
        DivMensajeError.Visible = true;
        lblMensajeError.Text = mensaje;
    }

    private void MostrarMensajeError(string mensaje)
    {
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = mensaje;
    }

    private void OcultarMensajes()
    {
        DivMensajeError.Visible = false;
        DivMensajeExito.Visible = false;
    }

    private void OcultarGrillas()
    {
        DivGrillaUsuarios.Visible = false;
    }

    private void OcultarFormularios()
    {
        DivAltaUsuario.Visible = false;
    }
    private void DeseleccionarCombos()
    {
        cmbEstado.ClearSelection();
        cmbPerfil.ClearSelection();
    }

    private void SeleccionarCombosDefecto()
    {
        cmbEstado.Items.FindByValue("1").Selected = true;
        cmbPerfil.Items.FindByValue("1").Selected = true;
    }

    private void LimpiarCamposTexto()
    {
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtContraseña.Value = String.Empty;
    }

    private void CargarCombos()
    {
        cmbPerfil.Items.Clear();
        List<Perfiles> perfiles = new List<Perfiles>();
        perfiles = PerfilNeg.ObtenerPerfiles();
        foreach (Perfiles item in perfiles)
        {
            cmbPerfil.Items.Add(new ListItem { Text = item.NombrePerfil, Value = item.idPerfil.ToString() });
        }
        cmbPerfil.Items.FindByValue("1").Selected = true;

        cmbEstado.Items.Clear();
        cmbEstado.Items.Add(new ListItem { Text = "Activo", Value = "1", Selected = true });
        cmbEstado.Items.Add(new ListItem { Text = "Inactivo", Value = "2" });
    }

    private void FuncionEditar_HabilitarCampos(Usuarios usuarioSeleccionado)
    {
        OcultarGrillas();
        OcultarMensajes();
        OcultarFormularios();
        DeseleccionarCombos();
        cmbEstado.Items.FindByValue(usuarioSeleccionado.idEstado.ToString()).Selected = true;
        cmbPerfil.Items.FindByValue(usuarioSeleccionado.idPerfil.ToString()).Selected = true;
        txtNombre.Value = usuarioSeleccionado.Nombre;
        txtApellido.Value = usuarioSeleccionado.Apellido;
        txtContraseña.Value = usuarioSeleccionado.Contraseña;
        txtDni.Value = usuarioSeleccionado.Dni;
        txtDni.Disabled = true;
        DivAltaUsuario.Visible = true;
    }
    #endregion
}