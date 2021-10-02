using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Bu alanı boş geçemessiniz.");
            RuleFor(x => x.WriterMail).EmailAddress().NotEmpty().WithMessage("Bu alanı boş geçemessiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karakter olmalıdır.");
            RuleFor(y => y.WriterPassword).Password();
        }


    }

    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var options = ruleBuilder
                          .NotEmpty().WithMessage("Şifre Boş Geçilemez.")
                          .NotNull().WithMessage("Şifre Boş Geçilemez.")
                          .MinimumLength(2).WithMessage("En az 2 karakter olmalıdır.")
                          .MaximumLength(16).WithMessage("En fazla 16 karakter girilebilir.")
                          .Matches("[A-Z]").WithMessage("En az bir büyük harf olmalı")
                          .Matches("[a-z]").WithMessage("En az bir küçük harf olmalı")
                          .Matches("[0-9]").WithMessage("En az bir rakam içermeli");
                          //.Matches("[^a-zA-Z0-9]").WithMessage("En az bir özel karakter içermeli");

            return options;
        }



    }
}
