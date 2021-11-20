using System.Collections.Generic;
using System.Threading.Tasks;
using MisKebap.DAL.Dtos.NBH;

namespace MisKebap.Business.Abstract
{
    public interface INBHService
    {
        /// <summary>
        /// mahalle ekleme
        /// </summary>
        /// <param name="NBHAddDto"></param>
        /// <returns></returns>
        Task<int> Add(NBHAddDto NBHAddDto);

        /// <summary>
        /// mahalle guncelleme
        /// </summary>
        /// <param name="NBHUpdateDto"></param>
        /// <returns></returns>
        Task<int> Update(NBHUpdateDto NBHUpdateDto);

        /// <summary>
        /// mahalle silme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<int> Delete(int id);

        /// <summary>
        /// tum mahalleleri getir
        /// </summary>
        /// <returns></returns>
        Task<List<NBHViewDto>> GetAll();

        /// <summary>
        /// tek bir mahalle getir
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<NBHViewDto> Get(int id);

        /// <summary>
        /// mahalle varmi yokmu kontrol
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        Task<bool> IsUniqueTitle(string title);
    }
}
