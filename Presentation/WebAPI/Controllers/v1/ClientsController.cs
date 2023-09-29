using Application.Exceptions;
using Application.Features.Clients.Commands.CreateClientCommand;
using Application.Features.Clients.Commands.DeleteClientCommand;
using Application.Features.Clients.Commands.UpdateClientCommand;
using Application.Features.Clients.Queries.GetClientByIdQuery;
using Application.Features.Clients.Queries.GetAllClientsQuery;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1;

[ApiVersion("1.0")]
public class ClientsController: BaseApiController
{
  [HttpGet("")]
  public async Task<IActionResult> GetById([FromQuery]GetAllClientParameters filter){
    return Ok(await Mediator.Send(new GetAllClientsQuery{
            FirstName = filter.FirstName, 
            LastName  = filter.LastName, 
            PageNumber  = filter.PageNumber, 
            PageSize  = filter.PageSize, 
          }));
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(int id){
    return Ok(await Mediator.Send(new GetClientByIdQuery{Id=id}));
  }

  [HttpPost]
  public async Task<IActionResult> Post(CreateClientCommand  cmd){
    return Ok(await Mediator.Send(cmd));
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Put(int id, UpdateClientCommand  cmd){
    if (id != cmd.Id)
      throw new ApiException("Id client difference");

    return Ok(await Mediator.Send(cmd));
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id){
    return Ok(await Mediator.Send(new DeleteClientCommand{ClientId=id}));
  }
}

