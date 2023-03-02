using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Productos
    {
        public int idProducto { get; set; }
        public string CodigoProducto { get; set; }
        public int idCategoriaProducto { get; set; }
        public string Descripcion { get; set; }
        public int idMarca { get; set; }
        public string NombreMarca { get; set; }
        public int idUnidadDeMedicion { get; set; }
        public decimal PrecioDeVenta { get; set; }
        public int StockTotal { get; set; }
        public int StockTotalPorSucursal { get; set; }

        public decimal ValorUnitarioDeCompra { get; set; }
        public decimal ValorTotalDeCompra { get; set; }
        public int CantidadStockDeCompra { get; set; }

        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
    }
}
