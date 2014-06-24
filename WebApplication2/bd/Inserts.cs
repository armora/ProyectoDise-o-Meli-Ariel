using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using WebApplication2.bd;
using WebApplication2.clases;

namespace WebApplication2.bd
{
    public class Inserts : Conexion
    {
        public void insertar_evento(Evento e)
        {
            iniciarConexion();
            //comando.CommandType = System.Data.CommandType.Text;
            String a = @"INSERT INTO EVENTO (CODIGO,NOMBRE,LUGAR,CATEGORIA,FOTO,FECHA,HORAINICIO,DESCRIPCION) 
            VALUES (@codigo,@nombre,@lugar,@categoria,@foto,@fecha,@horainicio,@descripcion)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@codigo", e.getCodigo());
            comando.Parameters.AddWithValue("@nombre", e.getNombre());
            comando.Parameters.AddWithValue("@lugar", e.getLugar());
            comando.Parameters.AddWithValue("@foto",e.getFoto());
            comando.Parameters.AddWithValue("@categoria", e.getCategoria().getNombreCategoria());
            comando.Parameters.AddWithValue("@fecha", e.getFecha());
            comando.Parameters.AddWithValue("@horainicio", e.getHoraInicio());
            comando.Parameters.AddWithValue("@descripcion", e.getDescripcion());
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void llenar_evento()
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM EVENTO";
            comando = new SqlCommand(consulta, conectar);
            conectar.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String codigo = (reader["CODIGO"]).ToString();
                String nombre = (reader["NOMBRE"]).ToString();
                String lugar = (reader["LUGAR"]).ToString();
                String categoria = (reader["CATEGORIA"]).ToString();
                String foto = (reader["FOTO"]).ToString();
                String descripcion = (reader["DESCRIPCION"]).ToString();
                DateTime fecha = DateTime.Parse((reader["FECHA"]).ToString());
                TimeSpan horaInicio = TimeSpan.Parse((reader["HORAINICIO"]).ToString());
                Categoria c = VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == categoria);
                Evento e = new Evento(codigo,nombre,lugar,c,foto,fecha, horaInicio, descripcion);
                VariablesGlobales.listaEventos.Add(e);
                

            }
            conectar.Close();
        }
        public void insertar_usuario(Usuario u)
        {
            iniciarConexion();
            //comando.CommandType = System.Data.CommandType.Text;
            String a = @"INSERT INTO USUARIO (USUARIO,CONTRASENNA,NOMBRE,APELLIDOS,FECHANACIMIENTO,GENERO,CORREO,DIRECCION,TELEFONO) 
            VALUES (@usuario,@contrasenna,@nombre,@apellidos,@fechanacimiento,@genero,@correo,@direccion,@telefono)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@usuario", u.getUsuario());
            comando.Parameters.AddWithValue("@contrasenna", u.getContrasena());
            comando.Parameters.AddWithValue("@nombre", u.getNombre());
            comando.Parameters.AddWithValue("@apellidos", u.getApellido());
            comando.Parameters.AddWithValue("@fechanacimiento", u.getFechaNacimiento());
            comando.Parameters.AddWithValue("@genero", u.getGenero());
            comando.Parameters.AddWithValue("@correo", u.getCorreo());
            comando.Parameters.AddWithValue("@direccion", u.getDireccion());
            comando.Parameters.AddWithValue("@telefono", u.getTelefono());
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void insertar_lista_preferencias(Categoria preferencia , String usuario) 
        {
            iniciarConexion();
            //comando.CommandType = System.Data.CommandType.Text;
            String a = @"INSERT INTO PREFERENCIA (CATEGORIA,CLIENTE)
            VALUES (@categoria,@cliente)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@categoria", preferencia.getNombreCategoria());
            comando.Parameters.AddWithValue("@contrasenna", usuario);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void llenar_usuarios()
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM USUARIO";
            comando = new SqlCommand(consulta, conectar);
            conectar.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String usuario = (reader["USUARIO"]).ToString();
                String contrasena = (reader["CONTRASENNA"]).ToString();
                String nombre = (reader["NOMBRE"]).ToString();
                String apellido = (reader["APELLIDOS"]).ToString();
                DateTime fechanac = DateTime.Parse((reader["FECHANACIMIENTO"]).ToString());
                String correo = (reader["CORREO"]).ToString();
                String genero = (reader["GENERO"]).ToString();
                String direccion = (reader["DIRECCION"]).ToString();
                String telefono = (reader["TELEFONO"]).ToString();
                int tipoUsuario = int.Parse(reader["TIPO"].ToString());
                Usuario u = new Usuario(usuario,contrasena,nombre,apellido,fechanac,correo,genero,direccion,telefono);
                VariablesGlobales.listaUsuario.Add(u);
                Cliente c = new Cliente(u);
                VariablesGlobales.listaCliente.Add(c);
                if(tipoUsuario == 1)
                {
                    Administrador admin = new Administrador(u);
                    VariablesGlobales.listaAdministradores.Add(admin);
                }
            }
            conectar.Close();
        }
        public void llenar_preferencias()
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM PREFERENCIA";
            comando = new SqlCommand(consulta, conectar);
            conectar.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String usuario = (reader["CLIENTE"]).ToString();
                String categoria = (reader["CATEGORIA"]).ToString();
                VariablesGlobales.listaCliente.Find(x => x.getUsuario().getUsuario() == usuario).agregarPreferencia(VariablesGlobales.listaCategoria.Find(x => x.getNombreCategoria() == categoria));
            }
            conectar.Close();
            for(int i = 0; i < VariablesGlobales.listaEventos.Count; i++)
            {
                ObservableEvento evento = (ObservableEvento)VariablesGlobales.listaEventos[i];
                evento.NotificarObservadores();
            }
        }

        public void insertar_horario(String codigo,DateTime fecha)
        {
            iniciarConexion();
            //comando.CommandType = System.Data.CommandType.Text;
            String a = @"INSERT INTO HORARIO (CODIGOEVENTO,FECHA,HORAINICIO,HORAFINAL) VALUES (@codigo,@fecha,@horainicio,@horafinal)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@fecha", fecha);
            comando.Parameters.AddWithValue("@horainicio", fecha);
            comando.Parameters.AddWithValue("@horafinal",fecha);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        
        public void insertar_promociones(String codigo,Promocion p)
        {
            iniciarConexion();
            String a = @"INSERT INTO PROMOCION (CODIGOEVENTO,NOMBRE,CATEGORIA,CANTENTRADASDISPONIBLES,DESCRIPCION,PRECIO) 
            VALUES (@codigo,@nombre,@categoria,@cantentradasdisponibles,@descripcion,@precio)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@codigo", codigo);
            comando.Parameters.AddWithValue("@nombre", p.getNombre());
            comando.Parameters.AddWithValue("@categoria", p.getCategoria());
            comando.Parameters.AddWithValue("@cantentradasdisponibles", p.getCantEntradasDisponibles());
            comando.Parameters.AddWithValue("@descripcion", p.getDescripcion());
            comando.Parameters.AddWithValue("@precio", p.getPrecio());
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void llenar_promociones()
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM PROMOCION";
            comando = new SqlCommand(consulta, conectar);
            conectar.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String codigo = (reader["CODIGOEVENTO"]).ToString();
                String nombre = (reader["NOMBRE"]).ToString();
                String categoria = (reader["CATEGORIA"]).ToString();
                int cant = int.Parse((reader["CANTENTRADASDISPONIBLES"]).ToString());
                String descripcion = (reader["DESCRIPCION"]).ToString();
                float precio = float.Parse((reader["PRECIO"]).ToString());
                Promocion p = new Promocion(nombre,categoria,cant,descripcion,precio);
                try
                {
                    VariablesGlobales.listaEventos.Find(x => x.getCodigo() == codigo).agregarPromocion(p);
                }
                catch 
                { 
                }
            }
            conectar.Close();
        }
        public void insertar_categoria(Categoria p)
        {
            iniciarConexion();
            String a = @"INSERT INTO CATEGORIA  (NOMBRE,DESCRIPCION) 
            VALUES (@nombre,@descripcion)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@nombre", p.getNombreCategoria());
            comando.Parameters.AddWithValue("@descripcion", p.getDescripcion());
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void llenar_categoria()
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM CATEGORIA";
            comando = new SqlCommand(consulta, conectar);
            conectar.Open();
            SqlDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                String nombre = (reader["NOMBRE"]).ToString();
                String descripcion = (reader["DESCRIPCION"]).ToString();
                Categoria p = new Categoria(nombre, descripcion);
                try
                {
                    VariablesGlobales.listaCategoria.Add(p);
                }
                catch
                {
                }
            }
            conectar.Close();
        }
        public void insertar_compra(Compra c1)
        {
            iniciarConexion();
            String a = @"INSERT INTO COMPRA (USUARIO,CODIGOCOMPRA,FECHA,TOTAL)
            VALUES (@usuario,@codigocompra,@fecha,@total)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@usuario", c1.getUsuario().getNombre());
            comando.Parameters.AddWithValue("@codigocompra", c1.getCodigoCompra());
            comando.Parameters.AddWithValue("@fecha", c1.getFecha());
            comando.Parameters.AddWithValue("@total", c1.getTotal());
            List<Tuple<Promocion,int, DateTime>> l = c1.getListaComprasPromociones();
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
            for (int j = 0; j < l.Count; j++)
            {
                insertar_lista_compra(c1.getCodigoCompra(), l[j].Item1.getNombre(), l[j].Item2, l[j].Item3);
            }
        }
        public void insertar_lista_compra(int codigo,String nombre, int precio,DateTime fechaevento)
        {
            iniciarConexion();
            String a = @"INSERT INTO LISTA_COMPRA (CODIGOCOMPRA,NOMBREPROMOCION,CANTIDAD,FECHAEVENTO)
            VALUES (@codigocompra,@nombrep,@precio,@fechaevento)";
            comando = new SqlCommand(a, conectar);
            comando.Parameters.AddWithValue("@codigocompra", codigo);
            comando.Parameters.AddWithValue("@nombrep", nombre);
            comando.Parameters.AddWithValue("@precio", precio);
            comando.Parameters.AddWithValue("@fechaevento", fechaevento);
            conectar.Open();
            comando.ExecuteNonQuery();
            conectar.Close();
        }
        public void llenar_compra()
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM COMPRA";
            comando = new SqlCommand(consulta, conectar);
            conectar.Open();
            SqlDataReader reader = comando.ExecuteReader();
            List<Compra> compras = new List<Compra>();
            while (reader.Read())
            {
                String usuario = (reader["USUARIO"]).ToString();
                int codigocompra = int.Parse((reader["CODIGOCOMPRA"]).ToString());
                DateTime fecha = DateTime.Parse((reader["FECHA"]).ToString());
                float cant = float.Parse((reader["TOTAL"]).ToString());
                Usuario u = VariablesGlobales.listaUsuario.Find(x => x.getUsuario() == usuario);
                Compra c = new Compra(codigocompra, u, fecha);
                compras.Add(c);                
            }
            conectar.Close();
         for(int j = 0; j < compras.Count;j++)
         {
            try
            {
                List<Tuple<Promocion, int, DateTime>> l = llenar_lista_compra(compras[j].getCodigoCompra());
                compras[j].agregarListaCompras(l);
                if (VariablesGlobales.listaHistorial.Count == 0)
                {
                    HistorialComprasUsuario h = new HistorialComprasUsuario();
                    h.agregarListaCompras(compras[j]);
                    VariablesGlobales.listaHistorial.Add(h);
                }
                else
                {
                    RolUsuario rolCliente = (RolUsuario)(VariablesGlobales.listaCliente.Find(x => x.getUsuario() == compras[j].getUsuario()));
                    List<HistorialComprasUsuario> listaHisoral = rolCliente.VerificarHistorial((VariablesGlobales.listaCliente.Find(x => x.getUsuario() == compras[j].getUsuario()).getUsuario()));
                    if (listaHisoral.Count == 0)
                    {
                        for (int i = 0; i < VariablesGlobales.listaHistorial.Count; i++)
                        {
                            if (VariablesGlobales.listaHistorial[i].getListaCompras()[0].getUsuario() == compras[j].getUsuario())
                            {
                                VariablesGlobales.listaHistorial[i].agregarListaCompras(compras[j]);
                                break;
                            }
                        }
                    }
                    else
                    {
                        HistorialComprasUsuario h = new HistorialComprasUsuario();
                        h.agregarListaCompras(compras[j]);
                        VariablesGlobales.listaHistorial.Add(h);
                    }

                }
            }
            catch
            {
            }
        }
        }
        public List<Tuple<Promocion,int,DateTime>> llenar_lista_compra(int codigo)
        {
            iniciarConexion();
            string consulta = @"SELECT * FROM LISTA_COMPRA WHERE CODIGOCOMPRA = @codigo";
            comando = new SqlCommand(consulta, conectar);
            comando.Parameters.AddWithValue("@codigo", codigo);
            conectar.Open();
            SqlDataReader resultado = comando.ExecuteReader();
            List<Tuple<Promocion, int,DateTime>> lp = new List<Tuple<Promocion,int,DateTime>>();
            while (resultado.Read())
            {
                String nombre = (resultado["NOMBREPROMOCION"]).ToString();
                int cant = int.Parse((resultado["CANTIDAD"]).ToString());
                DateTime fecha = DateTime.Parse((resultado["FECHAEVENTO"]).ToString());
                try
                {
                    for (int i = 0; i < VariablesGlobales.listaEventos.Count; i++) 
                    {
                        Promocion p = VariablesGlobales.listaEventos[i].getListaPromociones().Find(x => x.getNombre()==nombre);
                        if (p != null) 
                        {
                            Tuple<Promocion,int,DateTime> t = new Tuple<Promocion,int,DateTime>(p,cant,fecha);
                            lp.Add(t);
                            break;
                        }
                    }
                }
                catch
                {

                }
            }
            conectar.Close();
            return lp;
        }
    }
}
