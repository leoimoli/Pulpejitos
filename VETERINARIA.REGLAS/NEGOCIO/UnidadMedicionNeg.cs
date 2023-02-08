using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class UnidadMedicionNeg
    {
        public static List<string> CargarComboUnidadDeMedicion()
        {
            DaoUnidadMedicion _dao = new DaoUnidadMedicion();
            List<string> lista = new List<string>();
            lista = _dao.CargarComboUnidadMedicion();
            return lista;
        }
    }
}
