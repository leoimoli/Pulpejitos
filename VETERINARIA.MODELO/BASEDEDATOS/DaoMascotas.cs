using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoMascotas
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
        public List<Mascotas> BuscarMascotasPorFiltros(string dni, string nombreMascota, int especie, int raza)
        {
            List<Mascotas> _listaMascotas = new List<Mascotas>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("dni_in", dni),
                    new MySqlParameter("nombreMascota_in", nombreMascota),
                    new MySqlParameter("especie_in", especie),
                    new MySqlParameter("raza_in", raza)};
                    string proceso = "SP_Consultar_ListarMascotasPorFiltros";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "mascotas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Mascotas mascotas = new Mascotas();
                            mascotas.idMascota = Convert.ToInt32(item["idMascota"].ToString());
                            mascotas.Nombre = item["Nombre"].ToString();
                            mascotas.NombreEspecie = item["NombreEspecie"].ToString();
                            mascotas.NombreRaza = item["NombreRaza"].ToString();
                            mascotas.FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                            _listaMascotas.Add(mascotas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaMascotas;
        }
        public bool EditarMascota(Mascotas mascotas, int idMascotaSeleccionada)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EditarMascota";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idMascota_in", idMascotaSeleccionada);
                    cmd.Parameters.AddWithValue("Nombre_in", mascotas.Nombre);
                    cmd.Parameters.AddWithValue("FechaNacimiento_in", mascotas.FechaNacimiento);
                    cmd.Parameters.AddWithValue("idEspecie_in", mascotas.idEspecie);
                    cmd.Parameters.AddWithValue("idRaza_in", mascotas.idRaza);
                    cmd.Parameters.AddWithValue("idCliente_in", mascotas.idCliente);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", mascotas.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", mascotas.idUsuario);
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
        public bool InsertarMascota(Mascotas mascotas)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string proceso = "SP_insertar_InsertarMascota";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Nombre_in", mascotas.Nombre);
                    cmd.Parameters.AddWithValue("FechaNacimiento_in", mascotas.FechaNacimiento);
                    cmd.Parameters.AddWithValue("idEspecie_in", mascotas.idEspecie);
                    cmd.Parameters.AddWithValue("idRaza_in", mascotas.idRaza);
                    cmd.Parameters.AddWithValue("idCliente_in", mascotas.idCliente);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", mascotas.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", mascotas.idUsuario);
                    cmd.ExecuteNonQuery();
                    exito = true;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return exito;
        }
        public Mascotas ListarMascotaPorId(int idMascotaSeleccionada)
        {
            Mascotas _listaMascotas = new Mascotas();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idMascotaSeleccionada_in", idMascotaSeleccionada) };
                    string proceso = "SP_Consultar_ListarMascotaPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "mascotas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            _listaMascotas.idMascota = Convert.ToInt32(item["idMascota"].ToString());
                            _listaMascotas.Nombre = item["Nombre"].ToString();
                            _listaMascotas.NombreEspecie = item["NombreEspecie"].ToString();
                            _listaMascotas.NombreRaza = item["NombreRaza"].ToString();
                            _listaMascotas.FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                            _listaMascotas.idCliente = Convert.ToInt32(item["idCliente"].ToString());
                            _listaMascotas.DniCliente = item["DniCliente"].ToString();
                            _listaMascotas.ApellidoCliente = item["ApellidoCliente"].ToString();
                            _listaMascotas.NombreCliente = item["NombreCliente"].ToString();
                            _listaMascotas.idEspecie = Convert.ToInt32(item["idEspecie"].ToString());
                            _listaMascotas.NombreEspecie = item["NombreEspecie"].ToString();
                            _listaMascotas.idRaza = Convert.ToInt32(item["idRaza"].ToString());
                            _listaMascotas.NombreRaza = item["NombreRaza"].ToString();
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaMascotas;
        }
        public List<Mascotas> ListarMascotas()
        {
            List<Mascotas> _listaMascotas = new List<Mascotas>();
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
                    string proceso = "SP_Consultar_ListarMascotas";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "mascotas");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Mascotas mascotas = new Mascotas();
                            mascotas.idMascota = Convert.ToInt32(item["idMascota"].ToString());
                            mascotas.Nombre = item["Nombre"].ToString();
                            mascotas.NombreEspecie = item["NombreEspecie"].ToString();
                            mascotas.NombreRaza = item["NombreRaza"].ToString();
                            mascotas.FechaNacimiento = Convert.ToDateTime(item["FechaNacimiento"].ToString());
                            _listaMascotas.Add(mascotas);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaMascotas;
        }
    }
}
