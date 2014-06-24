using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;
using System.Drawing;
using WebApplication2.bd;

namespace WebApplication2
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        TableCell columnaNombrePromocion;
        TableCell columnaCategoria;
        TableCell columnaFecha;
        TableCell columnaCantidad;
        TableCell columnaPrecio;
        TableCell columnaSubTotal;
        TableRow filaCarrito;

        Label labelNombrePromocion;
        Label labelCategoria;
        Label labelFecha;
        Label labelCantidad;
        Label labelPrecio;
        Label labelSubTotal;

        Label labelMensaje;
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_Carrito();
            VariablesGlobales.TablaCarrito.Attributes["class"] = "col-md-12 table-responsive table cart-table";
            PanelCarrito.Controls.Add(VariablesGlobales.TablaCarrito);
        }

        protected void cargar_Carrito()
        {
            int indice = 1;
            float totalUsuario = 0;

           VariablesGlobales.TablaCarrito = new Table();

            for (int z = 0; z < VariablesGlobales.listaCliente.Count; z++)
            {
                if (VariablesGlobales.listaCliente[z].getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado)
                {
                    if (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito().Count > 0)
                    {
                        for (int i = 0; i < VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito().Count; i++)
                        {
                            if (i == 0 && z == 0)
                            {
                                crearFila("Nombre", "Categoría", "Fecha", "Cantidad de Entradas", "Precio", "total");
                                formatoEncabezado();

                            }
                            crearFila(VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getNombre(),
                            VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getCategoria(),
                            (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getHorario()).ToString(),
                            (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getCantidad()).ToString(),
                            (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getPrecio()).ToString(),
                            ((VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getCantidad() * (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getPrecio())).ToString()));

                            formatoTabla();

                            if ((indice % 2) != 0)
                            {
                                filaCarrito.BackColor = Color.Honeydew;
                            }
                            indice++;
                            totalUsuario = totalUsuario + (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getCantidad() * (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getPrecio()));

                        }

                        crearFila("Total: ", "", "", "", "", totalUsuario.ToString());
                        formatoTotal();
                        filaCarrito.BackColor = Color.Silver;
                        break;
                    
                    }
                    else
                    {
                        labelMensaje = new Label();
                        labelMensaje.Text = "No tiene ninguna promoción agregada a carrito, visite la sección de Eventos";
                        labelMensaje.BackColor = Color.Maroon;
                        PanelCarrito.Controls.Add(labelMensaje);
                    }
                        
                }
            }
                    
        }

        private void crearFila(String nombrePromocion, String categoria, String fecha, String cantidad, String precio, String subTotal)
        {
            columnaNombrePromocion = new TableCell();
            columnaCategoria = new TableCell();
            columnaFecha = new TableCell();
            columnaCantidad = new TableCell();
            columnaPrecio = new TableCell();
            columnaSubTotal = new TableCell();
            filaCarrito = new TableRow();

            labelNombrePromocion = new Label();
            labelCategoria = new Label();
            labelFecha = new Label();
            labelCantidad = new Label();
            labelPrecio = new Label();
            labelSubTotal = new Label();
        

            labelNombrePromocion.Text = nombrePromocion;
            labelCategoria.Text = categoria;
            labelFecha.Text = fecha;
            labelCantidad.Text = cantidad;
            labelPrecio.Text = precio;
            labelSubTotal.Text = subTotal;

            columnaNombrePromocion.Controls.Add(labelNombrePromocion);
            columnaCategoria.Controls.Add(labelCategoria);
            columnaFecha.Controls.Add(labelFecha);
            columnaCantidad.Controls.Add(labelCantidad);
            columnaPrecio.Controls.Add(labelPrecio);
            columnaSubTotal.Controls.Add(labelSubTotal);

            filaCarrito.Cells.Add(columnaNombrePromocion);
            filaCarrito.Cells.Add(columnaCategoria);
            filaCarrito.Cells.Add(columnaFecha);
            filaCarrito.Cells.Add(columnaCantidad);
            filaCarrito.Cells.Add(columnaPrecio);
            filaCarrito.Cells.Add(columnaSubTotal);


            VariablesGlobales.TablaCarrito.Rows.Add(filaCarrito);

        }
        private void formatoEncabezado()
        {
            filaCarrito.Attributes["class"] = "item-meta-container";
            columnaNombrePromocion.Attributes["class"] = "table-title";
            columnaCategoria.Attributes["class"] = "table-title";
            columnaFecha.Attributes["class"] = "table-title";
            columnaCantidad.Attributes["class"] = "table-title";
            columnaPrecio.Attributes["class"] = "table-title";
            columnaSubTotal.Attributes["class"] = "table-title";
        }


        private void formatoTotal()
        {
            filaCarrito.Attributes["class"] = "item-meta-container";
            columnaNombrePromocion.Attributes["class"] = "checkout_table-title";
            columnaSubTotal.Attributes["class"] = "checkout_table-price";
        }

        private void formatoTabla()
        {
            filaCarrito.Attributes["class"] = "item-meta-container";
            columnaNombrePromocion.Attributes["class"] = "item-name";
            columnaCategoria.Attributes["class"] = "item-name";
            columnaFecha.Attributes["class"] = "item-name";
            columnaCantidad.Attributes["class"] = "item-name";
            columnaPrecio.Attributes["class"] = "item-name";
            columnaSubTotal.Attributes["class"] = "item-name";

        }

        protected void btnContinueShopping_Click(object sender, EventArgs e)
        {
            Response.Redirect("Eventos.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarCarrito.aspx");
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            Compra nuevaCompra = VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).realizarCompra();
            Inserts insertar = new Inserts();
            insertar.insertar_compra(nuevaCompra);
            VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).getCarrito().vaciarCarrito();
            Response.Redirect("Default.aspx");
            
        }

    }
}