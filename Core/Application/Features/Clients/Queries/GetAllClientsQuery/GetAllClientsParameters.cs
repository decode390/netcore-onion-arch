using Application.Parameters;

namespace Application.Features.Clients.Queries.GetAllClientsQuery;

public class GetAllClientParameters: RequestParameters
{
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
}
