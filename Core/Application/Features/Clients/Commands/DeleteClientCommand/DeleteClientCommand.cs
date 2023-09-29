using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.DeleteClientCommand;

public class DeleteClientCommand: IRequest<Response<int>>
{
   public int? ClientId { get; set; }
}

public class DeleteClientCommandHandler: IRequestHandler<DeleteClientCommand, Response<int>>
{
  private readonly IRepositoryAsync<Client> _repositoryAsync;
  private readonly IMapper _mapper;

  public DeleteClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
  {
      _repositoryAsync = repositoryAsync;
      _mapper = mapper;
  }

  public async Task<Response<int>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
  {
    var client = await _repositoryAsync.GetByIdAsync(id: request.ClientId);
    if (client == null)
      throw new KeyNotFoundException("Client not found");

    await _repositoryAsync.DeleteAsync(client);
    return new Response<int>(client.Id);
  }
}

