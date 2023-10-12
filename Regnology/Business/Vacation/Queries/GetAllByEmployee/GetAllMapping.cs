
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetAllByEmployeeIdMapping : Profile
    {
        public GetAllByEmployeeIdMapping()
        {
            CreateMap<Vacation, GetAllVacationsResponse>();
        }
    }
}
