using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Context;
using MisKebap.DAL.Dtos.Category;
using MisKebap.DAL.Entities;

namespace MisKebap.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly MisKebapContext _misKebapContext;

        public CategoryService(MisKebapContext misKebapContext)
        {
            _misKebapContext = misKebapContext;
        }

        public Task<int> Add(CategoryAddDto categoryAddDto)
        {
            var category = new Category
            {
                Name = categoryAddDto.Name
            };

            _misKebapContext.Categories.Add(category);
            var result = _misKebapContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> Delete(int id)
        {
            var current = await _misKebapContext.Categories.Where(q => !q.IsDeleted && q.Id == id).FirstOrDefaultAsync();

            if (current == null)
            {
                //silinecek kategori bulunamadi
                return await Task.FromResult(-1);
            }
            else
            {
                var res = await _misKebapContext.Products.Where(q => !q.IsDeleted && q.CategoryId == id).FirstOrDefaultAsync();
                if (res != null)
                {
                    //kategoriye ait urunler oldugundan silinemez
                    return await Task.FromResult(-2);
                }
                else
                {
                    current.IsDeleted = true;
                    _misKebapContext.Categories.Update(current);
                    await _misKebapContext.SaveChangesAsync();
                    return await Task.FromResult(1); 
                }
            }
        }

        public Task<CategoryViewDto> Get(int id)
        {
            return _misKebapContext.Categories.Where(q => !q.IsDeleted)
                  .Select(q => new CategoryViewDto
                  {
                      Id = q.Id,
                      Name = q.Name,
                  }).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<List<CategoryViewDto>> GetAll()
        {
            return _misKebapContext.Categories.Where(q => !q.IsDeleted)
                 .Select(q => new CategoryViewDto
                 {
                     Id = q.Id,
                     Name = q.Name,
                 }).ToListAsync();
        }

        public async Task<bool> IsUniqueCategory(string name)
        {
            var category = await _misKebapContext.Categories.Where(q => !q.IsDeleted).Select(q => q.Name).ToListAsync();
            return !category.Contains(name);
        }

        public Task<int> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var item = _misKebapContext.Categories.FirstOrDefault(q => !q.IsDeleted && q.Id == categoryUpdateDto.Id);

            if (item == null)
            {
                //guncellenecek kategori bulunamadi
                return Task.FromResult(-1);
            }

            item.Name = categoryUpdateDto.Name;

            _misKebapContext.Categories.Update(item);
            var result = _misKebapContext.SaveChangesAsync();

            return result;
        }
    }
}
