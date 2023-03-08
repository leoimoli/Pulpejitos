<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="UsuariosWF.aspx.cs" Inherits="UsuariosWF" %>

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

    <!-- GRILLA DE CONSULTA USUARIOS -->
    <div class="row" id="DivGrillaUsuarios" runat="server">
        <div class="col-12">

            <!-- Recent Order Table -->
            <div class="card card-table-border-none recent-orders" id="recent-orders">
                <div class="card-header justify-content-between">
                    <h2 style="color: blueviolet">Lista de Usuarios</h2>
                </div>
                <div class="card-body pt-0 pb-5">
                    <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                        <thead>
                            <tr>
                                <th><b>Dni</b></th>
                                <th class="d-none d-lg-table-cell"><b>Apellido y Nombre</b></th>
                                <th class="d-none d-lg-table-cell"><b>Estado</b></th>
                                <th class="d-none d-lg-table-cell"><b>Perfil</b></th>
                                <th class="d-none d-lg-table-cell"><b>Última Conexión</b></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterUsuarios" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Dni") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("ApellidoNombre") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Estado") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("NombrePerfil") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("FechaUltimaConexion") %></td>
                                        <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <asp:LinkButton Text="EDITAR" CssClass="fa fa-times fa-lg" runat="server"
                                                            CommandArgument='<%# Eval("idUsuario") %>' ID="btnEditarCliente" OnCommand="btnEditarCliente_Command" />
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
            <div class="form-footer pt-4 pt-5 mt-4 border-top">
                <asp:Button Text="Nuevo Usuario" runat="server" OnClick="btnNuevoUsuario_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
            </div>
        </div>
    </div>

    <!-- FORMULARIO DE ALTA DE USUARIOS -->
    <div class="row" id="DivAltaUsuario" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">

                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Alta Cliente</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Dni(*)</label>
                                <input type="text" runat="server" id="txtDni" class="form-control" placeholder="Dni">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Apellido(*)</label>
                                <input type="text" runat="server" id="txtApellido" class="form-control" placeholder="Apellido" style='text-transform: uppercase'>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nombre(*)</label>
                                <input type="text" runat="server" id="txtNombre" class="form-control" placeholder="Nombre" style='text-transform: uppercase'>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Contraseña(*)</label>
                                <input type="password" runat="server" id="txtContraseña" class="form-control" placeholder="Teléfono" maxlength="10">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Perfil</label>
                                <asp:DropDownList class="form-control" ID="cmbPerfil" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Estado</label>
                                <asp:DropDownList class="form-control" ID="cmbEstado" runat="server">
                                </asp:DropDownList>
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
