using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoProductos
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
        public bool InsertarProducto(Productos _producto)
        {
            bool RespuestaExito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    string storedProcedure = "SP_Insertar_Producto";
                    MySqlCommand cmd = new MySqlCommand(storedProcedure, connection);
                    connection.Close();
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("CodigoProducto_in", _producto.CodigoProducto);
                    cmd.Parameters.AddWithValue("idCategoriaProducto_in", _producto.idCategoriaProducto);
                    cmd.Parameters.AddWithValue("Descripcion_in", _producto.Descripcion);
                    cmd.Parameters.AddWithValue("idMarca_in", _producto.idMarca);
                    cmd.Parameters.AddWithValue("idUnidadDeMedicion_in", _producto.idUnidadDeMedicion);
                    cmd.Parameters.AddWithValue("PrecioDeVenta_in", _producto.PrecioDeVenta);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", _producto.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", _producto.idUsuario);
                    MySqlDataReader r = cmd.ExecuteReader();

                    while (r.Read())
                    {
                        int idProducto = Convert.ToInt32(r["ID"].ToString());
                        if (idProducto > 0)
                        {
                            DaoStock _dao = new DaoStock();
                            int idStock = _dao.InsertarStock(idProducto, 0);
                            if (idStock > 0)
                            {
                                RespuestaExito = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return RespuestaExito;
        }
        public bool EditarProducto(Productos producto, int idProductoGrillaSeleccionado)
        {
            bool exito = false;
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    string Actualizar = "SP_Actualizar_Producto";
                    MySqlCommand cmd = new MySqlCommand(Actualizar, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("idProducto_in", idProductoGrillaSeleccionado);
                    cmd.Parameters.AddWithValue("CodigoProducto_in", producto.CodigoProducto);
                    cmd.Parameters.AddWithValue("idCategoriaProducto_in", producto.idCategoriaProducto);
                    cmd.Parameters.AddWithValue("Descripcion_in", producto.Descripcion);
                    cmd.Parameters.AddWithValue("idMarca_in", producto.idMarca);
                    cmd.Parameters.AddWithValue("idUnidadDeMedicion_in", producto.idUnidadDeMedicion);
                    cmd.Parameters.AddWithValue("PrecioDeVenta_in", producto.PrecioDeVenta);
                    cmd.Parameters.AddWithValue("FechaDeAlta_in", producto.FechaDeAlta);
                    cmd.Parameters.AddWithValue("idUsuario_in", producto.idUsuario);
                    cmd.ExecuteNonQuery();
                    exito = true;
                    connection.Close();
                    return exito;
                }
                catch (Exception ex)
                { throw ex; }
            }
        }

        public Productos BuscarProductosPorId(int idProducto)
        {
            Productos producto = new Productos();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("IdProducto_in", idProducto) };
                    string proceso = "SP_Consultar_ProductoPorId";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            producto = new Productos();
                            producto.idProducto = Convert.ToInt32(item["idProducto"].ToString());
                            producto.CodigoProducto = item["CodigoProducto"].ToString();
                            producto.Descripcion = item["Descripcion"].ToString();
                            producto.NombreMarca = item["NombreMarca"].ToString();
                            producto.StockTotal = Convert.ToInt32(item["StockTotal"].ToString());
                            producto.PrecioDeVenta = decimal.Parse(item["PrecioDeVenta"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return producto;
        }
        public List<Productos> ListarProductosDisponibles()
        {
            List<Productos> _lista = new List<Productos>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { };
                    string proceso = "SP_Consultar_ListarProductos";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Productos listaProducto = new Productos();
                            listaProducto.idProducto = Convert.ToInt32(item["idProducto"].ToString());
                            listaProducto.CodigoProducto = item["CodigoProducto"].ToString();
                            listaProducto.Descripcion = item["Descripcion"].ToString();
                            listaProducto.NombreMarca = item["MarcaProducto"].ToString();
                            listaProducto.StockTotal = Convert.ToInt32(item["Stock"].ToString());
                            _lista.Add(listaProducto);
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
        public bool ValidarProductoExistente(string codigoProducto)
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
                                      new MySqlParameter("CodigoProducto_in", codigoProducto) };
                string proceso = "ValidarProductoExistente";
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

        public List<Stock> BuscarProductoPorCodigo(string descripcion)
        {
            List<Stock> _listaStocks = new List<Stock>();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                connection.Close();
                connection.Open();               
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                DataTable Tabla = new DataTable();
                MySqlParameter[] oParam = { new MySqlParameter("descripcion_in", descripcion) };
                string proceso = "SP_Consultar_BuscarProductoPorCodigo";
                MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                dt.SelectCommand.Parameters.AddRange(oParam);
                dt.Fill(Tabla);
                if (Tabla.Rows.Count > 0)
                {
                    foreach (DataRow item in Tabla.Rows)
                    {
                        Stock listaStock = new Stock();
                        listaStock.idProducto = Convert.ToInt32(item["idProducto"].ToString());
                        listaStock.CodigoProducto = item["CodigoProducto"].ToString();
                        listaStock.NombreMarca = item["NombreMarca"].ToString();
                        //listaStock.Cantidad = String.IsNullOrEmpty(item["Cantidad"].ToString()) ? 0 : Convert.ToInt32(item["txCantidad"].ToString());
                        listaStock.Descripcion = item["Descripcion"].ToString();
                        _listaStocks.Add(listaStock);
                    }
                }
                connection.Close();
                return _listaStocks;
            }
        }
    }
}
