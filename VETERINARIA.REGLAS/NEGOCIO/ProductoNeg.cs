﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class ProductoNeg
    {
        public static bool InsertarProducto(Productos _producto)
        {
            bool exito = false;
            try
            {
                bool ProductoExistente = ValidarProductoExistente(_producto.CodigoProducto);
                if (ProductoExistente == true)
                {
                    //const string message = "Ya existe un producto registrado con el código ingresado.";
                    //const string caption = "Error";
                    //var result = MessageBox.Show(message, caption,
                    //                             MessageBoxButtons.OK,
                    //                           MessageBoxIcon.Exclamation);
                    //throw new Exception();
                }
                else
                {
                    DaoProductos _dao = new DaoProductos();
                    exito = _dao.InsertarProducto(_producto);
                }
            }
            catch (Exception ex)
            {

            }
            return exito;
        }

        public static List<Productos> ListarProductosDisponibles()
        {
            DaoProductos _dao = new DaoProductos();
            List<Productos> _listaProductos = new List<Productos>();
            try
            {
                _listaProductos = _dao.ListarProductosDisponibles();
            }
            catch (Exception ex)
            {
            }
            return _listaProductos;
        }

        private static bool ValidarProductoExistente(string codigoProducto)
        {
            DaoProductos _dao = new DaoProductos();
            bool existe = _dao.ValidarProductoExistente(codigoProducto);
            return existe;
        }     
    }
}