using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProyectoI.Models
{
    public class ComentarioDb : DbContext
    {
        public ComentarioDb()
            : base("DefaultConnection")
        { 
   
        }

        public DbSet<Comentario> Comentarios { get; set; }
    }
}