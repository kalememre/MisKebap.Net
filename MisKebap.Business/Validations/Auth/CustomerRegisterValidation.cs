using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Customer;

namespace MisKebap.Business.Validations.Auth
{
    public class CustomerRegisterValidation : AbstractValidator<CustomerRegisterDto>
    {

        private readonly IAuthService _authService;

        public CustomerRegisterValidation(IAuthService authService)
        {
            _authService = authService;

            RuleFor(q => q.NameSurname)
                .NotEmpty().WithMessage("Ad Soyad Boş Bırakılamaz")
                .MinimumLength(4).WithMessage("Ad Soyad En Az 4 Haneli Olmalıdır");

            RuleFor(q => q.Phone)
                .NotEmpty().WithMessage("Telefon Boş Geçilemez")
                .Length(11, 11).WithMessage("Telefon 11 Haneli Olmalıdır")
                .Matches("(0)([0-9]){10}").WithMessage("Lütfen geçerli bir telefon numarası giriniz.")
                .MustAsync( async (customer, phone, cancelation) =>
                {
                    return await _authService.IsUniquePhone(phone);
                })
                .WithMessage("Bu telefon numarası başka birine kayıtlı");

            RuleFor(q => q.Password)
                .NotEmpty().WithMessage("Parola Boş Geçilemez")
                .MinimumLength(6).WithMessage("Parola En Az 6 Haneli Olmalıdır");

            RuleFor(q => q.CustomerRole)
                .NotEmpty().WithMessage("Rol boş geçilemez");

            RuleFor(q => q.Email)
                .EmailAddress().WithMessage("Lütfen geçerli bir eposta adresi giriniz");

        }
    }
}
