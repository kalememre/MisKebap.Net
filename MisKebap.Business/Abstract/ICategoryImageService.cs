using System;
using Microsoft.AspNetCore.Http;

namespace MisKebap.Business.Abstract
{
    public interface ICategoryImageService
    {
        /// <summary>
        /// kategoriye resim ekleme
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        int AddCategoryImage(int CategoryId, IFormFile file);

        /// <summary>
        /// kategori resim guncelleme
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        int UpdateCategoryImage(int CategoryId, IFormFile file);

        /// <summary>
        /// kategori resmi silme
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        int DeleteCategoryImage(int CategoryId);

        /// <summary>
        /// kategori resmini getir
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        byte[] GetCategoryImageById(int CategoryId);
    }
}
