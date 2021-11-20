using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.NBH;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MisKebap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NBHController : Controller
    {
        private readonly INBHService _NBHService;

        public NBHController(INBHService NBHService)
        {
            _NBHService = NBHService;
        }
        // GET: api/values
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<NBHViewDto>>> Get()
        {
            var nbhList = await _NBHService.GetAll();
            return Ok(nbhList);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<NBHViewDto>> Get(int id)
        {
            var list = new List<string>();
            var result = await _NBHService.Get(id);
            if(result != null)
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
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Post(NBHAddDto NBHAddDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _NBHService.Add(NBHAddDto);
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

        // PUT api/values/5
        [HttpPut]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Put(NBHUpdateDto NBHUpdateDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _NBHService.Update(NBHUpdateDto);
                switch (result)
                {
                    case > 0:
                        list.Add("Güncelleme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("Böyle bir mahalle bulunamadı");
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
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var list = new List<string>();
            try
            {
                var result = await _NBHService.Delete(id);
                switch (result)
                {
                    case > 0:
                        list.Add("Silme İşlemi Başarılı.");
                        return Ok(new { code = StatusCode(1000), message = list, type = "success" });
                    case -1:
                        list.Add("silinecek mahalle bulunamadı");
                        return Ok(new { code = StatusCode(1001), message = list, type = "error" });
                    case -2:
                        list.Add("bu mahalleye ait adresler oldugundan silinemez");
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
