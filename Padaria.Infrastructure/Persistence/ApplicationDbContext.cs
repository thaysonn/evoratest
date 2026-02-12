using Microsoft.EntityFrameworkCore;
using Padaria.Application.Interfaces;
using Padaria.Domain.Entities;

namespace Padaria.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
        base(options)
    {            
    }

    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
