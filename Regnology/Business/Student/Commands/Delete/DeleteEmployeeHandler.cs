using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;

namespace Regnology.Business
{
    public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, int?>
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public DeleteEmployeeHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int?> Handle(DeleteEmployeeCommand command, CancellationToken cancellationToken)
        {
            var employee = await _applicationDbContext.Employees.SingleOrDefaultAsync(x => x.Id == command.Id,cancellationToken);

            if (employee == null)
                return -1;

            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();

            return 204;
        }
    }
}
