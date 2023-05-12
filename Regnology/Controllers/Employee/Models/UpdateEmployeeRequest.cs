using Regnology.Data;

namespace Regnology.Controllers
{
    public class UpdateEmployeeRequest
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
}
