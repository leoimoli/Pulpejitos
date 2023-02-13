using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class ProveedoresNeg
    {
        public static List<Proveedores> CargarComboProveedores()
        {
            DaoProveedores _dao = new DaoProveedores();
            List<Proveedores> lista = new List<Proveedores>();
            lista = _dao.CargarComboProveedores();
            return lista;
        }
    }
}
