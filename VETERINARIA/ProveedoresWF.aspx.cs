using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class ProveedoresWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                DivAltaProveedor.Visible = false;
                FuncionListarProveedores();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Botones
    protected void btnNuevoProveedor_Click(object sender, EventArgs e)
    {
        try
        {
            Funcion_AltaProveedor();
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
                Proveedores _proveedor = CargarEntidad();
                bool RespuestaExitosa = ProveedoresNeg.InsertarProveedor(_proveedor);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro del proveedor.";
                }
            }
            if (FuncionVariable == "EDITAR")
            {
                Proveedores _proveedor = CargarEntidad();
                bool RespuestaExitosa = ProveedoresNeg.EditarProveedor(_proveedor, idProveedorSeleccionado);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEditar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición del proveedor.";
                }
            }
        }
        catch (Exception ex)
        {
            int MensajesVisible = 2;
            MostrarMensajes(MensajesVisible);
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
    public static int idProveedorSeleccionado = 0;
    protected void btnEditarProveedor_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "EDITAR";
        Proveedores _proveedorSeleccionado = new Proveedores();
        idProveedorSeleccionado = Convert.ToInt32(e.CommandArgument);
        _proveedorSeleccionado = ProveedoresNeg.ListarPorveedorPorId(idProveedorSeleccionado);
        FuncionEditar_HabilitarCampos(_proveedorSeleccionado);
    }
    #endregion
    #region Metodos
    public static string FuncionVariable = "";

    private Proveedores CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Proveedores _proveedor = new Proveedores();
            _proveedor.NombreEmpresa = txtRazonSocial.Value;
            _proveedor.Contacto = txtContacto.Value;
            _proveedor.Email = txtEmail.Value;
            _proveedor.Calle = txtCalle.Value;
            _proveedor.Altura = txtAltura.Value;
            string telefono = txtTelefono.Value;
            _proveedor.Telefono = telefono;
            DateTime fechaActual = DateTime.Now;
            _proveedor.FechaDeAlta = fechaActual;
            _proveedor.idUsuario = 1;
            return _proveedor;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (String.IsNullOrEmpty(txtRazonSocial.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Razón Social es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Funcion_AltaProveedor()
    {
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);

        FuncionVariable = "NUEVO";
        DivGrillaProveedores.Visible = false;
        DivAltaProveedor.Visible = true;
    }
    private void FuncionListarProveedores()
    {
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        List<Proveedores> ListaProveedores = ProveedoresNeg.ListaDeProveedores();
        RepeaterProveedores.DataSource = ListaProveedores;
        RepeaterProveedores.DataBind();
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
    private void FuncionEditar_HabilitarCampos(Proveedores proveedorSeleccionado)
    {
        DivGrillaProveedores.Visible = false;
        DivAltaProveedor.Visible = true;
        txtRazonSocial.Value = proveedorSeleccionado.NombreEmpresa;
        txtContacto.Value = proveedorSeleccionado.Contacto;
        txtTelefono.Value = proveedorSeleccionado.Telefono;
        txtEmail.Value = proveedorSeleccionado.Email;
        txtCalle.Value = proveedorSeleccionado.Calle;
        txtAltura.Value = proveedorSeleccionado.Altura;
        txtRazonSocial.Disabled = true;
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
    private void LimpiarCampos_ExitoEditar()
    {
        idProveedorSeleccionado = 0;
        txtRazonSocial.Disabled = false;
        txtRazonSocial.Value = String.Empty;
        txtContacto.Value = String.Empty;
        txtTelefono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se Edito el proveedor exitosamente.";
        FuncionVariable = "NUEVO";
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtRazonSocial.Value = String.Empty;
        txtContacto.Value = String.Empty;
        txtTelefono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: Se registro el proveedor exitosamente.";
    }
    private void LimpiarCampos_Cancelar()
    {
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        txtRazonSocial.Value = String.Empty;
        txtContacto.Value = String.Empty;
        txtTelefono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        DivAltaProveedor.Visible = false;
        DivGrillaProveedores.Visible = true;
        DivMensajeError.Visible = false;
        DivMensajeExito.Visible = false;
        FuncionListarProveedores();
    }
    #endregion
}