using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message2>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
            RuleFor(x => x.MessageDetails).NotEmpty().WithMessage("Bu Alanı Boş Geçemezsiniz");
        }
    }
}
