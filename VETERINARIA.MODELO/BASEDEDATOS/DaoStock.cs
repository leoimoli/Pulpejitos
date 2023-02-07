using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoStock
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
        public int InsertarMovimientoAltaStock(Stock stock)
        {
            int idMovimietoAltaStock = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string proceso = "SP_Insertar_MovimientoAltaStock";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idProveedor_in", stock.idProveedor);
                    cmd.Parameters.AddWithValue("FechaFactura_in", stock.FechaFactura);
                    cmd.Parameters.AddWithValue("Remito_in", stock.Remito);
                    cmd.Parameters.AddWithValue("MontoTotal_in", stock.MontoTotal);
                    cmd.Parameters.AddWithValue("FechaRegistro_in", stock.FechaRegistro);
                    cmd.Parameters.AddWithValue("idUsuario_in", stock.idUsuario);
                    MySqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        idMovimietoAltaStock = Convert.ToInt32(r["ID"].ToString());
                    }
                    ///// Si registro el movimiento exitosamente, paso a resgitrar el historial para cada producto.
                    if (idMovimietoAltaStock > 0)
                    {
                        bool RespuestaExitosa = InsertarHistorialIngresoDeStock(stock, idMovimietoAltaStock);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return idMovimietoAltaStock;
        }
        private bool InsertarHistorialIngresoDeStock(Stock stock, int idMovimietoAltaStock)
        {
            bool RespuestaExitosa = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    foreach (var item in stock.ListaIngresoStock)
                    {
                        connection.Close();
                        connection.Open();
                        string proceso = "SP_Insertar_HistorialIngresoDeStock";
                        MySqlCommand cmd = new MySqlCommand(proceso, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idProducto_in", item.idProducto);
                        cmd.Parameters.AddWithValue("CantidadStockDeCompra_in", item.CantidadStockDeCompra);
                        cmd.Parameters.AddWithValue("ValorUnitarioDeCompra_in", item.ValorUnitarioDeCompra);
                        cmd.Parameters.AddWithValue("ValorTotalDeCompra_in", item.ValorTotalDeCompra);
                        cmd.Parameters.AddWithValue("idMovimietoAltaStock_in", idMovimietoAltaStock);
                        cmd.ExecuteNonQuery();
                        RespuestaExitosa = true;
                        if (RespuestaExitosa == true)
                        {
                            try
                            {
                                ///// Actualizo el stock para cada producto.
                                ActualizarStock(item.idProducto, item.CantidadStockDeCompra);
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return RespuestaExitosa;
            }
        }
        private void ActualizarStock(int idProducto, int cantidadStockDeCompra)
        {
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    int StockActual = ObtenerStockActual(idProducto);
                    int StockActualizado = StockActual + cantidadStockDeCompra;
                    connection.Close();
                    connection.Open();
                    string proceso = "SP_Actualizar_Stock";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idProducto_in", idProducto);
                    cmd.Parameters.AddWithValue("StockActualizado_in", StockActualizado);
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                { throw ex; }
            }
        }
        private int ObtenerStockActual(int idProducto)
        {
            int StockActual = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { };
                    string proceso = "SP_Consultar_Stock";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            StockActual = Convert.ToInt32(item["StockTotal"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return StockActual;
        }
        public int InsertarStock(int idProducto, int cantidad)
        {
            int RespuestaExito = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Stock";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idProducto_in", idProducto);
                    cmd.Parameters.AddWithValue("Cantidad_in", cantidad);
                    MySqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        RespuestaExito = Convert.ToInt32(r["ID"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RespuestaExito;
        }
    }
}
