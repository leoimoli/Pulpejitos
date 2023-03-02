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
    }
}

