<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Preferencia.aspx.cs" Inherits="WebApplication2.Agregar_Preferencia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
        	<div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Gestionar Preferencias</li>
					</ul>
        		</div>
        	</div>
        	<div class="container">
        		<div class="row">
        			<div class="col-md-12">
						<header class="content-title">
							<h1 class="title">Gestionar Preferencias</h1>
							
						</header>
        				<div class="xs-margin"></div><!-- space -->
						<form id="register_form" runat="server">
        				<div class="row">
        					
                             <asp:Label id="LabelMsjUsuario" runat="server" class="input-text"></asp:Label>
								<div class="col-md-6 col-sm-6 col-xs-12">
									
									<fieldset>
									<h2 class="sub-title">Información de categorías existentes</h2>
									
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Categoría&#42;</span></span>
										<asp:DropDownList id="ddl_categoria" runat="server" CssClass="form-control input-lg"></asp:DropDownList>
									</div><!-- End .input-group -->									
									
                                </fieldset>
        						<asp:Button ID="PrimerPaso" OnClick="boton_agregar_categorias" runat="server"  CssClass="btn btn-custom-2 btn-lg md-margin" Text="Agregar Preferencia" />
                                <asp:Button ID="Button1" OnClick="boton_eliminar_categorias" runat="server"  CssClass="btn btn-custom-2 btn-lg md-margin" Text="Eliminar Preferencia" />
                               </div><!-- End .col-md-6 -->
                            </div><!--End .col-md-6 -->
        				</form>
        			</div><!-- End .col-md-12 -->
        		</div><!-- End .row -->
			</div><!-- End .container -->
        
        </section><!-- End #content -->
</asp:Content>
