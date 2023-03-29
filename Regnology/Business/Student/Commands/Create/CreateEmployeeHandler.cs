using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateEmployeeHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            string majorAbbreviation = _dbContext.Divisions.Where(x => x.Id == request.DivisionId).Select(x => x.Abbreviation).FirstOrDefault();

            var employee = new Employee()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                CNP = request.CNP,
                IdSeriesNumber = request.IdSeriesNumber,
                DivisionId = request.DivisionId,
                ManagerId = request.ManagerId,
            };
            IdGenerator idGenerator = new IdGenerator();
            employee.EmployeeId = idGenerator.EmployeeIdValueGenerator(employee.DivisionId, (int)employee.Gender, majorAbbreviation);

            await _dbContext.AddAsync(employee,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }



    }


}

