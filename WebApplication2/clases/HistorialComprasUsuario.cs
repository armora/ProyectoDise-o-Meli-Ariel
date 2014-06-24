using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class HistorialComprasUsuario
    {
        private List<Compra> listaCompras;

        public HistorialComprasUsuario(Compra compra)
        {
            this.listaCompras = new List<Compra>();
            listaCompras.Add(compra);
        }

        public HistorialComprasUsuario()
        {
            this.listaCompras = new List<Compra>();
        }
        public List<Compra> getListaCompras()
        {
            return listaCompras;
        }

        public void agregarListaCompras(Compra nuevaCompras)
        {
            listaCompras.Add(nuevaCompras);
        }
    }
}