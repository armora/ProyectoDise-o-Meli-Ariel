using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Evento : ObservableEvento, EventoSoloLectura
    {
        private String codigo;
        private String nombre;
        private String lugar; 
        private DateTime fecha;
        private TimeSpan horaInicio;
        private Categoria categoria;
        private String foto;
        private String descripcion;
        private List <Promocion> listaPromociones;

        public Evento(String codigo, String nombre, String lugar, Categoria categoria, String foto, DateTime fecha, TimeSpan horaInicio, String descripcion)
        {
            this.codigo = codigo;
            this.nombre = nombre;
            this.lugar = lugar;
            this.categoria = categoria;
            this.foto = foto;
            this.descripcion = descripcion;
            listaPromociones = new List<Promocion>();
            this.fecha = fecha;
            this.horaInicio = horaInicio;
        }

        String EventoSoloLectura.getCodigo()
        {
            return codigo;
        }
        public String getCodigo()
        {
            return codigo;
        }

        public void setCodigo(String codigo)
        {
            this.codigo = codigo;
        }

        String EventoSoloLectura.getNombre()
        {
            return nombre;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        String EventoSoloLectura.getLugar()
        {
            return lugar;
        }

        public String getLugar()
        {
            return lugar;
        }

        public void setLugar(String lugar)
        {
            this.lugar = lugar;
        }

        Categoria EventoSoloLectura.getCategoria()
        {
            return categoria;
        }

        public Categoria getCategoria()
        {
            return categoria;
        }

        public void setCategoria(Categoria categoria)
        {
            this.categoria = categoria;
        }

        String EventoSoloLectura.getFoto()
        {
            return foto;
        }

        public String getFoto()
        {
            return foto;
}

        public void setFoto(String foto)
        {
            this.foto = foto;
        }

        String EventoSoloLectura.getDescripcion()
        {
            return descripcion;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }
        
        public DateTime getFecha()
        {
            return fecha;
        }

        DateTime EventoSoloLectura.getFecha()
        {
            return fecha;
        }

        public void setFecha(DateTime fecha)
        {
            this.fecha = fecha;
        }

        public TimeSpan getHoraInicio()
        {
            return horaInicio;
        }

        TimeSpan EventoSoloLectura.getHoraInicio()
        {
            return horaInicio;
        }
        public void setHoraInicio(TimeSpan horaInicio)
        {
            this.horaInicio = horaInicio;
        }
        List<Promocion> EventoSoloLectura.getListaPromociones()
        {
            return listaPromociones;
        }

        public List<Promocion> getListaPromociones()
        {
            return listaPromociones;
        }

        public void agregarPromocion(Promocion nuevaPromocion)
        {
            listaPromociones.Add(nuevaPromocion);
        }
        void ObservableEvento.NotificarObservadores()
        {
            for(int i = 0; i < VariablesGlobales.listaCliente.Count; i++)
            {
                 if ((VariablesGlobales.listaCliente[i].getListaPreferencias().Find(x => x == categoria)) ==  categoria)
                 {
                     ObservadorCliente obsCliente = (ObservadorCliente)VariablesGlobales.listaCliente[i];
                     obsCliente.ActualizarRecomendaciones(codigo);
                 }
            }
        }

    }

}