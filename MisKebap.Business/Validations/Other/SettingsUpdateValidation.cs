using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Other;

namespace MisKebap.Business.Validations.Other
{
    public class SettingsUpdateValidation : AbstractValidator<SettingsUpdateDto>
    {
        private readonly IOtherService _otherService;

        public SettingsUpdateValidation(IOtherService otherService)
        {
            _otherService = otherService;

            RuleFor(q => q.Title)
                .NotEmpty().WithMessage("Başlık boş bırakılamaz");
        }
    }
}
