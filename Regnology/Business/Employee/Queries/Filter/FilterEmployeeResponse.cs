using Regnology.Data;

namespace Regnology.Business
{
    public class FilterEmployeeResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string EmployeeId { get; set; }
        public int DivisionId { get; set; }
    }
}
