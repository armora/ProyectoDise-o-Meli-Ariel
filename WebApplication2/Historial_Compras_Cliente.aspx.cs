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
    public partial class Historial_Compras_Cliente : System.Web.UI.Page
    {
        TableCell columnaPromocion;
        TableCell columnaFecha;
        TableCell columnaCantidad;
        TableCell columnaPrecio;
        TableCell columnaTotal = new TableCell();
        TableRow filaCompra = new TableRow();

        Label labelPromocion;
        Label labelFecha;
        Label labelCantidad;
        Label labelPrecio;
        Label labelTotal = new Label();
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_historial();
            VariablesGlobales.TablaHistorialUsuario.Attributes["class"] = "col-md-12 table-responsive table cart-table";
            PanelHisorialClientes.Controls.Add(VariablesGlobales.TablaHistorialUsuario);
        }

        protected void cargar_historial()
        {
            int indice = 1;
            String fecha = "";
            VariablesGlobales.TablaHistorialUsuario = new Table();

            Cliente cliente = VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado);
            RolUsuario rolCliente = (RolUsuario)cliente;
            List<HistorialComprasUsuario> listaHisoral = rolCliente.VerificarHistorial(cliente.getUsuario());
            
            if(listaHisoral.Count == 0)
            {
                labelTotal.Text = "No ha realizado ninguna compra";
                columnaTotal.Controls.Add(labelTotal);
                filaCompra.Cells.Add(columnaTotal);
                filaCompra.ForeColor = Color.Red;
                VariablesGlobales.TablaHistorialUsuario.Rows.Add(filaCompra);
            }
            else
            {
                HistorialComprasUsuario historial = listaHisoral[0];
                if (historial.getListaCompras().Count > 0)
                {
                    for (int i = 0; i < historial.getListaCompras().Count; i++)
                    {
                        for (int y = 0; y < historial.getListaCompras()[i].getListaComprasPromociones().Count; y++)
                        {
                            if (y == 0 && i == 0)
                            {
                                crearFila("Promocion", "Fecha", "Cantidad de Entradas", "Precio", "Total");
                                formatoEncabezado();

                            }
                            fecha = (historial.getListaCompras()[i].getListaComprasPromociones()[y].Item3).ToString();
                            crearFila(historial.getListaCompras()[i].getListaComprasPromociones()[y].Item1.getNombre(),
                                fecha,
                                (historial.getListaCompras()[i].getListaComprasPromociones()[y].Item2).ToString(),
                                (historial.getListaCompras()[i].getListaComprasPromociones()[y].Item1.getPrecio()).ToString(),
                                 ((historial.getListaCompras()[i].getListaComprasPromociones()[y].Item2) * (historial.getListaCompras()[i].getListaComprasPromociones()[y].Item1.getPrecio())).ToString());

                            formatoTabla();

                            if ((indice % 2) != 0)
                            {
                                filaCompra.BackColor = Color.Honeydew;
                            }
                            indice++;

                        }
                        crearFila(fecha, "", "", "", (historial.getListaCompras()[i].getTotal()).ToString());
                        filaCompra.BackColor = Color.Silver;
                        formatoTotal();
                    }


                }
                else
                {
                    labelTotal.Text = "No ha realizado ninguna compra";
                    columnaTotal.Controls.Add(labelTotal);
                    filaCompra.Cells.Add(columnaTotal);
                    VariablesGlobales.TablaHistorialUsuario.Rows.Add(filaCompra);
                }
            }
        }

        private void crearFila(String promocion, String fecha, String cantidad, String precio, String total)
        {
            columnaPromocion = new TableCell();
            columnaFecha = new TableCell();
            columnaCantidad = new TableCell();
            columnaPrecio = new TableCell();
            columnaTotal = new TableCell();
            filaCompra = new TableRow();

            labelPromocion = new Label();
            labelFecha = new Label();
            labelCantidad = new Label();
            labelPrecio = new Label();
            labelTotal = new Label();

            labelPromocion.Text = promocion;
            labelFecha.Text = fecha;
            labelCantidad.Text = cantidad;
            labelPrecio.Text = precio;
            labelTotal.Text = total;

            columnaPromocion.Controls.Add(labelPromocion);
            columnaFecha.Controls.Add(labelFecha);
            columnaCantidad.Controls.Add(labelCantidad);
            columnaPrecio.Controls.Add(labelPrecio);
            columnaTotal.Controls.Add(labelTotal);

            filaCompra.Cells.Add(columnaPromocion);
            filaCompra.Cells.Add(columnaFecha);
            filaCompra.Cells.Add(columnaCantidad);
            filaCompra.Cells.Add(columnaPrecio);
            filaCompra.Cells.Add(columnaTotal);

            VariablesGlobales.TablaHistorialUsuario.Rows.Add(filaCompra);

        }

        private void formatoEncabezado()
        {
            filaCompra.Attributes["class"] = "item-meta-container";
            columnaPromocion.Attributes["class"] = "table-title";
            columnaFecha.Attributes["class"] = "table-title";
            columnaCantidad.Attributes["class"] = "table-title";
            columnaPrecio.Attributes["class"] = "table-title";
        }


        private void formatoTotal()
        {
            filaCompra.Attributes["class"] = "item-meta-container";
            columnaTotal.Attributes["class"] = "checkout_table-title";
            columnaPromocion.Attributes["class"] = "checkout_table-price";
        }

        private void formatoTabla()
        {
            filaCompra.Attributes["class"] = "item-meta-container";
            columnaPromocion.Attributes["class"] = "item-name";
            columnaFecha.Attributes["class"] = "item-name";
            columnaCantidad.Attributes["class"] = "item-name";
            columnaPrecio.Attributes["class"] = "item-name";

        }
    }
}