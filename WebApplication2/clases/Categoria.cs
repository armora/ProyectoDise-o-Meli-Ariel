using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Categoria
    {
        private String nombreCategoria;
        private String descripcion;

        public Categoria(String nombreCategoria, String descripcion)
        {
            this.nombreCategoria = nombreCategoria;
            this.descripcion = descripcion;
        }

        public String getNombreCategoria()
        {
            return nombreCategoria;
        }

        public void setNombreCategoria(String nombreCategoria)
        {
            this.nombreCategoria = nombreCategoria;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }

    }

}