using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
            MostrarError(string.Empty, false);
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
            if (usuarioDB == null)
                HttpContext.Current.Session["USUARIO"] = usuarioDB;
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
}