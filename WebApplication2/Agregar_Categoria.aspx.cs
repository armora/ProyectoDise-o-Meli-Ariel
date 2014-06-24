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
    public partial class Agregar_Categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void boton_agregar_categorias(object sender,  EventArgs e) 
        {
            if (input_nombre.Text != "" && input_descripcion.Text != "")
            {
                if ((VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == input_nombre.Text)) != null)
                {
                    if ((VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == input_nombre.Text)).getNombreCategoria().Equals(input_nombre.Text))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('La categoría ya existe, por favor cambien el nombre');", true);    
                    }
                }
                else
                {
                    Categoria c = new Categoria(input_nombre.Text, input_descripcion.Text);
                    Inserts i = new Inserts();
                    i.insertar_categoria(c);
                    VariablesGlobales.listaCategoria.Add(c);
                    input_nombre.Text = "";
                    input_descripcion.Text = "";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Categoría Agregada');", true);    
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Campos incompletos');", true);
            }
            
        }
    }
}