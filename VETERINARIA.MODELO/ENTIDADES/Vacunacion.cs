using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Vacunacion
    {
        public int idVacunacion { get; set; }
        public string NombreCampaña { get; set; }
        public DateTime FechaAplicacion { get; set; }
        public DateTime FechaProxima { get; set; }
        public int idMascota { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaAlta { get; set; }
        public int idUsuario { get; set; }
        public string UsuarioApellidoNombre { get; set; }
        public string Estado { get; set; }
    }
}
