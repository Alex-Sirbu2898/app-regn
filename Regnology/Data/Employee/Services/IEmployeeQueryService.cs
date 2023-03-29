using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public interface IEmployeeQueryService
    {
        Task<Employee> GetById(long id,CancellationToken cancellationToken);
        IQueryable<Employee> GetAll();
        IPagedList<Employee> Filter(FilterEmployeeQuery request);
    }
}
