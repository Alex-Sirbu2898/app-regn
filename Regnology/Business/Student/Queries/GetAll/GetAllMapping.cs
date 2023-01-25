
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetAllMapping : Profile
    {
        public GetAllMapping()
        {
            CreateMap<Student, GetAllResponse>();
        }
    }
}
