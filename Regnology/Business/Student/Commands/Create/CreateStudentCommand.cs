using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class CreateStudentCommand: IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public int MajorId { get; set; }
        public int EnrolmentYear { get; set; }

    }

    public sealed class CreateStudentResponse
    {
        public long Id { get; set; }
    }
}
