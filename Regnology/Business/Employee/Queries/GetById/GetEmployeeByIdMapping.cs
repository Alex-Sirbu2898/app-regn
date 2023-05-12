
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class GetEmployeeByIdMapping : Profile
    {
        public GetEmployeeByIdMapping()
        {
            CreateMap<Employee, GetEmployeeByIdResponse>()
                .ForMember(x => x.DivisionAbbreviation, y => y.MapFrom(z => z.Division.Abbreviation));
        }
    }
}
