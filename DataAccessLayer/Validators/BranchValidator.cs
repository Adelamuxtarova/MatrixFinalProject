using DataAccessLayer.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Validators
{
    public class BranchValidator : AbstractValidator<Branch>
    {
        public BranchValidator()
        {
            RuleFor(x => x.BranchName).NotEmpty().WithMessage("Please enter Name");
        }
    }
}
