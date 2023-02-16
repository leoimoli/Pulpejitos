using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class ClientesWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
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
                    DivMensajeError.Visible = true;
                    lblMensajeError.Text = "Atención: Falló el registro del Cliente.";
                }
            }
            if (FuncionVariable == "EDITAR")
            {
                //Clientes _cliente = CargarEntidadEdicion();
                //bool Exito = ClientesNeg.EditarCliente(_cliente, idClienteSeleccionado);
                //if (Exito == true)
                //{
                //    LimpiarCampos_ExitoInsert();
                //}

                //if (FuncionVariable == "ELIMINAR")
                //{ }
            }
        }
        catch (Exception ex)
        {
            DivMensajeError.Visible = true;
            lblMensajeError.Text = ex.Message;
        }
    }


    protected void btnEditarCliente_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument);

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
    }
    private void Funcion_AltaCliente()
    {
        DivGrillaClientes.Visible = false;
        DivAltaCliente.Visible = true;
        FuncionVariable = "NUEVO";
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
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Dni es un dato obligatorio.";
                throw new Exception();
            }
            if (String.IsNullOrEmpty(txtApellido.Value))
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Apellido es un dato obligatorio.";
                throw new Exception();
            }
            if (String.IsNullOrEmpty(txtNombre.Value))
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Nombre es un dato obligatorio.";
                throw new Exception();
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
    }
    #endregion
}