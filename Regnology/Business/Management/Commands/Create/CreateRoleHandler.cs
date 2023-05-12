using MediatR;
using Regnology.Data;

namespace Regnology.Business
{
    public sealed class CreateRoleHandler : IRequestHandler<CreateRoleCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateRoleHandler(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        public async Task<long> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new Role()
            {
                RoleName = request.RoleName
            };

            await _dbContext.AddAsync(role,cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return role.Id;
        }



    }


}

