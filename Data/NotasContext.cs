using Microsoft.EntityFrameworkCore;
using BACKEND.Models;

namespace BACKEND.Data{
    public class NotasContext : DbContext{
        public NotasContext (DbContextOptions<NotasContext> options): base(options)
        {

        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Nota> Notas { get; set; }
    }
}