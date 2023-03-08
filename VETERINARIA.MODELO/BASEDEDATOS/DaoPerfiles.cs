using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoPerfiles
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

        public List<Perfiles> ObtenerPerfiles()
        {
            List<Perfiles> perfiles = new List<Perfiles>();
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
                    string proceso = "SP_Consultar_ListarPerfiles";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Perfiles perfilDB = new Perfiles();
                            perfilDB.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());
                            perfilDB.idUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            perfilDB.Estado = Convert.ToInt32(item["Estado"].ToString());
                            perfilDB.NombrePerfil = item["NombrePerfil"].ToString();
                            perfiles.Add(perfilDB);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return perfiles;
        }

        public Perfiles ObtenerPerfilId(int idPerfil)
        {
            Perfiles _perfil = new Perfiles();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idPerfil_in", idPerfil) };
                    string proceso = "SP_Consultar_ListarPerfilPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            _perfil.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());
                            _perfil.idUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            _perfil.NombrePerfil = item["NombrePerfil"].ToString();
                            _perfil.Estado = Convert.ToInt32(item["Estado"].ToString());
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _perfil;
        }
    }
}

