using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class UpdateEmployeeCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public int DivisionId { get; set; }
        public int ManagerId { get; set; }

    }

    public sealed class UpdateStudentResponse
    {
        public long Id { get; set; }
    }
}
