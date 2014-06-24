using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;

namespace WebApplication2
{
    public partial class EditarCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            cargar_carrito();
        }
        protected void cargar_carrito()
        {
            for (int z = 0; z < VariablesGlobales.listaCliente.Count; z++)
            {
             if (VariablesGlobales.listaCliente[z].getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado)
                {
                    if (VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito().Count > 0)
                    {
                        for (int i = 0; i < VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito().Count; i++)
                        {
                            ListItem a = new ListItem(VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getNombre(), VariablesGlobales.listaCliente[z].getCarrito().getListaLineaCarrito()[i].getPromocion().getNombre(), true);
                            ddl_car.Items.Add(a);
                        }
                    }
                }
            }
        }

        protected void btn_cambiar_promocion_Click(object sender, EventArgs e)
        {
            int a = int.Parse(input_cant.Text);
            Promocion p = VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).getCarrito().getListaLineaCarrito().Find(y => y.getPromocion().getNombre() == ddl_car.SelectedValue).getPromocion();
            VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).cambiarCantPromocion(p,a);
            Response.Redirect("Carrito.aspx");
        }

        protected void btn_eliminar_carrito_Click(object sender, EventArgs e)
        {
            Promocion p = VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).getCarrito().getListaLineaCarrito().Find(y => y.getPromocion().getNombre() == ddl_car.SelectedValue).getPromocion();
            VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == VariablesGlobales.usuarioLogeado).sacarCarrito(p);
            Response.Redirect("Carrito.aspx");
            Response.Redirect("Carrito.aspx");
        }
    }
}