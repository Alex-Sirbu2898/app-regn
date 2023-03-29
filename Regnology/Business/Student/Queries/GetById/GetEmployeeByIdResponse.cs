using Regnology.Data;

namespace Regnology.Business
{
    public class GetEmployeeByIdResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public string EmployeeId { get; set; }
        public int DivisionId { get; set; }
        public string DivisionAbbreviation { get; set; }
    }
}
