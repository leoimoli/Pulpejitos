using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Stock
    {
        public int idProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int idProveedor { get; set; }
        public DateTime FechaFactura { get; set; }
        public string Remito { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal MontoTotalPorProducto { get; set; }
        public decimal MontoTotal { get; set; }
        public int Cantidad { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int idUsuario { get; set; }
        public List<Productos> ListaIngresoStock { get; set; }
        public string NombreMarca { get; set; }
        public string Descripcion { get; set; }
        public decimal ValorUnitarioDeCompra { get; set; }
        public decimal ValorTotalDeCompra { get; set; }
        public int CantidadStockDeCompra { get; set; }
    }
}
