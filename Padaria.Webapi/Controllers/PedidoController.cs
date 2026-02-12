using MediatR;
using Microsoft.AspNetCore.Mvc;
using Padaria.Application.Features.Pedido.Commands;
using Padaria.Application.Features.Pedido.Queries;
using Padaria.Application.Features.Produto.Commands;
using Padaria.Application.Features.Produto.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Padaria.Webapi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PedidoController(ISender mediator) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await mediator.Send(new GetPedidoByIdQuery(id)));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CadastrarPedidoCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] IncluirProdutoPedidoCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        return Ok(await mediator.Send(new RemoverProdutoPedidoCommand(id)));
    }
}
