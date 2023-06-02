namespace Regnology.Data
{
    public class Employee
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int Salary { get; set; }
        public string EmployeeId { get; set; }
        public string CNP { get; set; }
        public string IdSeriesNumber { get; set; }
        public int DivisionId { get; set; }
        public string? ManagerId { get; set; }
        public int VacationDays { get; set; }
        public int DivisionId2 { get; set; }
        public int ManagerId2 { get; set; }
        public int VacationDays2 { get; set; }
        public bool IsManagement { get; set; }
        public long? RoleId { get; set; }
        public DateTime? DateOfHire { get; set; }

        public virtual Division Division { get; set; }
        public virtual IList<Employee> Subordinates { get; set; }
        public virtual Role Role { get; set; }
        public virtual IList<Vacation> VacationRequests { get; set; }

    }
}
