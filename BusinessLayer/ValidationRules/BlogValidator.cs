using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
            RuleFor(x => x.BlogTitle).MinimumLength(3).WithMessage("En Az 3 Karakter Girmeniz Gereklidir.");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Bir Kategori Seçiniz");

            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçerik Alanını Boş Geçemezsiniz.");
            RuleFor(x => x.BlogContent).MinimumLength(120).WithMessage("En Az 120 Karakter Girmeniz Gereklidir.");
        }
    }
}
