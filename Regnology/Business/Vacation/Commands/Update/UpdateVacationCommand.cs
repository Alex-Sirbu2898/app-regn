using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class UpdateVacationCommand : IRequest<long>
    {
        public long Id { get; set; }
        public int NoOfUsedDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public VacationStatus VacationStatus { get; set; }

    }

    public sealed class UpdateVacationResponse
    {
        public long Id { get; set; }
    }
}
