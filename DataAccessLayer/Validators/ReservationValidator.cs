using DataAccessLayer.Entities;
using FluentValidation;

namespace DataAccessLayer.Validators
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator() 
        {
            RuleFor(x => x.TotalPrice).NotEmpty().WithMessage("Please enter TotalPrice");
        }

    }
}
