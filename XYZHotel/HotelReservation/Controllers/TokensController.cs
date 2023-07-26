using HotelReservation.Authendication;
using HotelReservation.Data;
using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelReservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        public IConfiguration _config;
        private readonly LoginDbContext _projectcontext;

        public TokensController(IConfiguration config, LoginDbContext context)
        {
            _config = config;
            _projectcontext = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Login _userInfo)
        {
            if (_userInfo != null && _userInfo.EmailId != null && _userInfo.Password != null && _userInfo.Roles != null)
            {
                var user = await GetUser(_userInfo.EmailId, _userInfo.Password, _userInfo.Roles);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _config["JWT:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                         new Claim("UserId", user.UserId.ToString()),
                         new Claim("Email", user.EmailId),
                        new Claim("Password",user.Password),
                        new Claim("Role",user.Roles)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Login> GetUser(string email, string password, string role)
        {
            return await _projectcontext.logins.FirstOrDefaultAsync(info => info.EmailId == email && info.Password == password && info.Roles == role);
        }
    }
}