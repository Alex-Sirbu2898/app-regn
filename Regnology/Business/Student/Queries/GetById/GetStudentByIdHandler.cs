using AutoMapper;
using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery,GetStudentByIdResponse>
    {
        private readonly IStudentQueryService _studentQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetStudentByIdHandler(ApplicationDbContext dbContext, IStudentQueryService studentQueryService , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _studentQueryService = studentQueryService;
        }

        public async Task<GetStudentByIdResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student = await _studentQueryService.GetById(request.Id, cancellationToken);

            return _mapper.Map<GetStudentByIdResponse>(student);
        }
    }
}
