using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class CreateVacationHandler : IRequestHandler<CreateVacationCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateVacationHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(CreateVacationCommand request, CancellationToken cancellationToken)
        {

            var employee = new Vacation()
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                EmployeeId = request.EmployeeId,    
                NoOfUsedDays = request.NoOfUsedDays,
                VacationStatus = VacationStatus.PENDING
            };
            await _dbContext.AddAsync(employee,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return employee.Id;
        }



    }


}

