using System;
using System.Web;
using System.Web.UI;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class _Formulario : Page
{
    private Usuarios _usuarioActual { get; set; }
    private Sucursal _sucursalActual { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["USUARIO"] == null) Response.Redirect("IngresoWF.aspx");
        _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
        _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];
    }

    public void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
}