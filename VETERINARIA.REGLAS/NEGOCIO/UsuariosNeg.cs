using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class UsuariosNeg
    {
        public static Usuarios ValidarUsuario(string usuario, string passwoord)
        {
            try
            {
                DaoUsuarios _dao = new DaoUsuarios();
                var usuarioDB = _dao.BuscarUsuarioLogin(usuario);
                if (usuarioDB != null && usuarioDB.Contraseña == passwoord)
                    return usuarioDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
