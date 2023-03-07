using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoPrecios
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

        public void GuardarHistorialPrecioDeVenta(int idProducto, Productos producto)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_PrecioDeVenta";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idProducto_in", idProducto);
                    cmd.Parameters.AddWithValue("PrecioDeVenta_in", producto.PrecioDeVenta);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", producto.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", producto.idUsuario);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public decimal ValidarPrecioDeVentaActual(Productos producto, int idProductoGrillaSeleccionado)
        {
            decimal PrecioActualDeVenta = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Close();
                connection.Open();
                List<Productos> lista = new List<Productos>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                                      new MySqlParameter("idProducto_in", idProductoGrillaSeleccionado) };
                string proceso = "SP_Consultar_ValidarPrecioDeVentaActual";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                DataSet ds = new DataSet();
                dt.Fill(ds, "productos");
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        PrecioActualDeVenta = Convert.ToDecimal(item["PrecioDeVenta"].ToString());
                    }
                }
                connection.Close();
            }
            return PrecioActualDeVenta;
        }

        public List<Precios> ListarPreciosDeVenta(int idProducto)
        {
            List<Precios> _lista = new List<Precios>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("idProducto_in", idProducto) };
                    string proceso = "SP_Consultar_ListarPrecios";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Precios precio = new Precios();
                            precio.idProducto = Convert.ToInt32(item["idProducto"].ToString());
                            precio.CodigoProducto = item["CodigoProducto"].ToString();
                            precio.Descripcion = item["Descripcion"].ToString();
                            precio.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            precio.Precio = decimal.Parse(item["Precio"].ToString());
                            _lista.Add(precio);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _lista;
        }
    }
}
