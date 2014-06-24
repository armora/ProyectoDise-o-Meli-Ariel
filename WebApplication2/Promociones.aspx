<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Promociones.aspx.cs" Inherits="WebApplication2.Promociones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript">
         function redir(sender) {
            var valor = window.event.srcElement.getAttribute("value2")
            var otro = document.getElementById(window.event.srcElement.getAttribute("id") + 1)
            var red = "http://localhost:4718/" + valor + "&cant=" + otro.value
            window.setTimeout(function () {
            window.location = red;}, 0);
         }
        
    </script>
        <section id="content">
        	<div id="category-breadcrumb">
        		<div class="container">
					<ul class="breadcrumb">
						<li><a href="Default.aspx">Inicio</a></li>
						<li class="active">Eventos</li>
                        <li class="active">Promociones</li>
					</ul>
        		</div>
        	</div>
            <form runat="server">
        	<div class="container">
        		<div class="row">
        			<div class="col-md-12">
        				
        				<div class="row">
        						<div class="md-margin"></div><!-- .space -->
        						<div id="contenedor_eventos" class="category-item-container category-list-container">

                                        <div>
                                           <asp:Panel ID="Panel1" runat="server"></asp:Panel>
                                        </div>
                                    
        						
        					</div>
        					</div><!-- End .col-md-9 -->        				
        			</div><!-- End .col-md-12 -->
        		</div><!-- End .row -->
			</div><!-- End .container -->
                </form>
        </section><!-- End #content -->
</asp:Content>
