using Regnology.Data;

namespace Regnology.Business
{
    public class GetByEmployeeIdResponse
    {
        public long Id { get; set; }
        public int NoOfUsedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeId { get; set; }
        public VacationStatus VacationStatus { get; set; }
    }
}
