using AutoMapper;
using Regnology.Business;

namespace Regnology.Controllers
{
    public class ManagementRequestMappings : Profile
    {
        public ManagementRequestMappings()
        {
            CreateMap<CreateManagementRequest, CreateRoleCommand>();
        }
    }
}
