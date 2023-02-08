using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class UnidadMedicionNeg
    {
        public static List<UnidadDeMedicion> CargarComboUnidadDeMedicion()
        {
            DaoUnidadMedicion _dao = new DaoUnidadMedicion();
            List<UnidadDeMedicion> lista = new List<UnidadDeMedicion>();
            lista = _dao.CargarComboUnidadMedicion();
            return lista;
        }
    }
}
