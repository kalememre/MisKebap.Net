using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MisKebap.Business.Abstract;
using MisKebap.DAL.Context;
using MisKebap.DAL.Dtos.Customer;
using MisKebap.DAL.Entities;
using MisKebap.DAL.LoginSecurity.Hashing;
using MisKebap.DAL.LoginSecurity.JWT;

namespace MisKebap.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly MisKebapContext _misKebapContext;
        private readonly ITokenHelper _tokenHelper;

        public AuthService(MisKebapContext misKebapContext, ITokenHelper tokenHelper)
        {
            _misKebapContext = misKebapContext;
            _tokenHelper = tokenHelper;
        }

        public async Task<AccessToken> CreateAccessToken(Customer customer)
        {
            var currentCustomerRoles = await GetUserRolesByUserIdAsync(customer.Id);
            return currentCustomerRoles == null ? null : _tokenHelper.CreateToken(customer, currentCustomerRoles);

        }

        private async Task<IEnumerable<Role>> GetUserRolesByUserIdAsync(Guid customerId)
        {
            return await _misKebapContext.CustomerRoles.Where(p => !p.IsDeleted && p.CustomerId == customerId)
                .Include(p => p.RoleFK)
                .Select(p => p.RoleFK)
                .ToListAsync();
        }


        public async Task<Customer> Login(CustomerLoginDto customerLoginDto)
        {
            var currentCustomer = await _misKebapContext.Customers.Where(p => !p.IsDeleted && p.Phone == customerLoginDto.Phone).FirstOrDefaultAsync();
            if (currentCustomer == null)
            {
                return null;
            }
            else
            {
                var passwordMatchResult = HashingHelper.VerifyPasswordHash(customerLoginDto.Password, currentCustomer.PasswordHash, currentCustomer.PasswordSalt);
                if (passwordMatchResult)
                {
                    return currentCustomer;
                }
                else
                {
                    return null;
                }
            }

           

        }

        public async Task<int> Register(CustomerRegisterDto customerRegisterDto)
        {
            var currentDate = DateTime.Now;
            HashingHelper.CreatePasswordHash(customerRegisterDto.Password, out var passwordHash, out var passwordSalt);

            var customer = new Customer
            {
                NameSurname = customerRegisterDto.NameSurname,
                Phone = customerRegisterDto.Phone,
                Email = customerRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CustomerRoles = new List<CustomerRole>
                {
                    new()
                    {
                        RoleId=customerRegisterDto.CustomerRole,CDate=currentDate
                    }
                }
            };
            await _misKebapContext.Customers.AddAsync(customer);
            return await _misKebapContext.SaveChangesAsync();
        }

        public async Task<bool> IsUniquePhone(string phone)
        {
            var customer = await _misKebapContext.Customers.Where(q => !q.IsDeleted).Select(q => q.Phone).ToListAsync();
            return !customer.Contains(phone);


        }
    }
}
