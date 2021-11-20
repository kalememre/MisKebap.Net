using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Product;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MisKebap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/values
        [HttpGet]
        public async Task<ActionResult<List<ProductViewDto>>> Get()
        {
            var productList = await _productService.GetAll();
            return Ok(productList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<ActionResult<ProductViewDto>> Get(int id)
        {
            var list = new List<string>();
            var result = await _productService.Get(id);
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

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<string>> Post(ProductAddDto productAddDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _productService.Add(productAddDto);
                switch (result)
                {
                    case > 0:
                        list.Add("Ekleme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("Böyle bir kategori bulunamadı");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
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

        // PUT api/values/5
        [HttpPut]
        public async Task<ActionResult<string>> Put(ProductUpdateDto productUpdateDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _productService.Update(productUpdateDto);
                switch (result)
                {
                    case > 0:
                        list.Add("Güncelleme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("Böyle bir ürün bulunamadı");
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

        // DELETE api/values/5
        [HttpDelete("{id}")]
        //[Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _productService.Delete(id);
                switch (result)
                {
                    case > 0:
                        list.Add("Silme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("silinecek ürün bulunamadı");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                    case -2:
                        list.Add("bu ürüne ait porsiyonlar oldugundan silinemez");
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
    }
}
