using MediatR;

namespace Regnology.Business
{
    public class DeleteStudentCommand : IRequest<int?>
    {
        public long Id { get; set; }

        public DeleteStudentCommand(long id)
        {
            Id = id;
        }
    }
}
