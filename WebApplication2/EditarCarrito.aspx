<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarCarrito.aspx.cs" Inherits="WebApplication2.EditarCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
        <div id="breadcrumb-container">
        	<div class="container">
				<ul class="breadcrumb">
					<li><a href="Default.aspx">Inicio</a></li>
					<li class="active">Crear Evento</li>
				</ul>
        	</div>
        </div>
        <div class="container">
        	<div class="row">
        		<div class="col-md-12">
					<header class="content-title">
						<h1 class="title">Crear Evento</h1>
					</header>
        			<div class="xs-margin"></div><!-- space -->
					<form id="register_form" runat="server">
        			<div class="row">
                        <asp:Label ID="MensajeHorarioAgregado" Text="" runat ="server" CssClass="form-control input-lg"></asp:Label>
        				<fieldset>	
                        <div class="col-md-6 col-sm-6 col-xs-12">
								<h2 class="sub-title">Horario del Evento</h2>
                                <div class="input-group">
									<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Nombre de promoción&#42;</span></span>
                                    <asp:DropDownlist id="ddl_car" runat="server"  CssClass="form-control input-lg"></asp:DropDownlist>
								</div><!-- End .input-group -->
								<div id="datetimepicker1" class="input-group">
									<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Cantidad nueva&#42;</span></span>
                                    <asp:TextBox id="input_cant" runat="server" CssClass="form-control input-lg" placeholder="Cantidad nueva" />
                                    <span class="add-on input-group-addon glyphicon glyphicon-calendar"></span>
								</div><!-- End .input-group -->
                            </div>
                            </fieldset>
        					<asp:Button ID="btn_cambiar_promocion" runat="server" CssClass="btn btn-custom-2 btn-lg md-margin" Text="Cambiar Promoción" OnClick="btn_cambiar_promocion_Click" />
                            <asp:Button ID="btn_eliminar_carrito" runat="server" CssClass="btn btn-custom-2 btn-lg md-margin" Text="Eliminar del Carrito" OnClick="btn_eliminar_carrito_Click"/>
                            </div><!-- End .col-md-6 -->
        			</form>
        		</div><!-- End .col-md-12 -->
        	</div><!-- End .row -->
		</div><!-- End .container -->
    </section><!-- End #content -->
</asp:Content>
