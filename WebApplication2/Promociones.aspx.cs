using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;

namespace WebApplication2
{
    public partial class Promociones : System.Web.UI.Page
    {
        TableCell columnaEvento;
        TableCell columnaNombre;
        TableCell columnaDescripcion;
        TableCell columnaPrecio;
        TableCell columnaCant;
        TableCell columnaAnnadir;
        TableRow nuevoEvento;

        Label evento;
        Label nom;
        Label des;
        Label pre;
        Label cantidad;
        Label comprar;
        TextBox cant;
        Button annaca;
        protected void Page_Load(object sender, EventArgs e)
        {
            string valor = Convert.ToString(Request.QueryString["key"]);
            ver_promociones(valor);
            VariablesGlobales.TablaPromociones.Attributes["class"] = "col-md-12 table-responsive table cart-table";
            Panel1.Controls.Add(VariablesGlobales.TablaPromociones);
        }
        
        protected void ver_promociones(String nombreEvento) 
        {
            List<Promocion> lisPromo = VariablesGlobales.listaEventos.Find(x => x.getCodigo() == nombreEvento).getListaPromociones();
            VariablesGlobales.TablaPromociones = new Table();
            for (int i = 0; i < lisPromo.Count; i++)
            {
                if(i == 0)
                {
                    agregarFilaPromo("Nombre del Evento", "Nombre de la Promoción", "Descripción", "Precio", "Cantidad", "comprar", 1);
                    
                }
                agregarFilaPromo(nombreEvento, lisPromo[i].getNombre(), lisPromo[i].getDescripcion(), (lisPromo[i].getPrecio()).ToString(), (lisPromo[i].getNombre() + "" + 1), "Añadir al Carrito", 2);
                
            }
        }

        private void agregarFilaPromo(String even, String nombr, String descripcion, String precio, String canti, String compr, int i)
        {
            columnaEvento = new TableCell();
            columnaNombre = new TableCell();
            columnaDescripcion = new TableCell();
            columnaPrecio = new TableCell();
            columnaCant = new TableCell();
            columnaAnnadir = new TableCell();
            nuevoEvento = new TableRow();

            if (i == 1)
            {
                evento = new Label();
                evento.Text = even;
            }
            else
            {
                evento = new Label();
                evento.Text = (VariablesGlobales.listaEventos.Find(x => x.getCodigo() == even)).getNombre();
            }
            nom = new Label();
            nom.Text = nombr;

            columnaEvento.Controls.Add(evento);
            columnaNombre.Controls.Add(nom);

            des = new Label();
            des.Text = descripcion;

            Label pre = new Label();
            pre.Text = precio;
            
            columnaDescripcion.Controls.Add(des);
            columnaPrecio.Controls.Add(pre);

            if(i == 1)
            {
                cantidad = new Label();
                cantidad.Text = canti;

                comprar = new Label();
                comprar.Text = compr;

                columnaCant.Controls.Add(cantidad);
                columnaAnnadir.Controls.Add(comprar);
            }
            else
            {
                cant = new TextBox();
                cant.ID = canti;

                Button annaca = new Button();
                annaca.ID = nombr + "";
                annaca.Attributes["value2"] = "Eventos.aspx?key=" + even + "&key2=" + nombr;
                annaca.Text = "Añadir al Carrito";
                annaca.Attributes["onclick"] = "redir(this)";
                columnaCant.Controls.Add(cant);
                columnaAnnadir.Controls.Add(annaca);

            }

            nuevoEvento.Cells.Add(columnaEvento);
            nuevoEvento.Cells.Add(columnaNombre);
            nuevoEvento.Cells.Add(columnaDescripcion);
            nuevoEvento.Cells.Add(columnaPrecio);
            nuevoEvento.Cells.Add(columnaCant);
            nuevoEvento.Cells.Add(columnaAnnadir);
            VariablesGlobales.TablaPromociones.Rows.Add(nuevoEvento);

        }
    }
}