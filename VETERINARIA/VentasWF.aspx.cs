using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class VentasWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    #region Botones
    protected void btnBuscarProducto_Click(object sender, EventArgs e)
    {
        try
        {
            Ventas_FuncionBuscarProducto();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCobrar_Click(object sender, EventArgs e)
    {
        try
        {
            Ventas_FacturarVenta();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public static List<DetalleOferta> listaOfertas = new List<DetalleOferta>();
    public static List<Ventas> listaProductosConDescuentos = new List<Ventas>();
    public static decimal PrecioFinal = 0;
    bool VentaCerrada = false;
    public static int idVenta = 0;
    private void Ventas_FacturarVenta()
    {
        List<DetalleOferta> lista = new List<DetalleOferta>();
        if (listadoDeProductos.Count > 0)
        {
            List<VentasEspejo> listaProductosOriginal = new List<VentasEspejo>();
            foreach (var item in listadoDeProductos)
            {
                VentasEspejo ProductosOriginal = new VentasEspejo();
                ProductosOriginal.CantidadVenta = item.CantidadVenta;
                ProductosOriginal.CodigoProducto = item.CodigoProducto;

                ProductosOriginal.FechaVenta = DateTime.Now;
                ProductosOriginal.idOferta = item.idOferta;

                ProductosOriginal.idProducto = item.idProducto;
                ProductosOriginal.Descripcion = item.Descripcion;

                ProductosOriginal.ValorUnitario = item.ValorUnitario;
                ProductosOriginal.PrecioVenta = item.PrecioVenta;

                ProductosOriginal.MontoTotalPorProducto = item.MontoTotalPorProducto;
                listaProductosOriginal.Add(ProductosOriginal);
            }
            //listaProductosConDescuentos = BuscarPromociones(listadoDeProductos);
            if (listaProductosConDescuentos.Count > 0)
            {
                int contarDescuentos = 1;
                decimal PrecioVentaOrig = Convert.ToDecimal(lblTotalFactura.Text);
                foreach (var item in listaProductosConDescuentos)
                {
                    if (contarDescuentos == 1)
                    {
                        PrecioFinal = PrecioVentaOrig + item.PrecioVenta;
                        contarDescuentos = contarDescuentos + 1;
                    }
                    else
                    {
                        PrecioFinal = PrecioFinal + item.PrecioVenta;
                        contarDescuentos = contarDescuentos + 1;
                    }

                    DetalleOferta detalle = new DetalleOferta();
                    detalle.Descripcion = item.Descripcion;
                    detalle.PrecioOferta = item.ValorUnitario;
                    detalle.MontoDescuento = item.MontoDescuento;
                    lista.Add(detalle);
                }
                List<Ventas> listaProductos = new List<Ventas>();

                foreach (var item in listaProductosOriginal)
                {
                    Ventas Productos = new Ventas();
                    Productos.CantidadVenta = item.CantidadVenta;
                    Productos.CodigoProducto = item.CodigoProducto;

                    Productos.FechaVenta = DateTime.Now;
                    Productos.idOferta = item.idOferta;

                    Productos.idProducto = item.idProducto;
                    Productos.Descripcion = item.Descripcion;

                    Productos.ValorUnitario = item.ValorUnitario;
                    Productos.PrecioVenta = item.PrecioVenta;

                    Productos.PrecioVenta = PrecioFinal;                    
                    listaProductos.Add(Productos);
                }
                listaOfertas = lista;
                VentaCerrada = true;
                //int idusuarioLogueado = Sesion.UsuarioLogueado.IdUsuario;
                int idusuario = 1;
                //listaProductos[0].MontoTotalDeLaVenta = PrecioTotalFinal;
                idVenta = VentasNeg.RegistrarVenta(listaProductos, idusuario);
                bool AplicaDescuento = true;
                
                //BloquearPantalla();
                //VueltoNuevoWF _vuelto = new VueltoNuevoWF(listaProductos[0].PrecioVentaFinal, AplicaDescuento, idVenta, listaProductos, listaOfertas);
                //_vuelto.Show();
                //Tkt(idVenta, listaProductos);
                //DesbloquearPantalla();
                //lblBack.Visible = true;
            }
            else
            {
                listaOfertas = lista;
                VentaCerrada = true;
                //int idusuarioLogueado = Sesion.UsuarioLogueado.IdUsuario;
                int idusuario = 1;
                //listadoDeProductos[0].MontoTotalDeLaVenta = PrecioTotalFinal;
                idVenta = VentasNeg.RegistrarVenta(listadoDeProductos, idusuario);
                bool AplicaDescuento = false;

                //BloquearPantalla();
                //VueltoNuevoWF _vuelto = new VueltoNuevoWF(listaProductos[0].PrecioVentaFinal, AplicaDescuento, idVenta, listaProductos, listaOfertas);
                //_vuelto.Show();
                //Tkt(idVenta, listaProductos);
                //DesbloquearPantalla();
                //lblBack.Visible = true;               
            }
        }
    }
    private List<Ventas> BuscarPromociones(List<Ventas> listadoDeProductos)
    {
        throw new NotImplementedException();
    }

    #endregion


    #region Funciones
    public static List<Ventas> listadoDeProductos = new List<Ventas>();
    decimal PrecioTotalFinal = 0;
    private void Ventas_FuncionBuscarProducto()
    {
        try
        {
            string CodigoProducto = txtProducto.Value;
            if (!listadoDeProductos.Any(x => x.CodigoProducto == CodigoProducto))
            {
                ListaProductoEnGrilla();
            }
            else
            {
                int cantidadingresada = 1;
                if (txtCantidad.Value != "")
                {
                    cantidadingresada = Convert.ToInt32(txtCantidad.Value);
                }
                foreach (var item in listadoDeProductos)
                {
                    if (item.CodigoProducto == CodigoProducto)
                    {
                        int CantidadOld = Convert.ToInt32(item.CantidadVenta.ToString());
                        int CantidadNew = Convert.ToInt32(cantidadingresada.ToString());
                        int cantidad = CantidadOld + CantidadNew;
                        item.CantidadVenta = cantidad;
                        decimal ValorVenta = Convert.ToDecimal(item.PrecioVenta.ToString());
                        decimal PrecioFinal = cantidad * ValorVenta;
                        item.MontoTotalPorProducto = PrecioFinal;
                    }
                }
                RepeaterVentas.DataSource = listadoDeProductos;
                RepeaterVentas.DataBind();
                txtProducto.Value = String.Empty;
                txtCantidad.Value = "1";
                txtProducto.Focus();
            }
            ///// Calculo el Valor Total de La Venta          
            foreach (var item in listadoDeProductos)
            {
                PrecioTotalFinal += Convert.ToDecimal(item.MontoTotalPorProducto.ToString());
            }
            txtProducto.Value = String.Empty;
            txtCantidad.Value = "1";
            lblTotalFactura.Text = Convert.ToString(PrecioTotalFinal);
            listadoDeProductos[0].MontoTotalDeLaVenta = PrecioTotalFinal;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void ListaProductoEnGrilla()
    {
        string codigoProducto = String.Empty;
        if (txtProducto.Value != "")
        { codigoProducto = txtProducto.Value; }

        List<Ventas> _lista = new List<Ventas>();
        _lista = StockNeg.BuscarProductoParaVenta(codigoProducto);

        if (_lista.Count > 0 && _lista[0].PrecioVenta > 0)
        {
            int cantidadingresada = Convert.ToInt32(txtCantidad.Value);
            _lista[0].CantidadVenta = cantidadingresada;
            _lista[0].MontoTotalPorProducto = _lista[0].PrecioVenta * cantidadingresada;
            _lista[0].PrecioVenta = _lista[0].PrecioVenta;
            var lista = _lista.First();
            listadoDeProductos.Add(lista);
            RepeaterVentas.DataSource = listadoDeProductos;
            RepeaterVentas.DataBind();
            txtProducto.Value = String.Empty;
            txtCantidad.Value = "1";
            txtProducto.Focus();
        }
        else
        {
            int MensajesVisible = 2;
            MostrarMensajes(MensajesVisible);
            lblMensajeError.Text = "Atención: El producto ingresado no existe o no tiene un precio de venta cargado.";

        }
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
    #endregion
}