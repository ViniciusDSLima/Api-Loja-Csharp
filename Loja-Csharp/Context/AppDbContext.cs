using Loja_Csharp.Models;
using Microsoft.EntityFrameworkCore;

namespace Loja_Csharp.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<Categoria> Categorias { get; private set; }
    public DbSet<Produto> Produtos { get; private set; }
}