<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="VentasWF.aspx.cs" Inherits="VentasWF" %>

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
    <div class="row" id="DivFiltros" runat="server">
        <div class="col-lg-12">
            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Registro de Ventas</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Cantidad</label>
                                <input type="text" runat="server" id="txtCantidad" class="form-control" value="1">
                            </div>
                        </div>
                        <div class="col-lg-8">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Producto</label>
                                <input type="text" runat="server" id="txtProducto" class="form-control" placeholder="">
                                <asp:Button Text="BuscarProducto" runat="server" OnClick="btnBuscarProducto_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet; opacity: 0; line-height: 0px; border: none;" />
                            </div>
                        </div>
                    </div>
                    <!-- BOTONES -->
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-footer pt-4 pt-5 mt-4">
                                <asp:Button Text="Cobrar" runat="server" ID="btnCobrar" OnClick="btnCobrar_Click" CssClass="btn btn-primary btn-default" />
                                <asp:Button Text="Limpiar" runat="server" ID="btnLimpiar" OnClick="btnLimpiar_Click" CssClass="btn btn-primary btn-default" Visible="false" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- GRILLA DE CONSULTA -->
    <div class="row" id="DivVentas" runat="server">
        <div class="col-12">

            <!-- Recent Order Table -->
            <div class="card card-table-border-none recent-orders" id="recent-orders">
                <%-- <div class="card-header justify-content-between">
                                <h2 style="color: blueviolet">Registro de Ventas</h2>
                            </div>--%>
                <div class="card-body pt-0 pb-5">
                    <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                        <thead>
                            <tr>
                                <th><b>Código Producto</b></th>
                                <th><b>Descripción</b></th>
                                <th class="d-none d-lg-table-cell"><b>Cantidad</b></th>
                                <th class="d-none d-lg-table-cell"><b>Valor de Venta</b></th>
                                <th class="d-none d-lg-table-cell"><b>Total</b></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterVentas" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("CodigoProducto") %></td>
                                        <td>
                                            <%# Eval("Descripcion") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("CantidadVenta") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("PrecioVenta") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("MontoTotalPorProducto") %></td>
                                        <%-- <td class="text-right">
                                                        <div class="dropdown show d-inline-block widget-dropdown">
                                                            <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                            <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                                <li class="dropdown-item">
                                                                    <asp:LinkButton Text="EDITAR" CssClass="fa fa-times fa-lg" runat="server"
                                                                        CommandArgument='<%# Eval("idMascota") %>' ID="btnEditarMascota" OnCommand="btnEditarMascota_Command" />
                                                                </li>
                                                            </ul>
                                                        </div>
                                                    </td>--%>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
                <div class="card-header justify-content-end">
                    <h2 style="color: blueviolet">Total a pagar:
                        <asp:Label ID="lblTotalFactura" runat="server"> </asp:Label>
                    </h2>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
