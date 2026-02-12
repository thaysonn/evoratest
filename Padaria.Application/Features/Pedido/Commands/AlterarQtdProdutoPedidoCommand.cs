using MediatR;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Pedido.Commands;

public record AlterarQtdProdutoPedidoCommand(int Quantidade, int IdPedido) : IRequest<int>
{
    public class AlterarQtdProdutoPedidoCommandHandler(IApplicationDbContext context) : IRequestHandler<AlterarQtdProdutoPedidoCommand, int>
    {
        public async Task<int> Handle(AlterarQtdProdutoPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = await context.Pedidos.FindAsync(new object[] { request.IdPedido }, cancellationToken);
            if (pedido is null)
                return 0;
            pedido.Quantidade = request.Quantidade;
            context.Pedidos.Update(pedido);
            await context.SaveChangesAsync(cancellationToken);
            return pedido.Id;
        }
    }
}



