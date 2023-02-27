<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="MascotasWF.aspx.cs" Inherits="MascotasWF" %>


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
    <!-- FILTROS DE BUSQUEDA EN CONSULTA -->
    <div class="row" id="DivFiltros" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Filtros de busqueda</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Dni del Titular</label>
                                <input type="text" runat="server" id="txtDniTitular" class="form-control" placeholder="Dni del titular">
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre</label>
                                <input type="text" runat="server" id="txtNombre" class="form-control" placeholder="Nombre de la mascota">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Especie de la mascosta</label>
                                <asp:DropDownList class="form-control" ID="cmbEspecies" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbEspecies_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Raza de la mascosta</label>
                                <asp:DropDownList class="form-control" ID="cmbRaza" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-footer pt-4 pt-5 mt-4">
                                <asp:Button Text="Limpiar" runat="server" OnClick="btnLimpiar_Click" CssClass="btn btn-secondary btn-default" Style="background-color: blueviolet" />
                                <asp:Button Text="Buscar" runat="server" OnClick="btnBuscar_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                    </div>
                </div>
                <!-- GRILLA DE CONSULTA -->
                <div class="row" id="DivGrillaMascotas" runat="server" visible="false">
                    <div class="col-12">

                        <!-- Recent Order Table -->
                        <div class="card card-table-border-none recent-orders" id="recent-orders">
                            <div class="card-header justify-content-between">
                                <h2 style="color: blueviolet">Lista de Mascotas</h2>
                            </div>
                            <div class="card-body pt-0 pb-5">
                                <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                                    <thead>
                                        <tr>
                                            <th><b>id Mascota</b></th>
                                            <th><b>Nombre</b></th>
                                            <th class="d-none d-lg-table-cell"><b>Especie</b></th>
                                            <th class="d-none d-lg-table-cell"><b>Raza</b></th>
                                            <th class="d-none d-lg-table-cell"><b>Edad</b></th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <asp:Repeater ID="RepeaterMascotas" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%# Eval("idMascota") %></td>
                                                    <td>
                                                        <%# Eval("Nombre") %>
                                                    </td>
                                                    <td class="d-none d-lg-table-cell"><%# Eval("NombreEspecie") %></td>
                                                    <td class="d-none d-lg-table-cell"><%# Eval("NombreRaza") %></td>
                                                    <td class="d-none d-lg-table-cell"><%# Eval("EdadMascota") %></td>
                                                    <td class="text-right">
                                                        <div class="dropdown show d-inline-block widget-dropdown">
                                                            <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                            <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                                <li class="dropdown-item">
                                                                    <asp:LinkButton Text="EDITAR" CssClass="fa fa-times fa-lg" runat="server"
                                                                        CommandArgument='<%# Eval("idMascota") %>' ID="btnEditarMascota" OnCommand="btnEditarMascota_Command" />
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row" id="divNuevaMascota" runat="server">
                    <div class="col-lg-12">
                        <div class="row">
                            <div class="col-lg-4">
                            </div>
                            <div class="col-lg-4">
                                <div class="form-footer pt-4 pt-5 mt-4 border-top">
                                    <asp:Button Text="Nueva Mascota" runat="server" OnClick="btnNuevoMascota_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                                </div>
                            </div>
                            <div class="col-lg-4">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- FORMULARIO DE ALTA CLIENTE -->
    <div class="row" id="DivAltaMascota" runat="server" visible="false">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Alta de la Mascota</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Dni titular(*)</label>
                                <input type="text" runat="server" id="txtDni" class="form-control" placeholder="Dni">
                                <asp:Button Text="BuscarCliente" runat="server" OnClick="btnBuscarCliente_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet; opacity: 0; line-height: 0px; border: none;" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Apellido(*)</label>
                                <input type="text" runat="server" id="txtApellido" class="form-control" placeholder="Apellido" disabled="true">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre(*)</label>
                                <input type="text" runat="server" id="Text1" class="form-control" placeholder="Nombre" disabled="true">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre de la Mascota(*)</label>
                                <input type="text" runat="server" id="txtNombreMascota" class="form-control" placeholder="Nombre de la Mascota" style='text-transform: uppercase'>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Especie de la Mascota(*)</label>
                                <asp:DropDownList class="form-control" ID="cmbAlta_Especie" AutoPostBack="true" runat="server" OnSelectedIndexChanged="cmbAlta_Especie_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Raza de la mascosta(*)</label>
                                <asp:DropDownList class="form-control" ID="cmbAlta_Raza" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Fecha de Nacimiento(*)</label>
                                <div class="input-group mb-2">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="mdi mdi-calendar-range"></i>
                                        </span>
                                    </div>
                                    <input type="date" class="form-control" runat="server" id="FechaNacimiento" placeholder="">
                                </div>
                                <p style="font-size: 90%">ex. 99/99/9999</p>
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
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
