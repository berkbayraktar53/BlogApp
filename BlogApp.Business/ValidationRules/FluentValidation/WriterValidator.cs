using BlogApp.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.ValidationRules.FluentValidation
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Yazar adı boş geçilemez");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Yazar soyadı boş geçilemez");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez");
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage("En az 3 karakter girebilirsiniz");
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage("En az 3 karakter girebilirsiniz");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("En fazla 50 karakter girebilirsiniz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail formatı şeklinde girmelisiniz");
            RuleFor(x => x.Password).Matches(@"[A-Z]+[a-z]+[0-9]").WithMessage("Şifreniz en az bir büyük harf, bir küçük harf, bir rakam içermelidir");
        }
    }
}