using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class LineaCarrito
    {
        private Promocion promocion;
        private int cantidad;
        private DateTime horario;
        private float subtotal;

        public LineaCarrito(Promocion promocion, int cantidad, DateTime horario)
        {
            this.promocion = promocion;
            this.cantidad = cantidad;
            this.horario = horario;
            
            CalcularSubtotal(promocion.getPrecio(), cantidad);
        }

        public Promocion getPromocion()
        {
            return promocion;
        }

        public void setPromocion(Promocion promocion)
        {
            this.promocion = promocion;
        }

        public DateTime getHorario()
        {
            return horario;
        }

        public void setHorario(DateTime horario)
        {
            this.horario = horario;
        }

        public int getCantidad()
        {
            return cantidad;
        }

        public void setCantidad(int cantidad)
        {
            this.cantidad = cantidad;
        }

        public float getSubtotal()
        {
            return subtotal;
        }

        public void setSubtotal(float subtotal)
        {
            this.subtotal = subtotal;
        }

        public void CalcularSubtotal(float precio, int cantidad)
        {
            float sub = precio * cantidad;
            setSubtotal(sub);
        }

        public void cambiarCantEntradas(int nuevaCantidad)
        {
            cantidad = nuevaCantidad;
            CalcularSubtotal(promocion.getPrecio(), cantidad);
        }
    }

}