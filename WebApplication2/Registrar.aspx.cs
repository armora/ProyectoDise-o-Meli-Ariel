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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Insertar_Usuario(object sender, EventArgs e) 
        {
            for(int i = 0; i > VariablesGlobales.listaUsuario.Count; i++)
            {
                if(VariablesGlobales.listaUsuario[i].getUsuario() == input_usuario.Text)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('El nombre de usuario ya pertenece al sistema');", true);
                    LabelMsjUsuario.Text = "Usuario no disponible";
                }
            }
            if(LabelMsjUsuario.Text == "")
            {
                if (input_contra.Text == input_confir_contra.Text)
                {
                    if(input_fecha_nacimiento.Text != "" && input_usuario.Text != "" && input_contra.Text != "" && input_nombre.Text != "" && input_apellido.Text != "" &&  input_correo.Text != "" && input_genero.Text != "" && input_direccion.Text != "" && input_telefono.Text != "")
                    {
                        DateTime fn = DateTime.Parse(input_fecha_nacimiento.Text);
                        Usuario u = new Usuario(input_usuario.Text, input_contra.Text, input_nombre.Text, input_apellido.Text, fn,
                        input_correo.Text, input_genero.Text, input_direccion.Text, input_telefono.Text);
                        VariablesGlobales.listaUsuario.Add(u);
                        Inserts i = new Inserts();
                        i.insertar_usuario(u);
                        Cliente c = new Cliente(u);
                        VariablesGlobales.listaCliente.Add(c);
                        LabelMsjUsuario.Text = "";
                        Response.Redirect("Inicio_sesion.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Datos Incompletos, verifique que lleno todos los dartos');", true);
                    }
                    
                }
                else 
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('Las contraseñas ingresadas no coinciden');", true);
                    LabelMsjUsuario.Text = "Las Contraseñas no son iguales";
                }
            }
          
        }
    }
}