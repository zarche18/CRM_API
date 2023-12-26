using GoFive_CRM.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GoFive_CRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Hardcoded username and password for testing
            const string hardcodedUsername = "testuser";
            const string hardcodedPassword = "testpassword";

            if (model.UserName == hardcodedUsername && model.Password == hardcodedPassword)
            {
                var token = GenerateJwtToken(model.UserName);

                if (token == null)
                    return Ok(new BaseResponse() { IsSuccess = false, ResponseCode = "005", ResponseMessage = $"Failed to generate token" });

                return Ok(new { Token = token });
            }

            return Ok(new ErrorResponse
            {
                IsSuccess = false,
                ResponseMessage = "Invalid username or password"
            });
        }

        private string GenerateJwtToken(string userName)
        {
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, userName),
            // Add more claims as needed
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"]));

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
