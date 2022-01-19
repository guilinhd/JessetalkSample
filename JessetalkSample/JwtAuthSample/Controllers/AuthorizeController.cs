using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JwtAuthSample.ViewModels;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using JwtAuthSample.Models;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace JwtAuthSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizeController : ControllerBase
    {
        private readonly IOptions<JwtSetting> _options;
        public AuthorizeController(IOptions<JwtSetting> options)
        {
            _options = options;
        }

        [HttpPost]
        public IActionResult Token(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!(model.User == "molw" && model.Password == "1234"))
                {
                    return BadRequest();
                }

                var claims = new List<Claim>() {
                    new Claim(ClaimTypes.Name, "molw"),
                    new Claim(ClaimTypes.Role, "admin")
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Value.SigningKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                        issuer: _options.Value.Issuer,
                        audience: _options.Value.Audience,
                        claims: claims,
                        notBefore:DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: creds
                    );

                return Ok(new {token = new JwtSecurityTokenHandler().WriteToken(token) });
            }

            return BadRequest();
        }
    }
}
