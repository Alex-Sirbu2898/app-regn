using Regnology.Data;

namespace Regnology.Controllers
{
    public class CreateStudentRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
        public int MajorId { get; set; }
        public int EnrolmentYear { get; set; }
    }
}
