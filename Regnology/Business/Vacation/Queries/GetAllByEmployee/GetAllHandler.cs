using AutoMapper;
using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetAllByVacationIdHandler : IRequestHandler<GetAllVacationByEmployeeIdQuery, GetAllVacationsResponse>
    {
        private readonly VacationQueryService _vacationQueryService;
        private readonly IMapper _mapper;

        public GetAllByVacationIdHandler(VacationQueryService vacationQueryService, IMapper mapper)
        {
            _mapper = mapper;
            _vacationQueryService = vacationQueryService;
        }

        public async Task<GetAllVacationsResponse> Handle(GetAllVacationByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var vacation = _vacationQueryService.GetAllByEmployeeId(request.EmployeeId);

            return _mapper.Map<GetAllVacationsResponse>(vacation);
        }
    }
}
