using MediatR;
using Microsoft.EntityFrameworkCore;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Produto.Commands;

public record EditarProdutoCommand(int Id, string Name, string? Description, int Stock, decimal Price) : IRequest<int>
{
    public class EditarProdutoCommandHandler(IApplicationDbContext context) : IRequestHandler<EditarProdutoCommand, int>
    {
        public async Task<int> Handle(EditarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await context.Produtos.FindAsync(new object[] { request.Id }, cancellationToken);
            if (produto is null)
                return 0;
            produto.Name = request.Name;
            produto.Description = request.Description;
            produto.Stock = request.Stock;
            produto.Price = request.Price;

            context.Produtos.Update(produto);
            await context.SaveChangesAsync(cancellationToken);
            return produto.Id;
        }
    }
}

