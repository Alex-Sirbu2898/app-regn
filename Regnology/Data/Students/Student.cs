namespace Regnology.Data
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int EnrolmentYear { get; set; }
        public string StudentId { get; set; }
        public int MajorId { get; set; }

        public virtual Division Major { get; set; }

    }
}
