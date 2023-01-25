using Microsoft.EntityFrameworkCore;

namespace Regnology.Data
{
    public sealed class StaffQueryService : IStaffQueryService
    {
        private readonly ApplicationDbContext _context;

        public StaffQueryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        private IQueryable<Staff> GetQuery()
        {
            return _context.Staffs.AsNoTracking();
        }

       public async Task<Staff> GetById(long id,CancellationToken cancellationToken)
        {
            return await GetQuery().Include(x => x.Department).Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCount(CancellationToken cancellationToken)
        {
            return await _context.Students.CountAsync(cancellationToken);
        }
    }
}
