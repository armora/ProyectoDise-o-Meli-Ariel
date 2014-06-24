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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void btn_iniciar_sesion(object sender, EventArgs e) 
        {
            Usuario u = VariablesGlobales.listaUsuario.Find(x => x.getUsuario() == input_usuario.Text);
            if (u != null) 
            { 
                if(u.getUsuario() == input_usuario.Text)
                {
                    if(u.getContrasena() == input_contrasena.Text)
                    {
                        VariablesGlobales.usuarioLogeado = input_usuario.Text;
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('El usuario ingresado no pertenece al sistema');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('El usuario ingresado no pertenece al sistema');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('El usuario ingresado no pertenece al sistema');", true);
            }
        }
    }
}