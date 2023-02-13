using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class SucursalesNeg
    {
        public static List<Sucursal> CargarComboSucursal()
        {
            DaoSucursal _dao = new DaoSucursal();
            List<Sucursal> lista = new List<Sucursal>();
            lista = _dao.CargarComboSucursal();
            return lista;
        }
    }
}
