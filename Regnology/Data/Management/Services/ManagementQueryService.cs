using Microsoft.EntityFrameworkCore;
using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public sealed class ManagementQueryService : IEmployeeQueryService
    {
        private readonly ApplicationDbContext _context;

        public ManagementQueryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        private IQueryable<Management> GetQuery()
        {
            return _context.Management.AsNoTracking();
        }

       public async Task<Management> GetById(long id,CancellationToken cancellationToken)
        {
            return await GetQuery().Include(x => x.Division).Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCount(CancellationToken cancellationToken)
        {
            return await _context.Employees.CountAsync(cancellationToken);
        }

        Task<Employee> IEmployeeQueryService.GetById(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public IPagedList<Employee> Filter(FilterEmployeeQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
