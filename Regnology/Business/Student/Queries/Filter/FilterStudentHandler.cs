using AutoMapper;
using MediatR;
using Regnology.Data;
using X.PagedList;

namespace Regnology.Business
{
    public sealed class FilterStudentHandler : IRequestHandler<FilterStudentQuery, PagedList<FilterStudentResponse>>
    {
        private readonly IStudentQueryService _studentQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public FilterStudentHandler(ApplicationDbContext dbContext, IStudentQueryService studentQueryService , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _studentQueryService = studentQueryService;
        }

        public async Task<PagedList<FilterStudentResponse>> Handle(FilterStudentQuery request,CancellationToken cancellationToken)
        {
            var pagedResult = _studentQueryService.Filter(request);

            var mappedData = _mapper.Map<List<FilterStudentResponse>>(pagedResult);


            return new PagedList<FilterStudentResponse>(pagedResult,mappedData);
        }
    }
}
