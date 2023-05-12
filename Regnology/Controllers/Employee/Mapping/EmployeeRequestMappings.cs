using AutoMapper;
using Regnology.Business;

namespace Regnology.Controllers
{
    public class EmployeeRequestMappings : Profile
    {
        public EmployeeRequestMappings()
        {
            CreateMap<CreateEmployeeRequest, CreateEmployeeCommand>();
            CreateMap<UpdateEmployeeRequest, UpdateEmployeeCommand>();
            CreateMap<FilterEmployeeRequest, FilterEmployeeQuery>();
        }
    }
}
