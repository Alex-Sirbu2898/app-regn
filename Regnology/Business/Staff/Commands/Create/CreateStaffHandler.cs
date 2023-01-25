using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class CreateStaffHandler : IRequestHandler<CreateStaffCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateStaffHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(CreateStaffCommand request, CancellationToken cancellationToken)
        {
            string departmentAbbreviation = _dbContext.Divisions.Where(x => x.Id == request.DepartmentId).Select(x => x.Abbreviation).FirstOrDefault();

            var staff = new Staff()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                StartYear = request.StartYear,
                DepartmentId = request.DepartmentId,
                SalaryBeforeTax = request.SalaryBeforeTax,
            };
            IdGenerator idGenerator = new IdGenerator();
            staff.StaffId = idGenerator.StaffIdValueGenerator(staff.StartYear);

            await _dbContext.AddAsync(staff,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return staff.Id;
        }



    }


}

