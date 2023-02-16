using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoClientes
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

        public bool InsertCliente(Clientes _cliente)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string proceso = "SP_insertar_AltaCliente";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("Dni_in", _cliente.Dni);
                    cmd.Parameters.AddWithValue("Sexo_in", _cliente.Sexo);
                    cmd.Parameters.AddWithValue("Apellido_in", _cliente.Apellido);
                    cmd.Parameters.AddWithValue("Nombre_in", _cliente.Nombre);
                    cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
                    cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", _cliente.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
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

        public List<Clientes> ListarClientes()
        {
            List<Clientes> _listaClientes = new List<Clientes>();
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
                    string proceso = "SP_Consultar_ListarClientes";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Clientes listaCliente = new Clientes();
                            listaCliente.IdCliente = Convert.ToInt32(item["idCliente"].ToString());
                            listaCliente.Apellido = item["Apellido"].ToString();
                            listaCliente.Nombre = item["Nombre"].ToString();
                            listaCliente.ApellidoNombre = listaCliente.Apellido + " " + listaCliente.Nombre;
                            listaCliente.Dni = item["Dni"].ToString();
                            listaCliente.Email = item["Email"].ToString();
                            listaCliente.Telefono = item["Telefono"].ToString();
                            _listaClientes.Add(listaCliente);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _listaClientes;
        }

        public bool ValidarClienteExistente(string dni)
        {
            bool Existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    List<Clientes> lista = new List<Clientes>();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("Dni_in", dni) };
                    string proceso = "SP_Consultar_ValidarClienteExistente";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    DataSet ds = new DataSet();
                    dt.Fill(ds, "clientes");
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
    }
}
