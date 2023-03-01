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
                    MySqlParameter[] oParam = { new MySqlParameter("usuario_in", usuario) };
                    string proceso = "SP_Consultar_BuscarUsuarioParaLogin";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            usuarioDB.idUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            usuarioDB.Usuario = item["Usuario"].ToString();
                            usuarioDB.Password = item["Password"].ToString();
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

