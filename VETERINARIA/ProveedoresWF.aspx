<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProveedoresWF.aspx.cs" Inherits="ProveedoresWF" %>


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
    <div class="row" id="DivGrillaProveedores" runat="server">
        <div class="col-12">

            <!-- Recent Order Table -->
            <div class="card card-table-border-none recent-orders" id="recent-orders">
                <div class="card-header justify-content-between">
                    <h2 style="color: blueviolet">Lista de Proveedores</h2>
                </div>
                <div class="card-body pt-0 pb-5">
                    <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                        <thead>
                            <tr>
                                <th><b>id Proveedor</b></th>
                                <th><b>Razón Social</b></th>
                                <th class="d-none d-lg-table-cell"><b>Domicilio</b></th>
                                <th class="d-none d-lg-table-cell"><b>Teléfono</b></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterProveedores" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idProveedor") %></td>
                                        <td>
                                            <%# Eval("NombreEmpresa") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Domicilio") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Telefono") %></td>
                                        <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <asp:LinkButton Text="EDITAR" CssClass="fa fa-times fa-lg" runat="server"
                                                            CommandArgument='<%# Eval("idProveedor") %>' ID="btnEditarProveedor" OnCommand="btnEditarProveedor_Command" />
                                                    </li>
                                                    <%--   <li class="dropdown-item">
                                                        <a href="#">Eliminar</a>
                                                    </li>--%>
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
                <asp:Button Text="Nuevo Proveedor" runat="server" OnClick="btnNuevoProveedor_Click" CssClass="btn btn-primary btn-default"  />
            </div>
        </div>
    </div>
    <!-- FORMULARIO DE ALTA PROVEEDOR -->
    <div class="row" id="DivAltaProveedor" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Alta Proveedor</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Razón Social(*)</label>
                                <input type="text" runat="server" id="txtRazonSocial" class="form-control" placeholder="Razón Social" style='text-transform:uppercase'>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Persona de Contacto</label>
                                <input type="text" runat="server" id="txtContacto" class="form-control" placeholder="Persona de Contacto" style='text-transform:uppercase'>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nro.Teléfono </label>
                                <input type="text" runat="server" id="txtTelefono" class="form-control" placeholder="Teléfono" maxlength="10">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Email</label>
                                <input type="text" runat="server" id="txtEmail" class="form-control" placeholder="Email" style='text-transform:uppercase'>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Calle</label>
                                <input type="text" runat="server" id="txtCalle" class="form-control" placeholder="Calle" style='text-transform:uppercase'>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Altura</label>
                                <input type="text" runat="server" id="txtAltura" class="form-control" placeholder="Altura">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-footer pt-4 pt-5 mt-4">
                                <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-default"  />
                                <asp:Button Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-default"  />
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
