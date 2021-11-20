using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Context;
using MisKebap.DAL.Dtos.Product;
using MisKebap.DAL.Entities;

namespace MisKebap.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly MisKebapContext _misKebapContext;

        public ProductService(MisKebapContext misKebapContext)
        {
            _misKebapContext = misKebapContext;
        }

        public Task<int> Add(ProductAddDto productAddDto)
        {
            var category = _misKebapContext.Categories.FirstOrDefault(q => !q.IsDeleted && q.Id == productAddDto.CategoryId);

            if (category == null) return Task.FromResult(-1);

            var product = new Product
            {
                Name = productAddDto.Name,
                Price = productAddDto.Price,
                CategoryId = productAddDto.CategoryId,                
                IsEnabled = true
            };

            _misKebapContext.Products.Add(product);
            var result = _misKebapContext.SaveChangesAsync();

            return result;
        }

        public async Task<int> Delete(int id)
        {
            var product = await _misKebapContext.Products.Where(q => !q.IsDeleted && q.Id == id).FirstOrDefaultAsync();

            if (product == null)
            {
                return await Task.FromResult(-1);
            }
            else
            {
                var res = await _misKebapContext.Portions.Where(q => !q.IsDeleted && q.ProductId == id).FirstOrDefaultAsync();
                if (res != null)
                {
                    return await Task.FromResult(-2);
                }
                else
                {
                    product.IsDeleted = true;
                    _misKebapContext.Products.Update(product);
                    await _misKebapContext.SaveChangesAsync();
                    return await Task.FromResult(1);
                }
            }
        }

        public Task<ProductViewDto> Get(int id)
        {
            return _misKebapContext.Products.Where(q => !q.IsDeleted)
                .Select(q => new ProductViewDto
                {
                    Id = q.Id,
                    Name = q.Name,
                    Price = q.Price,
                    IsEnabled = q.IsEnabled,
                    CategoryName = q.CategoryFK.Name

                }).FirstOrDefaultAsync(q => q.Id == id);
        }

        public Task<List<ProductViewDto>> GetAll()
        {
            return _misKebapContext.Products.Where(q => !q.IsDeleted)
                .Select(q => new ProductViewDto
                {
                    Id = q.Id,
                    Name = q.Name,
                    Price = q.Price,
                    IsEnabled = q.IsEnabled,
                    CategoryName = q.CategoryFK.Name

                }).ToListAsync();
        }

        public async Task<bool> IsUniqueProduct(string name)
        {
            var product = await _misKebapContext.Products.Where(q => !q.IsDeleted).Select(q => q.Name).ToListAsync();
            return !product.Contains(name);
        }

        public Task<int> Update(ProductUpdateDto productUpdateDto)
        {
            var item = _misKebapContext.Products.FirstOrDefault(q => !q.IsDeleted && q.Id == productUpdateDto.Id);
            var category = _misKebapContext.Categories.FirstOrDefault(q => !q.IsDeleted && q.Id == productUpdateDto.CategoryId);

            if (item == null)
            {
                //guncellenecek urun bulunamadi
                return Task.FromResult(-1);
            }

            if (category == null)
            {
                //kategori bulunamadi
                return Task.FromResult(-2);
            }

            item.Name = productUpdateDto.Name;
            item.Price = productUpdateDto.Price;
            item.IsEnabled = productUpdateDto.IsEnabled;
            item.CategoryId = productUpdateDto.CategoryId;

            _misKebapContext.Products.Update(item);
            var result = _misKebapContext.SaveChangesAsync();

            return result;
        }
    }
}
