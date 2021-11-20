using System;
using System.Collections.Generic;
using MisKebap.DAL.Entities;

namespace MisKebap.DAL.LoginSecurity.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(Customer customer, IEnumerable<Role> roles);
    }
}
