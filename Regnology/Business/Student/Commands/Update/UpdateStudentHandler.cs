using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;

namespace Regnology.Business
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public UpdateStudentHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            string majorAbbreviation = _dbContext.Divisions.Where(x => x.Id == request.MajorId).Select(x => x.Abbreviation).First();

            var dbEntity = await _dbContext.Students.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            dbEntity.FirstName = request.FirstName;
            dbEntity.LastName = request.LastName;
            dbEntity.Address = request.Address;
            dbEntity.DateOfBirth = request.DateOfBirth;
            dbEntity.Gender = request.Gender;
            dbEntity.EnrolmentYear = request.EnrolmentYear;
            dbEntity.MajorId = request.MajorId;
            IdGenerator idGenerator = new IdGenerator();
            dbEntity.StudentId = idGenerator.StudentIdValueGenerator(dbEntity.EnrolmentYear, (int)dbEntity.Gender, majorAbbreviation);

            _dbContext.Update(dbEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dbEntity.Id;
        }
    }
}
