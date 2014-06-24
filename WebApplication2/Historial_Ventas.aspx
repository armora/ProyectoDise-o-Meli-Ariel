<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Historial_Ventas.aspx.cs" Inherits="WebApplication2.Historial_Ventas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
        <div id="breadcrumb-container">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Historial de Ventas</li>
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
                                    

                                        <asp:Panel ID="PanelHisorial" runat="server"></asp:Panel>

	
        			    </div>
        			    </div><!-- End .col-md-9 -->        				
        	    </div><!-- End .col-md-12 -->
            </div><!-- End .row -->
	    </div><!-- End .container -->
       </form>
    </section><!-- End #content -->
</asp:Content>
