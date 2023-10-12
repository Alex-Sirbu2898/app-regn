using AutoMapper;
using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetByEmployeeIdHandler : IRequestHandler<GetByEmployeeIdQuery,GetByEmployeeIdResponse>
    {
        private readonly VacationQueryService _vacationQueryService;
        private readonly IMapper _mapper;

        public GetByEmployeeIdHandler(VacationQueryService vacationQueryService, IMapper mapper)
        {
            _mapper = mapper;
            _vacationQueryService = vacationQueryService;
        }

        public async Task<GetByEmployeeIdResponse> Handle(GetByEmployeeIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _vacationQueryService.GetById(request.Id, cancellationToken);

            return _mapper.Map<GetByEmployeeIdResponse>(student);
        }
    }
}
