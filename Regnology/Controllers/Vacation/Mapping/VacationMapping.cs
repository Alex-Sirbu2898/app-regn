using AutoMapper;
using Regnology.Business;

namespace Regnology.Controllers.Vacation.Mapping
{
    public class VacationMapping : Profile
    {
        public VacationMapping()
        {
            CreateMap<CreateVacationRequest, CreateVacationCommand>();
        }
    }
}
