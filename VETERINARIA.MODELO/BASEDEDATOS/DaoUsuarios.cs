using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.MODELO.BASEDEDATOS
{
    public class DaoUsuarios
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

        public Usuarios BuscarUsuarioLogin(string usuario)
        {
            Usuarios usuarioDB = new Usuarios();
            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            {
                try
                {
                    connection.Close();
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    DataTable Tabla = new DataTable();
                    MySqlParameter[] oParam = { new MySqlParameter("Dni_in", usuario) };
                    string proceso = "SP_Consultar_BuscarUsuarioParaLogin";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            usuarioDB.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            usuarioDB.Apellido = item["Apellido"].ToString();
                            usuarioDB.Nombre = item["Nombre"].ToString();
                            usuarioDB.Dni = item["Dni"].ToString();
                            usuarioDB.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            usuarioDB.FechaUltimaConexion = Convert.ToDateTime(item["FechaUltimaConexion"].ToString());
                            usuarioDB.Contraseña = item["Contrasenia"].ToString();
                            usuarioDB.idEstado = Convert.ToInt32(item["Estado"].ToString());
                            usuarioDB.NombreEstado = (usuarioDB.idEstado == 1) ? "ACTIVO" : "INACTIVO";
                            usuarioDB.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());
                            usuarioDB.NombrePerfil = item["NombrePerfil"].ToString();
                        }
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return usuarioDB;
        }

        public List<Usuarios> ListarUsuarios()
        {
            List<Usuarios> _listaUsuarios = new List<Usuarios>();
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
                    string proceso = "SP_Consultar_ListarUsuarios";
                    MySqlDataAdapter dt = new MySqlDataAdapter(proceso, connection);
                    dt.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dt.SelectCommand.Parameters.AddRange(oParam);
                    dt.Fill(Tabla);
                    if (Tabla.Rows.Count > 0)
                    {
                        foreach (DataRow item in Tabla.Rows)
                        {
                            Usuarios usuarioDB = new Usuarios();
                            usuarioDB.IdUsuario = Convert.ToInt32(item["idUsuario"].ToString());
                            usuarioDB.idUsuarioAlta = Convert.ToInt32(item["idUsuarioAlta"].ToString());
                            usuarioDB.Apellido = item["Apellido"].ToString();
                            usuarioDB.Nombre = item["Nombre"].ToString();
                            usuarioDB.ApellidoNombre = usuarioDB.Apellido + " " + usuarioDB.Nombre;
                            usuarioDB.Dni = item["Dni"].ToString();
                            usuarioDB.idEstado = Convert.ToInt32(item["Estado"].ToString());
                            usuarioDB.NombreEstado = (usuarioDB.idEstado == 1) ? "ACTIVO" : "INACTIVO";
                            usuarioDB.Contraseña = item["Contrasenia"].ToString();
                            usuarioDB.Contraseña2 = item["Contrasenia"].ToString();
                            usuarioDB.FechaDeAlta = Convert.ToDateTime(item["FechaAlta"].ToString());
                            usuarioDB.FechaUltimaConexion = Convert.ToDateTime(item["FechaUltimaConexion"].ToString());
                            usuarioDB.idPerfil = Convert.ToInt32(item["idPerfil"].ToString());
                            DaoPerfiles _daoPerfiles = new DaoPerfiles();
                            usuarioDB.NombrePerfil = _daoPerfiles.ObtenerPerfilId(usuarioDB.idPerfil).NombrePerfil;
                            _listaUsuarios.Add(usuarioDB);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _listaUsuarios;
        }
    }
}

