using MediatR;

namespace Regnology.Business
{
    public class DeleteEmployeeCommand : IRequest<int?>
    {
        public long Id { get; set; }

        public DeleteEmployeeCommand(long id)
        {
            Id = id;
        }
    }
}
