
using AutoMapper;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class FilterEmployeeMapping : Profile
    {
        public FilterEmployeeMapping()
        {
            CreateMap<Employee, FilterEmployeeResponse>();
        }
    }
}
