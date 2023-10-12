using MediatR;

namespace Regnology.Business
{
    public class GetAllVacationByEmployeeIdQuery : IRequest<GetAllVacationsResponse>
    {
        public string EmployeeId { get; set; }
    }
}
