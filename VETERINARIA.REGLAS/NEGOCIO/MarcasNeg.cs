using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class MarcasNeg
    {
        public static List<Marcas> CargarComboMarcas()
        {
            DaoMarcas _dao = new DaoMarcas();
            List<Marcas> lista = new List<Marcas>();
            lista = _dao.CargarCombomMarcas();
            return lista;
        }
    }
}
