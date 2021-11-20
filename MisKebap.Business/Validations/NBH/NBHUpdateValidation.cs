using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.NBH;

namespace MisKebap.Business.Validations.NBH
{
    public class NBHUpdateValidation : AbstractValidator<NBHUpdateDto>
    {
        private readonly INBHService _NBHService;

        public NBHUpdateValidation(INBHService NBHService)
        {
            _NBHService = NBHService;

            RuleFor(q => q.Title)
                .NotEmpty().WithMessage("Mahalle Adı Boş bırakılamaz")
                .MinimumLength(2).WithMessage("mahalle adı en az 2 haneli olmalıdır")
                .MustAsync(async (nbh, title, cancelation) =>
                {
                    return await _NBHService.IsUniqueTitle(title);
                })
                .WithMessage("Bu mahalle adı ile daha önce kayıt girilmiş"); ;

            RuleFor(q => q.Limit)
                 .GreaterThan(0).WithMessage("sipariş limiti 0 dan büyük olmalıdır");
        }
    }
}
