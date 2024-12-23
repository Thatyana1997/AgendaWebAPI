using AgendaWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaWebAPI.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ContactoModel> Contactos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactoModel>()
                .HasKey(e => e.IdContacto); // Especifica la clave primaria
        }
    }
}
