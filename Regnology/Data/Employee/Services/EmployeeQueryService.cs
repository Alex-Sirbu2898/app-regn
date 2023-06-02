using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public sealed class EmployeeQueryService : IQueryService<Employee>
    {
        private readonly ApplicationDbContext _context;

        public EmployeeQueryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        private IQueryable<Employee> GetQuery()
        {
            return _context.Employees.AsNoTracking();
        }

        public async Task<Employee> GetById(long id, CancellationToken cancellationToken)
        {
            return await this.GetQuery().Include(x => x.Division).Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCount(CancellationToken cancellationToken)
        {
            return await this._context.Employees.CountAsync(cancellationToken);
        }

        public IQueryable<Employee> GetAll()
        {
            return GetQuery().Include(x => x.Division);
        }

        public IPagedList<Employee> Filter(FilterEmployeeQuery request)
        {
            var employee = GetQuery();
            if (!String.IsNullOrEmpty(request.FirstName))
            {
                employee = employee.Where(s =>
                           s.FirstName.Contains(request.FirstName));
            }

            if (!String.IsNullOrEmpty(request.LastName))
            {
                employee = employee.Where(s =>
                           s.LastName.Contains(request.LastName));
            }

            if (!String.IsNullOrEmpty(request.ManagerId))
            {
                employee = employee.Where(s =>
                           s.ManagerId == request.ManagerId);
            }

            if (request.RoleId > 0)
            {
                employee = employee.Where(s =>
                           s.RoleId == request.RoleId);
            }

            if (!String.IsNullOrEmpty(request.IdSeriesNumber))
            {
                employee = employee.Where(s =>
                           s.IdSeriesNumber.Contains(request.IdSeriesNumber));
            }
            switch (request.sortOrder)
            {

                case "firstName_desc":
                    employee = employee.OrderByDescending(s => s.FirstName);
                    break;
                case "FirstName":
                    employee = employee.OrderBy(s => s.FirstName);
                    break;
                case "lastName_desc":
                    employee = employee.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    employee = employee.OrderBy(s => s.DateOfBirth);
                    break;
                case "date_desc":
                    employee = employee.OrderByDescending(s => s.DateOfBirth);
                    break;
                default:
                    employee = employee.OrderBy(s => s.LastName);
                    break;
            }


            int pageSize = 100;
            int pageNumber = (request.page ?? 1);
            return employee.ToPagedList(pageNumber, pageSize);
        }
    }
}
