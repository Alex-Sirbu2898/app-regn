using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public class CreateRoleCommand: IRequest<long>
    {
        public string RoleName { get; set; }

    }

    public sealed class CreateStaffResponse
    {
        public long Id { get; set; }
    }
}
