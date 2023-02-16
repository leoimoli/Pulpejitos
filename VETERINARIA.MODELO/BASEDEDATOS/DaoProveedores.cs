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

        public List<Proveedores> ListarProveedores()
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
                    if (Tabla.Rows.Count > 0)
                    {

                        foreach (DataRow item in Tabla.Rows)
                        {
                            Proveedores listaProveedor = new Proveedores();
                            listaProveedor.idProveedor = Convert.ToInt32(item["idProveedor"].ToString());
                            listaProveedor.NombreEmpresa = item["NombreEmpresa"].ToString();
                            listaProveedor.Contacto = item["NombreContacto"].ToString();
                            listaProveedor.Email = item["Email"].ToString();
                            // listaProveedor.SitioWeb = item["SitioWeb"].ToString();
                            listaProveedor.Calle = item["Calle"].ToString();
                            listaProveedor.Altura = item["Altura"].ToString();
                            listaProveedor.Domicilio = listaProveedor.Calle + " " + "N° " + listaProveedor.Altura;
                            listaProveedor.Telefono = item["Telefono"].ToString();
                            _listaProveedores.Add(listaProveedor);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _listaProveedores;
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

        public bool ValidarProveedorExistente(string nombreEmpresa)
        {
            bool Existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    List<Proveedores> lista = new List<Proveedores>();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("NombreEmpresa_in", nombreEmpresa) };
                    string proceso = "SP_Consultar_ValidarEmpresaExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "proveedores");
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
        public bool InsertarProveedor(Proveedores _proveedor)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string proceso = "SP_insertar_AltaProveedor";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("NombreEmpresa_in", _proveedor.NombreEmpresa);
                    cmd.Parameters.AddWithValue("Contacto_in", _proveedor.Contacto);
                    cmd.Parameters.AddWithValue("Email_in", _proveedor.Email);
                    cmd.Parameters.AddWithValue("SitioWeb_in", _proveedor.SitioWeb);
                    cmd.Parameters.AddWithValue("Calle_in", _proveedor.Calle);
                    cmd.Parameters.AddWithValue("Altura_in", _proveedor.Altura);
                    cmd.Parameters.AddWithValue("Telefono_in", _proveedor.Telefono);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", _proveedor.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", _proveedor.idUsuario);
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
    }
}
