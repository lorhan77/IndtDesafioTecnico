using IndtApi.Models;
using Microsoft.EntityFrameworkCore;

namespace IndtApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Usuarios> Usuarios{get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Usuarios>().HasData(
                    new Usuarios { Id = 1, Nome = "aaaaaa", Sobrenome = "bbbbbbbbb", Email = "aaaaaa@gmail.com", Senha = "12312", NivelDeAcesso = "Administrador" },
                    new Usuarios { Id = 2, Nome = "bbbbbb", Sobrenome = "ccccccccc", Email = "bbbbbb@gmail.com", Senha = "45678", NivelDeAcesso = "Comum" },
                    new Usuarios { Id = 3, Nome = "cccccc", Sobrenome = "ddddddddd", Email = "cccccc@gmail.com", Senha = "23123", NivelDeAcesso = "Comum" },
                    new Usuarios { Id = 4, Nome = "dddddd", Sobrenome = "eeeeeeeee", Email = "dddddd@gmail.com", Senha = "21312", NivelDeAcesso = "Comum" }
                    );

        }
    }
}
