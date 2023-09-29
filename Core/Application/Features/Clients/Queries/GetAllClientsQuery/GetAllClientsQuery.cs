using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Clients.Queries.GetAllClientsQuery;

public class GetAllClientsQuery: IRequest<PagedResponse<IEnumerable<ClientDto>>>
{
  public string FirstName { get; set; }
  public string LastName { get; set; }
  public int PageNumber { get; set; }
  public int PageSize { get; set; }
}

public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, PagedResponse<IEnumerable<ClientDto>>>
{
    private readonly IRepositoryAsync<Client> _repositoryAsync;
    private readonly IMapper _mapper;

    public GetAllClientsQueryHandler(IRepositoryAsync<Client> repositoryAsync, IMapper mapper)
    {
        this._repositoryAsync = repositoryAsync;
        this._mapper = mapper;
    }

    public async Task<PagedResponse<IEnumerable<ClientDto>>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
    {
      IEnumerable<Client> clients = await _repositoryAsync.ListAsync(new PagedClientsSpecification(
            request.PageNumber,
            request.PageSize,
            request.FirstName,
            request.LastName
            ));

      IEnumerable<ClientDto> clientsDto = _mapper.Map<IEnumerable<ClientDto>>(clients);
      return new PagedResponse<IEnumerable<ClientDto>>(clientsDto, request.PageNumber, request.PageSize);
    }
}
