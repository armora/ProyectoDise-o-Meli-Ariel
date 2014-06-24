using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;
using WebApplication2.bd;

namespace WebApplication2
{
    public partial class WebForm6 : System.Web.UI.Page
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
            if (input_codigo.Text != "" && input_nombre.Text != "" && input_lugar.Text != "" && pdffile.Text != "" && input_fecha.Value != "" && input_hora_inicio.Value != "" && input_descripcion.Text != "")
            {
                if ((VariablesGlobales.listaEventos.Find(x => x.getCodigo() == input_codigo.Text)) != null)
                {
                    if ((VariablesGlobales.listaEventos.Find(x => x.getCodigo() == input_codigo.Text)).getCodigo().Equals(input_codigo.Text))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('El evento ya existe, por favor cambien el código');", true);
                    }
                }
                else
                {
                    String sourceFile = @"" + pdffile.Text;
                    string[] lines = Regex.Split(sourceFile, @"\\");
                    String filename = lines[(lines.Length - 1)];
                    String destinationFile = @"C:\Users\sony\Documents\Visual Studio 2013\Projects\WebApplication2\WebApplication2\images\" + filename;
                    System.IO.File.Copy(sourceFile, destinationFile, true);
                    DateTime fecha = DateTime.Parse(input_fecha.Value);
                    TimeSpan horaInicio = TimeSpan.Parse(input_hora_inicio.Value);
                    Categoria c = VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == ddl_categoria.SelectedValue);
                    Evento even = new Evento(input_codigo.Text, input_nombre.Text, input_lugar.Text, c, "images/" + filename, fecha, horaInicio, input_descripcion.Text);
                    Inserts i = new Inserts();
                    i.insertar_evento(even);
                    VariablesGlobales.listaEventos.Add(even);
                    Response.Redirect("Default.aspx");

                    input_nombre.Text = "";
                    input_descripcion.Text = "";
                    input_codigo.Text = "";
                    input_lugar.Text = "";
                    pdffile.Text = "";
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Evento Agregada');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Campos incompletos');", true);
            }
        }
    }
}