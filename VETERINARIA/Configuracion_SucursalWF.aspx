<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Configuracion_SucursalWF.aspx.cs" Inherits="Configuracion_SucursalWF" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- MENSAJES DE RESPUESTA -->
    <div class="row" id="DivMensajeExito" runat="server" visible="false">
        <div class="col-lg-12">
            <div class="alert alert-dismissible fade show alert-primary" role="alert">
                <asp:Label ID="lblMensajeExito" runat="server" Text="Exito"></asp:Label>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </div>

    </div>
    <div class="row" id="DivMensajeError" runat="server" visible="false">
        <div class="col-lg-12">
            <div class="alert alert-dismissible fade show alert-danger" role="alert">
                <asp:Label ID="lblMensajeError" runat="server" Text="Error"></asp:Label>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </div>

    </div>
    <!-- GRILLA DE CONSULTA -->
    <div class="row" id="DivGrillaSucursal" runat="server">
        <div class="col-12">
            <!-- Recent Order Table -->
            <div class="card card-table-border-none recent-orders" id="recent-orders">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Filtros de busqueda</h2>
                </div>
                <!-- FILTROS DE BUSQUEDA -->
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6 col-sm-6">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre Sucursal(*)</label>
                                <input type="text" runat="server" id="txtBuscarSucursal" class="form-control" placeholder="Nombre Sucursal">
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4" style="margin-top: 30px;">
                            <asp:Button Text="Buscar" runat="server" OnClick="btnBuscar_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                        </div>
                    </div>
                </div>
                <!-- GRILLA DE MARCAS -->
                <div class="card-body pt-0 pb-5">
                    <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                        <thead>
                            <tr>
                                <th><b>id Sucursal</b></th>
                                <th><b>Nombre Sucursal</b></th>
                                <th class="d-none d-lg-table-cell"><b>Domicilio</b></th>
                                 <th class="d-none d-lg-table-cell"><b>Provincia</b></th>
                                 <th class="d-none d-lg-table-cell"><b>Localidad</b></th>
                                <th class="d-none d-lg-table-cell"><b>Usuario</b></th>
                                <th class="d-none d-lg-table-cell"><b>Estado</b></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterSucursal" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idSucursal") %></td>
                                        <td>
                                            <%# Eval("Nombre") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Domicilio") %></td>
                                          <td class="d-none d-lg-table-cell"><%# Eval("NombreProvincia") %></td>
                                          <td class="d-none d-lg-table-cell"><%# Eval("NombreLocalidad") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("UsuarioApellidoNombre") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Estado") %></td>
                                        <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <asp:LinkButton Text='<%# (Eval("Estado").ToString() == "Inactivo") ? "ACTIVAR" : "ELIMINAR" %>' CssClass="fa fa-times fa-lg" runat="server"
                                                            CommandArgument='<%# Eval("idSucursal") %>' ID="btnEliminarSucursal" OnCommand="btnEliminarCategoria_Command" />
                                                    </li>
                                                </ul>
                                            </div>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    <div class="form-footer pt-4 pt-5 mt-4 border-top">
                        <asp:Button Text="Nueva Sucursal" runat="server" OnClick="btnNueva_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- FORMULARIO DE ALTA MARCA -->
    <div class="row" id="DivAltaSucursal" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">
                <div id="divAltaSucursalEncabezado" style="color: blueviolet" runat="server" class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Alta Sucursal</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre Sucursal(*)</label>
                                <input type="text" runat="server" id="txtNombreSucursal" class="form-control" placeholder="Nombre Sucursal">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Calle</label>
                                <input type="text" runat="server" id="txtCalle" class="form-control" placeholder="Calle">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Altura</label>
                                <input type="text" runat="server" id="txtAltura" class="form-control" placeholder="Calle">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Provincia</label>
                                <asp:DropDownList class="form-control" ID="cmbAlta_Provincia" AutoPostBack="true" runat="server" OnSelectedIndexChanged="cmbAlta_Provincia_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                              <label for="exampleFormControlSelect12" style="color: blueviolet">Localidad</label>
                                <asp:DropDownList class="form-control" ID="cmbAlta_Localidad" runat="server" OnSelectedIndexChanged="cmbAlta_Localidad_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Código Postal</label>
                                <input type="text" runat="server" id="txtCódigoPostal" class="form-control" placeholder="Código Postal">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-footer pt-4 pt-5 mt-4">
                                <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-default" Style="background-color: blueviolet" />
                                <asp:Button Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
