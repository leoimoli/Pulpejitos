using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class IngresoWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext.Current.Session["USUARIO"] = null;
            HttpContext.Current.Session["SUCURSAL"] = null;
            MostrarError(string.Empty, false);
            CargarComboSucursal();
        }
    }

    protected void btnIngresar_Click(object sender, EventArgs e)
    {
        try
        {
            HttpContext.Current.Session["USUARIO"] = null;
            MostrarError(string.Empty, false);
            string usuario = txtUsuario.Value;
            string password = txtPassword.Value;
            Usuarios usuarioDB = UsuariosNeg.ValidarUsuario(usuario, password);
            if (usuarioDB != null)
            {
                HttpContext.Current.Session["USUARIO"] = usuarioDB;
                Sucursal SucursalDB = SucursalesNeg.ValidarSucursal(cmbSucursal.SelectedItem.Value);
                HttpContext.Current.Session["SUCURSAL"] = SucursalDB;
                Response.Redirect("InicioWF.aspx");
            }
            else
                MostrarError("Nombre de usuario o contraseña inválidos.", true);
        }
        catch (Exception ex)
        {
            MostrarError("Ha ocurrido un error, vuelva a intentarlo. " + ex.Message, true);
        }
    }

    private void MostrarError(string mensaje, bool mostrar)
    {
        lblMensajeError.Text = mensaje;
        DivMensajeError.Visible = mostrar;
    }

    private void CargarComboSucursal()
    {
        List<Sucursal> SucursalesSeleccionada = new List<Sucursal>();
        SucursalesSeleccionada = SucursalesNeg.CargarComboSucursal();
        foreach (Sucursal item in SucursalesSeleccionada)
        {
            cmbSucursal.Items.Add(new ListItem { Text = item.Nombre, Value = item.idSucursal.ToString() });
        }
    }
}