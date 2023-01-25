using MediatR;

namespace Regnology.Business
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdResponse>
    {
        public long Id { get; set; }

        public GetStudentByIdQuery(long id)
        {
            Id = id;
        }
    }
}
