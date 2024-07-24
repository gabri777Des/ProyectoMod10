using Microsoft.EntityFrameworkCore;

namespace ProyectoMod10.Models
{
    public class ContextoDeDatos : DbContext
    {
        public ContextoDeDatos(DbContextOptions opciones) : base(opciones)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
    }
}
