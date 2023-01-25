using AutoMapper;
using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetAllHandler : IRequestHandler<GetAllQuery, GetAllResponse>
    {
        private readonly IStudentQueryService _studentQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllHandler(ApplicationDbContext dbContext, IStudentQueryService studentQueryService , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _studentQueryService = studentQueryService;
        }

        public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var student = _studentQueryService.GetAll();

            return _mapper.Map<GetAllResponse>(student);
        }
    }
}
