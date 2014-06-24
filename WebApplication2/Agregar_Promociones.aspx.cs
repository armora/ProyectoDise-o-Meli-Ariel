using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;
using WebApplication2.bd;

namespace WebApplication2
{
    public partial class AgregarPromociones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_eventos();

        }

        protected void insertar_promocion(object sender, EventArgs e)
        {
            if (input_nombre.Text != "" && input_categoria.Text != "" && input_cantEntradasDisponibles.Text != "" && input_descripcion.Text != "" && input_precio.Text != "")
            {
               bool existePromo = false; 
                for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++ )
                {
                    if ((VariablesGlobales.listaEventos[i].getListaPromociones().Find(x => x.getNombre() == input_nombre.Text)) != null)
                    {
                        if ((VariablesGlobales.listaEventos[i].getListaPromociones().Find(x => x.getNombre() == input_nombre.Text)).getNombre().Equals(input_nombre.Text))
                        {
                            existePromo = true;
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('La Promoción ya existe, por favor cambien el nombre');", true);
                        }
                    }
                }
                if(existePromo == false)
                {
                    try
                    {
                        Promocion nuevaPromocion = new Promocion(input_nombre.Text, input_categoria.Text, int.Parse(input_cantEntradasDisponibles.Text), input_descripcion.Text, float.Parse(input_precio.Text));
                        Inserts i = new Inserts();
                        i.insertar_promociones(ddl_evento.SelectedValue, nuevaPromocion);
                        VariablesGlobales.listaEventos.Find(x => x.getCodigo() == ddl_evento.SelectedValue).agregarPromocion(nuevaPromocion);

                        input_nombre.Text = "";
                        input_descripcion.Text = "";
                        input_categoria.Text = "";
                        input_cantEntradasDisponibles.Text = "";
                        input_precio.Text = "";
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Promoción Agregada');", true);
                    }
                    catch
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('El tipo de dato de cantidad o precio es incorrecto');", true);
                    }
                }
                    
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Campos incompletos');", true);
            }
        }

        protected void cargar_eventos()
        {
            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                ListItem a = new ListItem(VariablesGlobales.listaEventos[i].getNombre(),VariablesGlobales.listaEventos[i].getCodigo(),true);
                ddl_evento.Items.Add(a);
            }
        }
    }
}