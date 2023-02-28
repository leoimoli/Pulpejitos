using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class DetalleOferta
    {
        public int idOferta { get; set; }
        public int idProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public int Unidades { get; set; }
        public decimal PrecioOferta { get; set; }
        public decimal MontoDescuento { get; set; }
    }
}
