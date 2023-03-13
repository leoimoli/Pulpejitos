using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoSucursal
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

        public List<Sucursal> BuscarSucursalPorNombre(string sucursal)
        {
            List<Sucursal> _listaSucursales = new List<Sucursal>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Sucursal_in", sucursal) };
                    string proceso = "SP_Consultar_BuscarSucursalPorNombre";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "sucursales");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Sucursal sucursales = new Sucursal();
                            sucursales.idSucursal = Convert.ToInt32(item["idSucursal"].ToString());
                            sucursales.Nombre = item["Nombre"].ToString();
                            sucursales.Calle = item["Calle"].ToString();
                            sucursales.Altura = item["Altura"].ToString();
                            sucursales.Domicilio = sucursales.Calle + "N° " + sucursales.Altura;
                            sucursales.NombreProvincia = item["NombreProvincia"].ToString();
                            sucursales.NombreLocalidad = item["NombreLocalidad"].ToString();
                            sucursales.CodigoPostal = item["CodigoPostal"].ToString();
                            sucursales.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            sucursales.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { sucursales.Estado = "Activo"; }
                            else
                            { sucursales.Estado = "Inactivo"; }
                            _listaSucursales.Add(sucursales);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaSucursales;
        }
        public List<Sucursal> CargarComboLocalidad(int idProvinciaSeleccionada)
        {
            List<Sucursal> _listaSucursal = new List<Sucursal>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idProvinciaSeleccionada_in", idProvinciaSeleccionada)};
                    string proceso = "SP_Consultar_CargarComboLocalidad";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "localidades");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Sucursal Localidad = new Sucursal();
                            Localidad.idLocalidad = Convert.ToInt32(item["idLocalidad"].ToString());
                            Localidad.NombreLocalidad = item["Nombre"].ToString();
                            _listaSucursal.Add(Localidad);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaSucursal;
        }
        public List<Sucursal> CargarComboProvincia()
        {
            List<Sucursal> _listaSucursal = new List<Sucursal>();
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
                    string proceso = "SP_Consultar_CargarComboProvincia";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "provincias");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Sucursal provincia = new Sucursal();
                            provincia.idProvincia = Convert.ToInt32(item["idProvincia"].ToString());
                            provincia.NombreProvincia = item["Nombre"].ToString();
                            _listaSucursal.Add(provincia);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaSucursal;
        }
        public List<Sucursal> CargarComboSucursal()
        {
            List<Sucursal> _listaSucursales = new List<Sucursal>();
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
                    string proceso = "SP_Consultar_ListarSucursales";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "sucursales");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Sucursal sucursales = new Sucursal();
                            sucursales.idSucursal = Convert.ToInt32(item["idSucursal"].ToString());
                            sucursales.Nombre = item["Nombre"].ToString();
                            _listaSucursales.Add(sucursales);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaSucursales;
        }
        public bool EliminarSucursal(Sucursal sucursal, int idSucursalSeleccionada, int valor)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EstadoSucursal";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idsucursal_in", idSucursalSeleccionada);
                    cmd.Parameters.AddWithValue("Estado_in", valor);
                    cmd.Parameters.AddWithValue("FechaAlta_in", sucursal.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", sucursal.idUsuario);
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
        public bool InsertSucursal(Sucursal sucursal)
        {
            bool RespuestaExito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Sucursal";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre_in", sucursal.Nombre);
                    cmd.Parameters.AddWithValue("Calle_in", sucursal.Calle);
                    cmd.Parameters.AddWithValue("Altura_in", sucursal.Altura);
                    cmd.Parameters.AddWithValue("idProvincia_in", sucursal.idProvincia);
                    cmd.Parameters.AddWithValue("idLocalidad_in", sucursal.idLocalidad);
                    cmd.Parameters.AddWithValue("CodigoPostal_in", sucursal.CodigoPostal);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", sucursal.FechaAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", sucursal.idUsuario);
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
        public List<Sucursal> ListarSucursal()
        {
            List<Sucursal> _listaSucursal = new List<Sucursal>();
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
                    string proceso = "SP_Consultar_ListarSucursal";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "sucursales");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Sucursal sucursales = new Sucursal();
                            sucursales.idSucursal = Convert.ToInt32(item["idSucursal"].ToString());
                            sucursales.Nombre = item["Nombre"].ToString();
                            sucursales.Calle = item["Calle"].ToString();
                            sucursales.Altura = item["Altura"].ToString();
                            sucursales.Domicilio = sucursales.Calle + "N° " + sucursales.Altura;
                            sucursales.NombreProvincia = item["NombreProvincia"].ToString();
                            sucursales.NombreLocalidad = item["NombreLocalidad"].ToString();
                            sucursales.CodigoPostal = item["CodigoPostal"].ToString();
                            sucursales.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            sucursales.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { sucursales.Estado = "Activo"; }
                            else
                            { sucursales.Estado = "Inactivo"; }
                            _listaSucursal.Add(sucursales);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaSucursal;
        }
        public Sucursal ListarSucursalPorId(int idSucursalSeleccionada)
        {
            Sucursal sucursales = new Sucursal();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idSucursalSeleccionada_in", idSucursalSeleccionada) };
                    string proceso = "SP_Consultar_ListarSucursalPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "sucursales");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            sucursales.idSucursal = Convert.ToInt32(item["idSucursal"].ToString());
                            sucursales.Nombre = item["Nombre"].ToString();
                            sucursales.Calle = item["Calle"].ToString();
                            sucursales.Altura = item["Altura"].ToString();
                            sucursales.NombreProvincia = item["NombreProvincia"].ToString();
                            sucursales.NombreLocalidad = item["NombreLocalidad"].ToString();
                            sucursales.CodigoPostal = item["CodigoPostal"].ToString();
                            sucursales.FechaAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            sucursales.UsuarioApellidoNombre = item["Apellido"].ToString() + ", " + item["NombreUsuario"].ToString();
                            int Estado = Convert.ToInt32(item["Estado"].ToString());
                            if (Estado == 1)
                            { sucursales.Estado = "Activo"; }
                            else
                            { sucursales.Estado = "Inactivo"; }
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return sucursales;
        }
        public string ObtenerCodigoPostalPorLocalidad(int idLocalidadSeleccionada)
        {
            string CodigoPostal = "";
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idLocalidadSeleccionada_in", idLocalidadSeleccionada) };
                    string proceso = "SP_Consultar_ObtenerCodigoPostalPorLocalidad";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            CodigoPostal = item["CodigoPostal"].ToString();
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return CodigoPostal;
        }
        public Sucursal ObtenerSucursal(string idSucursal)
        {
            Sucursal sucursalDB = new Sucursal();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idSucursal_in", idSucursal) };
                    string proceso = "SP_Consultar_ObtenerSucursal";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            sucursalDB.idSucursal = Convert.ToInt32(item["idSucursal"].ToString());
                            sucursalDB.Nombre = item["Nombre"].ToString();
                            sucursalDB.Calle = item["Calle"].ToString();
                            sucursalDB.Altura = item["Altura"].ToString();
                            sucursalDB.idProvincia = Convert.ToInt32(item["Provincia"].ToString());
                            sucursalDB.idLocalidad = Convert.ToInt32(item["Localidad"].ToString());
                            sucursalDB.CodigoPostal = item["CodigoPostal"].ToString();
                            sucursalDB.idUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return sucursalDB;
        }
        public bool ValidarSucursalExistente(string nombre)
        {
            bool Existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    List<Sucursal> lista = new List<Sucursal>();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("Nombre_in", nombre) };
                    string proceso = "SP_Consultar_ValidarSucursalExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "sucursales");
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

