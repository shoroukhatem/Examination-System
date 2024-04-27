using ExaminationSystem.Core.Features.User.Commands.Models;
using FluentValidation;

namespace ExaminationSystem.Core.Features.User.Commands.Validators
{
    public class AddUserValidator : AbstractValidator<AddUserCommandDto>
    {

        #region Constructors
        public AddUserValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            //Name Validations
            RuleFor(user => user.Name)
                .NotEmpty().WithMessage("Name Must Not Be Empty")
                .NotNull().WithMessage("Name Must Not Be NULL")
                .MaximumLength(20).WithMessage("Max Length is 20");
            //Email Validations
            RuleFor(user => user.Email)
                .NotEmpty().WithMessage("Email Must Not Be Empty")
                .NotNull().WithMessage("Email Must Not Be NULL")
                .EmailAddress();
            //password Validations
            RuleFor(user => user.Password)
               .NotEmpty().WithMessage("Password Must Not Be Empty")
               .NotNull().WithMessage("Password Must Not Be NULL");
            //ConfirmPassword Validations
            RuleFor(user => user.ConfirmPassword)
               .NotEmpty().WithMessage("Confirm Password Must Not Be Empty")
               .NotNull().WithMessage("Confirm Password Must Not Be NULL")
               .Equal(x => x.Password).WithMessage("ConfirmPassword does not Match Password");
            //Role Validations
            RuleFor(user => user.RoleName)
               .NotEmpty().WithMessage("RoleName Must Not Be Empty")
               .NotNull().WithMessage("RoleName Must Not Be NULL");
            RuleFor(user => user.IsAgree)
                .Equal(user => user.IsAgree == true).WithMessage("You Should Agree to The Terms and Conditions");

        }
        public void ApplyCustomValidationRules()
        {

        }
        #endregion
    }
}
