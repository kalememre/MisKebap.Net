using System;
using FluentValidation;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Category;

namespace MisKebap.Business.Validations.Category
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddDto>
    {
        private readonly ICategoryService _categoryService;

        public CategoryAddValidation(ICategoryService categoryService)
        {
            _categoryService = categoryService;

            RuleFor(q => q.Name)
                .NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz")
                .MinimumLength(2).WithMessage("Kategori adı en az 2 haneli olmalıdır")
                .MustAsync(async (category, name, cancelation) =>
                {
                    return await _categoryService.IsUniqueCategory(name);
                })
                .WithMessage("Bu kategori adı ile daha önce kayıt girilmiş");
        }
    }
}
