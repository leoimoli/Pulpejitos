<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="StockWF.aspx.cs" Inherits="_StockWF" %>

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

    <!-- FORMULARIO DE ALTA PRODUCTOS -->
    <div class="row" id="DivAltaProducto" runat="server">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Alta de Producto:</h2>
                </div>

                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Código Producto(*)</label>
                                <input type="text" runat="server" id="txtCodigo" class="form-control" placeholder="Código Producto">
                                <%--<span class="mt-2 d-block">We'll never share your email with anyone else.</span>--%>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Categoria del Producto(*)</label>
                                <asp:DropDownList class="form-control" ID="cmbCategoria" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Descripción(*)</label>
                                <input type="text" runat="server" id="txtDescripción" class="form-control" placeholder="Descripción Producto" style='text-transform: uppercase'>
                                <%--<span class="mt-2 d-block">We'll never share your email with anyone else.</span>--%>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Marcas del Producto(*)</label>
                                <asp:DropDownList class="form-control" ID="cmbMarca" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Unidades de Medición(*)</label>
                                <asp:DropDownList class="form-control" ID="cmbUnidadesMedicion" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Precio de Venta(*)</label>
                                <input type="text" runat="server" id="txtPrecio" class="form-control" placeholder="Precio de venta" style='text-transform: uppercase'>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <asp:Button Text="Generar Código" runat="server" OnClick="btnGenerarCodigo_Click" CssClass="btn btn-secondary btn-default" Style="background-color: blueviolet" />
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
    <!-- FORMULARIO DE ALTA STOCKS -->
    <div class="row" id="DivAltaStock" runat="server" visible="false">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom">
                    <h2 style="color: blueviolet">Registrar Stock</h2>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Código Producto(*)</label>
                                <input type="text" runat="server" id="AltaStock_txtCodigoProducto" class="form-control" placeholder="Código Producto">
                                <asp:Button Text="Buscar" runat="server" OnClick="btnBuscarProducto_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet; opacity: 0; line-height: 0px; border: none;" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Producto(*)</label>
                                <input type="text" runat="server" id="AltaStock_txtDescripcion" class="form-control" placeholder="Producto">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Marca(*)</label>
                                <input type="text" runat="server" id="AltaStock_txtMarca" class="form-control" placeholder="Marca">
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Sucursal(*)</label>
                                <asp:DropDownList class="form-control" ID="AltaStock_cmbSucursal" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlSelect12" style="color: blueviolet">Proveedor</label>
                                <asp:DropDownList class="form-control" ID="AltaStock_cmbProveedor" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Fecha de Factura</label>
                                <div class="input-group mb-2">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="mdi mdi-calendar-range"></i>
                                        </span>
                                    </div>
                                    <input type="date" class="form-control" runat="server" id="AltaStock_FechaFactura" data-mask="00/00/0000" placeholder="">
                                </div>
                                <p style="font-size: 90%">ex. 99/99/9999</p>
                            </div>
                        </div>

                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Nro.Factura o Remito</label>
                                <input type="text" runat="server" id="AltaStock_Remito" class="form-control" placeholder="Nro.Factura o Remito">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Cantidad(*)</label>
                                <input type="text" runat="server" id="AltaStock_Cantidad" class="form-control" placeholder="Cantidad">
                            </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="form-group">
                                <label for="exampleFormControlInput1" style="color: blueviolet">Valor Unitario(*)</label>
                                <input type="text" runat="server" id="AltaStock_ValorUnitario" class="form-control" placeholder="Valor Unitario">
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4">
                            <div class="form-footer pt-4 pt-5 mt-4">
                                <asp:Button Text="Volver" runat="server" OnClick="btnVolver_Click" CssClass="btn btn-secondary btn-default" Style="background-color: blueviolet" />
                                <asp:Button Text="Cargar" runat="server" OnClick="btnCargar_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
    <!-- GRILLA DE CONSULTA PRODUCTOS -->
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
                                <th><b>id Producto</b></th>
                                <th><b>Descripción</b></th>
                                <th class="d-none d-lg-table-cell"><b>Código Producto</b></th>
                                <th class="d-none d-lg-table-cell"><b>Nombre Marca</b></th>
                                <th><b>Stock en Sucursal</b></th>
                                <th><b>Stock Total</b></th>
                                <th><b>Precio de Venta</b></th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterProductos" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idProducto") %></td>
                                        <td><%# Eval("Descripcion") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("CodigoProducto") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("NombreMarca") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("StockTotalPorSucursal") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("StockTotal") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("PrecioDeVenta") %></td>

                                        <td class="text-right">
                                            <div class="dropdown show d-inline-block widget-dropdown">
                                                <a class="dropdown-toggle icon-burger-mini" href="" role="button" id="dropdown-recent-order1" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false" data-display="static"></a>
                                                <ul class="dropdown-menu dropdown-menu-right" aria-labelledby="dropdown-recent-order1">
                                                    <li class="dropdown-item">
                                                        <asp:LinkButton Text="EDITAR" CssClass="fa fa-times fa-lg" runat="server"
                                                            CommandArgument='<%# Eval("idProducto") %>' ID="btnEditarProducto" OnCommand="btnEditarProducto_Command" />
                                                    </li>
                                                    <li class="dropdown-item">
                                                        <a href="#">ELIMINAR</a>
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
    <!-- GRILLA DE ALTA STOCKS -->
    <div class="row" id="DivGrillaCargaStock" runat="server" visible="false">
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
                                <th><b>id Producto</b></th>
                                <th><b>Descripción</th>
                                <th class="d-none d-lg-table-cell"><b>Código Producto</b></th>
                                <th class="d-none d-lg-table-cell"><b>Cantidad</b></th>
                                <th><b>Valor Unitario</b></th>
                                <th><b>Monto Total</b></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="RepeaterCargaStock" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("idProducto") %></td>
                                        <td>
                                            <%# Eval("Descripcion") %>
                                        </td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("CodigoProducto") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("Cantidad") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("ValorUnitario") %></td>
                                        <td class="d-none d-lg-table-cell"><%# Eval("MontoTotalPorProducto") %></td>
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
                <div class="card-header justify-content-end">
                    <h2 style="color: blueviolet">Total factura:
                        <asp:Label ID="lblTotalFactura" runat="server"> </asp:Label>
                    </h2>
                </div>
            </div>
            <div class="form-footer pt-4 pt-5 mt-4 border-top">
                <asp:Button Text="Guardar" runat="server" OnClick="btnGuardarStock_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
                <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelarStock_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet" />
            </div>
        </div>
    </div>

</asp:Content>
