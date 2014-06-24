using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication2.clases
{
    public static class VariablesGlobales
    {
        public static List<Evento> listaEventos = new List<Evento>();
        public static List<Usuario> listaUsuario = new List<Usuario>();
        public static List<HistorialComprasUsuario> listaHistorial = new List<HistorialComprasUsuario>();
        public static List<Carrito> listaCarrito = new List<Carrito>();
        public static List<int> listaCodigos;
        public static List<Categoria> listaCategoria =  new List<Categoria>();
        public static List<Cliente> listaCliente = new List<Cliente>();
        public static List<Administrador> listaAdministradores = new List<Administrador>();
       
        public static Table TablaEventos = new Table();
        public static Table TablaHistorialUsuario = new Table();
        public static Table TablaHistorial = new Table();
        public static Table TablaPromociones = new Table();
        public static Table TablaRecomendaciones = new Table();
        public static Table TablaCarrito = new Table();
        public static Boolean cargarDefault = false;
        public static String usuarioLogeado = "";

    }
}