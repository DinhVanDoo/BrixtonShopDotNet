using Brixton.Models;
using FluentValidation;

namespace Brixton.Validator
{
    public class AccountValidate : AbstractValidator<AccountModel>
    {
        public AccountValidate()
        {
            RuleFor(model => model.AccId)
                .NotEmpty().WithMessage("Please enter your user name")
                .Length(6, 15).WithMessage("Username must be between 6 and 15 characters.")
                .Matches(@"^[a-zA-Z0-9]{6,15}$").WithMessage("Username invalid");

            RuleFor(model => model.UserName)
                .NotEmpty().WithMessage("Name is required.")
                .Matches(@"^[a-zA-Z ]+$").WithMessage("Invalid Name");

            RuleFor(model => model.UserAddress)
                .NotEmpty().WithMessage("Address is required.")
                .Matches(@"^[a-zA-Z0-9\s]+$").WithMessage("Invalid Address");
            RuleFor(model => model.UserPhone)
                .NotEmpty().WithMessage("Phone is required.")
                .Matches(@"^(0\d{9,10})$").WithMessage("Invalid phone number");

        }
    }
}
