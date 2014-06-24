<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Promociones.aspx.cs" Inherits="WebApplication2.AgregarPromociones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <section id="content">
        	<div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Crear Promoción</li>
					</ul>
        		</div>
        	</div>
        	<div class="container">
        		<div class="row">
        			<div class="col-md-12">
						<header class="content-title">
							<h1 class="title">Crear Promoción</h1>
						</header>
        				<div class="xs-margin"></div><!-- space -->
						<form id="register_form" runat="server">
        				<div class="row">
        					
                             <asp:Label id="LabelMsjUsuario" runat="server" class="input-text"></asp:Label>
								<div class="col-md-6 col-sm-6 col-xs-12">
									
									<fieldset>
									<h2 class="sub-title">Información de la Promoción</h2>
                                    <div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Evento&#42;</span></span>
                                        <asp:DropDownlist id="ddl_evento" runat="server"  CssClass="form-control input-lg"></asp:DropDownlist>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Nombre&#42;</span></span>
                                        <asp:TextBox id="input_nombre" runat="server"  CssClass="form-control input-lg" placeholder="Nombre"></asp:TextBox>
									</div><!-- End .input-group -->
                                    <div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Categoría&#42;</span></span>
										<asp:TextBox id="input_categoria" runat="server" CssClass="form-control input-lg" placeholder="Categoría"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Entradas Disponibles&#42;</span></span>
										<asp:TextBox id="input_cantEntradasDisponibles" runat="server" CssClass="form-control input-lg" placeholder="Cantidad de Entradas Disponibles"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Descripción&#42;</span></span>
										<asp:TextBox id="input_descripcion" runat="server" CssClass="form-control input-lg" placeholder="Descripción de la promoción"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Precio&#42;</span></span>
										<asp:TextBox id="input_precio" runat="server" CssClass="form-control input-lg" placeholder="Precio"></asp:TextBox>
									</div><!-- End .input-group -->
                                </fieldset>
        						<asp:Button ID="Boton_Agregar_Promocion" OnClick="insertar_promocion" runat="server"  CssClass="btn btn-custom-2 btn-lg md-margin" Text="Agregar Promoción"></asp:Button>
                                </div><!-- End .col-md-6 -->
                            </div><!--End .col-md-6 -->
        				</form>
        			</div><!-- End .col-md-12 -->
        		</div><!-- End .row -->
			</div><!-- End .container -->
        
        </section><!-- End #content -->
</asp:Content>
