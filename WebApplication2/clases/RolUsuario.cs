using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    public abstract class RolUsuario
    {
        public abstract List<HistorialComprasUsuario> VerificarHistorial(Usuario usuario);
    }
}