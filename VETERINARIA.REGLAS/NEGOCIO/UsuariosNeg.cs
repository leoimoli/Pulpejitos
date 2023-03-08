using System;
using System.Collections.Generic;
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

        public static List<Usuarios> ListarUsuarios()
        {
            DaoUsuarios _dao = new DaoUsuarios();
            List<Usuarios> _listaUsuarios = new List<Usuarios>();
            try
            {
                _listaUsuarios = _dao.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _listaUsuarios;
        }

        public static Usuarios ListarUsuariosPorId(int idUsuarioSeleccionado)
        {
            return ListarUsuarios().Find(x => x.IdUsuario == idUsuarioSeleccionado);
        }

        public static void InsertarUsuario(Usuarios usuario)
        {
            DaoUsuarios _dao = new DaoUsuarios();
        }

        public static void EditarUsuario(Usuarios usuario, int idClienteSeleccionado)
        {
            DaoUsuarios _dao = new DaoUsuarios();
        }
    }
}
