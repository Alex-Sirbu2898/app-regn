using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public sealed class VacationQueryService : IQueryService<Vacation>
    {
        private readonly ApplicationDbContext _context;

        public VacationQueryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        private IQueryable<Vacation> GetQuery()
        {
            return _context.Vacations.AsNoTracking();
        }

        public async Task<Vacation> GetById(long id, CancellationToken cancellationToken)
        {
            return await GetQuery().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCount(CancellationToken cancellationToken)
        {
            return await this._context.Employees.CountAsync(cancellationToken);
        }

        public IQueryable<Vacation> GetAll()
        {
            return GetQuery().Include(x => x.Employee);
        }

        public IPagedList<Vacation> Filter(FilterEmployeeQuery request)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Vacation> GetAllByEmployeeId(string employeeId)
        {
            return GetQuery().Where(x => x.EmployeeId == employeeId);
        }
    }
}
