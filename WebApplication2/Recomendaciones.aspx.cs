using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;

namespace WebApplication2
{
    public partial class Recomendaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar_tabla();
            VariablesGlobales.TablaRecomendaciones.Attributes["class"] = "col-md-12 table-responsive table cart-table";
            PanelRecomendaciones.Controls.Add(VariablesGlobales.TablaRecomendaciones);
        }

        private void llenar_tabla()
        {
            VariablesGlobales.TablaRecomendaciones = new Table();
            Cliente cliente = VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado);

            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                if ((cliente.getListaRecomendaciones().Find(x => x == VariablesGlobales.listaEventos[i].getCodigo())) == VariablesGlobales.listaEventos[i].getCodigo())
                {
                    EventoSoloLectura eventoSoloLectura = (EventoSoloLectura)VariablesGlobales.listaEventos[i];

                    TableCell columnaImagen = new TableCell();
                    TableCell columnaNombre = new TableCell();
                    TableCell columnaBotonAgregar = new TableCell();
                    TableRow nuevoEvento = new TableRow();

                    Image myImage = new Image();
                    myImage.ImageUrl = eventoSoloLectura.getFoto();
                    myImage.Attributes["class"] = "item-image";

                    Button myButton = new Button();
                    myButton.PostBackUrl = "Promociones.aspx?key=" + eventoSoloLectura.getCodigo();
                    //myButton.CommandName = VariablesGlobales.listaEventos[i].getCodigo();
                    myButton.CssClass = "item-add-btn icon-cart-text";
                    //myButton.Attributes.Add("OnClick","ver_promocion");
                    //myButton.OnClientClick = "ver_pro()";
                    //myButton.Click += ver_pro;
                    //myButton.OnClientClick = "ver_pro";
                    myButton.Text = "Ver Promociones";



                    Label label = new Label();
                    label.Text = eventoSoloLectura.getNombre();

                    nuevoEvento.Attributes["class"] = "item-meta-container";
                    columnaImagen.Attributes["class"] = "item-name";
                    columnaNombre.Attributes["class"] = "item-name";
                    columnaBotonAgregar.Attributes["class"] = "item-name";
                    columnaImagen.Controls.Add(myImage);
                    columnaNombre.Controls.Add(label);
                    columnaBotonAgregar.Controls.Add(myButton);
                    nuevoEvento.Attributes["id"] = eventoSoloLectura.getCodigo();
                    nuevoEvento.Cells.Add(columnaImagen);
                    nuevoEvento.Cells.Add(columnaNombre);
                    nuevoEvento.Cells.Add(columnaBotonAgregar);
                    VariablesGlobales.TablaRecomendaciones.Rows.Add(nuevoEvento);
                }   
            }
        }
    }
}