using MediatR;
using Microsoft.EntityFrameworkCore;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Produto.Queries;

public record GetProdutoByIdQuery(int Id) : IRequest<Padaria.Domain.Entities.Produto?>
{
    public class GetProdutoByIdQueryHandler(IApplicationDbContext context) : IRequestHandler<GetProdutoByIdQuery, Padaria.Domain.Entities.Produto?>
    {
        public async Task<Padaria.Domain.Entities.Produto?> Handle(GetProdutoByIdQuery request, CancellationToken cancellationToken)
        {
            return await context.Produtos.FirstOrDefaultAsync(p => p.Id == request.Id);
        }
    }
}
