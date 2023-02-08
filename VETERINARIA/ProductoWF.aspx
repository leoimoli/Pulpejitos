<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="ProductoWF.aspx.cs" Inherits="_ProductoWF" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ========================================================================= -->
    <!-- INICIO DEL CONTENIDO DEL SITIO PARTICULAR - DEFAULT.ASPX -->
    <!-- ========================================================================= -->

    <!-- ========================================================================= -->
    <!-- FORMULARIO. -->
    <!-- ========================================================================= -->

    <div class="row">
        <div class="col-lg-12">

            <div class="card card-default">
                <div class="card-header card-header-border-bottom" >
                    <h2 style="color:blueviolet">Stock de Productos</h2>
                </div>

                <div class="card-body">
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color:blueviolet">Código Producto</label>
                        <input type="text" runat="server" id="txtCodigo" class="form-control" placeholder="Código Producto">
                        <%--<span class="mt-2 d-block">We'll never share your email with anyone else.</span>--%>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect12" style="color:blueviolet">Categoria del Producto</label>
                        <select class="form-control" id="cmbCategoria" runat="server">
                            <%-- <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>--%>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlInput1" style="color:blueviolet">Descripción</label>
                        <input type="text" runat="server" id="txtDescripción" class="form-control" placeholder="Descripción Producto">
                        <%--<span class="mt-2 d-block">We'll never share your email with anyone else.</span>--%>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect12" style="color:blueviolet">Marcas del Producto</label>
                        <select class="form-control" id="cmbMarca" runat="server">
                            <%--  <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>--%>
                        </select>
                    </div>
                    <div class="form-group">
                        <label for="exampleFormControlSelect12" style="color:blueviolet">Unidades de Medición</label>
                        <select class="form-control" id="cmbUnidadesMedicion" runat="server">
                            <%-- <option>1</option>
                            <option>2</option>
                            <option>3</option>
                            <option>4</option>
                            <option>5</option>--%>
                        </select>
                    </div>
                    <div class="form-footer pt-4 pt-5 mt-4 border-top">
                        <asp:Button Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-default" style="background-color:blueviolet" />
                        <asp:Button Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-default" style="background-color:blueviolet" />
                    </div>

                </div>
            </div>

        </div>
    </div>
    <!-- ========================================================================= -->

    <!-- ========================================================================= -->
    <!-- FIN DEL CONTENIDO DEL SITIO PARTICULAR - DEFAULT.ASPX -->
    <!-- ========================================================================= -->
</asp:Content>
