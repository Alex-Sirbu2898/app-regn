using Regnology.Data;

namespace Regnology.Controllers
{
    public class CreateVacationRequest
    {
        public long Id { get; set; }
        public int NoOfUsedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeId { get; set; }
        public VacationStatus VacationStatus { get; set; }
    }
}
