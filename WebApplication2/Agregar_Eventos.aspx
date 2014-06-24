<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Agregar_Eventos.aspx.cs" Inherits="WebApplication2.WebForm6" %>
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
        					
                             <asp:Label id="LabelMsjUsuario" runat="server" class="input-text"></asp:Label>
								<div class="col-md-6 col-sm-6 col-xs-12">
									
									<fieldset>
									<h2 class="sub-title">Información Personal</h2>
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Código de Evento&#42;</span></span>
                                        <asp:TextBox id="input_codigo" runat="server"  CssClass="form-control input-lg" placeholder="Código de Evento"></asp:TextBox>
									</div><!-- End .input-group -->
                                    <div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Nombre&#42;</span></span>
										<asp:TextBox id="input_nombre" runat="server" CssClass="form-control input-lg" placeholder="Nombre"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Lugar&#42;</span></span>
										<asp:TextBox id="input_lugar" runat="server" CssClass="form-control input-lg" placeholder="Lugar"></asp:TextBox>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Categoría&#42;</span></span>
										<asp:DropDownList id="ddl_categoria" runat="server" CssClass="form-control input-lg"></asp:DropDownList>
									</div><!-- End .input-group -->
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil input-append"></span><span class="input-text">Foto&#42;</span></span>
                                        <asp:TextBox id="pdffile" type="file"  runat="server" CssClass="form-control input-lg" placeholder="Foto"></asp:TextBox>
                                    </div><!-- End .input-group -->
                                    <div id="datetimepicker1" class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Fecha&#42;</span></span>
                                        <input id="input_fecha" runat="server" type="text" data-format="dd/MM/yyyy" class="form-control input-lg" />
                                        <span class="add-on input-group-addon glyphicon glyphicon-calendar"></span>
									</div><!-- End .input-group -->
                                    <script type="text/javascript">
                                        $(function () {
                                            $('#datetimepicker1').datetimepicker();
                                        });
                                    </script>
                                    <div id="datetimepicker4" class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Hora de inicio&#42;</span></span>
										<input id="input_hora_inicio" data-format="hh:mm" runat="server" class="form-control input-lg">
                                        <span class="add-on input-group-addon glyphicon glyphicon-time"></span>
									</div><!-- End .input-group -->
                                    <script type="text/javascript">
                                        $(function () {
                                            $('#datetimepicker4').datetimepicker({
                                                pickDate: false
                                            });
                                        });
                                    </script>
									<div class="input-group">
										<span class="input-group-addon"><span class="input-icon input-icon-pencil"></span><span class="input-text">Descripción</span></span>
										<asp:TextBox id="input_descripcion" runat="server" CssClass="form-control input-lg" placeholder="Descripción"></asp:TextBox>
									</div><!-- End .input-group -->
                                </fieldset>
        						<asp:Button ID="PrimerPaso" OnClick="boton_agregar_categorias" runat="server"  CssClass="btn btn-custom-2 btn-lg md-margin" Text="Agregar Evento" />
                               </div><!-- End .col-md-6 -->
                            </div><!--End .col-md-6 -->
        				</form>
        			</div><!-- End .col-md-12 -->
        		</div><!-- End .row -->
			</div><!-- End .container -->
        
        </section><!-- End #content -->
</asp:Content>
