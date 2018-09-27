using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MrinalCore.Interfaces;
using MrinalCore.Dtos;
using MrinalCore.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using MrinalCore.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MrinalCore.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly ILogin _login;
        private readonly IUserRepository _userRepository;
        public LoginController(ILogin login, IUserRepository userRepository)
        {
            _login = login;
            _userRepository = userRepository;

        }

        [HttpPost("auth")]
        public async Task<IActionResult> Post([FromBody]UserDto userDto)
        {
            try
            {


                User LoggedInUser = _login.Login(userDto.Username, userDto.Password);

                if (LoggedInUser.Id != 0)
                {

                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ABCneedtogetthisfromenvironmentXYZ"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:50188",
                        audience: "http://localhost:50188",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signinCredentials
                    );

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    return Ok(new { Token = tokenString, User = LoggedInUser });
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (System.Exception ex)
            {
                //Console.WriteLine(ex.Message);
                return BadRequest(Error.AddErrorToModelState("login_failure", "Invalid username or password.", ModelState));
            }
        }
    }
}
