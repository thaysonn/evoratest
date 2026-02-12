using MediatR;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Pedido.Commands;

public record RemoverProdutoPedidoCommand(int IdPedido) : IRequest<int>
{
    public class RemoverProdutoCommandHandler(IApplicationDbContext context) : IRequestHandler<RemoverProdutoPedidoCommand, int>
    {
        public async Task<int> Handle(RemoverProdutoPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await context.Pedidos.FindAsync(new object[] { request.IdPedido }, cancellationToken);
            if (pedido is null)
                return 0;
            pedido.IdProduto = null;
            context.Pedidos.Update(pedido);
            await context.SaveChangesAsync(cancellationToken);
            return pedido.Id;
        }
    }
}



