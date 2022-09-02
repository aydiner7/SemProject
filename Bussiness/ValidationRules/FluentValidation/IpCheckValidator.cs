using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Bussiness.ValidationRules.FluentValidation
{
    public class IpCheckValidator : AbstractValidator<IpCheck>
    {
        public IpCheckValidator()
        {
            RuleFor(u => u.IpAdres)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Must(IsIPValid).WithMessage("{PropertyName} Contains Invalid Characters");


            RuleFor(u => u.UrlAdres)
               .NotEmpty().WithMessage("{PropertyName} is Empty")
               .Must(IsUrlValid).WithMessage("{PropertyName} Contains Invalid Characters");
        }

        protected bool IsIPValid(string URL)
        {
            string Pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }

        protected bool IsUrlValid(string URL)
        {
            string Pattern = @"^(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+$";
            Regex Rgx = new Regex(Pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return Rgx.IsMatch(URL);
        }
    }
}