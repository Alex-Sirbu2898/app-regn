using FluentValidation;

namespace Regnology.Business
{
    public sealed class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(item => item.RoleName).NotEmpty();
            RuleFor(item => item.RoleName).Matches(@"^[a-zA-Z-']$");
        }
    }
}
