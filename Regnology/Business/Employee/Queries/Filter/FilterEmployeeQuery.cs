using MediatR;
using X.PagedList;

namespace Regnology.Business
{
    public class FilterEmployeeQuery : IRequest<PagedList<FilterEmployeeResponse>>
    {
        public string? SearchString { get; set; }
        public string? sortOrder { get; set; }
        public int? page { get; set; }

        public FilterEmployeeQuery(string sortOrder, string searchString, int? page)
        {
            this.SearchString = searchString;
            this.page = page;
            this.sortOrder = sortOrder;
        }
    }
}
