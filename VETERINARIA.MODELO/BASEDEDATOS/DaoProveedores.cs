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
    public class DaoProveedores
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
        public List<Proveedores> CargarComboProveedores()
        {
            List<Proveedores> _listaProveedores = new List<Proveedores>();
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
                    string proceso = "SP_Consultar_ListarProveedores";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "proveedores");
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in ds.Tables[0].Rows)
                        {
                            Proveedores proveedores = new Proveedores();
                            proveedores.idProveedor = Convert.ToInt32(item["idProveedor"].ToString());
                            proveedores.NombreEmpresa = item["NombreEmpresa"].ToString();
                            _listaProveedores.Add(proveedores);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                { }
            }
            return _listaProveedores;
        }
    }
}
