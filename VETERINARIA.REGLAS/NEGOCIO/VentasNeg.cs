using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class VentasNeg
    {
        public static int RegistrarVenta(List<Ventas> listaProductos, int idusuario)
        {
            DaoVentas _dao = new DaoVentas();
            int idVenta = 0;
            try
            {
                idVenta = _dao.InsertarVenta(listaProductos, idusuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return idVenta;
        }
    }
}
