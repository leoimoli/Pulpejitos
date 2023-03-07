using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;

public partial class InicioWF : System.Web.UI.Page
{
    private Usuarios _usuarioActual { get; set; }
    private Sucursal _sucursalActual { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["USUARIO"] == null) Response.Redirect("IngresoWF.aspx");
        _usuarioActual = (Usuarios)HttpContext.Current.Session["USUARIO"];
        _sucursalActual = (Sucursal)HttpContext.Current.Session["SUCURSAL"];
    }
}