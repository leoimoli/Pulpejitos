﻿using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<string> CargarCombomMarcas()
        {
            List<string> _listaMarcas = new List<string>();
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
                            _listaMarcas.Add(item["Nombre"].ToString());
                        }
                    }
                    connection.Close();
                  
                }
                catch (Exception ex)
                { }
            }
            return _listaMarcas;
        }
    }
}