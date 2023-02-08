using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.BASEDEDATOS;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class _ProductoWF : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            CargarCombos();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            Productos _producto = CargarEntidad();
            bool RespuestaExitosa = ProductoNeg.InsertarProducto(_producto);
            if (RespuestaExitosa == true)
            {
                LimpiarCampos();
                FuncionListarProductos();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {

        }
        catch (Exception ex)
        {

        }
    }
    #region Metodos
    private Productos CargarEntidad()
    {
        ///// Harcodear idUsuarios
        Productos _producto = new Productos();
        _producto.CodigoProducto = txtCodigo.Value;
        _producto.idCategoriaProducto = 1;
        _producto.Descripcion = txtDescripción.Value;
        _producto.idMarca = 1;
        _producto.idUnidadDeMedicion = 1;
        DateTime fechaActual = DateTime.Now;
        _producto.FechaDeAlta = fechaActual;
        _producto.idUsuario = 1;
        return _producto;
    }
    private void LimpiarCampos()
    {
        txtCodigo.Value = String.Empty;
        txtDescripción.Value = String.Empty;
        //CargarCombo();
        //progressBar1.Value = Convert.ToInt32(null);
        //progressBar1.Visible = false;
        //chcProductoEspecial.Checked = false;
    }
    private void FuncionListarProductos()
    {
        //FuncionBuscartexto();
        //dgvProductos.Rows.Clear();
        //List<Entidades.Productos> ListaProductos = Negocio.Consultar.ListaDeProductos();
        //if (ListaProductos.Count > 0)
        //{
        //    foreach (var item in ListaProductos)
        //    {
        //        dgvProductos.Rows.Add(item.idProducto, item.CodigoProducto, item.Descripcion, item.MarcaProducto);
        //    }
        //}
        //dgvProductos.ReadOnly = true;
    }
    private void CargarCombos()
    {
        List<string> Marcas = new List<string>();
        Marcas = MarcasNeg.CargarComboMarcas();
        foreach (string item in Marcas)
        {
            if (cmbMarca.Items.Count == 0)
            {
                cmbMarca.Items.Add("Seleccione");
            }
            cmbMarca.Items.Add(item);
        }

        List<string> Categorias = new List<string>();
        Categorias = CategoriasNeg.CargarComboCategoria();
        foreach (string item in Categorias)
        {
            if (cmbCategoria.Items.Count == 0)
            {
                cmbCategoria.Items.Add("Seleccione");
            }
            cmbCategoria.Items.Add(item);
        }

        List<string> UnidadesMedicion = new List<string>();
        UnidadesMedicion = UnidadMedicionNeg.CargarComboUnidadDeMedicion();
        foreach (string item in UnidadesMedicion)
        {
            if (cmbUnidadesMedicion.Items.Count == 0)
            {
                cmbUnidadesMedicion.Items.Add("Seleccione");
            }
            cmbUnidadesMedicion.Items.Add(item);
        }
    }
    #endregion
}