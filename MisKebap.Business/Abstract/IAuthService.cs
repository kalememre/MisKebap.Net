using System;
using System.Threading.Tasks;
using MisKebap.DAL.Dtos.Customer;
using MisKebap.DAL.Entities;
using MisKebap.DAL.LoginSecurity.JWT;

namespace MisKebap.Business.Abstract
{
    public interface IAuthService
    {
        /// <summary>
        /// kullanıcı kayıt
        /// </summary>
        /// <param name="customerRegisterDto"></param>
        /// <returns></returns>
        Task<int> Register(CustomerRegisterDto customerRegisterDto);

        /// <summary>
        /// Personel Id' ye göre Token oluşturma
        /// </summary>
        Task<AccessToken> CreateAccessToken(Customer customer);

        /// <summary>
        ///     Kullanıcı girişinde kullanıcı adı şifre eşleştirmesi
        /// </summary>
        Task<Customer> Login(CustomerLoginDto customerLoginDto);

        /// <summary>
        /// telefon numarasi var mi yok mu kontrol
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        Task<bool> IsUniquePhone(string phone);

    }
}
