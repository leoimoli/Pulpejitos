using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class PerfilNeg
    {
        public static List<Perfiles> ObtenerPerfiles()
        {
            try
            {
                DaoPerfiles _dao = new DaoPerfiles();
                var menusDB = _dao.ObtenerPerfiles();
                if (menusDB != null)
                    return menusDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        public static List<Menu> ObtenerMenuPorPerfil(int idPerfil)
        {
            try
            {
                DaoMenus _dao = new DaoMenus();
                var menusDB = _dao.ObtenerMenuPorPerfil(idPerfil);
                if (menusDB != null)
                    return menusDB;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
