using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class CreateVacationCommand: IRequest<long>
    {
        public int NoOfUsedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string EmployeeId { get; set; }
        public VacationStatus VacationStatus { get; set; }

    }

    public sealed class CreateVacationResponse
    {
        public long Id { get; set; }
    }
}
