using MediatR;
using Microsoft.EntityFrameworkCore;
using Regnology.Data;

namespace Regnology.Business
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int?>
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public DeleteStudentHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int?> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
        {
            var student = await _applicationDbContext.Students.SingleOrDefaultAsync(x => x.Id == command.Id,cancellationToken);

            if (student == null)
                return -1;

            _applicationDbContext.Students.Remove(student);
            await _applicationDbContext.SaveChangesAsync();

            return 204;
        }
    }
}
