using Microsoft.EntityFrameworkCore;
using FilmeRazor.Models;

namespace FilmeRazor
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> options)
            : base(options)
        {
        }
        public DbSet<Filme> Filmes { get; set; }
    }
}