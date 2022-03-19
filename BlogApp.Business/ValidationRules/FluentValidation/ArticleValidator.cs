using BlogApp.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.ValidationRules.FluentValidation
{
    public class ArticleValidator : AbstractValidator<Article>
    {
        public ArticleValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("İçerik boş geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim boş geçilemez");
            RuleFor(x => x.Thumbnail).NotEmpty().WithMessage("Küçük resim boş geçilemez");
        }
    }
}