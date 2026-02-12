using MediatR;
using Microsoft.EntityFrameworkCore;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Pedido.Queries;

public record GetPedidoByIdQuery(int Id) : IRequest<Padaria.Domain.Entities.Pedido?>
{
    public class GetPedidoByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetPedidoByIdQuery, Padaria.Domain.Entities.Pedido?>
    {
        public async Task<Padaria.Domain.Entities.Pedido?> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.Pedidos.Include(e => e.Produto).FirstOrDefaultAsync(p => p.Id == request.Id);
        }
    }
}
