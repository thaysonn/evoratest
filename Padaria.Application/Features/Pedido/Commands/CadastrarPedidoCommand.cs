using MediatR;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Pedido.Commands;

public record CadastrarPedidoCommand(int IdProduto, int Quantidade) : IRequest<int>
{
    public class CadastrarPedidoCommandHandler(IApplicationDbContext context) : IRequestHandler<CadastrarPedidoCommand, int>
    {
        public async Task<int> Handle(CadastrarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Padaria.Domain.Entities.Pedido
            {
                IdProduto = request.IdProduto,
                Quantidade = request.Quantidade,
                Status = "Iniciado"
            };

            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync(cancellationToken);
            return pedido.Id;
        }
    }
}