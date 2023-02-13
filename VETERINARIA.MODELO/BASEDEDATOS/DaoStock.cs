using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
        public int InsertarMovimientoAltaStock(List<Stock> stock, decimal MontoTotalFactura)
        {
            int idMovimietoAltaStock = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    var PrimerElemento = stock.First();
                    connection.Close();
                    connection.Open();
                    string proceso = "SP_Insertar_MovimientoAltaStock";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idProveedor_in", PrimerElemento.idProveedor);
                    cmd.Parameters.AddWithValue("FechaFactura_in", PrimerElemento.FechaFactura);
                    cmd.Parameters.AddWithValue("Remito_in", PrimerElemento.Remito);
                    cmd.Parameters.AddWithValue("MontoTotal_in", MontoTotalFactura);
                    cmd.Parameters.AddWithValue("FechaRegistro_in", PrimerElemento.FechaRegistro);
                    cmd.Parameters.AddWithValue("idUsuario_in", PrimerElemento.idUsuario);
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
        private bool InsertarHistorialIngresoDeStock(List<Stock> stock, int idMovimietoAltaStock)
        {
            bool RespuestaExitosa = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    foreach (var item in stock)
                    {
                        connection.Close();
                        connection.Open();
                        string proceso = "SP_Insertar_HistorialIngresoDeStock";
                        MySqlCommand cmd = new MySqlCommand(proceso, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idProducto_in", item.idProducto);
                        cmd.Parameters.AddWithValue("CantidadStockDeCompra_in", item.Cantidad);
                        cmd.Parameters.AddWithValue("ValorUnitarioDeCompra_in", item.ValorUnitario);
                        cmd.Parameters.AddWithValue("ValorTotalDeCompra_in", item.MontoTotalPorProducto);
                        cmd.Parameters.AddWithValue("idMovimietoAltaStock_in", idMovimietoAltaStock);
                        cmd.Parameters.AddWithValue("idSucursal_in", item.idSucursal);
                        cmd.ExecuteNonQuery();
                        RespuestaExitosa = true;
                        if (RespuestaExitosa == true)
                        {
                            try
                            {
                                ///// Actualizo el stock para cada producto.
                                ActualizarStock(item.idProducto, item.Cantidad);
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
                    MySqlParameter[] oParam = { new MySqlParameter("idProducto_in", idProducto) };
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

        public bool ValidarCodigoExistente(string codigoArmado)
        {
            bool Existe = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Close();
                connection.Open();
                List<Productos> lista = new List<Productos>();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = {
                                      new MySqlParameter("CodigoProducto_in", codigoArmado) };
                string proceso = "SP_Consulta_ValidarCodigoExistente";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                DataSet ds = new DataSet();
                dt.Fill(ds, "productos");
                if (Tabla.Rows.Count > 0)
                {
                    Existe = true;
                }
                connection.Close();
            }
            return Existe;
        }
    }
}
