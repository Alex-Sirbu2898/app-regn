using Regnology.Data;

namespace Regnology.Controllers
{
    public class FilterEmployeeRequest
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public string? EmployeeId { get; set; }
        public string? CNP { get; set; }
        public string? IdSeriesNumber { get; set; }
        public int DivisionId { get; set; }
        public string? ManagerId { get; set; }
        public int VacationDays { get; set; }
        public bool IsManagement { get; set; }
        public long RoleId { get; set; }
        public string? sortOrder { get; set; }
        public int? page { get; set; }
    }
}
