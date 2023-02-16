using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Proveedores
    {
        public int idProveedor { get; set; }
        public string NombreEmpresa { get; set; }
        public string Contacto { get; set; }
        public string Email { get; set; }
        public string SitioWeb { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public string Telefono { get; set; }
        public byte[] Foto { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
        public string Domicilio { get; set; }
    }
}
