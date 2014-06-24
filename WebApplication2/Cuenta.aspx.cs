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
    public partial class Cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_datos();
        }
        protected void cargar_datos() 
        {
            try
            {
                Usuario u = VariablesGlobales.listaUsuario.Find(x => x.getUsuario() == VariablesGlobales.usuarioLogeado);
                input_usuario.Text = u.getUsuario();
                input_nombre.Text = u.getNombre()+" "+u.getApellido();
                input_correo.Text = u.getCorreo();
                input_direccion.Text = u.getDireccion();
                input_telefono.Text = u.getTelefono();
                
            }
            catch 
            { 
            
            }
        }

        protected void btn_volver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}