using FluentValidation;

namespace Regnology.Business
{
    public sealed class CreateStaffCommandValidator : AbstractValidator<CreateStaffCommand>
    {
        public CreateStaffCommandValidator()
        {
            RuleFor(item => item.FirstName).NotEmpty();
            RuleFor(item => item.LastName).NotEmpty();
            RuleFor(item => item.Address).NotEmpty();
            RuleFor(item => item.StartYear).NotEmpty().Must(x => x.ToString().Length == 4);
            RuleFor(item => item.Address).Matches(@"^[a-zA-Z-']$");
        }
    }
}
