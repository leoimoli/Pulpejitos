using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class MarcasNeg
    {
        public static List<string> CargarComboMarcas()
        {
            DaoMarcas _dao = new DaoMarcas();
            List<string> lista = new List<string>();
            lista = _dao.CargarCombomMarcas();
            return lista;
        }
    }
}
