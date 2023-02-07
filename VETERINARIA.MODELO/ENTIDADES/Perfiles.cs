using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
   public class Perfiles
    {
        public int idPerfil { get; set; }
        public string NombrePerfil { get; set; }
        public int Estado { get; set; }
        public int idUsuario { get; set; }
    }
}
