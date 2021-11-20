using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MisKebap.DAL.Dtos.Category;

namespace MisKebap.Business.Abstract
{
    public interface ICategoryService
    {
        Task<int> Add(CategoryAddDto categoryAddDto);
        Task<int> Delete(int id);
        Task<int> Update(CategoryUpdateDto categoryUpdateDto);
        Task<List<CategoryViewDto>> GetAll();
        Task<CategoryViewDto> Get(int id);
        Task<bool> IsUniqueCategory(string name);
    }
}
