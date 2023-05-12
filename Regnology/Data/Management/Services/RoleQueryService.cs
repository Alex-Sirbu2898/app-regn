using Microsoft.EntityFrameworkCore;
using Regnology.Business;
using X.PagedList;

namespace Regnology.Data
{
    public sealed class RoleQueryService : IQueryService<Role>
    {
        private readonly ApplicationDbContext _context;

        public RoleQueryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        private IQueryable<Role> GetQuery()
        {
            return _context.Roles.AsNoTracking();
        }

       public async Task<Role> GetById(long id,CancellationToken cancellationToken)
        {
            return await GetQuery().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
        public IQueryable<Role> GetAll()
        {
            throw new NotImplementedException();
        }

        public IPagedList<Role> Filter(FilterEmployeeQuery request)
        {
            throw new NotImplementedException();
        }
    }
}
