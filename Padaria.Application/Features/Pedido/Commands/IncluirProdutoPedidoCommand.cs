using MediatR;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Pedido.Commands;

public record IncluirProdutoPedidoCommand(int IdProduto, int IdPedido) : IRequest<int>
{
    public class IncluirProdutoPedidoCommandHandler(IApplicationDbContext context) : IRequestHandler<IncluirProdutoPedidoCommand, int>
    {
        public async Task<int> Handle(IncluirProdutoPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await context.Pedidos.FindAsync(new object[] { request.IdPedido }, cancellationToken);
            if (pedido is null)
                return 0;
            pedido.IdProduto = request.IdProduto;
            context.Pedidos.Update(pedido);
            await context.SaveChangesAsync(cancellationToken);
            return pedido.Id;
        }
    }
}



