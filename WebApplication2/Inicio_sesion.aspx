<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inicio_sesion.aspx.cs" Inherits="WebApplication2.WebForm4" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
    <div class="panel-body">
			<div class="row">
			<div class="col-md-6 col-sm-6">					   		
				<h2 class="Comprar-title">Iniciar Sesión</h2>
				<p>If you have an account with us, please log in.</p>
				<div class="xs-margin"></div>
								   		
                <asp:Label ID="LabelMensajeLog" runat="server" class="input-text"></asp:Label>
				<div class="input-group">
					<span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Nombre de Usuario&#42;</span></span>
                    <asp:TextBox id="input_usuario" runat="server" CssClass="form-control input-lg" placeholder="Nombre de Usuario"></asp:TextBox>
				</div><!-- End .input-group -->
				<div class="input-group">
					<span class="input-group-addon"><span class="input-icon input-icon-password"></span><span class="input-text">Contraseña&#42;</span></span>
					<asp:TextBox id="input_contrasena" runat="server" CssClass="form-control input-lg" placeholder="Contraseña" type="password"></asp:TextBox>
				</div><!-- End .input-group -->
				<span class="help-block text-right"><a href="#">Forgot your password?</a></span>
				<div class="input-group custom-checkbox sm-margin top-10px">
						<input type="checkbox"> <span class="checbox-container">
						<i class="fa fa-check"></i>
						</span>
						Remember my password
										 
				</div><!-- End .input-group -->
			</div><!-- End .col-md-6 -->
								   	
			</div><!-- End.row -->
						   
			<asp:Button ID="Button1" runat="server" CssClass="btn btn-custom-2" OnClick="btn_iniciar_sesion" Text="Iniciar Sesión" />
			</div><!-- End .panel-body -->
    </form>
</asp:Content>
