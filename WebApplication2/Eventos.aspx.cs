using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using WebApplication2.clases;

namespace WebApplication2
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        TableCell columnaImagen = new TableCell();
        TableCell columanNombre = new TableCell();
        TableCell clumnaBotonAgregar = new TableCell();
        TableCell columnaFecha;
        TableCell columnaHora;
        TableCell columnaLugar;

        TableRow nuevoEvento = new TableRow();

        Image myImage = new Image();
        Button  myButton = new Button();
        Label label = new Label();
        Label labelFecha;
        Label labelHora;
        Label labelLugar;
        protected void Page_Load(object sender, EventArgs e)
        {
            llenar_tabla();
            VariablesGlobales.TablaEventos.Attributes["class"] = "col-md-12 table-responsive table cart-table";
            Panel1.Controls.Add(VariablesGlobales.TablaEventos);
            if ((Request.QueryString["key2"]) != null)
            {
                agregarCarrito(Convert.ToString(Request.QueryString["key"]), Convert.ToString(Request.QueryString["key2"]), int.Parse(Request.QueryString["cant"]));
            }
            
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label1.Text = "Clicked at " + DateTime.Now.ToString();
        }
        private void llenar_tabla()
        {
            VariablesGlobales.TablaEventos = new Table();
            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                EventoSoloLectura eventoSoloLectura = (EventoSoloLectura)VariablesGlobales.listaEventos[i];
                crearFila(eventoSoloLectura.getFoto(), "Promociones.aspx?key=" + eventoSoloLectura.getCodigo(), eventoSoloLectura.getNombre(), (eventoSoloLectura.getFecha()).ToString(), (eventoSoloLectura.getHoraInicio()).ToString(), (eventoSoloLectura.getLugar().ToString()));
                formatoTabla();
            }
        }

        private void crearFila(String foto, String codigo, String nombre, String fecha, String hora, String lugar)
        {
            columnaImagen = new TableCell();
            columanNombre = new TableCell();
            clumnaBotonAgregar = new TableCell();
            columnaFecha = new TableCell();
            columnaHora = new TableCell();
            columnaLugar = new TableCell();
            nuevoEvento = new TableRow();

            myImage = new Image();
            myImage.ImageUrl = foto;
            myImage.Attributes["class"] = "item-image";

            myButton = new Button();
            myButton.PostBackUrl = codigo;
            myButton.CssClass = "btn btn-custom-2 btn-lg md-margin";
            myButton.Text = "Ver Promociones";
            
            label = new Label();
            label.Text = nombre;

            labelFecha = new Label();
            labelFecha.Text = fecha;

            labelHora = new Label();
            labelHora.Text = hora;

            labelLugar = new Label();
            labelLugar.Text = lugar;

            nuevoEvento.Attributes["class"] = "item-meta-container";
            columnaImagen.Attributes["class"] = "item-name";
            columanNombre.Attributes["class"] = "item-name";
            clumnaBotonAgregar.Attributes["class"] = "item-name";
            columnaFecha.Attributes["class"] = "item-name";
            columnaHora.Attributes["class"] = "item-name";
            columnaLugar.Attributes["class"] = "item-name";

            columnaImagen.Controls.Add(myImage);
            columanNombre.Controls.Add(label);
            columnaFecha.Controls.Add(labelFecha);
            columnaHora.Controls.Add(labelHora);
            columnaLugar.Controls.Add(labelLugar);
            clumnaBotonAgregar.Controls.Add(myButton);

            nuevoEvento.Attributes["id"] = codigo;
            nuevoEvento.Cells.Add(columnaImagen);
            nuevoEvento.Cells.Add(columanNombre);
            nuevoEvento.Cells.Add(columnaFecha);
            nuevoEvento.Cells.Add(columnaHora);
            nuevoEvento.Cells.Add(columnaLugar);
            nuevoEvento.Cells.Add(clumnaBotonAgregar);

            VariablesGlobales.TablaEventos.Rows.Add(nuevoEvento);

        }

        private void agregarCarrito(String codigoEvento, String promocion, int cantidad)
        {
            Evento evento = VariablesGlobales.listaEventos.Find(x => x.getCodigo() == codigoEvento);
            VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).agregarCarrito(evento.getListaPromociones().Find(x => x.getNombre() == promocion), cantidad, evento.getFecha());
            
        }
        
        private void formatoTabla()
        {
            nuevoEvento.Attributes["class"] = "item-meta-container";
            columnaImagen.Attributes["class"] = "item-name";
            columanNombre.Attributes["class"] = "item-name";
            clumnaBotonAgregar.Attributes["class"] = "item-name";

        }

    }
}