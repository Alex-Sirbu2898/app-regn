using AutoMapper;
using MediatR;
using Regnology.Data;
using X.PagedList;

namespace Regnology.Business
{
    public sealed class FilterEmployeeHandler : IRequestHandler<FilterEmployeeQuery, PagedList<FilterEmployeeResponse>>
    {
        private readonly IEmployeeQueryService _employeeQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FilterEmployeeHandler(ApplicationDbContext dbContext, IEmployeeQueryService employeeQueryService , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _employeeQueryService = employeeQueryService;
        }

        public async Task<PagedList<FilterEmployeeResponse>> Handle(FilterEmployeeQuery request,CancellationToken cancellationToken)
        {
            var pagedResult = _employeeQueryService.Filter(request);

            var mappedData = _mapper.Map<List<FilterEmployeeResponse>>(pagedResult);


            return new PagedList<FilterEmployeeResponse>(pagedResult,mappedData);
        }
    }
}
