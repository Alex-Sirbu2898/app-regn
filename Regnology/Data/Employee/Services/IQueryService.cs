using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public interface IQueryService<T>
    {
        Task<T> GetById(long id,CancellationToken cancellationToken);
        IQueryable<T> GetAll();
        IPagedList<T> Filter(FilterEmployeeQuery request);
    }
}
