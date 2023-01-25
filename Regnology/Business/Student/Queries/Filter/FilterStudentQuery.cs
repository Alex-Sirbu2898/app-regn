using MediatR;
using X.PagedList;

namespace Regnology.Business
{
    public class FilterStudentQuery : IRequest<PagedList<FilterStudentResponse>>
    {
        public string? SearchString { get; set; }
        public string? sortOrder { get; set; }
        public int? page { get; set; }

        public FilterStudentQuery(string sortOrder, string searchString, int? page)
        {
            this.SearchString = searchString;
            this.page = page;
            this.sortOrder = sortOrder;
        }
    }
}
