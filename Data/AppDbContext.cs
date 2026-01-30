using Microsoft.EntityFrameworkCore;
using Teste.Estagio.Models;

namespace Teste.Estagio.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<AnimeModel> Animes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}