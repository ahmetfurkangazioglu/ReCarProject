using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public  class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(3);
            RuleFor(c => c.CarName).MaximumLength(100).WithMessage("Araba ismi 100 karakteri geçemez.");
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(1700).WithMessage("Arabanın model yılı 1700'den küçük olamaz.");
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(50);
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c => c.Description).MaximumLength(350).WithMessage("Arabanın açıklaması 350 karakterden fazla olamaz.");

            
        }
    }
}
