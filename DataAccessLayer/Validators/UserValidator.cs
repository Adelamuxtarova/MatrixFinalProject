using DataAccessLayer.Entities;
using FluentValidation;

namespace DATAlayer.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Please enter your Name");
        }

    }
}
