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
    }
}
