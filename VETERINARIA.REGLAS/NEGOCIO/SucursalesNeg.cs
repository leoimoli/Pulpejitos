using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class SucursalesNeg
    {
        public static List<Sucursal> BuscarSucursalPorNombre(string sucursal)
        {
            DaoSucursal _dao = new DaoSucursal();
            List<Sucursal> lista = new List<Sucursal>();
            lista = _dao.BuscarSucursalPorNombre(sucursal);
            return lista;
        }
        public static List<Sucursal> CargarComboLocalidad(int idProvinciaSeleccionada)
        {
            DaoSucursal _dao = new DaoSucursal();
            List<Sucursal> lista = new List<Sucursal>();
            lista = _dao.CargarComboLocalidad(idProvinciaSeleccionada);
            return lista;
        }
        public static List<Sucursal> CargarComboProvincia()
        {
            DaoSucursal _dao = new DaoSucursal();
            List<Sucursal> lista = new List<Sucursal>();
            lista = _dao.CargarComboProvincia();
            return lista;
        }
        public static List<Sucursal> CargarComboSucursal()
        {
            DaoSucursal _dao = new DaoSucursal();
            List<Sucursal> lista = new List<Sucursal>();
            lista = _dao.CargarComboSucursal();
            return lista;
        }
        public static bool EliminarSucursal(Sucursal sucursal, int idSucursalSeleccionada, int valor)
        {
            bool exito = false;
            DaoSucursal _dao = new DaoSucursal();
            try
            {
                exito = _dao.EliminarSucursal(sucursal, idSucursalSeleccionada, valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool InsertarSucursal(Sucursal sucursal)
        {
            DaoSucursal _dao = new DaoSucursal();
            bool exito = false;
            try
            {
                bool sucursalExistente = _dao.ValidarSucursalExistente(sucursal.Nombre);
                if (sucursalExistente == true)
                {
                    const string message = "Atención:Ya existe una sucursal registrada con el nombre ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertSucursal(sucursal);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static List<Sucursal> ListarSucursal()
        {
            DaoSucursal _dao = new DaoSucursal();
            List<Sucursal> lista = new List<Sucursal>();
            lista = _dao.ListarSucursal();
            return lista;
        }
        public static Sucursal ListarSucursalPorId(int idSucursalSeleccionada)
        {
            DaoSucursal _dao = new DaoSucursal();
            Sucursal lista = new Sucursal();
            lista = _dao.ListarSucursalPorId(idSucursalSeleccionada);
            return lista;
        }
        public static string ObtenerCodigoPostalPorLocalidad(int idLocalidadSeleccionada)
        {
            DaoSucursal _dao = new DaoSucursal();
            string CodigoPostal = "";
            CodigoPostal = _dao.ObtenerCodigoPostalPorLocalidad(idLocalidadSeleccionada);
            return CodigoPostal;
        }
        public static Sucursal ValidarSucursal(string idSucursal)
        {
            try
            {
                DaoSucursal _dao = new DaoSucursal();
                var sucursalDB = _dao.ObtenerSucursal(idSucursal);
                if (sucursalDB != null)
                    return sucursalDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
