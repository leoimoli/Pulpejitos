using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class EspecieNeg
    {
        public static List<Especies> CargarComboEspecie()
        {
            DaoEspecies _dao = new DaoEspecies();
            List<Especies> lista = new List<Especies>();
            lista = _dao.CargarComboEspecie();
            return lista;
        }
        public static bool EliminarEspecie(Especies especie, int idEspecieSeleccionada, int Valor)
        {
            bool exito = false;
            DaoEspecies _dao = new DaoEspecies();
            try
            {
                exito = _dao.EliminarEspecie(especie, idEspecieSeleccionada, Valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool InsertarEspecie(Especies especie)
        {
            DaoEspecies _dao = new DaoEspecies();
            bool exito = false;
            try
            {
                bool UsuarioExistente = _dao.ValidarEspecieExistente(especie.Nombre);
                if (UsuarioExistente == true)
                {
                    const string message = "Atención:Ya existe una especie registrada con el nombre ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertEspecie(especie);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static Especies ListarEspeciePorId(int idEspecieSeleccionada)
        {
            DaoEspecies _dao = new DaoEspecies();
            Especies lista = new Especies();
            lista = _dao.ListarEspeciePorId(idEspecieSeleccionada);
            return lista;
        }
        public static List<Especies> ListarEspecie()
        {
            DaoEspecies _dao = new DaoEspecies();
            List<Especies> lista = new List<Especies>();
            lista = _dao.ListarEspecie();
            return lista;
        }
        public static List<Especies> BuscarEspeciePorNombre(string especie)
        {
            DaoEspecies _dao = new DaoEspecies();
            List<Especies> lista = new List<Especies>();
            lista = _dao.BuscarEspeciePorNombre(especie);
            return lista;
        }
    }
}
