using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
   public class Menu
    {
        public int idMenuPorPerfil { get; set; }
        public int idPerfil { get; set; }
        public int idUsuario { get; set; }
        public string Activo { get; set; }
        public string NombreMenu { get; set; }
        public string Aspx { get; set; }
        public string Icono { get; set; }
    }
}
