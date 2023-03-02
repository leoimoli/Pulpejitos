using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Ventas
    {
        public int idProducto { get; set; }
        public int idUsuario { get; set; }
        public int idSucursal { get; set; }
        public string CodigoProducto { get; set; }
        public decimal ValorUnitario { get; set; }
        public int CantidadVenta{ get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioVenta { get; set; }
        public int idOferta { get; set; }
        public decimal MontoDescuento { get; set; }
        public decimal MontoTotalPorProducto { get; set; }
        public int StockActual { get; set; }
        public int StockActualParaSucursal { get; set; }
        public DateTime FechaVenta { get; set; }
        public int StockNuevoCalculado { get; set; }
        public decimal MontoTotalDeLaVenta { get; set; }

    }
}
