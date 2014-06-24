using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.clases
{
    interface ObservableEvento
    {
      //  public abstract void agregarObservador();
        void NotificarObservadores();

    }
}