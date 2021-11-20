using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Customer;

namespace MisKebap.Business.Validations.Auth
{
    public class CustomerLoginValidation : AbstractValidator<CustomerLoginDto>
    {
        private readonly IAuthService _authService;

        public CustomerLoginValidation(IAuthService authService)
        {
            _authService = authService;

            RuleFor(q => q.Phone)
                .NotEmpty().WithMessage("Telefon Boş Geçilemez")
                .Length(11, 11).WithMessage("Telefon 11 Haneli Olmalıdır")
                .Matches("(0)([0-9]){10}").WithMessage("Lütfen geçerli bir telefon numarası giriniz.");
            RuleFor(q => q.Password)
                .NotEmpty().WithMessage("Parola Boş Geçilemez")
                .MinimumLength(6).WithMessage("Parola En Az 6 Haneli Olmalıdır");

        }
    }
}
