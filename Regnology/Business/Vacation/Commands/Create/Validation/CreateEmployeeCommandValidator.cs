using FluentValidation;

namespace Regnology.Business
{
    public sealed class CreateVacationCommandValidator : AbstractValidator<CreateVacationCommand>
    {
        public CreateVacationCommandValidator()
        {
        }
    }
}
