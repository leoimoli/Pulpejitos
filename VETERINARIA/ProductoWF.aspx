<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProductoWF.aspx.cs" Inherits="_ProductoWF" %>


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
            <div class="alert alert-dismissible fade show alert-primary" role="alert">
                <asp:Label ID="Label1" runat="server" Text="Error"></asp:Label>
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        </div>

    </div>
    <!-- GRILLA DE CONSULTA -->
    <div class="row" id="DivGrillaProductos" runat="server">
        <div class="col-12">

            <!-- Recent Order Table -->
            <div class="card card-table-border-none recent-orders" id="recent-orders">
                <div class="card-header justify-content-between">
                    <h2 style="color: blueviolet">Lista de Productos</h2>
                </div>
                <div class="card-body pt-0 pb-5">
                    <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                        <thead>
                            <tr>
                                <th>id Producto</th>
                                <th>Descripción</th>
                                <th class="d-none d-lg-table-cell">Código Producto</th>
                                <th class="d-none d-lg-table-cell">Nombre Marca</th>
                                <th>Stock</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterProductos" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idProducto") %></td>
                                        <td>
                                            <%# Eval("Descripcion") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("CodigoProducto") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("NombreMarca") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("StockTotal") %></td>
                                        <%--  <td>
                                            <span class="badge badge-success">Completed</span>
                                        </td>--%>
                                        <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <a href="#">Editar</a>
                                                    </li>
                                                    <li class="dropdown-item">
                                                        <a href="#">Eliminar</a>
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
                <asp:Button Text="Nuevo Producto" runat="server" OnClick="btnNuevoProducto_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                <asp:Button Text="Registrar Stock" runat="server" OnClick="btnRegistrarStock_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
            </div>
        </div>
    </div>
    <!-- FORMULARIO DE ALTA PRODUCTO -->
    <div class="row" id="DivAltaProducto" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Stock de Productos</h2>
                </div>

                <div class="card-body">
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Código Producto</label>
                        <input type="text" runat="server" id="txtCodigo" class="form-control" placeholder="Código Producto">
                        <%--<span class="mt-2 d-block">We'll never share your email with anyone else.</span>--%>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect12" style="color: blueviolet">Categoria del Producto</label>
                        <asp:DropDownList class="form-control" ID="cmbCategoria" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Descripción</label>
                        <input type="text" runat="server" id="txtDescripción" class="form-control" placeholder="Descripción Producto">
                        <%--<span class="mt-2 d-block">We'll never share your email with anyone else.</span>--%>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect12" style="color: blueviolet">Marcas del Producto</label>
                        <asp:DropDownList class="form-control" ID="cmbMarca" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect12" style="color: blueviolet">Unidades de Medición</label>
                        <asp:DropDownList class="form-control" ID="cmbUnidadesMedicion" runat="server">
                        </asp:DropDownList>
                    </div>
                    <div class="form-footer pt-4 pt-5 mt-4 border-top">
                        <asp:Button Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                        <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-default" Style="background-color: blueviolet" />
                    </div>

                </div>
            </div>

        </div>
    </div>

    <!-- FORMULARIO DE ALTA STOCK -->
    <div class="row" id="divAltaStock" runat="server" visible="false">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Registrar Stock</h2>
                </div>

                <div class="card-body">
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Código Producto</label>
                        <input type="text" runat="server" id="AltaStock_txtCodigoProducto" class="form-control" placeholder="Código Producto">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Producto</label>
                        <input type="text" runat="server" id="AltaStock_txtDescripcion" class="form-control" placeholder="Producto">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Marca</label>
                        <input type="text" runat="server" id="AltaStock_txtMarca" class="form-control" placeholder="Marca">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Proveedor</label>
                        <input type="text" runat="server" id="AltaStock_txtProveedor" class="form-control" placeholder="Proveedor">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Código Producto</label>
                        <input type="text" runat="server" id="AltaStock_FechaFactura" class="form-control" placeholder="Código Producto">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Nro.Factura o Remito</label>
                        <input type="text" runat="server" id="AltaStock_Remito" class="form-control" placeholder="Nro.Factura o Remito">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Cantidad</label>
                        <input type="text" runat="server" id="AltaStock_Cantidad" class="form-control" placeholder="Cantidad">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Valor Unitario</label>
                        <input type="text" runat="server" id="AltaStock_ValorUnitario" class="form-control" placeholder="Valor Unitario">
                    </div>
                    <div class="form-footer pt-4 pt-5 mt-4 border-top">
                        <asp:Button Text="Cargar" runat="server" OnClick="btnCargar_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                        <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-default" Style="background-color: blueviolet" />
                    </div>

                </div>
            </div>

        </div>
    </div>
    <!-- GRILLA DE ALTA DE STOCK -->
    <div class="row" id="Div1" runat="server">
        <div class="col-12">

            <!-- Recent Order Table -->
            <div class="card card-table-border-none recent-orders" id="recent-orders">
                <div class="card-header justify-content-between">
                    <h2 style="color: blueviolet">Lista de Productos</h2>
                </div>
                <div class="card-body pt-0 pb-5">
                    <table class="table card-table table-responsive table-responsive-large" style="width: 100%">
                        <thead>
                            <tr>
                                <th>id Producto</th>
                                <th>Descripción</th>
                                <th class="d-none d-lg-table-cell">Código Producto</th>
                                <th class="d-none d-lg-table-cell">Cantidad</th>
                                <th>Valor Unitario</th>
                                <th>Monto Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idProducto") %></td>
                                        <td>
                                            <%# Eval("Descripcion") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("CodigoProducto") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("CantidadStockDeCompra") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("ValorUnitarioDeCompra") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("MontoTotal") %></td>
                                        <%--  <td>
                                            <span class="badge badge-success">Completed</span>
                                        </td>--%>
                                        <%--  <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <a href="#">Editar</a>
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
            </div>
            <div class="form-footer pt-4 pt-5 mt-4 border-top">
                <asp:Button Text="Guardar" runat="server" OnClick="btnGuardarStock_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelarStock_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
            </div>
        </div>
    </div>

</asp:Content>
