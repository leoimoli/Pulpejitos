<%@ Page Title="VETERINARIA" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Formulario.aspx.cs" Inherits="_Formulario" %>

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
			<div class="card-header card-header-border-bottom">
				<h2>Basic Form Controls</h2>
			</div>

			<div class="card-body">
					<div class="form-group">
						<label for="exampleFormControlInput1">Email address</label>
						<input type="email" runat="server" id="Email_Texto" class="form-control" placeholder="Enter Email">
						<span class="mt-2 d-block">We'll never share your email with anyone else.</span>
					</div>

					<div class="form-group">
						<label for="exampleFormControlPassword">Password</label>
						<input type="password" runat="server" class="form-control" id="exampleFormControlPassword" placeholder="Password">
					</div>

					<div class="form-group">
						<label for="exampleFormControlSelect12">Example select</label>
						<select class="form-control" id="exampleFormControlSelect12">
							<option>1</option>
							<option>2</option>
							<option>3</option>
							<option>4</option>
							<option>5</option>
						</select>
					</div>

					<div class="form-group">
						<label for="exampleFormControlSelect2">Example multiple select</label>
						<select multiple class="form-control" id="exampleFormControlSelect2">
							<option>1</option>
							<option>2</option>
							<option>3</option>
							<option>4</option>
							<option>5</option>
						</select>
					</div>

					<div class="form-group">
						<label for="exampleFormControlTextarea1">Example textarea</label>
						<textarea class="form-control" id="exampleFormControlTextarea1" rows="3"></textarea>
					</div>

					<div class="form-group">
						<label for="exampleFormControlFile1">Example file input</label>
						<input type="file" class="form-control-file" id="exampleFormControlFile1">
					</div>

					<div class="form-footer pt-4 pt-5 mt-4 border-top">
<%--						<button type="submit" class="btn btn-primary btn-default">Submit</button>
						<button type="submit" class="btn btn-secondary btn-default">Cancel</button>--%>
						<asp:Button Text="Aceptar" runat="server" OnClick="btnAceptar_Click" CssClass="btn btn-primary btn-default" />
						<asp:Button Text="Cancelar" runat="server" OnClick="btnCancelar_Click" CssClass="btn btn-secondary btn-default" />
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
