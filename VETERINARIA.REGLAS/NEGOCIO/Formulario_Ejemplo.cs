using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public static class Formulario_Ejemplo
    {
        public static bool InsertarFormulario(string valor)
        {
            EjemploDAO.InsertarEjemplo(valor);
            return true;
        }
    }
}
