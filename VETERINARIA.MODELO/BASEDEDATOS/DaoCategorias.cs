using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoCategorias
    {
        private string _connectionString;
        public string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                    _connectionString = ConfigurationManager.ConnectionStrings["PULPEJITOS"].ConnectionString;
                return _connectionString;
            }
        }

        public List<Categorias> BuscarCategoriaPorNombre(string categoria)
        {
            List<Categorias> _listaCategorias = new List<Categorias>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Categoria_in", categoria) };
                    string proceso = "SP_Consultar_BuscarCategoriaPorNombre";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "categoriaproductos");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Categorias categorias = new Categorias();
                            categorias.idCategoria = Convert.ToInt32(item["idCategoriaProducto"].ToString());
                            categorias.Nombre = item["Nombre"].ToString();
                            categorias.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            categorias.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { categorias.Estado = "Activo"; }
                            else
                            { categorias.Estado = "Inactivo"; }
                            _listaCategorias.Add(categorias);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaCategorias;
        }
        public List<Categorias> CargarComboCategoria()
        {
            List<Categorias> _listaCategorias = new List<Categorias>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { };
                    string proceso = "SP_Consultar_ListarCategorias";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "categoriaproductos");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Categorias categoria = new Categorias();
                            categoria.idCategoria = Convert.ToInt32(item["idCategoriaProducto"].ToString());
                            categoria.Nombre = item["Nombre"].ToString();
                            _listaCategorias.Add(categoria);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaCategorias;
        }
        public bool EliminarCategoria(Categorias categoria, int idCategoriaSeleccionada, int valor)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EstadoCategoria";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idCategoria_in", idCategoriaSeleccionada);
                    cmd.Parameters.AddWithValue("Estado_in", valor);
                    cmd.Parameters.AddWithValue("FechaAlta_in", categoria.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", categoria.idUsuario);
                    cmd.ExecuteNonQuery();
                    exito = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                connection.Close();
                return exito;
            }
        }
        public bool InsertCategoria(Categorias categoria)
        {
            bool RespuestaExito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Categoria";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre_in", categoria.Nombre);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", categoria.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", categoria.idUsuario);
                    cmd.ExecuteNonQuery();
                    RespuestaExito = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RespuestaExito;
        }
        public List<Categorias> ListarCategoria()
        {
            List<Categorias> _listaCategoria = new List<Categorias>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { };
                    string proceso = "SP_Consultar_ListadoDeCategorias";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "categoriaproductos");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Categorias categorias = new Categorias();
                            categorias.idCategoria = Convert.ToInt32(item["idCategoriaProducto"].ToString());
                            categorias.Nombre = item["Nombre"].ToString();
                            categorias.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            categorias.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { categorias.Estado = "Activo"; }
                            else
                            { categorias.Estado = "Inactivo"; }


                            _listaCategoria.Add(categorias);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaCategoria;
        }
        public Categorias ListarCategoriaPorId(int idCategoriaSeleccionada)
        {
            Categorias categoria = new Categorias();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idCategoriaSeleccionada_in", idCategoriaSeleccionada) };
                    string proceso = "SP_Consultar_ListarCategoriaPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "categoriaproductos");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {

                            categoria.idCategoria = Convert.ToInt32(item["idCategoriaProducto"].ToString());
                            categoria.Nombre = item["Nombre"].ToString();
                            categoria.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            categoria.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { categoria.Estado = "Activo"; }
                            else
                            { categoria.Estado = "Inactivo"; }

                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return categoria;
        }
        public bool ValidarCategoriaExistente(string nombre)
        {
            bool Existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    List<Categorias> lista = new List<Categorias>();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", nombre) };
                    string proceso = "SP_Consultar_ValidarCategoriaExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "categoriaproductos");
                    if (Tabla.Rows.Count > 0)
                    {
                        Existe = true;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Existe;
        }
    }
}
