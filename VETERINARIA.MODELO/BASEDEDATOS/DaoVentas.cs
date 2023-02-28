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
    public class DaoVentas
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

        public List<Ventas> BuscarProductoParaVenta(string codigoProducto)
        {
            List<Ventas> _lista = new List<Ventas>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("codigoProducto_in", codigoProducto) };
                    string proceso = "SP_Consultar_BuscarProductoParaVenta";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Ventas listaProducto = new Ventas();
                            listaProducto.idProducto = Convert.ToInt32(item["idproducto"].ToString());
                            listaProducto.CodigoProducto = codigoProducto;
                            listaProducto.Descripcion = item["Descripcion"].ToString();
                            if (item["PrecioDeVenta"].ToString() != null & item["PrecioDeVenta"].ToString() != "")
                            {
                                listaProducto.PrecioVenta = Convert.ToDecimal(item["PrecioDeVenta"].ToString());
                            }
                            else
                            {
                                listaProducto.PrecioVenta = Convert.ToDecimal("0.00");
                            }
                            listaProducto.StockActual = Convert.ToInt32(item["Stock"].ToString());
                            _lista.Add(listaProducto);
                        }
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
            return _lista;
        }

        public int InsertarVenta(List<Ventas> listaProductos, int idusuario)
        {
            int idUltimaVenta = 0;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {

                    connection.Close();
                    connection.Open();
                    var producto = listaProductos.First();
                    producto.FechaVenta = DateTime.Now;
                    string proceso = "SP_Insertar_InsertarVenta";
                    MySqlCommand cmd = new MySqlCommand(proceso, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PrecioVentaFinal_in", producto.MontoTotalDeLaVenta);
                    cmd.Parameters.AddWithValue("idUsuario_in", idusuario);
                    cmd.Parameters.AddWithValue("Fecha_in", producto.FechaVenta);
                    MySqlDataReader r = cmd.ExecuteReader();
                    while (r.Read())
                    {
                        idUltimaVenta = Convert.ToInt32(r["ID"].ToString());
                    }
                    if (idUltimaVenta > 0)
                    {
                        RegistrarDetalleVenta(listaProductos, idUltimaVenta);
                    }
                    if (idUltimaVenta > 0)
                    {
                        ActualizarStockPorProductosVendidos(listaProductos);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                { }
                return idUltimaVenta;
            }
        }

        private bool ActualizarStockPorProductosVendidos(List<Ventas> listaProductos)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {

                    for (int i = 0; i < listaProductos.Count; i++)
                    {
                        connection.Close();
                        connection.Open();
                        string proceso = "ActualizarStock";
                        MySqlCommand cmd = new MySqlCommand(proceso, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idProducto_in", listaProductos[i].idProducto);
                        cmd.Parameters.AddWithValue("Cantidad_in", listaProductos[i].StockNuevoCalculado);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return exito;
            }
        }
        private bool RegistrarDetalleVenta(List<Ventas> listaProductos, int idUltimaVenta)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    for (int i = 0; i < listaProductos.Count; i++)
                    {
                        connection.Close();
                        connection.Open();
                        string proceso = "SP_Insetar_RegistrarDetalleVenta";
                        MySqlCommand cmd = new MySqlCommand(proceso, connection);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("idUltimaVenta_in", idUltimaVenta);
                        cmd.Parameters.AddWithValue("idProducto_in", listaProductos[i].idProducto);
                        cmd.Parameters.AddWithValue("Cantidad_in", listaProductos[i].CantidadVenta);
                        cmd.Parameters.AddWithValue("PrecioVenta_in", listaProductos[i].PrecioVenta);
                        cmd.ExecuteNonQuery();
                        exito = true;
                    }
                }
                catch (Exception ex)
                {
                    exito = false;
                    throw ex;
                }
                connection.Close();
                return exito;
            }

        }
    }
}

