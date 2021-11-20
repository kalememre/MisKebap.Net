using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MisKebap.DAL.Entities;
using MisKebap.DAL.LoginSecurity.Encryption;
using MisKebap.DAL.LoginSecurity.Extension;

namespace MisKebap.DAL.LoginSecurity.JWT
{
    public class TokenHelper : ITokenHelper
    {
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public TokenHelper(IOptions<TokenOptions> tokenOptions)
        {
            _tokenOptions = tokenOptions.Value;
        }


        public AccessToken CreateToken(Customer customer, IEnumerable<Role> roles)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwtSecurityToken = CreateJwtSecurityToken(_tokenOptions, customer, signingCredentials, roles);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, Customer customer,
           SigningCredentials signingCredentials, IEnumerable<Role> roles)
        {
            var jwtSecurityToken = new JwtSecurityToken(
                tokenOptions.Issuer,
                tokenOptions.Audience,
                SetJwtClaims(customer, roles),
                DateTime.Now,
                _accessTokenExpiration,
                signingCredentials
            );
            return jwtSecurityToken;
        }

        private static IEnumerable<Claim> SetJwtClaims(Customer customer, IEnumerable<Role> roles)
        {
            var claims = new List<Claim>();
            claims.AddUserIdentifier(customer.Id);
            claims.AddName($"{customer.NameSurname}");
            claims.AddRole(roles.Select(p => p.Name).AsEnumerable());
            return claims;
        }

    }
}
