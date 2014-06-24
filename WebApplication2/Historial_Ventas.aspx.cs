using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;
using System.Drawing;

namespace WebApplication2
{
    public partial class Historial_Ventas : System.Web.UI.Page
    {
        TableCell columnaPromocion;
        TableCell columnaFecha;
        TableCell columnaCantidad;
        TableCell columnaPrecio;
        TableCell columnaUsuario;
        TableRow filaCompra;

        Label labelPromocion;
        Label labelFecha;
        Label labelCantidad;
        Label labelPrecio;
        Label labelUsuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            VariablesGlobales.TablaHistorial = new Table();
            cargar_historial();
            VariablesGlobales.TablaHistorial.Attributes["class"] = "col-md-12 table-responsive table cart-table";
            PanelHisorial.Controls.Add(VariablesGlobales.TablaHistorial);
        }

        protected void cargar_historial()
        {
            int indice = 1;
            float totalUsuario = 0;
            int total = 0;
            
            Administrador admin = VariablesGlobales.listaAdministradores.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado);
            RolUsuario rolAdmin = (RolUsuario)admin;
            List<HistorialComprasUsuario> hisoral = rolAdmin.VerificarHistorial(admin.getUsuario());

            for (int z = 0; z < VariablesGlobales.listaHistorial.Count; z++)
            {
                for (int i = 0; i < VariablesGlobales.listaHistorial[z].getListaCompras().Count; i++)
                {
                    for (int y = 0; y < VariablesGlobales.listaHistorial[z].getListaCompras()[i].getListaComprasPromociones().Count; y++)
                    {
                        if (y == 0 && i == 0 && z == 0)
                        {
                            crearFila("Cliente", "Promocion", "Fecha", "Cantidad de Entradas", "Precio");
                            formatoEncabezado();

                        }
                        crearFila(VariablesGlobales.listaHistorial[z].getListaCompras()[i].getUsuario().getNombre() + " " + VariablesGlobales.listaHistorial[z].getListaCompras()[i].getUsuario().getApellido(),
                        VariablesGlobales.listaHistorial[z].getListaCompras()[i].getListaComprasPromociones()[y].Item1.getNombre(),
                        (VariablesGlobales.listaHistorial[z].getListaCompras()[i].getListaComprasPromociones()[y].Item3).ToString(),
                        (VariablesGlobales.listaHistorial[z].getListaCompras()[i].getListaComprasPromociones()[y].Item2).ToString(),
                        (VariablesGlobales.listaHistorial[z].getListaCompras()[i].getListaComprasPromociones()[y].Item1.getPrecio()).ToString());

                        formatoTabla();

                        if ((indice % 2) != 0)
                        {
                            filaCompra.BackColor = Color.Honeydew;
                        }
                        indice++;

                    }

                    totalUsuario = totalUsuario + VariablesGlobales.listaHistorial[z].getListaCompras()[i].getTotal();
                }
                crearFila("Total Ventas de: " + VariablesGlobales.listaHistorial[z].getListaCompras()[0].getUsuario().getNombre() + " " + VariablesGlobales.listaHistorial[z].getListaCompras()[0].getUsuario().getApellido(),"","","", totalUsuario.ToString());
                formatoTotal();
                filaCompra.BackColor = Color.Silver;
                total = total + (int)totalUsuario;
                totalUsuario = 0;
            }
            crearFila("Total Ventas", "", "", "", total.ToString());
            formatoTotal();
            filaCompra.BackColor = Color.WhiteSmoke;

        }

        private void crearFila(String usuario, String promocion, String fecha, String cantidad, String precio)
        {
            columnaPromocion = new TableCell();
            columnaFecha = new TableCell();
            columnaCantidad = new TableCell();
            columnaPrecio = new TableCell();
            columnaUsuario = new TableCell();
            filaCompra = new TableRow();

            labelPromocion = new Label();
            labelFecha = new Label();
            labelCantidad = new Label();
            labelPrecio = new Label();
            labelUsuario = new Label();

            labelUsuario.Text = usuario;
            labelPromocion.Text = promocion;
            labelFecha.Text = fecha;
            labelCantidad.Text = cantidad;
            labelPrecio.Text = precio;

            columnaUsuario.Controls.Add(labelUsuario);
            columnaPromocion.Controls.Add(labelPromocion);
            columnaFecha.Controls.Add(labelFecha);
            columnaCantidad.Controls.Add(labelCantidad);
            columnaPrecio.Controls.Add(labelPrecio);

            filaCompra.Cells.Add(columnaUsuario);
            filaCompra.Cells.Add(columnaPromocion);
            filaCompra.Cells.Add(columnaFecha);
            filaCompra.Cells.Add(columnaCantidad);
            filaCompra.Cells.Add(columnaPrecio);


            VariablesGlobales.TablaHistorial.Rows.Add(filaCompra);

        }

        private void crearFila(String usuario, String precio)
        {
            columnaPromocion = new TableCell();
            columnaFecha = new TableCell();
            columnaCantidad = new TableCell();
            columnaPrecio = new TableCell();
            columnaUsuario = new TableCell();
            filaCompra = new TableRow();

            labelPromocion = new Label();
            labelFecha = new Label();
            labelCantidad = new Label();
            labelPrecio = new Label();
            labelUsuario = new Label();

            labelUsuario.Text = usuario;
            labelPrecio.Text = precio;

            columnaUsuario.Controls.Add(labelUsuario);
            columnaPrecio.Controls.Add(labelPrecio);

            filaCompra.Cells.Add(columnaUsuario);
            filaCompra.Cells.Add(columnaPrecio);


            VariablesGlobales.TablaHistorial.Rows.Add(filaCompra);

        }

        private void formatoEncabezado()
        {
            filaCompra.Attributes["class"] = "item-meta-container";
            columnaUsuario.Attributes["class"] = "table-title";
            columnaPromocion.Attributes["class"] = "table-title";
            columnaFecha.Attributes["class"] = "table-title";
            columnaCantidad.Attributes["class"] = "table-title";
            columnaPrecio.Attributes["class"] = "table-title";
        }


        private void formatoTotal()
        {
            filaCompra.Attributes["class"] = "item-meta-container";
            columnaUsuario.Attributes["class"] = "checkout_table-title";
            columnaPromocion.Attributes["class"] = "checkout_table-price";
        }

        private void formatoTabla()
        {
            filaCompra.Attributes["class"] = "item-meta-container";
            columnaUsuario.Attributes["class"] = "item-name";
            columnaPromocion.Attributes["class"] = "item-name";
            columnaFecha.Attributes["class"] = "item-name";
            columnaCantidad.Attributes["class"] = "item-name";
            columnaPrecio.Attributes["class"] = "item-name";

        }

    }
}