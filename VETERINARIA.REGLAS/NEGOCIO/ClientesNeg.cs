using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;

namespace VETERINARIA.REGLAS.NEGOCIO
{
    public class ClientesNeg
    {
        public static bool InsertarCliente(Clientes _cliente)
        {
            DaoClientes _dao = new DaoClientes();
            bool exito = false;
            try
            {
                bool UsuarioExistente = _dao.ValidarClienteExistente(_cliente.Dni);
                if (UsuarioExistente == true)
                {
                    const string message = "Atención:Ya existe un cliente registrado con el dni ingresado.";
                    throw new Exception(message);
                }
                else
                {
                    exito = _dao.InsertCliente(_cliente);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static bool EditarCliente(Clientes cliente, int idClienteSeleccionado)
        {
            bool exito = false;
            DaoClientes _dao = new DaoClientes();
            try
            {
                exito = _dao.EditarCliente(cliente, idClienteSeleccionado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }
        public static List<Clientes> ListaDeClientes()
        {
            DaoClientes _dao = new DaoClientes();
            List<Clientes> _listaClientes = new List<Clientes>();
            try
            {
                _listaClientes = _dao.ListarClientes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _listaClientes;
        }
        public static Clientes ListarClientePorId(int idCliente)
        {
            DaoClientes _dao = new DaoClientes();
            Clientes _Clientes = new Clientes();
            try
            {
                _Clientes = _dao.ListarClientePorId(idCliente);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _Clientes;
        }
    }
}
