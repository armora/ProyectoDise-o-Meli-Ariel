using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public class Usuario
    {
        private String usuario;
        private String contrasena;
        private String nombre;
        private String apellido;
        private DateTime fechaNacimiento;
        private String correo;
        private String genero;
        private String direccion;
        private String telefono;

        public Usuario(String usuario, String contrasena, String nombre, String apellido, DateTime fechaNacimiento, String correo, String genero, String direccion, String telefono)
        {
            this.usuario = usuario;
            this.contrasena = contrasena;
            this.nombre = nombre;
            this.apellido = apellido;
            this.fechaNacimiento = fechaNacimiento;
            this.correo = correo;
            this.genero = genero;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public String getUsuario()
        {
            return usuario;
        }

        public void setUsuario(String usuario)
        {
            this.usuario = usuario;
        }

        public String getContrasena()
        {
            return contrasena;
        }

        public void setContrasena(String contrasena)
        {
            this.contrasena = contrasena;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getApellido()
        {
            return apellido;
        }

        public void setApellido(String apellido)
        {
            this.apellido = apellido;
        }

        public DateTime getFechaNacimiento()
        {
            return fechaNacimiento;
        }

        public void setFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }

        public String getCorreo()
        {
            return correo;
        }

        public void setCorreo(String correo)
        {
            this.correo = correo;
        }

        public String getGenero()
        {
            return genero;
        }

        public void setGenero(String genero)
        {
            this.genero = genero;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }

        public String getTelefono()
        {
            return telefono;
        }

        public void setTelefono(String telefono)
        {
            this.telefono = telefono;
        }

        
    }
}