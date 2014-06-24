<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="WebApplication2.WebForm2" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
        	<div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Register Account</li>
					</ul>
        		</div>
        	</div>
        	<div class="container">
        		<div class="row">
        			<div class="col-md-12">
						<header class="content-title">
							<h1 class="title">Registrar Cuenta</h1>
							<p class="title-desc">Si ya tiene una cuenta por favor inicie sesión <a href="Inicio_sesion.aspx">iniciar sesión</a>.</p>
						</header>
        				<div class="xs-margin"></div><!-- space -->
						<form id="register_form" runat="server">
        				<div class="row">
        					
                             <asp:Label id="LabelMsjUsuario" runat="server" class="input-text"></asp:Label>
								<div class="col-md-6 col-sm-6 col-xs-12">
									
									<fieldset>
									<h2 class="sub-title">Información Personal</h2>
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Usuario&#42;</span></span>
                                        <asp:TextBox id="input_usuario" runat="server"  CssClass="form-control input-lg" placeholder="Usuario"></asp:TextBox>
									</div><!-- End .input-group -->
                                    <div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Nombre&#42;</span></span>
										<asp:TextBox id="input_nombre" runat="server" CssClass="form-control input-lg" placeholder="Nombre"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Apellido&#42;</span></span>
										<asp:TextBox id="input_apellido" runat="server" CssClass="form-control input-lg" placeholder="Apellido"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-email"></span><span class="input-text">Correoelectrónico&#42;</span></span>
										<asp:TextBox id="input_correo" runat="server" CssClass="form-control input-lg" placeholder="Correo"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-phone"></span><span class="input-text">Telefóno&#42;</span></span>
										<asp:TextBox id="input_telefono" runat="server" CssClass="form-control input-lg" placeholder="Telefóno"></asp:TextBox>
									</div><!-- End .input-group -->
									<div id="datetimepicker1" class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Fecha Nacimiento&#42;</span></span>
                                        <asp:TextBox id="input_fecha_nacimiento" data-format="dd/MM/yyyy" runat="server" type="text"  CssClass="form-control input-lg" />
                                        <span class="add-on input-group-addon glyphicon glyphicon-calendar"></span>
									</div><!-- End .input-group -->
                                    <script type="text/javascript">
                                        $(function () {
                                            $('#datetimepicker1').datetimepicker();
                                        });
                                    </script>
									
									</fieldset>
									
									<fieldset>
									<h2 class="sub-title">Contraseña</h2>
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-password"></span><span class="input-text">Contraseña&#42;</span></span>
										<asp:TextBox id="input_contra" runat="server" CssClass="form-control input-lg" placeholder="Contraseña" type="password"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-password"></span><span class="input-text">Confirmar Contraseña&#42;</span></span>
										<asp:TextBox id="input_confir_contra" runat="server" CssClass="form-control input-lg" placeholder="Confirmar Contraseña" type="password"></asp:TextBox>
									</div><!-- End .input-group -->
									</fieldset>
									
									
								</div><!-- End .col-md-6 -->
        						
        						<div class="col-md-6 col-sm-6 col-xs-12">
        						<fieldset>
									<h2 class="sub-title">Otros Datos</h2>
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-address"></span><span class="input-text">Dirección&#42;</span></span>
										<asp:TextBox id="input_direccion" runat="server"  CssClass="form-control input-lg" placeholder="Dirección"></asp:TextBox>
									</div><!-- End .input-group -->
                                    <div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Género&#42;</span></span>
										<asp:TextBox id="input_genero" runat="server" CssClass="form-control input-lg" placeholder="Género"></asp:TextBox>
									</div><!-- End .input-group -->
									</fieldset>
        						</div><!-- End .col-md-6 -->
        					
        				</div><!-- End .row -->
						
						<div class="row">
							<div class="col-md-6 col-sm-6 col-xs-12">
																
								<asp:Button ID="Button" runat="server" OnClick="Insertar_Usuario" CssClass="btn btn-custom-2 btn-lg md-margin" Text="Registrarme" />

							</div><!-- End .col-md-6 -->
						</div><!-- End .row -->
        				</form>
        			</div><!-- End .col-md-12 -->
        		</div><!-- End .row -->
			</div><!-- End .container -->
        
        </section><!-- End #content -->
</asp:Content>
