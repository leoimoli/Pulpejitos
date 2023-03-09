using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class CategoriasNeg
    {
        public static List<Categorias> CargarComboCategoria()
        {
            DaoCategorias _dao = new DaoCategorias();
            List<Categorias> lista = new List<Categorias>();
            lista = _dao.CargarComboCategoria();
            return lista;
        }

        public static bool EliminarCategoria(Categorias categoria, int idCategoriaSeleccionada, int Valor)
        {
            bool exito = false;
            DaoCategorias _dao = new DaoCategorias();
            try
            {
                exito = _dao.EliminarCategoria(categoria, idCategoriaSeleccionada, Valor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool InsertarCategoria(Categorias categoria)
        {
            DaoCategorias _dao = new DaoCategorias();
            bool exito = false;
            try
            {
                bool UsuarioExistente = _dao.ValidarCategoriaExistente(categoria.Nombre);
                if (UsuarioExistente == true)
                {
                    const string message = "Atención:Ya existe una categoria registrada con el nombre ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertCategoria(categoria);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static Categorias ListarCategoriaPorId(int idCategoriaSeleccionada)
        {
            DaoCategorias _dao = new DaoCategorias();
            Categorias lista = new Categorias();
            lista = _dao.ListarCategoriaPorId(idCategoriaSeleccionada);
            return lista;
        }
        public static List<Categorias> ListarCategoria()
        {
            DaoCategorias _dao = new DaoCategorias();
            List<Categorias> lista = new List<Categorias>();
            lista = _dao.ListarCategoria();
            return lista;
        }
        public static List<Categorias> BuscarCategoriaPorNombre(string categoria)
        {
            DaoCategorias _dao = new DaoCategorias();
            List<Categorias> lista = new List<Categorias>();
            lista = _dao.BuscarCategoriaPorNombre(categoria);
            return lista;
        }
    }
}
