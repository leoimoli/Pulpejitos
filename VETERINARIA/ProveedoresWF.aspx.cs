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
            Proveedores _proveedor = CargarEntidad();
            bool RespuestaExitosa = ProveedoresNeg.InsertarProveedor(_proveedor);
            if (RespuestaExitosa == true)
            {
                LimpiarCampos_ExitoInsert();
            }
            else
            {
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: Falló el registro del proveedor.";
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
    #endregion
    #region Metodos
    public static string FuncionVariable = "";
    private void LimpiarCampos_ExitoInsert()
    {
        txtRazonSocial.Value = String.Empty;
        txtContacto.Value = String.Empty;
        txtCodTelefono.Value = String.Empty;
        txtTelefono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        DivMensajeExito.Visible = true;
        lblMensajeExito.Text = "Atención: Se registro el proveedor exitosamente.";
    }
    private void LimpiarCampos_Cancelar()
    {
        txtRazonSocial.Value = String.Empty;
        txtContacto.Value = String.Empty;
        txtCodTelefono.Value = String.Empty;
        txtTelefono.Value = String.Empty;
        txtEmail.Value = String.Empty;
        txtCalle.Value = String.Empty;
        txtAltura.Value = String.Empty;
        DivAltaProveedor.Visible = false;
        DivGrillaProveedores.Visible = true;
        DivMensajeError.Visible = false;
        DivMensajeExito.Visible = false;
    }
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
            string telefono = txtCodTelefono.Value + "-" + txtTelefono.Value;
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
                DivMensajeError.Visible = true;
                lblMensajeError.Text = "Atención: El campo Razón Social es un dato obligatorio.";
                throw new Exception();
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void Funcion_AltaProveedor()
    {
        DivGrillaProveedores.Visible = false;
        DivAltaProveedor.Visible = true;
    }
    private void FuncionListarProveedores()
    {
        List<Proveedores> ListaProveedores = ProveedoresNeg.ListaDeProveedores();
        RepeaterProveedores.DataSource = ListaProveedores;
        RepeaterProveedores.DataBind();
    }
    #endregion
}