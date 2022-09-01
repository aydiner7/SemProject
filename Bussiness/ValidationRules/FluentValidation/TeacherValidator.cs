using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(u => u.TeacherName).MinimumLength(2).WithMessage("Geçersiz Öğretmen Adı");

            RuleFor(u => u.TeacherName).NotEmpty().WithMessage("HATAAAA");
            // RuleFor(u => u.UserLastName).MaximumLength(2).WithMessage("");

        }
    }

    
}
