using DataAccessLayer.Entities;
using FluentValidation;

namespace DataAccessLayer.Validators
{
    public class AdvertisementValidator : AbstractValidator<Advertisement>
    {
        public AdvertisementValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter Description");
        }
    }
}
