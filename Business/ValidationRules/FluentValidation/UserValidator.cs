﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.FirstName).MaximumLength(60);
            RuleFor(u => u.LastName).NotEmpty();
            RuleFor(u => u.LastName).MaximumLength(60);
            RuleFor(u => u.LastName).MinimumLength(3);
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.Password).NotEmpty();
            RuleFor(u => u.Password).MaximumLength(50);
            RuleFor(u => u.Password).MinimumLength(5);

        }
    }
}
