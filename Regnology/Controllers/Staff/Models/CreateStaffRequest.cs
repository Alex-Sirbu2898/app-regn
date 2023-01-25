using Regnology.Data;

namespace Regnology.Controllers
{
    public class CreateStaffRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float SalaryBeforeTax { get; set; }
        public int StartYear { get; set; }
        public int DepartmentId { get; set; }
    }
}
