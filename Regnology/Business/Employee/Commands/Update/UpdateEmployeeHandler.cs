using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;

namespace Regnology.Business
{
    public class UpdateEmployeeHandler : IRequestHandler<UpdateEmployeeCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public UpdateEmployeeHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            string majorAbbreviation = _dbContext.Divisions.Where(x => x.Id == request.DivisionId).Select(x => x.Abbreviation).First();

            var dbEntity = await _dbContext.Employees.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            dbEntity.FirstName = request.FirstName;
            dbEntity.LastName = request.LastName;
            dbEntity.Address = request.Address;
            dbEntity.DateOfBirth = request.DateOfBirth;
            dbEntity.Gender = request.Gender;
            dbEntity.ManagerId = request.ManagerId;
            dbEntity.DivisionId = request.DivisionId;
            IdGenerator idGenerator = new IdGenerator();
            dbEntity.EmployeeId = idGenerator.EmployeeIdValueGenerator(dbEntity.DivisionId, (int)dbEntity.Gender, majorAbbreviation);

            _dbContext.Update(dbEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dbEntity.Id;
        }
    }
}
