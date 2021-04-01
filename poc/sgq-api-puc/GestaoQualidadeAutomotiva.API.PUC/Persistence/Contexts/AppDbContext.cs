using GestaoQualidadeAutomotiva.API.PUC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoQualidadeAutomotiva.API.PUC.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Norma> Norma { get; set; }

    }
}
