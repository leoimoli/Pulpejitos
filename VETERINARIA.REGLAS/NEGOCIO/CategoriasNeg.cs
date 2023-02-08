using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class CategoriasNeg
    {
        public static List<Categorias> CargarComboCategoria()
        {
            DaoCategorias _dao = new DaoCategorias();
            List<Categorias> lista = new List<Categorias>();
            lista = _dao.CargarComboCategoria();
            return lista;
        }
    }
}
