using Microsoft.EntityFrameworkCore;
using Padaria.Domain.Entities;

namespace Padaria.Application.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Pedido> Pedidos { get; }
    public DbSet<Produto> Produtos { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
