using AutoMapper;
using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetAllHandler : IRequestHandler<GetAllQuery, GetAllResponse>
    {
        private readonly IEmployeeQueryService _employeeQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllHandler(ApplicationDbContext dbContext, IEmployeeQueryService employeeQueryService , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _employeeQueryService = employeeQueryService;
        }

        public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var employee = _employeeQueryService.GetAll();

            return _mapper.Map<GetAllResponse>(employee);
        }
    }
}
