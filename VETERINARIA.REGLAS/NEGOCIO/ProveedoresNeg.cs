using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class ProveedoresNeg
    {
        public static List<Proveedores> CargarComboProveedores()
        {
            DaoProveedores _dao = new DaoProveedores();
            List<Proveedores> lista = new List<Proveedores>();
            lista = _dao.CargarComboProveedores();
            return lista;
        }
      
        public static bool InsertarProveedor(Proveedores _proveedor)
        {
            DaoProveedores _dao = new DaoProveedores();
            bool exito = false;
            try
            {
                bool ProveedorExistente = _dao.ValidarProveedorExistente(_proveedor.NombreEmpresa);
                if (ProveedorExistente == true)
                {
                    const string message = "Atención:Ya existe un proveedor registrado con el nombre ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertarProveedor(_proveedor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool EditarProveedor(Proveedores proveedor, int idProveedorSeleccionado)
        {
            bool exito = false;
            DaoProveedores _dao = new DaoProveedores();
            try
            {
                exito = _dao.EditarProveedor(proveedor, idProveedorSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static List<Proveedores> ListaDeProveedores()
        {
            DaoProveedores _dao = new DaoProveedores();
            List<Proveedores> _listaProveedores = new List<Proveedores>();
            try
            {
                _listaProveedores = _dao.ListarProveedores();
            }
            catch (Exception ex)
            {
            }
            return _listaProveedores;
        }
        public static Proveedores ListarPorveedorPorId(int idProveedorSeleccionado)
        {
            Proveedores _proveedor = new Proveedores();
            DaoProveedores _dao = new DaoProveedores();
            try
            {
                _proveedor = _dao.ListarPorveedorPorId(idProveedorSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _proveedor;
        }
    }
}
