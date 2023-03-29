using FluentValidation;

namespace Regnology.Business
{
    public sealed class CreateStaffCommandValidator : AbstractValidator<CreateManagementCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(item => item.FirstName).NotEmpty();
            RuleFor(item => item.LastName).NotEmpty();
            RuleFor(item => item.Address).NotEmpty();
            RuleFor(item => item.Address).Matches(@"^[a-zA-Z-']$");
        }
    }
}
