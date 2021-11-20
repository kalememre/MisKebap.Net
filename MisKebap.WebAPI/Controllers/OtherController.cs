using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Dtos.Other;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MisKebap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OtherController : Controller
    {
        private readonly IOtherService _otherService;

        public OtherController(IOtherService otherService)
        {
            _otherService = otherService;
        }


        [HttpPut]
        [Route("AboutUs")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateAboutUs(AboutUsUpdateDto aboutUsUpdateDto)
        {
            var result = await _otherService.UpdateAboutUs(aboutUsUpdateDto);
            var list = new List<string>();
            if (result == -1)
            {
                list.Add("Kayıt Bulunamadı");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            else
            {
                list.Add("Kayıt Güncelleme Başarılı");
                return Ok(new { code = StatusCode(1000), message = list, type = "success" });
            }
        }

        [HttpGet("AboutUs/{id}")]
        [Authorize]
        public async Task<ActionResult<string>> GetAboutUs(int id)
        {
            var list = new List<string>();
            var result = await _otherService.AboutUsGet(id);
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

        [HttpPut]
        [Route("Settings")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateSettings(SettingsUpdateDto settingsUpdateDto)
        {
            var result = await _otherService.UpdateSettings(settingsUpdateDto);
            var list = new List<string>();
            if (result == -1)
            {
                list.Add("Kayıt Bulunamadı");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            else
            {
                list.Add("Kayıt Güncelleme Başarılı");
                return Ok(new { code = StatusCode(1000), message = list, type = "success" });
            }
        }

        [HttpGet("Settings/{id}")]
        [Authorize]
        public async Task<ActionResult<string>> GetSettings(int id)
        {
            var list = new List<string>();
            var result = await _otherService.GetSettings(id);
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
        [Route("WriteUs")]
        [Authorize]
        public async Task<ActionResult<string>> AddWriteUs(WriteUsAddDto writeUsAddDto)
        {
            var list = new List<string>();
            try
            {
                var result = await _otherService.WriteUsAdd(writeUsAddDto);
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

        [HttpPut]
        [Route("WriteUs")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<string>> UpdateWriteUs(WriteUsUpdateDto writeUsUpdateDto)
        {
            var result = await _otherService.WriteUsUpdate(writeUsUpdateDto);
            var list = new List<string>();
            if (result == -1)
            {
                list.Add("Kayıt Bulunamadı");
                return Ok(new { code = StatusCode(1001), message = list, type = "error" });
            }
            else
            {
                list.Add("Kayıt Güncelleme Başarılı");
                return Ok(new { code = StatusCode(1000), message = list, type = "success" });
            }
        }

        [HttpGet("WriteUs/{id}")]
        [Authorize]
        public async Task<ActionResult<string>> GetWriteUs(int id)
        {
            var list = new List<string>();
            var result = await _otherService.WriteUsGet(id);
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

        [HttpGet]
        [Route("WriteUs")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<List<WriteUsViewDto>>> GetWriteUs(bool IsRead)
        {
            var wrlist = await _otherService.WriteUsGetAll(IsRead);
            return Ok(wrlist);
        }
    }
}
