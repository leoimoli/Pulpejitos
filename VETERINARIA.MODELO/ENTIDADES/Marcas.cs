using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Marcas
    {
        public int idMarca { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaAlta { get; set; }
        public int idUsuario { get; set; }
        public string UsuarioApellidoNombre { get; set; }
        public string Estado { get; set; }
    }
}
