using AutoMapper;
using Regnology.Business;

namespace Regnology.Controllers
{
    public class StudentRequestMappings : Profile
    {
        public StudentRequestMappings()
        {
            CreateMap<CreateStudentRequest, CreateStudentCommand>();
            CreateMap<UpdateStudentRequest, UpdateStudentCommand>();
            CreateMap<FilterStudentRequest, FilterStudentQuery>();
        }
    }
}
