using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class MarcasNeg
    {
        public static List<Marcas> BuscarMarcasPorNombre(string marca)
        {
            DaoMarcas _dao = new DaoMarcas();
            List<Marcas> lista = new List<Marcas>();
            lista = _dao.BuscarMarcasPorNombre(marca);
            return lista;
        }
        public static List<Marcas> CargarComboMarcas()
        {
            DaoMarcas _dao = new DaoMarcas();
            List<Marcas> lista = new List<Marcas>();
            lista = _dao.CargarCombomMarcas();
            return lista;
        }
        public static bool EliminarMarca(Marcas marca, int idMarcaSeleccionada, int v)
        {
            bool exito = false;
            DaoMarcas _dao = new DaoMarcas();
            try
            {
                exito = _dao.EliminarMarca(marca, idMarcaSeleccionada, 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public static bool InsertarMarca(Marcas marca)
        {
            DaoMarcas _dao = new DaoMarcas();
            bool exito = false;
            try
            {
                bool UsuarioExistente = _dao.ValidarMarcaExistente(marca.Nombre);
                if (UsuarioExistente == true)
                {
                    const string message = "Atención:Ya existe una marca registrada con el nombre ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertMarca(marca);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static Marcas ListarMarcaPorId(int idMarcaSeleccionada)
        {
            DaoMarcas _dao = new DaoMarcas();
            Marcas lista = new Marcas();
            lista = _dao.ListarMarcaPorId(idMarcaSeleccionada);
            return lista;
        }
        public static List<Marcas> ListarMarcas()
        {
            DaoMarcas _dao = new DaoMarcas();
            List<Marcas> lista = new List<Marcas>();
            lista = _dao.ListarMarcas();
            return lista;
        }
    }
}
