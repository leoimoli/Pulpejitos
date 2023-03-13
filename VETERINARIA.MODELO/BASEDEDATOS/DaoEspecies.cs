using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoEspecies
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
        public List<Especies> BuscarEspeciePorNombre(string especie)
        {
            List<Especies> _listaEspecies = new List<Especies>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Especie_in", especie) };
                    string proceso = "SP_Consultar_BuscarEspeciePorNombre";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "especies");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Especies especies = new Especies();
                            especies.idEspecie = Convert.ToInt32(item["idEspecie"].ToString());
                            especies.Nombre = item["Nombre"].ToString();
                            especies.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            especies.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { especies.Estado = "Activo"; }
                            else
                            { especies.Estado = "Inactivo"; }
                            _listaEspecies.Add(especies);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaEspecies;
        }
        public List<Especies> CargarComboEspecie()
        {
            List<Especies> _listaEspecies = new List<Especies>();
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
                    string proceso = "SP_Consultar_ListarEspecies";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "especies");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Especies especies = new Especies();
                            especies.idEspecie = Convert.ToInt32(item["idEspecie"].ToString());
                            especies.Nombre = item["Nombre"].ToString();
                            _listaEspecies.Add(especies);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaEspecies;
        }
        public bool EliminarEspecie(Especies especie, int idEspecieSeleccionada, int valor)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EstadoEspecie";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idEspecie_in", idEspecieSeleccionada);
                    cmd.Parameters.AddWithValue("Estado_in", valor);
                    cmd.Parameters.AddWithValue("FechaAlta_in", especie.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", especie.idUsuario);
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
        public bool InsertEspecie(Especies especie)
        {
            bool RespuestaExito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Especie";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre_in", especie.Nombre);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", especie.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", especie.idUsuario);
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
        public List<Especies> ListarEspecie()
        {
            List<Especies> _listaEspecies = new List<Especies>();
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
                    string proceso = "SP_Consultar_ListadoEspecies";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "especies");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Especies especies = new Especies();
                            especies.idEspecie = Convert.ToInt32(item["idEspecie"].ToString());
                            especies.Nombre = item["Nombre"].ToString();
                            especies.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            especies.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { especies.Estado = "Activo"; }
                            else
                            { especies.Estado = "Inactivo"; }


                            _listaEspecies.Add(especies);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaEspecies;
        }
        public Especies ListarEspeciePorId(int idEspecieSeleccionada)
        {
            Especies especies = new Especies();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idEspecieSeleccionada_in", idEspecieSeleccionada) };
                    string proceso = "SP_Consultar_ListarEspeciePorId";
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

                            especies.idEspecie = Convert.ToInt32(item["idEspecie"].ToString());
                            especies.Nombre = item["Nombre"].ToString();
                            especies.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            especies.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { especies.Estado = "Activo"; }
                            else
                            { especies.Estado = "Inactivo"; }

                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return especies;
        }
        public bool ValidarEspecieExistente(string nombre)
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
                    string proceso = "SP_Consultar_ValidarEspecieExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "especies");
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