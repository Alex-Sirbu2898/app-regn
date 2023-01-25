
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class FilterStudentMapping : Profile
    {
        public FilterStudentMapping()
        {
            CreateMap<Student, FilterStudentResponse>();
        }
    }
}
