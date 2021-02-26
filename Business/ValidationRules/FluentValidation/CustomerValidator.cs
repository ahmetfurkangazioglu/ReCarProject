using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class CustomerValidator:AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MaximumLength(100).WithMessage("Şiret ismi 100 karakterden fazla olamaz");
            RuleFor(c => c.CompanyName).MinimumLength(3);
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
