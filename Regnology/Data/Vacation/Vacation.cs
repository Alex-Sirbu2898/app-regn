namespace Regnology.Data
{
    public class Vacation
    {
        public long Id { get; set; }
        public int NoOfUsedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long EmployeeId { get; set; }
        public VacationStatus VacationStatus { get; set; }
        
        public virtual Employee Employee { get; set; }
    }
}
