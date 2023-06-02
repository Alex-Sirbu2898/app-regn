using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public interface IQueryService<T> : IFilter<T, FilterEmployeeQuery>
    {
        Task<T> GetById(long id,CancellationToken cancellationToken);
        IQueryable<T> GetAll();
    }
}
