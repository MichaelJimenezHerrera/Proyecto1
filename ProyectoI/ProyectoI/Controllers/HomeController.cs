using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using ProyectoI.Models;
namespace ProyectoI.Controllers
{
    public class HomeController : Controller
    {
        private ComentarioDb db = new ComentarioDb();
        //
        // GET: /Home/

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Contact(string nombre = "", string email = "", string contraseña = "", string asunto = "", string comentario = "")
        {
                   //datos del mensaje y el correo al que le vamos a enviar el mensaje
            System.Net.Mail.MailMessage mmsg = new System.Net.Mail.MailMessage();//Creamos un nuevo Objeto para el mensaje mmsg
           
            mmsg.To.Add("michaeljimenezh@hotmail.com");//Direccion de correo electronico a la que queremos enviar el mensaje//con To nos permite enviar mensajes a mas de un correo
            
            mmsg.Subject = asunto;//Asunto del correo
            mmsg.SubjectEncoding = System.Text.Encoding.UTF8;

            //mmsg.Bcc.Add("michaeljimenezh@hotmail.com"); para enviar una copia del correo si queremos
           
            mmsg.Body = comentario;//El mensaje que vamos a enviar
            mmsg.BodyEncoding = System.Text.Encoding.UTF8;
            mmsg.IsBodyHtml = false; //Si no queremos que se envíe como HTML
            
            mmsg.From = new System.Net.Mail.MailAddress(email);//Correo electronico desde la que enviamos el mensaje

            //Aqui van los datos del que va a enviar el mensaje
            
            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();//Creamos un objeto de cliente de correo
            
            cliente.Credentials =
                new System.Net.NetworkCredential(email,contraseña);//Hay que crear las credenciales del correo que envia el mensaje

            
            cliente.Port = 587;//esto es obligatorio si enviamos el mensaje desde Gmail
            cliente.EnableSsl = true;//esto es obligatorio si enviamos el mensaje desde Gmail


            cliente.Host = "smtp.gmail.com"; 
            //cliente.Host = "smtp.hotmail.com"; 

            // y enviamos nuestro correo

            try
            {
                    
                cliente.Send(mmsg);//Enviamos el mensaje  
            }
            catch (System.Net.Mail.SmtpException ex)
            {

               // aqui todos los erros al no poder enviar el correo
            }
            return View();
        }





        public ActionResult Recommendations()
        {
            List<Comentario> comentarios = db.Comentarios.ToList();
            ViewBag.comentarios = comentarios;
            return View();
        }

        public ActionResult Recommend()
        {
            return View();
        }

       [HttpPost]
        public ActionResult Recommend(string nombre = "", string comentario = "")
        {
            DateTime Hoy = DateTime.Now;
            string fecha = Hoy.ToString("d/M/yyyy hh:mm:ss tt"); 
            Comentario nueva = new Comentario();
            nueva.Nombre = nombre;
            nueva.Cometario = comentario;
            nueva. Fecha=fecha ;
            if (ModelState.IsValid)
            {
                db.Comentarios.Add(nueva);
                db.SaveChanges();
               
            }
            return View();
        }
    }
}
