using MediatR;

namespace Regnology.Business
{
    public class GetByEmployeeIdQuery : IRequest<GetByEmployeeIdResponse>
    {
        public long Id { get; set; }

        public GetByEmployeeIdQuery(long id)
        {
            Id = id;
        }
    }
}
