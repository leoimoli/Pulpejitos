﻿<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="StockWF.aspx.cs" Inherits="_StockWF" %>


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
                        <asp:Button Text="Buscar" runat="server" OnClick="btnBuscarProducto_Click" CssClass="btn btn-primary btn-default" Style="background-color: blueviolet; opacity: 0; line-height: 0px; border: none;" />
                    </div>

                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Producto</label>
                        <input type="text" runat="server" id="AltaStock_txtDescripcion" class="form-control" placeholder="Producto">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Marca</label>
                        <input type="text" runat="server" id="AltaStock_txtMarca" class="form-control" placeholder="Marca" enableviewstate="false">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Proveedor</label>
                        <input type="text" runat="server" id="AltaStock_txtProveedor" class="form-control" placeholder="Proveedor" enableviewstate="false">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Fecha de Factura</label>
                        <div class="input-group mb-2">
                            <div class="input-group-prepend">
                                <span class="input-group-text">
                                    <i class="mdi mdi-calendar-range"></i>
                                </span>
                            </div>
                            <input type="date" class="form-control" runat="server" id="AltaStock_FechaFactura" data-mask="00/00/0000" placeholder="" enableviewstate="false">
                        </div>
                        <p style="font-size: 90%">ex. 99/99/9999</p>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Nro.Factura o Remito</label>
                        <input type="text" runat="server" id="AltaStock_Remito" class="form-control" placeholder="Nro.Factura o Remito" enableviewstate="false">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Cantidad</label>
                        <input type="text" runat="server" id="AltaStock_Cantidad" class="form-control" placeholder="Cantidad" enableviewstate="false">
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color: blueviolet">Valor Unitario</label>
                        <input type="text" runat="server" id="AltaStock_ValorUnitario" class="form-control" placeholder="Valor Unitario" enableviewstate="false">
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