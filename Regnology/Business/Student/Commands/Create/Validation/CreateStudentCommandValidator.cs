using FluentValidation;

namespace Regnology.Business
{
    public sealed class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(item => item.FirstName).NotEmpty();
            RuleFor(item => item.LastName).NotEmpty();
            RuleFor(item => item.Address).NotEmpty();
            RuleFor(item => item.EnrolmentYear).LessThanOrEqualTo(4).GreaterThan(0);
            RuleFor(item => item.Address).Matches(@"^[a-zA-Z-']$");
        }
    }
}
