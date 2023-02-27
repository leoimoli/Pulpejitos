using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VETERINARIA.MODELO.ENTIDADES;
using VETERINARIA.REGLAS.NEGOCIO;

public partial class MascotasWF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                txtDniTitular.Focus();
                DivFiltros.Visible = true;
                CargarComboEspecies();
                FuncionListarMascotas();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    #region Botones
    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        try
        {
            Limpiar_FiltrosDeBusqueda();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            string dni = txtDniTitular.Value;
            string NombreMascota = txtNombre.Value;
            int Especie = Convert.ToInt32(cmbEspecies.SelectedItem.Value);
            int Raza = Convert.ToInt32(cmbRaza.SelectedItem.Value);

            List<Mascotas> _listaMascotas = MascotasNeg.BuscarMascotasPorFiltros(dni, NombreMascota, Especie, Raza);
            if (_listaMascotas.Count > 0)
            {
                DivGrillaMascotas.Visible = true;
                foreach (var item in _listaMascotas)
                {
                    DateTime nacimiento = item.FechaNacimiento; //Fecha de nacimiento
                    item.EdadMascota = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
                }
                RepeaterMascotas.DataSource = _listaMascotas;
                RepeaterMascotas.DataBind();
                int MensajesVisible = 0;
                MostrarMensajes(MensajesVisible);
            }
            else
            {
                //DivGrillaMascotas.Visible = false;
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: No se encontraron resultados para la busqueda ingresada.";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmbEspecies_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idEspecieSeleccionada = Convert.ToInt32(cmbEspecies.SelectedItem.Value);
            CargarComboRazas(idEspecieSeleccionada);
        }
        catch (Exception ex)
        { }
    }
    protected void btnNuevoMascota_Click(object sender, EventArgs e)
    {
        try
        {
            Funcion_AltaMascota();
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        try
        {
            if (FuncionVariable == "NUEVO")
            {
                Mascotas _mascotas = CargarEntidad();
                bool RespuestaExitosa = MascotasNeg.InsertarMascota(_mascotas);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoInsert();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló el registro de la Mascota.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (FuncionVariable == "EDITAR")
            {
                Mascotas _mascotas = CargarEntidad();
                bool RespuestaExitosa = MascotasNeg.EditarMascota(_mascotas, idMascotaSeleccionada);
                if (RespuestaExitosa == true)
                {
                    LimpiarCampos_ExitoEditar();
                }
                else
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: Falló la edición de la Mascota.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
        }
        catch (Exception ex)
        {
            DivMensajeError.Visible = true;
            lblMensajeError.Text = ex.Message;
        }
    }
    private void LimpiarCampos_ExitoEditar()
    {
        idClienteTitularMascota = 0;
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtNombreMascota.Value = String.Empty;
        FechaNacimiento.Value = String.Empty;
        cmbAlta_Especie.ClearSelection();
        cmbAlta_Raza.ClearSelection();
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: se registro la edición de la mascota exitosamente.";
        txtDni.Focus();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        try
        {
            LimpiarCampos_Cancelar();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void cmbAlta_Especie_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idEspecieSeleccionada = Convert.ToInt32(cmbAlta_Especie.SelectedItem.Value);
            CargarComboRazas_AltaMascota(idEspecieSeleccionada);
        }
        catch (Exception ex)
        { }
    }
    protected void btnBuscarCliente_Click(object sender, EventArgs e)
    {
        try
        {
            string NroDni = txtDni.Value;
            List<Clientes> Cliente = ClientesNeg.BuscarClientePorDni(NroDni);
            if (Cliente.Count > 0)
            {
                foreach (Clientes item in Cliente)
                {
                    txtDniTitular.Value = NroDni;
                    Text1.Value = item.Nombre;
                    txtApellido.Value = item.Apellido;
                    idClienteSeleccionado = item.IdCliente;
                }
            }
            else
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: No se encontro ningún cliente con el Dni ingresado.";
            }
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnEditarMascota_Command(object sender, CommandEventArgs e)
    {
        FuncionVariable = "EDITAR";
        Mascotas _mascotaSeleccionado = new Mascotas();
        idMascotaSeleccionada = Convert.ToInt32(e.CommandArgument);
        _mascotaSeleccionado = MascotasNeg.ListarMascotaPorId(idMascotaSeleccionada);
        idClienteTitularMascota = _mascotaSeleccionado.idCliente;
        FuncionEditar_HabilitarCampos(_mascotaSeleccionado);
    }
    #endregion


    #region Metodos
    public static string FuncionVariable = "";
    public static int idClienteTitularMascota = 0;
    public static int idClienteSeleccionado = 0;
    public static int idMascotaSeleccionada = 0;
    private void Funcion_AltaMascota()
    {
        CargarComboEspecies_AltaMascota();
        DivFiltros.Visible = false;
        DivAltaMascota.Visible = true;
        FuncionVariable = "NUEVO";
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
    }
    private void MostrarMensajes(int mensajesVisible)
    {
        ///// NADA
        if (mensajesVisible == 0)
        {
            DivMensajeError.Visible = false;
            DivMensajeExito.Visible = false;
        }
        ///// Hay EXITO
        if (mensajesVisible == 1)
        {
            DivMensajeError.Visible = false;
            DivMensajeExito.Visible = true;
        }
        ///// Hay ERROR
        if (mensajesVisible == 2)
        {
            DivMensajeError.Visible = true;
            DivMensajeExito.Visible = false;
        }
    }
    private void CargarComboEspecies()
    {
        cmbEspecies.Items.Clear();
        List<Especies> EspecieSeleccionada = new List<Especies>();
        EspecieSeleccionada = EspecieNeg.CargarComboEspecie();
        cmbEspecies.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Especies item in EspecieSeleccionada)
        {
            cmbEspecies.Items.Add(new ListItem { Text = item.Nombre, Value = item.idEspecie.ToString() });
        }
    }
    private void CargarComboEspecies_AltaMascota()
    {
        cmbAlta_Especie.Items.Clear();
        List<Especies> EspecieSeleccionada = new List<Especies>();
        EspecieSeleccionada = EspecieNeg.CargarComboEspecie();
        cmbAlta_Especie.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Especies item in EspecieSeleccionada)
        {
            cmbAlta_Especie.Items.Add(new ListItem { Text = item.Nombre, Value = item.idEspecie.ToString() });
        }
    }
    private void CargarComboEspecies_EditarMascota(int idEspecie, string NombreEspecie)
    {
        List<Especies> EspecieSeleccionada = new List<Especies>();
        EspecieSeleccionada = EspecieNeg.CargarComboEspecie();
        cmbAlta_Especie.Items.Add(new ListItem { Text = NombreEspecie, Value = Convert.ToString(idEspecie), Selected = true });
        cmbAlta_Especie.Items.Add(new ListItem { Text = "Seleccione", Value = "0" });
        foreach (Especies item in EspecieSeleccionada)
        {
            cmbAlta_Especie.Items.Add(new ListItem { Text = item.Nombre, Value = item.idEspecie.ToString() });
        }
    }
    private void Limpiar_FiltrosDeBusqueda()
    {
        txtDniTitular.Value = String.Empty;
        txtNombre.Value = String.Empty;
        CargarComboEspecies();
        txtDniTitular.Focus();
    }
    private void CargarComboRazas(int idEspecieSeleccionada)
    {
        cmbRaza.Items.Clear();
        List<Razas> RazaSeleccionada = new List<Razas>();
        RazaSeleccionada = RazaNeg.CargarComboRaza(idEspecieSeleccionada);
        cmbRaza.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Razas item in RazaSeleccionada)
        {
            cmbRaza.Items.Add(new ListItem { Text = item.Nombre, Value = item.idRaza.ToString() });
        }
    }
    private void CargarComboRazas_AltaMascota(int idEspecieSeleccionada)
    {
        cmbAlta_Raza.Items.Clear();
        List<Razas> RazaSeleccionada = new List<Razas>();
        RazaSeleccionada = RazaNeg.CargarComboRaza(idEspecieSeleccionada);
        cmbAlta_Raza.Items.Add(new ListItem { Text = "Seleccione", Value = "0", Selected = true });
        foreach (Razas item in RazaSeleccionada)
        {
            cmbAlta_Raza.Items.Add(new ListItem { Text = item.Nombre, Value = item.idRaza.ToString() });
        }
    }
    private Mascotas CargarEntidad()
    {
        try
        {
            ValidarDatosObligatorios();
            Mascotas _mascota = new Mascotas();
            _mascota.idCliente = idClienteSeleccionado;
            _mascota.Nombre = txtNombreMascota.Value;
            _mascota.idEspecie = Convert.ToInt32(cmbAlta_Especie.SelectedItem.Value);
            _mascota.idRaza = Convert.ToInt32(cmbAlta_Raza.SelectedItem.Value);
            _mascota.idCliente = idClienteTitularMascota;
            _mascota.FechaNacimiento = Convert.ToDateTime(FechaNacimiento.Value);
            DateTime fechaActual = DateTime.Now;
            _mascota.FechaDeAlta = fechaActual;
            _mascota.idUsuario = 1;
            return _mascota;
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void ValidarDatosObligatorios()
    {
        try
        {
            if (FuncionVariable != "EDITAR")
            {
                if (String.IsNullOrEmpty(txtDniTitular.Value))
                {
                    int MensajesVisible = 2;
                    MostrarMensajes(MensajesVisible);
                    lblMensajeError.Text = "Atención: El campo Dni del Titular es un dato obligatorio.";
                    throw new Exception(lblMensajeError.Text);
                }
            }
            if (String.IsNullOrEmpty(txtNombreMascota.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Nombre de la mascota es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
            if (String.IsNullOrEmpty(cmbAlta_Especie.SelectedItem.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Especie es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
            if (String.IsNullOrEmpty(cmbAlta_Raza.SelectedItem.Value))
            {
                int MensajesVisible = 2;
                MostrarMensajes(MensajesVisible);
                lblMensajeError.Text = "Atención: El campo Raza es un dato obligatorio.";
                throw new Exception(lblMensajeError.Text);
            }
        }
        catch (Exception ex)
        { throw ex; }
    }
    private void LimpiarCampos_Cancelar()
    {
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtNombreMascota.Value = String.Empty;
        cmbAlta_Especie.ClearSelection();
        cmbAlta_Raza.ClearSelection();
        FechaNacimiento.Value = String.Empty;
        DivAltaMascota.Visible = false;
        DivFiltros.Visible = true;
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        FuncionListarMascotas();
    }
    private void FuncionListarMascotas()
    {
        List<Mascotas> ListaMascotas = MascotasNeg.ListarMascotas();
        if (ListaMascotas.Count > 0)
        {
            DivGrillaMascotas.Visible = true;
            foreach (var item in ListaMascotas)
            {
                DateTime nacimiento = item.FechaNacimiento; //Fecha de nacimiento
                item.EdadMascota = DateTime.Today.AddTicks(-nacimiento.Ticks).Year - 1;
            }
            RepeaterMascotas.DataSource = ListaMascotas;
            RepeaterMascotas.DataBind();
            int MensajesVisible = 0;
            MostrarMensajes(MensajesVisible);
        }
        else
        {
            //DivGrillaMascotas.Visible = false;
            int MensajesVisible = 2;
            MostrarMensajes(MensajesVisible);
            lblMensajeError.Text = "Atención: No se encontraron resultados para la busqueda ingresada.";
        }
    }
    private void LimpiarCampos_ExitoInsert()
    {
        txtDni.Value = String.Empty;
        txtApellido.Value = String.Empty;
        txtNombre.Value = String.Empty;
        txtNombreMascota.Value = String.Empty;
        CargarComboEspecies_AltaMascota();
        CargarComboRazas_AltaMascota(0);
        FechaNacimiento.Value = String.Empty;
        int MensajesVisible = 1;
        MostrarMensajes(MensajesVisible);
        lblMensajeExito.Text = "Atención: se registro la mascota exitosamente.";
        txtDni.Focus();
    }
    private void FuncionEditar_HabilitarCampos(Mascotas mascotaSeleccionado)
    {
        DivFiltros.Visible = false;
        DivAltaMascota.Visible = true;
        txtDni.Value = mascotaSeleccionado.DniCliente;
        txtApellido.Value = mascotaSeleccionado.ApellidoCliente;
        Text1.Value = mascotaSeleccionado.NombreCliente;
        txtNombreMascota.Value = mascotaSeleccionado.Nombre;
        //string fecha = mascotaSeleccionado.FechaNacimiento.Date.ToShortDateString();
        string fecha = Convert.ToDateTime(mascotaSeleccionado.FechaNacimiento).Date.ToString("yyyy-MM-dd");
        FechaNacimiento.Value = fecha;
        txtDni.Disabled = true;
        txtApellido.Disabled = true;
        Text1.Disabled = true;
        cmbAlta_Especie.ClearSelection();
        cmbAlta_Raza.ClearSelection();
        cmbAlta_Raza.Items.Add(new ListItem { Text = mascotaSeleccionado.NombreRaza, Value = Convert.ToString(mascotaSeleccionado.idRaza), Selected = true });
        int MensajesVisible = 0;
        MostrarMensajes(MensajesVisible);
        CargarComboEspecies_EditarMascota(mascotaSeleccionado.idEspecie, mascotaSeleccionado.NombreEspecie);
    }
    #endregion
}