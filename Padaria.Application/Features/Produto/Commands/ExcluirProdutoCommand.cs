using MediatR;
using Microsoft.EntityFrameworkCore;
using Padaria.Application.Interfaces;

namespace Padaria.Application.Features.Produto.Commands;

public record ExcluirProdutoCommand(int Id) : IRequest<bool>
{
    public class ExcluirProdutoCommandHandler(IApplicationDbContext context) : IRequestHandler<ExcluirProdutoCommand, bool>
    {
        public async Task<bool> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await context.Produtos.FindAsync(new object[] { request.Id }, cancellationToken);
            if (produto is null)
                return false;
            context.Produtos.Remove(produto);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}

