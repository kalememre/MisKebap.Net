using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Other;

namespace MisKebap.Business.Validations.Other
{
    public class WriteUsUpdateValidation : AbstractValidator<WriteUsUpdateDto>
    {
        private readonly IOtherService _otherService;

        public WriteUsUpdateValidation(IOtherService otherService)
        {
            _otherService = otherService;

            RuleFor(q => q.IsRead)
                .NotEmpty().WithMessage("Okundu bilgisi boş bırakılamaz");
        }
    }
}
