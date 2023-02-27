using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
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

        public List<Clientes> BuscarClientePorDni(string nroDni)
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
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("NroDni_in", nroDni)};
                    string proceso = "SP_Consultar_BuscarClientePorDni";
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
        public bool EditarCliente(Clientes _cliente, int idClienteSeleccionado)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Editar_EditarCliente";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idCliente_in", idClienteSeleccionado);
                    cmd.Parameters.AddWithValue("Apellido_in", _cliente.Apellido);
                    cmd.Parameters.AddWithValue("Nombre_in", _cliente.Nombre);
                    cmd.Parameters.AddWithValue("Email_in", _cliente.Email);
                    cmd.Parameters.AddWithValue("Telefono_in", _cliente.Telefono);
                    cmd.Parameters.AddWithValue("idUsuario_in", _cliente.idUsuario);
                    cmd.ExecuteNonQuery();
                    exito = true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                connection.Close();
                return exito;
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

        public Clientes ListarClientePorId(int idCliente)
        {
            Clientes _cliente = new Clientes();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = {
                                      new MySqlParameter("idCliente_in", idCliente)};
                    string proceso = "SP_Consultar_ListarClientePorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            _cliente.IdCliente = Convert.ToInt32(item["idCliente"].ToString());
                            _cliente.Dni = item["Dni"].ToString();
                            _cliente.Apellido = item["Apellido"].ToString();
                            _cliente.Nombre = item["Nombre"].ToString();
                            _cliente.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            _cliente.Email = item["Email"].ToString();
                            _cliente.Telefono = item["Telefono"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _cliente;
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
