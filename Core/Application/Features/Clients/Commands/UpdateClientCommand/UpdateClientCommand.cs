using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Commands.UpdateClientCommand;

public class UpdateClientCommand: IRequest<Response<int>>
{
  public int Id { get; set; }
  public string? FirstName { get; set; } 
  public string? LastName { get; set; } 
  public DateTime BirthDate { get; set; }
  public string? Phone { get; set; }
  public string? Email { get; set; }
  public string? Address { get; set; }
}

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<int>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;
    private readonly IMapper _mapper;

    public UpdateClientCommandHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<int>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
      Client foundClient = await _repositoryAsync.GetByIdAsync(request.Id);
      if (foundClient == null)
        throw new KeyNotFoundException("Client not found");

      foundClient.FirstName = request.FirstName;
      foundClient.LastName = request.LastName;
      foundClient.BirthDate = request.BirthDate;
      foundClient.Phone = request.Phone;
      foundClient.Email = request.Email;
      foundClient.Address = request.Address;

      await _repositoryAsync.UpdateAsync(foundClient);
      return new Response<int>(foundClient.Id);
    }
}


