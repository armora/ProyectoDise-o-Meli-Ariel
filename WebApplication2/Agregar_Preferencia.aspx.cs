using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.bd;
using WebApplication2.clases;

namespace WebApplication2
{
    public partial class Agregar_Preferencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_categorias();
        }

        protected void cargar_categorias()
        {
            ddl_categoria.Items.Clear();
            for (int i = 0; i < VariablesGlobales.listaCategoria.Count; i++)
            {
                ddl_categoria.Items.Add(VariablesGlobales.listaCategoria[i].getNombreCategoria());
            }

        }

        protected void boton_agregar_categorias(object sender, EventArgs e)
        {
            if (VariablesGlobales.usuarioLogeado != "")
            {
                Categoria c = VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == ddl_categoria.SelectedValue);
                VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).agregarPreferencia(c);
                Inserts insertarpre = new Inserts();
                insertarpre.insertar_lista_preferencias(c, VariablesGlobales.usuarioLogeado);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Por favor inicie cesión, para poder ingresar preferencias');", true);
            }
        }
        protected void boton_eliminar_categorias(object sender, EventArgs e)
        {
            if (VariablesGlobales.usuarioLogeado != "")
            {
                Categoria c = VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == ddl_categoria.SelectedValue);
                VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).eliminarPreferencia(c);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Por favor inicie cesión, para poder eliminar preferencias');", true);
            }
        }
    }
}