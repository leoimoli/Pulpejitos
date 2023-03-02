using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VETERINARIA.MODELO.ENTIDADES
{
    public class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Dni { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public DateTime FechaDeAlta { get; set; }
        public DateTime FechaUltimaConexion { get; set; }
        public string Contraseña { get; set; }
        public string Contraseña2 { get; set; }
        public int idPerfil { get; set; }
        public string NombrePerfil { get; set; }
        public string Estado { get; set; }
        public byte[] Foto { get; set; }
        public int NroLote { get; set; }
        public int CantidadVentasDelMes { get; set; }
        public decimal EfectivoVentasDelMes { get; set; }
        public string CodigoAnulacion { get; set; }
    }
}
