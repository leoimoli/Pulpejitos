using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoUsuarios
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

        public Usuarios BuscarUsuarioLogin(string usuario)
        {
            Usuarios usuarioDB = new Usuarios();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Dni_in", usuario)};
                    string proceso = "SP_Consultar_BuscarUsuarioParaLogin";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            usuarioDB.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            usuarioDB.Apellido = item["Apellido"].ToString();
                            usuarioDB.Nombre = item["Nombre"].ToString();
                            usuarioDB.Dni = item["Dni"].ToString();                            
                            usuarioDB.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            usuarioDB.FechaUltimaConexion = Convert.ToDateTime(item["FechaUltimaConexion"].ToString());
                            usuarioDB.Contraseña = item["Contrasenia"].ToString();
                            usuarioDB.Estado = item["Estado"].ToString();
                            usuarioDB.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());                            
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return usuarioDB;
        }
    }
}

