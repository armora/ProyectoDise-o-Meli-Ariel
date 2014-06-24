<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Eventos.aspx.cs" Inherits="WebApplication2.WebForm5" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
        <div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Crear Evento</li>
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
                                    

                                        <asp:Panel ID="Panel1" runat="server"></asp:Panel>

	
        			    </div>
        			    </div><!-- End .col-md-9 -->        				
        	    </div><!-- End .col-md-12 -->
            </div><!-- End .row -->
	    </div><!-- End .container -->
       </form>
    </section><!-- End #content -->
</asp:Content>
