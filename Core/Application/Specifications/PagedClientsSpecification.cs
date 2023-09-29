using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications;

public class PagedClientsSpecification: Specification<Client>
{
   public PagedClientsSpecification(int pageNumber, int pageSize, string firstName, string lastName)
   {
     Query.Skip((pageNumber-1) * pageSize)
       .Take(pageSize);

     if (!string.IsNullOrEmpty(firstName))
       Query.Search(x => x.FirstName, $"%{firstName}%");

     if (!string.IsNullOrEmpty(lastName))
       Query.Search(x => x.LastName, $"%{lastName}%");
   }
}
