using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;

namespace Regnology.Business
{
    public class DeleteVacationHandler : IRequestHandler<DeleteVacationCommand, int?>
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public DeleteVacationHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int?> Handle(DeleteVacationCommand command, CancellationToken cancellationToken)
        {
            var vacation = await _applicationDbContext.Vacations.SingleOrDefaultAsync(x => x.Id == command.Id,cancellationToken);

            if (vacation == null)
                return -1;

            _applicationDbContext.Vacations.Remove(vacation);
            await _applicationDbContext.SaveChangesAsync();

            return 204;
        }
    }
}
