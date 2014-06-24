<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Categoria.aspx.cs" Inherits="WebApplication2.Agregar_Categoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
        	<div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Crear Categoría</li>
					</ul>
        		</div>
        	</div>
        	<div class="container">
        		<div class="row">
        			<div class="col-md-12">
						<header class="content-title">
							<h1 class="title">Crear Categoría</h1>
						</header>
        				<div class="xs-margin"></div><!-- space -->
						<form id="register_form" runat="server">
        				<div class="row">
        					
                             <asp:Label id="LabelMsjUsuario" runat="server" class="input-text"></asp:Label>
								<div class="col-md-6 col-sm-6 col-xs-12">
									
									<fieldset>
									<h2 class="sub-title">Información de Categoría</h2>
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Nombre de categoría&#42;</span></span>
                                        <asp:TextBox id="input_nombre" runat="server"  CssClass="form-control input-lg" placeholder="Nombre de categoría"></asp:TextBox>
									</div><!-- End .input-group -->
                                    <div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Descripción&#42;</span></span>
										<asp:TextBox id="input_descripcion" runat="server" CssClass="form-control input-lg" placeholder="Descripción"></asp:TextBox>
									</div><!-- End .input-group -->
                                </fieldset>
        						<asp:Button ID="PrimerPaso" OnClick="boton_agregar_categorias" runat="server"  CssClass="btn btn-custom-2 btn-lg md-margin" Text="Agregar Categoría" />
                               </div><!-- End .col-md-6 -->
                            </div><!--End .col-md-6 -->
        				</form>
        			</div><!-- End .col-md-12 -->
        		</div><!-- End .row -->
			</div><!-- End .container -->
        
        </section><!-- End #content -->
</asp:Content>
