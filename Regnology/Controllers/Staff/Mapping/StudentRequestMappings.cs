using AutoMapper;
using Regnology.Business;

namespace Regnology.Controllers
{
    public class StaffRequestMappings : Profile
    {
        public StaffRequestMappings()
        {
            CreateMap<CreateStaffRequest, CreateStaffCommand>();
        }
    }
}
