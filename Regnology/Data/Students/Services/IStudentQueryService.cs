using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public interface IStudentQueryService
    {
        Task<Student> GetById(long id,CancellationToken cancellationToken);
        IQueryable<Student> GetAll();
        IPagedList<Student> Filter(FilterStudentQuery request);
    }
}
