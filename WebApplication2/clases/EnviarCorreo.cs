using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace WebApplication2.clases
{
    public class EnviarCorreo
    {
        public EnviarCorreo(String UsuarioDestino, int codigo)
        {
            MailMessage nuevoCorreo = new MailMessage();
            nuevoCorreo.From = new MailAddress("todoevento.cr2014@gmail.com");
            nuevoCorreo.To.Add(UsuarioDestino);
            nuevoCorreo.Subject = "Confirmación de compra en TodoEvento";
            nuevoCorreo.Body = "Gracias por realizar la compra en la plataforma Todo Evento. / Su código de confirmación es: " + Convert.ToString(codigo);
            nuevoCorreo.IsBodyHtml = false;
            nuevoCorreo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("todoevento.cr2014@gmail.com", "todoevento2014");

            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(nuevoCorreo);
                System.Console.Write("Correo Enviado");
            }
            catch
            {
                System.Console.Write("Correo noooooooooo enviado");
            }
            nuevoCorreo.Dispose();
        }
    }
}