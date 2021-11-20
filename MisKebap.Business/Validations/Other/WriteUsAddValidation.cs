using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Other;

namespace MisKebap.Business.Validations.Other
{
    public class WriteUsAddValidation : AbstractValidator<WriteUsAddDto>
    {
        private readonly IOtherService _otherService;

        public WriteUsAddValidation(IOtherService otherService)
        {
            _otherService = otherService;

            RuleFor(q => q.NameSurname)
                .NotEmpty().WithMessage("Ad soyad boş bırakılamaz");
            RuleFor(q => q.Phone)
                .NotEmpty().WithMessage("Telefon Boş Geçilemez")
                .Length(11, 11).WithMessage("Telefon 11 Haneli Olmalıdır")
                .Matches("(0)([0-9]){10}").WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
            RuleFor(q => q.Message)
                .NotEmpty().WithMessage("Mesaj boş bırakılamaz")
                .MinimumLength(2).WithMessage("Mesaj en az 2 karakterden oluşmalıdır");


        }
    }
}
