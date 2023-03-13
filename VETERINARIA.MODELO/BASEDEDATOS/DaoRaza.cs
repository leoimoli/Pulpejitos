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
    public class DaoRaza
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
        public List<Razas> BuscarRazaPorNombre(string raza)
        {
            List<Razas> _listaRazas = new List<Razas>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Raza_in", raza) };
                    string proceso = "SP_Consultar_BuscarRazaPorNombre";
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
                            Razas razas = new Razas();
                            razas.idRaza = Convert.ToInt32(item["idRaza"].ToString());
                            razas.Nombre = item["Nombre"].ToString();
                            razas.NombreEspecie = item["NombreEspecie"].ToString();
                            razas.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            razas.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { razas.Estado = "Activo"; }
                            else
                            { razas.Estado = "Inactivo"; }
                            _listaRazas.Add(razas);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                { }
            }
            return _listaRazas;
        }
        public List<Razas> CargarComboRaza(int idEspecieSeleccionada)
        {
            List<Razas> _listaRazas = new List<Razas>();
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
                    string proceso = "SP_Consultar_ListarRazas";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "raza");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Razas razas = new Razas();
                            razas.idRaza = Convert.ToInt32(item["idRaza"].ToString());
                            razas.Nombre = item["Nombre"].ToString();
                            _listaRazas.Add(razas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaRazas;
        }
        public bool EliminarRaza(Razas raza, int idRazaSeleccionada, int valor)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EstadoRaza";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idRaza_in", idRazaSeleccionada);
                    cmd.Parameters.AddWithValue("Estado_in", valor);
                    cmd.Parameters.AddWithValue("FechaAlta_in", raza.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", raza.idUsuario);
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
        public bool InsertRaza(Razas raza)
        {
            bool RespuestaExito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Raza";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre_in", raza.Nombre);
                    cmd.Parameters.AddWithValue("idEspecie_in", raza.idEspecie);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", raza.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", raza.idUsuario);
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
        public List<Razas> ListarRaza()
        {
            List<Razas> _listaRazas = new List<Razas>();
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
                    string proceso = "SP_Consultar_ListadoDeRazas";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "raza");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Razas razas = new Razas();
                            razas.idRaza = Convert.ToInt32(item["idRaza"].ToString());
                            razas.Nombre = item["Nombre"].ToString();
                            razas.NombreEspecie = item["NombreEspecie"].ToString();
                            razas.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            razas.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { razas.Estado = "Activo"; }
                            else
                            { razas.Estado = "Inactivo"; }

                            _listaRazas.Add(razas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaRazas;
        }
        public Razas ListarRazaPorId(int idRazaSeleccionada)
        {
            Razas Raza = new Razas();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idRazaSeleccionada_in", idRazaSeleccionada) };
                    string proceso = "SP_Consultar_ListarRazaPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "raza");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {

                            Raza.idRaza = Convert.ToInt32(item["idRaza"].ToString());
                            Raza.Nombre = item["Nombre"].ToString();
                            Raza.NombreEspecie = item["NombreEspecie"].ToString();
                            Raza.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            Raza.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { Raza.Estado = "Activo"; }
                            else
                            { Raza.Estado = "Inactivo"; }

                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return Raza;
        }
        public bool ValidarRazaExistente(string nombre, int idEspecie)
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
                                      new MySqlParameter("Nombre_in", nombre),
                    new MySqlParameter("idEspecie_in", idEspecie)};
                    string proceso = "SP_Consultar_ValidarRazaExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "raza");
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
