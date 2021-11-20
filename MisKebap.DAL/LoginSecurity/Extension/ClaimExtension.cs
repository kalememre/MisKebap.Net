using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MisKebap.DAL.LoginSecurity.Extension
{
    public static class ClaimExtension
    {
        public static void AddUserIdentifier(this ICollection<Claim> claims, Guid id)
        {
            claims.Add(new Claim(MisKebapClaimIdentifier.UserIdentifier, id.ToString()));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(MisKebapClaimIdentifier.Name, name));
        }

        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(MisKebapClaimIdentifier.Email, email));
        }

        public static void AddRole(this ICollection<Claim> claims, IEnumerable<string> roles)
        {
            foreach (var item in roles) claims.Add(new Claim(MisKebapClaimIdentifier.Role, item));
        }


    }
}
