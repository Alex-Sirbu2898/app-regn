using MediatR;

namespace Regnology.Business
{
    public class DeleteVacationCommand : IRequest<int?>
    {
        public long Id { get; set; }

        public DeleteVacationCommand(long id)
        {
            Id = id;
        }
    }
}
