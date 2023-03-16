using Microsoft.EntityFrameworkCore;

namespace WebApiAutores.Entidades
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autor> Autores { get; set; }
    }
}
