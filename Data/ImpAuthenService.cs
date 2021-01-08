using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JWTApi.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace JWTApi.Data
{
    public class ImpAuthenService : IAuthenService
    {
        public ImpAuthenService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public UserModel AuthenticateUser(UserModel login)
        {
            UserModel userlogin = null;
            if (login.UserID == "admin" && login.Password == "123")
            {
                userlogin = new UserModel { UserID = "admin", Password = "123", Email = "xx@xx.com" };

            }
            return userlogin;
        }

        public string GennerateJSONWebToken(UserModel userinfo)
        {

            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.UserID),
                new Claim(JwtRegisteredClaimNames.Email,userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: Configuration["JWT:Issuer"],
                audience: Configuration["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(2),
                signingCredentials: credentials
            );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}