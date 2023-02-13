using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class StockNeg
    {
        public static int RegistrarStock(List<Stock> _stock, decimal MontoTotalFactura)
        {
            int exito = 0;
            try
            {
                DaoStock _dao = new DaoStock();
                //ValidarDatos(_stock);
                exito = _dao.InsertarMovimientoAltaStock(_stock, MontoTotalFactura);
            }
            catch (Exception ex)
            { }
            return exito;
        }
        public static bool EditarProducto(Productos _producto, int idProductoGrillaSeleccionado)
        {
            bool exito = false;
            try
            {
                DaoProductos _dao = new DaoProductos();
                //ValidarDatos(_producto);
                exito = _dao.EditarProducto(_producto, idProductoGrillaSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool ValidarCodigoExistente(string codigoArmado)
        {
            DaoStock _dao = new DaoStock();
            bool existe = _dao.ValidarCodigoExistente(codigoArmado);
            return existe;
        }
        //public static List<Productos> ListadoDeProductos()
        //{
        //    List<Productos> _listaProductos = new List<Productos>();
        //    try
        //    {
        //        DaoProductos _dao = new DaoProductos();
        //        _listaProductos = _dao.ListarProductos();
        //    }
        //    catch (Exception ex)
        //    {
        //    }
        //    return _listaProductos;
        //}

    }
}
