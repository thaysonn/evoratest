using MediatR;
using Microsoft.EntityFrameworkCore;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Produto.Commands;

public record CadastrarProdutoCommand(string Name, string? Description, int Stock, decimal Price) : IRequest<int>
{
    public class CadatrarProdutoCommandHandler(IApplicationDbContext context) : IRequestHandler<CadastrarProdutoCommand, int>
    {
        public async Task<int> Handle(CadastrarProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = new Padaria.Domain.Entities.Produto
            {
                Name = request.Name,
                Description = request.Description,
                Stock = request.Stock,
                Price = request.Price
            };
            context.Produtos.Add(produto);
            await context.SaveChangesAsync(cancellationToken);
            return produto.Id;
        }
    }
}