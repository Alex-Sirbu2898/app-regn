using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;

namespace Regnology.Business
{
    public class UpdateVacationHandler : IRequestHandler<UpdateVacationCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public UpdateVacationHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(UpdateVacationCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = await _dbContext.Vacations.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            dbEntity.StartDate = request.StartDate;
            dbEntity.EndDate = request.EndDate;
            dbEntity.NoOfUsedDays = request.NoOfUsedDays;
            dbEntity.VacationStatus = request.VacationStatus;
            _dbContext.Update(dbEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dbEntity.Id;
        }
    }
}
