using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class UrlValidator : AbstractValidator<Url>
    {
        public UrlValidator()
        {
            RuleFor(u => u.Adres)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Must(IsUrlValid).WithMessage("{PropertyName} Contains Invalid Characters");
        }

        protected bool IsUrlValid(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}

