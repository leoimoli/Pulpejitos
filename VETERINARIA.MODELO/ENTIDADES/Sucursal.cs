using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Sucursal
    {
        public int idSucursal { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Altura { get; set; }
        public int idProvincia { get; set; }
        public string NombreProvincia { get; set; }
        public int idLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public string CodigoPostal { get; set; }            
        public string Domicilio { get; set; }
        public DateTime FechaAlta { get; set; }
        public int idUsuario { get; set; }
        public string UsuarioApellidoNombre { get; set; }
        public string Estado { get; set; }
    }
}
