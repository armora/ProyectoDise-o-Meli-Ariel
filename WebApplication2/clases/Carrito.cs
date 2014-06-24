using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Carrito
    {
        private List <LineaCarrito> listaLineaCarrito;
        private float totalAcumulado;

        public Carrito()
        {
            listaLineaCarrito = new List<LineaCarrito>();
            totalAcumulado = 0;
           // this.totalAcumulado = (float)lineaCarrito.getCantidad() * lineaCarrito.getPromocion().getPrecio();
        }

        public List <LineaCarrito> getListaLineaCarrito()
        {
            return listaLineaCarrito;
        }

        public void agregarLineaCarrito(LineaCarrito nuevaLineaCarrito)
        {
            listaLineaCarrito.Add(nuevaLineaCarrito);
            totalAcumulado = totalAcumulado + ((float)nuevaLineaCarrito.getCantidad() * nuevaLineaCarrito.getPromocion().getPrecio()); ;
        }

        public void eliminarLineaCarrito(LineaCarrito lineaCarrito)
        {
            totalAcumulado = totalAcumulado - ((float)lineaCarrito.getCantidad() * lineaCarrito.getPromocion().getPrecio());
            listaLineaCarrito.Remove(lineaCarrito);
        }

        public void modificarCantLineaCarrito(LineaCarrito lineaCarrito, int cantidadEntradas)
        {
            totalAcumulado = totalAcumulado - ((float)lineaCarrito.getCantidad() * lineaCarrito.getPromocion().getPrecio());
            lineaCarrito.cambiarCantEntradas(cantidadEntradas);
            totalAcumulado = totalAcumulado + ((float)lineaCarrito.getCantidad() * lineaCarrito.getPromocion().getPrecio());
        }

        public float getTotalAcumulado()
        {
            return totalAcumulado;
        }
   
        public void vaciarCarrito()
        {
            listaLineaCarrito = new List<LineaCarrito>();
            totalAcumulado = 0;
        }
    }

}