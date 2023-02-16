using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public string Apellido { get; set; }

        public string ApellidoNombre { get; set; }
        public string Sexo { get; set; }
        public string Nombre { get; set; }
        public string Calle { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Altura { get; set; }
        public string Dni { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public int idUsuario { get; set; }
    }
}
