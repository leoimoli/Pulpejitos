using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoMarcas
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

        public List<Marcas> BuscarMarcasPorNombre(string marca)
        {
            List<Marcas> _listaMarcas = new List<Marcas>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Marca_in", marca) };
                    string proceso = "SP_Consultar_BuscarMarcasPorNombre";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "marcas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Marcas marcas = new Marcas();
                            marcas.idMarca = Convert.ToInt32(item["idMarca"].ToString());
                            marcas.Nombre = item["Nombre"].ToString();
                            marcas.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            marcas.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { marcas.Estado = "Activo"; }
                            else
                            { marcas.Estado = "Inactivo"; }
                            _listaMarcas.Add(marcas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaMarcas;
        }

        public List<Marcas> CargarCombomMarcas()
        {
            List<Marcas> _listaMarcas = new List<Marcas>();
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
                    string proceso = "SP_Consultar_ListarMarcas";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "marcas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Marcas marcas = new Marcas();
                            marcas.idMarca = Convert.ToInt32(item["idMarca"].ToString());
                            marcas.Nombre = item["Nombre"].ToString();
                            _listaMarcas.Add(marcas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaMarcas;
        }
        public bool EliminarMarca(Marcas marca, int idMarcaSeleccionada, int valor)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EstadoMarca";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idMarca_in", idMarcaSeleccionada);
                    cmd.Parameters.AddWithValue("Estado_in", 0);
                    cmd.Parameters.AddWithValue("FechaAlta_in", marca.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", marca.idUsuario);
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
        public bool InsertMarca(Marcas marca)
        {
            bool RespuestaExito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Marca";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre_in", marca.Nombre);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", marca.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", marca.idUsuario);
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
        public Marcas ListarMarcaPorId(int idMarcaSeleccionada)
        {
            Marcas marcas = new Marcas();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idMarcaSeleccionada_in", idMarcaSeleccionada) };
                    string proceso = "SP_Consultar_ListarMarcaPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "marcas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {

                            marcas.idMarca = Convert.ToInt32(item["idMarca"].ToString());
                            marcas.Nombre = item["Nombre"].ToString();
                            marcas.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            marcas.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { marcas.Estado = "Activo"; }
                            else
                            { marcas.Estado = "Inactivo"; }

                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return marcas;
        }
        public List<Marcas> ListarMarcas()
        {
            List<Marcas> _listaMarcas = new List<Marcas>();
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
                    string proceso = "SP_Consultar_ListadoDeMarcas";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "marcas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Marcas marcas = new Marcas();
                            marcas.idMarca = Convert.ToInt32(item["idMarca"].ToString());
                            marcas.Nombre = item["Nombre"].ToString();
                            marcas.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            marcas.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { marcas.Estado = "Activo"; }
                            else
                            { marcas.Estado = "Inactivo"; }


                            _listaMarcas.Add(marcas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaMarcas;
        }
        public bool ValidarMarcaExistente(string nombre)
        {
            bool Existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    List<Clientes> lista = new List<Clientes>();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", nombre) };
                    string proceso = "SP_Consultar_ValidarMarcaExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "marcas");
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
