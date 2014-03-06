using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoI.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Cometario { get; set; }
        public string Fecha { get; set; }
    }
}