using ExaminationSystem.Core.Features.User.Commands.Models;
using FluentValidation;

namespace ExaminationSystem.Core.Features.User.Commands.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommandDto>
    {

        #region Constructors
        public SignInValidator()
        {
            ApplyValidationRules();

        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {

            //Email Validations
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email Must Not Be Empty")
                .NotNull().WithMessage("Email Must Not Be NULL")
                .EmailAddress();
            //password Validations
            RuleFor(user => user.Password)
               .NotEmpty().WithMessage("Password Must Not Be Empty")
               .NotNull().WithMessage("Password Must Not Be NULL");

        }
        #endregion
    }
}
