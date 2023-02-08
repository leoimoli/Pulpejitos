using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class CategoriasNeg
    {
        public static List<string> CargarComboCategoria()
        {
            DaoCategorias _dao = new DaoCategorias();
            List<string> lista = new List<string>();
            lista = _dao.CargarComboCategoria();
            return lista;
        }
    }
}
