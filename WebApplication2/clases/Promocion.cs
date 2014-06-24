using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Promocion
    {
        private String nombre;
        private String categoria;
        private int cantEntradasDisponibles;
        private String descripcion;
        private float precio;

        public Promocion(String nombre, String categoria, int cantEntradasDisponibles, String descripcion, float precio)
        {
            this.nombre = nombre;
            this.categoria = categoria;
            this.cantEntradasDisponibles = cantEntradasDisponibles;
            this.descripcion = descripcion;
            this.precio = precio;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getCategoria()
        {
            return categoria;
        }

        public void setCategoria(String categoria)
        {
            this.categoria = categoria;
        }

        public int getCantEntradasDisponibles()
        {
            return cantEntradasDisponibles;
        }

        public void setCantEntradasDisponibles(int cantEntradasDisponibles)
        {
            this.cantEntradasDisponibles = cantEntradasDisponibles;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

        public float getPrecio()
        {
            return precio;
        }

        public void setPrecio(float precio)
        {
            this.precio = precio;
        }

        public void reducirEntradasDisponibles( int cantADescontar)
        {
            cantEntradasDisponibles = cantEntradasDisponibles - cantADescontar;
        }
    }

}