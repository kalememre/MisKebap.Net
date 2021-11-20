using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Category;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MisKebap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryImageService _categoryImageService;
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryImageService categoryImageService, ICategoryService categoryService)
        {
            _categoryImageService = categoryImageService;
            _categoryService = categoryService;
        }


        [HttpPost]
        [Route("Image/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult AddImage(int id, IFormFile file)
        {
            try
            {
                var result = _categoryImageService.AddCategoryImage(id, file);
                if(result == -1)
                {
                    return Ok(new { code = StatusCode(1001), message = "Böyle bir kategori bulunamadı", type = "error" });
                }
                else if (result == -2)
                {
                    return UpdateImage(id, file);
                }
                else
                {
                    return Ok(new { code = StatusCode(1000), message = "Resim Eklendi", type = "success" });
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message + e.InnerException);
            }
        }

        [HttpGet]
        [Route("Image/{id}")]
        [Authorize]
        public ActionResult GetImage(int id)
        {
            var result = _categoryImageService.GetCategoryImageById(id);
            if(result == null)
            {
                return Ok(new { code = StatusCode(1001), message = "Böyle bir kategori bulunamadı", type = "error" });
            }
            else
            {
                return File(result, "image/jpeg");
            }
           
        }

        [HttpPut]
        [Route("Image/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult UpdateImage(int id, IFormFile file)
        {
            var result = _categoryImageService.UpdateCategoryImage(id, file);
            switch (result)
            {
                case -1:
                   return Ok(new { code = StatusCode(1001), message = "Böyle bir kategori bulunamadı", type = "error" });
                case 1:
                    return Ok(new { code = StatusCode(1000), message = "Resim Güncellendi", type = "success" });
                default:
                    return Ok(new { code = StatusCode(1001), message = "Bir sorun oluştu", type = "error" });
            }
        }

        [HttpDelete]
        [Route("Image/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteImage(int id)
        {
            var result = _categoryImageService.DeleteCategoryImage(id);
            switch (result)
            {
                case -1:
                    return Ok(new { code = StatusCode(1001), message = "Böyle bir kategori bulunamadı", type = "error" });
                case 1:
                    return Ok(new { code = StatusCode(1000), message = "Resim Silindi", type = "success" });
                default:
                    return Ok(new { code = StatusCode(1001), message = "Bir sorun oluştu", type = "error" });

            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<CategoryViewDto>>> GetAll()
        {
            var categoryList = await _categoryService.GetAll();
            return Ok(categoryList);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<CategoryViewDto>> Get(int id)
        {
            var list = new List<string>();
            var result = await _categoryService.Get(id);
            if (result != null)
            {
                return Ok(result);

            }
            else
            {
                list.Add("Kayıt Bulunamadı");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });

            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Post(CategoryAddDto categoryAddDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _categoryService.Add(categoryAddDto);
                switch (result)
                {
                    case > 0:
                        list.Add("Ekleme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    default:
                        list.Add("Ekleme İşlemi Başarısız.");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _categoryService.Delete(id);
                switch (result)
                {
                    case > 0:
                        list.Add("Silme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("silinecek kategori bulunamadı");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                    case -2:
                        list.Add("bu kategoriye ait ürünler oldugundan silinemez");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                    default:
                        list.Add("Silme İşlemi Başarısız.");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Update(CategoryUpdateDto categoryUpdateDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _categoryService.Update(categoryUpdateDto);
                switch (result)
                {
                    case > 0:
                        list.Add("Güncelleme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("Böyle bir kategori bulunamadı");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                    default:
                        list.Add("Güncelleme İşlemi Başarısız.");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.InnerException);
            }
        }
    }
}
