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
