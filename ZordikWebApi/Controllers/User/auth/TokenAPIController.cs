using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Setup.Request.User.auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ZordikWebApi.Controllers.User.auth
{
    [Route("api/[action]")]
    [ApiController]
    public class TokenAPIController : ControllerBase
    {
        IConfiguration configuration;
        public TokenAPIController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Token([FromBody] TokenRequest objRequest)
        {
            IActionResult response = Unauthorized();
            string UserName = objRequest.Email;
            if (!string.IsNullOrEmpty(UserName))
            {
                try
                {
                    var issuer = configuration["Jwt:Issuer"];
                    var audience = configuration["Jwt:Audience"];
                    var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]);

                    var signingCredentials = new SigningCredentials(
                                            new SymmetricSecurityKey(key),
                                            SecurityAlgorithms.HmacSha512Signature
                                        );

                    var subject = new ClaimsIdentity(new[]
                     {
                new Claim(JwtRegisteredClaimNames.Sub, objRequest.Email),
                });

                    var expires = DateTime.UtcNow.AddMinutes(1);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = subject,
                        Expires = expires,
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = signingCredentials
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwtToken = tokenHandler.WriteToken(token);
                    return Ok(new { Message = "Token Generate Successfully", Token = jwtToken });
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Message = "Failed to generate token", Token = (string)null, Error = ex.Message });
                }
            }
            return response;
        }
    }
}
