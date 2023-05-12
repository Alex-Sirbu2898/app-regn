using AutoMapper;
using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery,GetEmployeeByIdResponse>
    {
        private readonly IQueryService<Employee> _employeeQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEmployeeByIdHandler(ApplicationDbContext dbContext, IQueryService<Employee> employeeQueryService , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _employeeQueryService = employeeQueryService;
        }

        public async Task<GetEmployeeByIdResponse> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _employeeQueryService.GetById(request.Id, cancellationToken);

            return _mapper.Map<GetEmployeeByIdResponse>(student);
        }
    }
}
