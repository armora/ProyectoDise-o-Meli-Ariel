using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Compra
    {
        private int codigoCompra;
        private List<Tuple<Promocion, int, DateTime>> listaComprasPromociones = new List<Tuple<Promocion, int, DateTime>>();
        private Usuario usuario;
        private DateTime fecha;
        private float total = 0;

        public Compra(int codigoCompra, List<Tuple<Promocion, int, DateTime>> listaComprasPromociones, Usuario usuario, DateTime fecha)
        {
            this.codigoCompra = codigoCompra;
            this.listaComprasPromociones = listaComprasPromociones;
            this.usuario = usuario;
            this.fecha = fecha;
            for (int i = 0; i < listaComprasPromociones.Count; i++)
            {
                this.total = total + (listaComprasPromociones[i].Item1.getPrecio() * listaComprasPromociones[i].Item2);
            }
            actualizarDisponibles(listaComprasPromociones);
        }

        public Compra(int codigoCompra, Usuario usuario, DateTime fecha)
        {
            this.codigoCompra = codigoCompra;
            this.listaComprasPromociones = new List<Tuple<Promocion,int,DateTime>>();
            this.usuario = usuario;
            this.fecha = fecha;
        }

        public void agregarListaCompras(List<Tuple<Promocion, int, DateTime>> listaComprasPromociones)
        {
            this.listaComprasPromociones = listaComprasPromociones;
            for (int i = 0; i < listaComprasPromociones.Count; i++)
            {
                this.total = total + (listaComprasPromociones[i].Item1.getPrecio() * listaComprasPromociones[i].Item2);
            }
            actualizarDisponibles(listaComprasPromociones);
        }

        public int getCodigoCompra()
        {
            return codigoCompra;
        }

        public List<Tuple<Promocion, int, DateTime>> getListaComprasPromociones()
        {
            return listaComprasPromociones;
        }

        public Usuario getUsuario()
        {
            return usuario;
        }

        public DateTime getFecha()
        {
            return fecha;
        }

        public float getTotal()
        {
            return total;
        }

     /*   public void agregarListaCompras(List<LineaCarrito> listaLineaCarrito)
        {
            for (int i = 0; i < listaLineaCarrito.Count; i++) // Loop through List with for
            {
                listaComprasPromociones.Add(new Tuple<Promocion, int, Horario> (listaLineaCarrito[i].getPromocion(), listaLineaCarrito[i].getCantidad(), listaLineaCarrito[i].getHorario()));
            }
        }*/

        public void actualizarHistorial(Compra nuevaCompra)
        {
            if ((VariablesGlobales.listaHistorial.Find(x => x.getListaCompras()[0].getUsuario() == usuario)) == null)
            {
                HistorialComprasUsuario nuevoHistorial = new HistorialComprasUsuario(nuevaCompra);
                VariablesGlobales.listaHistorial.Add(nuevoHistorial);
            }
            else
            {
                for (int i = 0; i < VariablesGlobales.listaHistorial.Count; i++)
                {
                    if (VariablesGlobales.listaHistorial[i].getListaCompras()[0].getUsuario() == usuario)
                    {
                        VariablesGlobales.listaHistorial[i].getListaCompras().Add(nuevaCompra);
                    }
                }
            }
            
        }

        public void actualizarDisponibles(List<Tuple<Promocion, int, DateTime>> listaCompras)
        {
            for(int i = 0; i < listaCompras.Count; i++)
            {
                for(int y = 0; y < VariablesGlobales.listaEventos.Count; y++)
                {
                    if((VariablesGlobales.listaEventos[y].getListaPromociones().Find(x => x.getNombre() == listaCompras[i].Item1.getNombre()))== listaCompras[i].Item1)
                    {
                        Promocion p = VariablesGlobales.listaEventos[y].getListaPromociones().Find(x => x.getNombre() == listaCompras[i].Item1.getNombre());
                        VariablesGlobales.listaEventos[y].getListaPromociones().Find(x => x.getNombre() == listaCompras[i].Item1.getNombre()).setCantEntradasDisponibles(p.getCantEntradasDisponibles() - listaCompras[i].Item2);  
                    }
                    
                }
            }
        }

        public void enviarCorreo()
        {
           // EnviarCorreo nuevoCorreo = new EnviarCorreo(usuario.getCorreo(), codigoCompra);
            EnviarCorreo nuevoCorreo = new EnviarCorreo(usuario.getCorreo(), codigoCompra);
        }

    }

}