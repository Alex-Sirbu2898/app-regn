
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetStudentByIdMapping : Profile
    {
        public GetStudentByIdMapping()
        {
            CreateMap<Student, GetStudentByIdResponse>()
                .ForMember(x => x.MajorAbbreviation, y => y.MapFrom(z => z.Major.Abbreviation));
        }
    }
}
