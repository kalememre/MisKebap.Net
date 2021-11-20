using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MisKebap.Business.Abstract;
using MisKebap.Business.Validations.Auth;
using MisKebap.DAL.Dtos.Customer;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MisKebap.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Register(CustomerRegisterDto customerRegisterDto)
        {
            var registerResult = await _authService.Register(customerRegisterDto);
            if (registerResult > 0)
            {
                return Ok(new { code = StatusCode(1000), message = "Kullanıcı kaydı başarılı", type = "success" });
            }
            return Ok(new { code = StatusCode(1001), message = "Kullanıcı kaydı başarısız", type = "error" });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(CustomerLoginDto customerLoginDto)
        {
            //var validator = new CustomerLoginValidation(_authService);
            //var validatorResult = validator.Validate(customerLoginDto);
            //var list = new List<string>();

           // if (!validatorResult.IsValid)
           // {
           //     foreach (var error in validatorResult.Errors)
           //     {
           //         list.Add(error.ErrorMessage);
           //     }
           //     return Ok(new { code = StatusCode(1002), message = list, type = "error" });
           // }


           //else
           // {
                var currentCustomer = await _authService.Login(customerLoginDto);
                if (currentCustomer == null)
                {
                    return Ok(new { code = StatusCode(1001), message = "Kullanıcı adı veya şifre yanlış", type = "error" });

                }
                else
                {
                    var accessToken = await _authService.CreateAccessToken(currentCustomer);
                    return Ok(accessToken);
                }
            //}
            
        }


    }
}
