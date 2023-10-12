
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetByEmployeeIdMapping : Profile
    {
        public GetByEmployeeIdMapping()
        {
            CreateMap<Vacation, GetByEmployeeIdResponse>();
        }
    }
}
