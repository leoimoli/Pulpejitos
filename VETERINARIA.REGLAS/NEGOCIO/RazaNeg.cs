using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class RazaNeg
    {
        public static List<Razas> CargarComboRaza(int idEspecieSeleccionada)
        {
            DaoRaza _dao = new DaoRaza();
            List<Razas> lista = new List<Razas>();
            lista = _dao.CargarComboRaza(idEspecieSeleccionada);
            return lista;
        }
        public static bool EliminarRaza(Razas raza, int idRazaSeleccionada, int Valor)
        {
            bool exito = false;
            DaoRaza _dao = new DaoRaza();
            try
            {
                exito = _dao.EliminarRaza(raza, idRazaSeleccionada, Valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool InsertarRaza(Razas raza)
        {
            DaoRaza _dao = new DaoRaza();
            bool exito = false;
            try
            {
                bool UsuarioExistente = _dao.ValidarRazaExistente(raza.Nombre, raza.idEspecie);
                if (UsuarioExistente == true)
                {
                    const string message = "Atención:Ya existe una raza registrada con el nombre ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertRaza(raza);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static Razas ListarRazaPorId(int idRazaSeleccionada)
        {
            DaoRaza _dao = new DaoRaza();
            Razas lista = new Razas();
            lista = _dao.ListarRazaPorId(idRazaSeleccionada);
            return lista;
        }
        public static List<Razas> ListarRaza()
        {
            DaoRaza _dao = new DaoRaza();
            List<Razas> lista = new List<Razas>();
            lista = _dao.ListarRaza();
            return lista;
        }
        public static List<Razas> BuscarRazaPorNombre(string raza)
        {
            DaoRaza _dao = new DaoRaza();
            List<Razas> lista = new List<Razas>();
            lista = _dao.BuscarRazaPorNombre(raza);
            return lista;
        }
    }
}
