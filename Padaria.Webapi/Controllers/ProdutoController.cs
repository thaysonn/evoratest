using MediatR;
using Microsoft.AspNetCore.Mvc;
using Padaria.Application.Features.Produto.Commands;
using Padaria.Application.Features.Produto.Queries;

namespace Padaria.Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController(ISender mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await mediator.Send(new GetProdutoByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CadastrarProdutoCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] EditarProdutoCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await mediator.Send(new ExcluirProdutoCommand(id)));
    }
}
