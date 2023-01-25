using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class CreateStaffCommand: IRequest<long>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float SalaryBeforeTax { get; set; }
        public int StartYear { get; set; }
        public int DepartmentId { get; set; }

    }

    public sealed class CreateStaffResponse
    {
        public long Id { get; set; }
    }
}
