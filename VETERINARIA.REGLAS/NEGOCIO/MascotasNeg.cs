using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class MascotasNeg
    {
        public static List<Mascotas> BuscarMascotasPorFiltros(string dni, string nombreMascota, int especie, int raza)
        {
            List<Mascotas> lista = new List<Mascotas>();
            try
            {
                DaoMascotas _dao = new DaoMascotas();

                lista = _dao.BuscarMascotasPorFiltros(dni, nombreMascota, especie, raza);
            }
            catch (Exception ex)
            { }
            return lista;
        }

        public static bool EditarMascota(Mascotas mascotas, int idMascotaSeleccionada)
        {
            throw new NotImplementedException();
        }

        public static bool InsertarMascota(Mascotas mascotas)
        {
            throw new NotImplementedException();
        }
        public static List<Mascotas> ListarMascotas()
        {
            DaoMascotas _dao = new DaoMascotas();
            List<Mascotas> _listaMascotas = new List<Mascotas>();
            try
            {
                _listaMascotas = _dao.ListarMascotas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _listaMascotas;
        }
    }
}
