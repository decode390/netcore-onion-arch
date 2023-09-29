using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Queries.GetClientByIdQuery;

public class GetClientByIdQuery: IRequest<Response<ClientDto>>
{
  public int Id { get; set; }
}

public class GetClientByIdHandler : IRequestHandler<GetClientByIdQuery, Response<ClientDto>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetClientByIdHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
    {
        _repositoryAsync = repositoryAsync;
        _mapper = mapper;
    }

    public async Task<Response<ClientDto>> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
      Client client = await _repositoryAsync.GetByIdAsync(request.Id);
      if (client == null)
        throw new KeyNotFoundException("Client not found");

      ClientDto clientDto = _mapper.Map<ClientDto>(client);
      return new Response<ClientDto>(clientDto);
    }
}

