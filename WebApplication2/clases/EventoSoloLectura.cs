using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    interface EventoSoloLectura
    {
        String getCodigo();
        String getNombre();
        String getLugar();
        Categoria getCategoria();
        String getFoto();
        String getDescripcion();
        DateTime getFecha();

        TimeSpan getHoraInicio();
        List<Promocion> getListaPromociones();
    }
}