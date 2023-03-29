using MediatR;

namespace Regnology.Business
{
    public class GetEmployeeByIdQuery : IRequest<GetEmployeeByIdResponse>
    {
        public long Id { get; set; }

        public GetEmployeeByIdQuery(long id)
        {
            Id = id;
        }
    }
}
