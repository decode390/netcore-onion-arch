namespace Application.Parameters;

public class RequestParameters
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }

    public RequestParameters()
    {
      PageNumber = 1;
      PageSize = 10;
    }

    public RequestParameters(int PageNumber, int PageSize)
    {
      this.PageNumber = PageNumber < 1 ? 1 : PageNumber;
      this.PageSize = PageSize > 10 ? 10 : PageSize;
    }
}
