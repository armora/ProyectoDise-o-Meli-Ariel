<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="WebApplication2.WebForm3" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <section id="content">
        <div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Carrito</li>
					</ul>
        		</div>
        </div>
       <form id="fm_eventos" runat ="server"> 
        <div class="container">
            <div class="row">
        	    <div class="col-md-12">
        				
        		    <div class="row">
        				    <div class="md-margin"></div><!-- .space -->
        				    <div id="contenedor_eventos" class="category-item-container category-list-container">
                                    

                                        <asp:Panel ID="PanelCarrito" runat="server"></asp:Panel>

	
        			    </div>
                        <asp:Button ID="btnContinueShopping" runat ="server" Text="Continuar Comprando" CssClass="btn btn-custom-2 btn-lg md-margin" OnClick="btnContinueShopping_Click"/>
                        <asp:Button ID="btnEditar" runat ="server" Text="Editar Compra" CssClass="btn btn-custom-2 btn-lg md-margin" OnClick="btnEditar_Click"/>
                        <asp:Button ID="btnComprar" runat ="server" Text="Comprar" CssClass="btn btn-custom-2 btn-lg md-margin" OnClick="btnComprar_Click"/>
        			    </div><!-- End .col-md-9 -->        				
        	    </div><!-- End .col-md-12 -->
            </div><!-- End .row -->
	    </div><!-- End .container -->
       </form>
    </section><!-- End #content -->
</asp:Content>
