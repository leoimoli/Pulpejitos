using System;
using System.Collections.Generic;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class ProductoNeg
    {
        public static List<Stock> BuscarProductoPorCodigo(string codigo)
        {
            List<Stock> _listaProducto = new List<Stock>();
            try
            {
                DaoProductos _dao = new DaoProductos();
                _listaProducto = _dao.BuscarProductoPorCodigo(codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _listaProducto;
        }

        public static Productos BuscarProductoPorId(int idProducto)
        {
            Productos _producto = new Productos();
            try
            {
                DaoProductos _dao = new DaoProductos();
                _producto = _dao.BuscarProductosPorId(idProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _producto;
        }

        public static void InsertarProducto(Productos _producto, int idSucursal)
        {
            try
            {
                bool ProductoExistente = ValidarProductoExistente(_producto.CodigoProducto);
                if (ProductoExistente == true)
                {
                    throw new Exception("El producto ingresado ya existe.");
                }
                DaoProductos _dao = new DaoProductos();
                _dao.InsertarProducto(_producto, idSucursal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void EditarProducto(Productos _producto, int idProductoSeleccionado)
        {
            try
            {
                DaoProductos _dao = new DaoProductos();
                var productoOriginal = _dao.BuscarProductosPorId(idProductoSeleccionado);
                bool ProductoExistente = ValidarProductoExistente(_producto.CodigoProducto);
                if (ProductoExistente == true && productoOriginal.CodigoProducto != _producto.CodigoProducto)
                {
                    throw new Exception("El código ingresado ya existe y no se puede repetir.");
                }
                _dao.EditarProducto(_producto, idProductoSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<Productos> ListarProductosDisponibles()
        {
            List<Productos> _listaProductos = new List<Productos>();
            try
            {
                DaoProductos _dao = new DaoProductos();
                _listaProductos = _dao.ListarProductosDisponibles();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _listaProductos;
        }
        public static List<Precios> ListarPrecios(int idProducto)
        {
            List<Precios> _producto = new List<Precios>();
            try
            {
                DaoPrecios _dao = new DaoPrecios();
                _producto = _dao.ListarPreciosDeVenta(idProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _producto;
        }
        private static bool ValidarProductoExistente(string codigoProducto)
        {
            bool existe = false;
            try
            {
                DaoProductos _dao = new DaoProductos();
                existe = _dao.ValidarProductoExistente(codigoProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return existe;
        }
    }
}
