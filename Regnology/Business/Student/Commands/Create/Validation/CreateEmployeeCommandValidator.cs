using FluentValidation;

namespace Regnology.Business
{
    public sealed class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(item => item.FirstName).NotEmpty();
            RuleFor(item => item.LastName).NotEmpty();
            RuleFor(item => item.Address).NotEmpty();
            RuleFor(item => item.Address).Matches(@"^[a-zA-Z-']$");
        }
    }
}
