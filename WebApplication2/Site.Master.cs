using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication2.clases;
using WebApplication2.bd;

namespace WebApplication2
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (VariablesGlobales.cargarDefault == false)
            {
                try
                {
                    VariablesGlobales.cargarDefault = true;
                    Inserts i = new Inserts();
                    i.llenar_categoria();
                    i.llenar_evento();
                    i.llenar_promociones();
                    i.llenar_usuarios();
                    i.llenar_compra();
                    i.llenar_preferencias();
                }
                catch 
                { 
                }
                /*                                
                Promocion p1 = new Promocion("Combo Palco", "Palco", 30, "Butacas comodas, bajo techo", 8000.00f);
                Promocion p2 = new Promocion("Combo Sol", "Sol", 30, "Gradería, sin techo", 4000.00f);
                Promocion p3 = new Promocion("Combo VIP", "VIP", 30, "Gramilla", 45000.00f);
                Promocion p4 = new Promocion("Combo Gradería Sur", "Gradertía Sur", 30, "Gradería, sin techo", 15000.00f);
                Promocion p5 = new Promocion("Combo todoIncluido 3 días", "todoIncluido", 30, "Incluye transporte, alimentación y hospedaje", 115000.00f);
                Promocion p6 = new Promocion("Combo todoIncluido 1 semana", "todoIncluido Semanal", 30, "Incluye transporte, alimentación y hospedaje", 315000.00f);

                Evento e1 = new Evento("Con_029", "Final de Clásico", "Estadio Morera Soto", c1, "images/futbol.png", "Final del Torneo");
                e1.agregarHorario(h1);
                e1.agregarHorario(h2);
                e1.agregarPromocion(p1);
                e1.agregarPromocion(p2);
                Evento e2 = new Evento("Con_030", "Concierto Aerosmith", "Estadio Nacional", c2, "images/aerosmith.png", "Concierto");
                e2.agregarHorario(h1);
                e2.agregarHorario(h4);
                e2.agregarPromocion(p3);
                e2.agregarPromocion(p4);
                Evento e3 = new Evento("Con_031", "Paseo Familiar a la playa", "Puntarenas, Puntarenas", c3, "images/playa.png", "Viaje");
                e3.agregarHorario(h2);
                e3.agregarHorario(h3);
                e3.agregarPromocion(p5);
                e3.agregarPromocion(p6);

                VariablesGlobales.listaEventos.Add(e1);
                VariablesGlobales.listaEventos.Add(e2);
                VariablesGlobales.listaEventos.Add(e3);

                VariablesGlobales.listaCategoria.Add(c1);
                VariablesGlobales.listaCategoria.Add(c2);
                VariablesGlobales.listaCategoria.Add(c3);

                Usuario u1 = new Usuario("meliguve06", "meli123", "Melissa", "Gutiérrez", new DateTime(1992, 11, 06), "meliguve06@gmail.com", "femenino", "Tacares", "24584206");
                Usuario u2 = new Usuario("armora10", "ariel123", "Ariel", "Mora", new DateTime(1992, 03, 21), "armora9221@gmail.com", "masculino", "Cartago", "22506889");
                Usuario u3 = new Usuario("lorvega", "lorena123", "Lorena", "Vega", new DateTime(1970, 10, 15), "lorvega14@gmail.com", "femenino", "Tacares", "24584206");
                Usuario u4 = new Usuario("nena", "nena123", "María Elena", "Zúñiga", new DateTime(1962, 08, 15), "nena@gmail.com", "femenino", "Buenos Aires", "24558092");
                Usuario u5 = new Usuario("julio", "julio123", "Andres", "Calderón", new DateTime(1992, 11, 15), "andres.ca1511@gmail.com", "masculino", "San José", "88689254");
                Usuario u6 = new Usuario("alguti17", "allan123", "Allan", "Gutiérrez", new DateTime(1987, 03, 17), "alguti17@gmail.com", "masculino", "Alajuela", "89874563");

                VariablesGlobales.listaUsuario.Add(u1);
                VariablesGlobales.listaUsuario.Add(u2);
                VariablesGlobales.listaUsuario.Add(u3);
                VariablesGlobales.listaUsuario.Add(u4);
                VariablesGlobales.listaUsuario.Add(u5);

                Administrador adm1 = new Administrador(u1);
                Administrador adm2 = new Administrador(u2);

                VariablesGlobales.listaAdministradores.Add(adm1);
                VariablesGlobales.listaAdministradores.Add(adm2);

                Cliente cli1 = new Cliente(u1);
                Cliente cli2 = new Cliente(u2);
                Cliente cli3 = new Cliente(u3);
                Cliente cli4 = new Cliente(u4);
                Cliente cli5 = new Cliente(u5);



                Tuple<Promocion, int, Horario> co1 = new Tuple<Promocion, int, Horario>(p1, 12, h1);
                Tuple<Promocion, int, Horario> co2 = new Tuple<Promocion, int, Horario>(p2, 5, h2);
                Tuple<Promocion, int, Horario> co3 = new Tuple<Promocion, int, Horario>(p3, 8, h3);
                Tuple<Promocion, int, Horario> co4 = new Tuple<Promocion, int, Horario>(p4, 1, h4);
                Tuple<Promocion, int, Horario> co5 = new Tuple<Promocion, int, Horario>(p5, 2, h2);
                Tuple<Promocion, int, Horario> co6 = new Tuple<Promocion, int, Horario>(p6, 5, h3);
                Tuple<Promocion, int, Horario> co7 = new Tuple<Promocion, int, Horario>(p6, 3, h4);
                Tuple<Promocion, int, Horario> co8 = new Tuple<Promocion, int, Horario>(p6, 1, h4);
                Tuple<Promocion, int, Horario> co9 = new Tuple<Promocion, int, Horario>(p3, 1, h1);
                Tuple<Promocion, int, Horario> co10 = new Tuple<Promocion, int, Horario>(p5, 4, h2);
                Tuple<Promocion, int, Horario> co11 = new Tuple<Promocion, int, Horario>(p3, 7, h2);
                Tuple<Promocion, int, Horario> co12 = new Tuple<Promocion, int, Horario>(p1, 8, h2);
                Tuple<Promocion, int, Horario> co13 = new Tuple<Promocion, int, Horario>(p3, 4, h4);
                Tuple<Promocion, int, Horario> co14 = new Tuple<Promocion, int, Horario>(p2, 2, h3);
                Tuple<Promocion, int, Horario> co15 = new Tuple<Promocion, int, Horario>(p5, 7, h3);
                Tuple<Promocion, int, Horario> co16 = new Tuple<Promocion, int, Horario>(p6, 9, h2);
                Tuple<Promocion, int, Horario> co17 = new Tuple<Promocion, int, Horario>(p6, 1, h2);
                Tuple<Promocion, int, Horario> co18 = new Tuple<Promocion, int, Horario>(p3, 4, h4);
                Tuple<Promocion, int, Horario> co19 = new Tuple<Promocion, int, Horario>(p6, 6, h3);
                Tuple<Promocion, int, Horario> co20 = new Tuple<Promocion, int, Horario>(p1, 3, h3);

                List<Tuple<Promocion, int, Horario>> com1 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com2 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com3 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com4 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com5 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com6 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com7 = new List<Tuple<Promocion, int, Horario>>();
                List<Tuple<Promocion, int, Horario>> com8 = new List<Tuple<Promocion, int, Horario>>();

                com1.Add(co1);
                com2.Add(co2);
                com3.Add(co3);
                com4.Add(co4);
                com5.Add(co5);
                com6.Add(co6);
                com6.Add(co7);
                com6.Add(co8);
                com8.Add(co9);
                com2.Add(co10);
                com3.Add(co11);
                com7.Add(co12);
                com1.Add(co13);
                com4.Add(co14);
                com7.Add(co15);
                com2.Add(co16);
                com1.Add(co17);
                com8.Add(co18);
                com1.Add(co19);
                com2.Add(co20);

                Compra lco1 = new Compra(1, com1, u1, DateTime.Now);
                Compra lco2 = new Compra(2, com2, u2, DateTime.Now);
                Compra lco3 = new Compra(3, com3, u1, DateTime.Now);
                Compra lco4 = new Compra(4, com4, u4, DateTime.Now);
                Compra lco5 = new Compra(5, com5, u2, DateTime.Now);
                Compra lco6 = new Compra(6, com6, u2, DateTime.Now);
                Compra lco7 = new Compra(7, com7, u1, DateTime.Now);
                Compra lco8 = new Compra(8, com8, u2, DateTime.Now);

                HistorialComprasUsuario hcc1 = new HistorialComprasUsuario(lco1);
                HistorialComprasUsuario hcc2 = new HistorialComprasUsuario(lco2);
                HistorialComprasUsuario hcc3 = new HistorialComprasUsuario(lco4);
                hcc1.agregarListaCompras(lco3);
                hcc1.agregarListaCompras(lco7);
                hcc2.agregarListaCompras(lco5);
                hcc2.agregarListaCompras(lco6);
                hcc2.agregarListaCompras(lco8);

                VariablesGlobales.listaHistorial.Add(hcc1);
                VariablesGlobales.listaHistorial.Add(hcc2);
                VariablesGlobales.listaHistorial.Add(hcc3);

                

                cli1.agregarPreferencia(c1);
                cli1.agregarPreferencia(c3);
                cli2.agregarPreferencia(c2);
                cli3.agregarPreferencia(c1);
                cli3.agregarPreferencia(c2);
                cli3.agregarPreferencia(c3);
                cli4.agregarPreferencia(c3);


                VariablesGlobales.listaCliente.Add(cli1);
                VariablesGlobales.listaCliente.Add(cli2);
                VariablesGlobales.listaCliente.Add(cli3);
                VariablesGlobales.listaCliente.Add(cli4);
                VariablesGlobales.listaCliente.Add(cli5);

                ObservableEvento obsE1 = (ObservableEvento)e1;
                obsE1.NotificarObservadores();
                ObservableEvento obsE2 = (ObservableEvento)e2;
                obsE2.NotificarObservadores();
                ObservableEvento obsE3 = (ObservableEvento)e3;
                obsE3.NotificarObservadores();

                List<String> lis = VariablesGlobales.listaCliente[0].getListaRecomendaciones();
                List<String> lis2 = VariablesGlobales.listaCliente[1].getListaRecomendaciones();
                List<String> lis3 = VariablesGlobales.listaCliente[2].getListaRecomendaciones();
                List<String> lis4 = VariablesGlobales.listaCliente[3].getListaRecomendaciones();
                List<String> lis5 = VariablesGlobales.listaCliente[4].getListaRecomendaciones();*/
            }
        }
    }
}