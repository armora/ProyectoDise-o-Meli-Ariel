<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cuenta.aspx.cs" Inherits="WebApplication2.Cuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Mi Cuenta</li>
					</ul>
        		</div>
        </div>
        <form id="frm_cuenta" runat="server">
           <div class="container">
        		    <div class="row">
        			    <div class="col-md-12">
						    <header class="content-title">
							    <h1 class="title">Mi Cuenta</h1>
						    </header>
        				    <div class="xs-margin"></div><!-- space -->
						    
        				    <div class="row">
        					
                                 <asp:Label id="LabelMsjUsuario" runat="server" class="input-text"></asp:Label>
								    <div class="col-md-6 col-sm-6 col-xs-12">
									
									    <fieldset>
									    <h2 class="sub-title">Información Personal</h2>
									    <div class="input-group">
										    <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Usuario&#42;</span></span>
                                            <asp:label id="input_usuario" runat="server"  CssClass="form-control input-lg"></asp:label>
									    </div><!-- End .input-group -->
                                        <div class="input-group">
										    <span class="input-group-addon"><span class="input-icon input-icon-user"></span><span class="input-text">Nombre&#42;</span></span>
										    <asp:Label id="input_nombre" runat="server" CssClass="form-control input-lg"></asp:Label>
									    </div><!-- End .input-group -->
									    <div class="input-group">
										    <span class="input-group-addon"><span class="input-icon input-icon-email"></span><span class="input-text">Correoelectrónico&#42;</span></span>
										    <asp:Label id="input_correo" runat="server" CssClass="form-control input-lg"></asp:Label>
									    </div><!-- End .input-group -->
									    <div class="input-group">
										    <span class="input-group-addon"><span class="input-icon input-icon-phone"></span><span class="input-text">Telefóno&#42;</span></span>
										    <asp:Label id="input_telefono" runat="server" CssClass="form-control input-lg"></asp:Label>
									    </div><!-- End .input-group -->
                                        </fieldset>
								    </div><!-- End .col-md-6 -->
        						
        						    <div class="col-md-6 col-sm-6 col-xs-12">
        						    <fieldset>
									    <h2 class="sub-title">Otros Datos</h2>
									    <div class="input-group">
										    <span class="input-group-addon"><span class="input-icon input-icon-address"></span><span class="input-text">Dirección&#42;</span></span>
										    <asp:Label id="input_direccion" runat="server"  CssClass="form-control input-lg" placeholder="Dirección"></asp:Label>
									    </div><!-- End .input-group -->
									    </fieldset>
        						    </div><!-- End .col-md-6 -->
        					
        				    </div><!-- End .row -->
                                <asp:Button ID ="btn_volver" runat ="server" CssClass="btn btn-custom-2 btn-lg md-margin" Text ="Ir a Inicio" OnClick="btn_volver_Click"/>
        			    </div><!-- End .col-md-12 -->
        		    </div><!-- End .row -->
			    </div><!-- End .container -->
           </form>
    </section><!-- End #content -->
</asp:Content>
