using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoMenus
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

        public List<Menu> ObtenerMenuPorPerfil(int idPerfil)
        {
            List<Menu> menus = new List<Menu>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("IdPerfil_in", idPerfil) };
                    string proceso = "SP_Consultar_ObtenerMenuPorPerfil";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Menu menuDB = new Menu();
                            menuDB.idMenuPorPerfil = Convert.ToInt32(item["idMenuPorPerfil"].ToString());
                            menuDB.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());
                            menuDB.idUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            menuDB.NombreMenu = item["NombreMenu"].ToString();
                            menuDB.Aspx = item["Aspx"].ToString();
                            menuDB.Icono = item["Icono"].ToString();
                            menuDB.Activo = string.Empty;
                            menus.Add(menuDB);
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return menus;
        }
    }
}

