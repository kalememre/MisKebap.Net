using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Other;

namespace MisKebap.Business.Validations.Other
{
    public class AboutUsUpdateValidation : AbstractValidator<AboutUsUpdateDto>
    {
        private readonly IOtherService _otherService;

        public AboutUsUpdateValidation(IOtherService otherService)
        {
            _otherService = otherService;

            RuleFor(q => q.Title)
                .NotEmpty().WithMessage("Hakkımızda metni boş bırakılamaz");
        }
    }
}
