using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Cliente : RolUsuario, ObservadorCliente
    {
        private Usuario usuario;
        private Carrito carrito;
        private List<Categoria> listaPreferencias;
        private List<String> listaRecomendaciones;

        public Cliente(Usuario usuario)
        {
            this.usuario = usuario;
            carrito = new Carrito();
            listaPreferencias =  new List<Categoria>();
            listaRecomendaciones = new List<string>();
        }
        public List<Categoria> getListaPreferencias()
        {
            return listaPreferencias;
        }

        public void setListaPreferencias(List<Categoria> listaPreferencias)
        {
            this.listaPreferencias = listaPreferencias;
        }

        public List<String> getListaRecomendaciones()
        {
            return listaRecomendaciones;
        }

        public void setListaRecomendaciones(List<String> listaRecomendaciones)
        {
            this.listaRecomendaciones = listaRecomendaciones;
        }

        public Usuario getUsuario()
        {
            return usuario;
        }

        public void setUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        public Carrito getCarrito()
        {
            return carrito;
        }

        public void setCarrito(Carrito carrito)
        {
            this.carrito = carrito;
        }

        public override List<HistorialComprasUsuario> VerificarHistorial(Usuario usuario)
        {
            List<HistorialComprasUsuario> listaUsuario = new List<HistorialComprasUsuario>();
            for (int i = 0; i < VariablesGlobales.listaHistorial.Count; i++)
            {
                if(VariablesGlobales.listaHistorial[i].getListaCompras()[0].getUsuario() == usuario)
                {
                    listaUsuario.Add(VariablesGlobales.listaHistorial[i]);
                }
            }
            return listaUsuario;
        }

        public void agregarCarrito(Promocion promocion, int cantidad, DateTime horario)
        {
            LineaCarrito nuevaLineaCarrito = new LineaCarrito(promocion, cantidad, horario);
            carrito.getListaLineaCarrito().Add(nuevaLineaCarrito);

        }

        public void sacarCarrito(Promocion promocion)
        {
            for(int i = 0; i < carrito.getListaLineaCarrito().Count; i++)
            {
                if(carrito.getListaLineaCarrito()[i].getPromocion() == promocion)
                {
                    carrito.getListaLineaCarrito().Remove(carrito.getListaLineaCarrito()[i]);
                }

            }
        }

        public void cambiarCantPromocion(Promocion promocion, int cantidad)
        {
            for (int i = 0; i < carrito.getListaLineaCarrito().Count; i++)
            {
                if (carrito.getListaLineaCarrito()[i].getPromocion() == promocion)
                {
                    carrito.getListaLineaCarrito()[i].setCantidad(cantidad);
                }
            }
        }
        private int GenerarCodigo()
        {
            int minimo = 11234567;
            int maximo = 99897989;

            Random random = new Random();
            return random.Next(minimo, maximo);
        }

        private bool existeCodigo(int codigo)
        {
            for (int i = 0; i < VariablesGlobales.listaHistorial.Count; i++)
            {
                Compra compra = VariablesGlobales.listaHistorial[i].getListaCompras().Find(x => x.getCodigoCompra() == codigo);
                if(compra != null)
                {
                    if(compra.getCodigoCompra() == codigo)
                    {
                        return true;
                    }
                }
                
            }
            return false;
        }
        public Compra realizarCompra()
        {
            Cliente cliente = VariablesGlobales.listaCliente.Find(x => x.getUsuario() == usuario);
            List<Tuple<Promocion, int, DateTime>> listaCompra = new List<Tuple<Promocion,int,DateTime>>();
            int codigo = GenerarCodigo();
            while(true)
            {
                if(existeCodigo(codigo) == false)
                {
                    break;
                }
                else
                {
                    codigo = GenerarCodigo();
                }
            }
            for (int i = 0; i < cliente.getCarrito().getListaLineaCarrito().Count; i++ )
            {
                Tuple<Promocion, int, DateTime> tuplaCompra = new Tuple<Promocion, int, DateTime>(cliente.getCarrito().getListaLineaCarrito()[i].getPromocion(), cliente.getCarrito().getListaLineaCarrito()[i].getCantidad(),  cliente.getCarrito().getListaLineaCarrito()[i].getHorario());
                listaCompra.Add(tuplaCompra);
            }
            Compra nuevaCompra = new Compra(codigo, listaCompra, cliente.getUsuario(), DateTime.Now);
            nuevaCompra.actualizarHistorial(nuevaCompra);
            nuevaCompra.enviarCorreo();
            return nuevaCompra;
        }
        public void agregarPreferencia(Categoria nuevaPreferencia)
        {
            for(int i = 0; i < listaPreferencias.Count; i++)
            {
                if(listaPreferencias[i] == nuevaPreferencia)
                {
                    System.Console.Write("El usuario ya indicó esta preferencia");
                }
            }
            listaPreferencias.Add(nuevaPreferencia);
        }

        public void eliminarPreferencia(Categoria preferencia)
        {
            for (int i = 0; i < listaPreferencias.Count; i++)
            {
                if (listaPreferencias[i] == preferencia)
                {
                    listaPreferencias.Remove(preferencia);
                }
            }
            
        }

        void ObservadorCliente.ActualizarRecomendaciones(String recomendacion) // La recomendación es el código del evento
        {
            if (existeRecomendacion(recomendacion) == false)
            {
                listaRecomendaciones.Add(recomendacion);
            }
            else
            {
                System.Console.Write("Ya se agrego esta recomendación");
            }
        }

        public bool existeRecomendacion(String recomendacion)
        {
            if((listaRecomendaciones.Find(x => x == recomendacion)) == recomendacion)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
    
}