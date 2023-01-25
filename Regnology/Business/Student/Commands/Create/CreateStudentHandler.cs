using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class CreateStudentHandler : IRequestHandler<CreateStudentCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateStudentHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            string majorAbbreviation = _dbContext.Divisions.Where(x => x.Id == request.MajorId).Select(x => x.Abbreviation).FirstOrDefault();

            var student = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                EnrolmentYear = request.EnrolmentYear,
                MajorId = request.MajorId,
            };
            IdGenerator idGenerator = new IdGenerator();
            student.StudentId = idGenerator.StudentIdValueGenerator(student.EnrolmentYear, (int)student.Gender, majorAbbreviation);

            await _dbContext.AddAsync(student,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return student.Id;
        }



    }


}

