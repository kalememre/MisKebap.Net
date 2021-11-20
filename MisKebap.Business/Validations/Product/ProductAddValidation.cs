using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Product;

namespace MisKebap.Business.Validations.Product
{
    public class ProductAddValidation : AbstractValidator<ProductAddDto>
    {
        private readonly IProductService _productService;

        public ProductAddValidation(IProductService productService)
        {
            _productService = productService;

            RuleFor(q => q.Name)
               .NotEmpty().WithMessage("Ürün Adı Boş bırakılamaz")
               .MinimumLength(2).WithMessage("mahalle adı en az 2 haneli olmalıdır")
               .MustAsync(async (product, name, cancelation) =>
               {
                   return await _productService.IsUniqueProduct(name);
               })
               .WithMessage("Bu ürün adı ile daha önce kayıt girilmiş");

            RuleFor(q => q.Price)
                .NotEmpty().WithMessage("Ürün Fiyatı boş bırakılamaz")
                .GreaterThan(0).WithMessage("Ürün Fiyatı 0 dan büyük olmalıdır");
            RuleFor(q => q.CategoryId)
                .NotEmpty().WithMessage("ürün kategorisi boş bırakılamaz");
        }
    }
}
