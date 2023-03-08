<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Configuracion_MarcasWF.aspx.cs" Inherits="Configuracion_MarcasWF" %>

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
    <div class="row" id="DivGrillaMarcas" runat="server">
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
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre Marca</label>
                                <input type="text" runat="server" id="txtBuscarMarca" class="form-control" placeholder="Nombre de la Marca">
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
                                <th><b>id Marca</b></th>
                                <th><b>Nombre MArca</b></th>
                                <th class="d-none d-lg-table-cell"><b>Fecha Alta</b></th>
                                <th class="d-none d-lg-table-cell"><b>Usuario</b></th>
                                <th class="d-none d-lg-table-cell"><b>Estado</b></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterMarcas" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idMarca") %></td>
                                        <td>
                                            <%# Eval("Nombre") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("FechaAlta") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("UsuarioApellidoNombre") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Estado") %></td>
                                        <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <asp:LinkButton Text="ELIMINAR" CssClass="fa fa-times fa-lg" runat="server"
                                                            CommandArgument='<%# Eval("idMarca") %>' ID="btnEliminarMarca" OnCommand="btnEliminarMarca_Command" />
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
                        <asp:Button Text="Nueva Marca" runat="server" OnClick="btnNuevaMarca_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- FORMULARIO DE ALTA MARCA -->
    <div class="row" id="DivAltaMarca" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">
                <div id="divAltaMarcaEncabezado" style="color: blueviolet" runat="server" class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Alta Marca</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre Marca(*)</label>
                                <input type="text" runat="server" id="txtNombreMarca" class="form-control" placeholder="Nombre Marca">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
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
