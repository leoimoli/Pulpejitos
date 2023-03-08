using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class ClientesWF : System.Web.UI.Page
{
    private Usuarios _usuarioActual { get; set; }
    private Sucursal _sucursalActual { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (HttpContext.Current.Session["USUARIO"] == null) Response.Redirect("IngresoWF.aspx");
            _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
            _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];

            if (!IsPostBack)
            {
                DivAltaCliente.Visible = false;
                FuncionListarClientes();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    #region Botones
    protected void btnNuevoCliente_Click(object sender, EventArgs e)
    {
        try
        {
            Funcion_AltaCliente();
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
                Clientes _cliente = CargarEntidad();
                bool RespuestaExitosa = ClientesNeg.InsertarCliente(_cliente);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro del Cliente.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "EDITAR")
            {
                Clientes _cliente = CargarEntidad();
                bool RespuestaExitosa = ClientesNeg.EditarCliente(_cliente, idClienteSeleccionado);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEditar();
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
    public static int idClienteSeleccionado = 0;
    protected void btnEditarCliente_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "EDITAR";
        Clientes _clienteSeleccionado = new Clientes();
        idClienteSeleccionado = Convert.ToInt32(e.CommandArgument);
        _clienteSeleccionado = ClientesNeg.ListarClientePorId(idClienteSeleccionado);
        FuncionEditar_HabilitarCampos(_clienteSeleccionado);
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
    #endregion

    #region Metodos
    public static string FuncionVariable = "";
    private void FuncionListarClientes()
    {
        List<Clientes> ListaClientes = ClientesNeg.ListaDeClientes();
        RepeaterClientes.DataSource = ListaClientes;
        RepeaterClientes.DataBind();
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
    private void Funcion_AltaCliente()
    {
        DivGrillaClientes.Visible = false;
        DivAltaCliente.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
    private Clientes CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Clientes _cliente = new Clientes();
            _cliente.Dni = txtDni.Value;
            _cliente.Apellido = txtApellido.Value;
            _cliente.Nombre = txtNombre.Value;
            _cliente.Telefono = txtTeléfono.Value;
            _cliente.Email = txtEmail.Value;
            DateTime fechaActual = DateTime.Now;
            _cliente.FechaDeAlta = fechaActual;
            _cliente.idUsuario = 1;
            return _cliente;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtDni.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Dni es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
            if (String.IsNullOrEmpty(txtApellido.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Apellido es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
            if (String.IsNullOrEmpty(txtNombre.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtTeléfono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro el cliente exitosamente.";
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
    }
    private void LimpiarCampos_ExitoEditar()
    {
        txtDni.Disabled = false;
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtTeléfono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se registro la edición del cliente exitosamente.";
        idClienteSeleccionado = 0;
        FuncionVariable = "NUEVO";
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
    private void LimpiarCampos_Cancelar()
    {
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtTeléfono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        DivAltaCliente.Visible = false;
        DivGrillaClientes.Visible = true;
        DivMensajeError.Visible = false;
        DivMensajeExito.Visible = false;
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        FuncionListarClientes();
    }
    private void FuncionEditar_HabilitarCampos(Clientes clienteSeleccionado)
    {
        DivGrillaClientes.Visible = false;
        DivAltaCliente.Visible = true;
        txtDni.Value = clienteSeleccionado.Dni;
        txtApellido.Value = clienteSeleccionado.Apellido;
        txtNombre.Value = clienteSeleccionado.Nombre;
        txtTeléfono.Value = clienteSeleccionado.Telefono;
        txtEmail.Value = clienteSeleccionado.Email;
        txtDni.Disabled = true;
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
    #endregion
}