using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Temp.DataAccess.Data;
using Temp.Service.DTO;
using Temp.Service.Service;

namespace Temp.Web.Controllers
{
    [Route("api/[controller]")]
    public class JwtController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IAccountService _service;

        public JwtController(IConfiguration config, IAccountService service)
        {
            _config = config;
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(LogInDto logInDto)
        {
            IActionResult response = Unauthorized();
            var user = _service.LogIn(logInDto);
            if (user !=  null)
            {
                var tokenString = GenerateJwt(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJwt(User user)
        {
            var securityKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer:_config["Jwt:Issuer"],
                audience:_config["Jwt:Issuer"],
                claims,
                expires:DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );

            var encodetoken = new JwtSecurityTokenHandler().WriteToken(token);
            return encodetoken;
        }
    }
}
