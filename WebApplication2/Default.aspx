<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication2.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section id="content">
       	<div id="slider-sequence" class="homeslider">
        		<div class="sequence-prev"></div><!-- End sequence-prev-->
        		<div class="sequence-next"></div><!-- End sequence-next-->
        		<ul class="sequence-canvas">
        			<li class="sequence-slide1">
        				<div class="sequencebg">
        					<img src="images/homeslider/aerosmith4.png" alt="Slide 1 image" class="sequencebg-image">
        				</div><!-- End .sequencebg -->
        				<div class="sequence-container container">
        				</div><!-- End .sequence-container -->
        			</li>
        			
        			<li class="sequence-slide2">
        				<div class="sequencebg">
        					<img src="images/homeslider/playa3.png" alt="Slide 2 image" class="sequencebg-image">
        				</div><!-- End .sequencebg -->
        				<div class="sequence-container container">
        					<img src="images/homeslider/slide2_2.png" alt="Model 2" class="sequence-model">
        				</div><!-- End .sequence-container -->
        			</li>
        			
        		</ul>
        		
					<ul class="sequence-pagination">
						<li>Frame 1</li>
						<li>Frame 2</li>
					</ul>
        	</div><!-- End #slider-sequence -->
        </section><!-- End #content -->
  </asp:Content>