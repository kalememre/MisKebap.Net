using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MisKebap.DAL.Dtos.Product;

namespace MisKebap.Business.Abstract
{
    public interface IProductService
    {
        Task<int> Add(ProductAddDto productAddDto);
        Task<int> Update(ProductUpdateDto productUpdateDto);
        Task<ProductViewDto> Get(int id);
        Task<List<ProductViewDto>> GetAll();
        Task<int> Delete(int id);
        Task<bool> IsUniqueProduct(string name);

    }
}
