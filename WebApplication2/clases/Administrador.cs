using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebApplication2.clases
{
    public class Administrador : RolUsuario
    {
        private Usuario usuario;

        public Administrador(Usuario usuario)
        {
            this.usuario = usuario;
        }
        
        public Usuario getUsuario()
        {
            return usuario;
        }
        public void CrearEvento(String codigo,String nombre, String lugar, Categoria categoria, String foto, DateTime fecha, TimeSpan hora, String descripcion)
        {
            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                if (VariablesGlobales.listaEventos[i].getCodigo() == codigo)
                {
                    System.Console.Write("El codigo del evento ya existe");
                    break;
                }
                Evento nuevoEvento = new Evento(codigo, nombre, lugar, categoria, foto, fecha, hora, descripcion);
                VariablesGlobales.listaEventos.Add(nuevoEvento);
            }
        }
        public void EliminarEvento(String codigo)
        {
            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                if (VariablesGlobales.listaEventos[i].getCodigo() == codigo)
                {
                    VariablesGlobales.listaEventos.Remove(VariablesGlobales.listaEventos[i]);
                    break;
                }
                System.Console.Write("El evento no existe");
            }
        }
        public void agregarPromocion(Evento evento, String nombre, String categoria, int cantidadEntradas, String descripcion, float precio)
        {
            Promocion nuevaPromocion = new Promocion(nombre, categoria, cantidadEntradas, descripcion, precio);
            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                if (VariablesGlobales.listaEventos[i] == evento)
                {
                    for (int y = 0; y < VariablesGlobales.listaEventos[i].getListaPromociones().Count; y++)
                    {
                        if (VariablesGlobales.listaEventos[i].getListaPromociones()[y] == nuevaPromocion)
                        {
                            System.Console.Write("La promoción ya existe");
                            break;
                        }
                        VariablesGlobales.listaEventos[i].getListaPromociones().Add(nuevaPromocion);
                    }
                }
            }

        }

        public void eliminarPromocion(Evento evento, Promocion promocion)
        {
            for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                if (VariablesGlobales.listaEventos[i] == evento)
                {
                    for (int y = 0; y < VariablesGlobales.listaEventos[i].getListaPromociones().Count; y++)
                    {
                        if (VariablesGlobales.listaEventos[i].getListaPromociones()[y] == promocion)
                        {
                            VariablesGlobales.listaEventos[i].getListaPromociones().Remove(promocion);
                            break;
                        }
                        System.Console.Write("La promocion no existe");
                    }
                }
            }
        }
        public override List<HistorialComprasUsuario> VerificarHistorial(Usuario usuario)
        {
            List<HistorialComprasUsuario> listaAdmin = VariablesGlobales.listaHistorial;
            return listaAdmin; 
        }

    }
}