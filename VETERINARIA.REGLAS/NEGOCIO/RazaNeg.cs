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
    }
}
