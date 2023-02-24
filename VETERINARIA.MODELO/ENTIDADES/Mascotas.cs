using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Mascotas
    {
        public int idMascota { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int idEspecie { get; set; }
        public string NombreEspecie { get; set; }
        public int idRaza { get; set; }
        public string NombreRaza { get; set; }
        public int idCliente { get; set; }
        public DateTime FechaDeAlta { get; set; }        
        public int idUsuario { get; set; }
        public int EdadMascota { get; set; }
    }
}
