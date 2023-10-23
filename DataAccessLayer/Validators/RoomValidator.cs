using DataAccessLayer.Entities;
using FluentValidation;

namespace DATAlayer.Validators
{
    public class RoomValidator : AbstractValidator<Room>
    {
        public RoomValidator() 
        {
            RuleFor(x=>x.RoomName).NotEmpty().WithMessage("enter room name");
        }
    }
}
