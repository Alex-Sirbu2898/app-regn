using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class CreateManagementHandler : IRequestHandler<CreateManagementCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateManagementHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(CreateManagementCommand request, CancellationToken cancellationToken)
        {
            string departmentAbbreviation = _dbContext.Divisions.Where(x => x.Id == request.DivisionId).Select(x => x.Abbreviation).FirstOrDefault();

            var staff = new Management()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                CNP = request.CNP,
                DivisionId = request.DivisionId,
                IdSeriesNumber = request.IdSeriesNumber,
                Salary = request.Salary,
            };
            IdGenerator idGenerator = new IdGenerator();
            staff.EmployeeId = idGenerator.ManagementIdValueGenerator(staff.Salary);

            await _dbContext.AddAsync(staff,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return staff.Id;
        }



    }


}

