namespace Regnology.Data
{
    public class Staff
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public float SalaryBeforeTax { get; set; }
        public int StartYear { get; set; }
        public string StaffId { get; set; }
        public int DepartmentId { get; set; }

        public virtual Division Department { get; set; }

    }
}
