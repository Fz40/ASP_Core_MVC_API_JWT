using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using JWTApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace JWTApi.Controllers
{

    [Route("api/Login")]
    [ApiController]
    public class LoginController : Controller
    {

        private IConfiguration _config;
        private ILogger<LoginController> _logger;

        public LoginController(IConfiguration config, ILogger<LoginController> logger)
        {
            _config = config;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login(string username, string pass)
        {
            try
            {
                UserModel login = new UserModel();
                login.UserID = username;
                login.Password = pass;
                IActionResult response = Unauthorized();

                var user = AuthenticateUser(login);
                if (user != null)
                {
                    var tokenStr = GennerateJSONWebToken(user);
                    response = Ok(new { token = tokenStr });
                }

                return response;
            }
            catch (Exception)
            {
                _logger.LogError("Failed to execute GET");
                return BadRequest();
            }
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel userlogin = null;
            if (login.UserID == "admin" && login.Password == "123")
            {
                userlogin = new UserModel { UserID = "admin", Password = "123", Email = "xx@xx.com" };

            }
            return userlogin;
        }

        private string GennerateJSONWebToken(UserModel userinfo)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,userinfo.UserID),
                new Claim(JwtRegisteredClaimNames.Email,userinfo.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
            );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }




    }
}