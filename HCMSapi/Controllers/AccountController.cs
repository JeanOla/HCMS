using AutoMapper;
using HCMSapi.Models;
using HCMSapi.DTO;
using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace HCMSapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _appConfig { get; }
        public IMapper _mapper { get; }
        
        IAccountRepository _repo;
        public AccountController(IAccountRepository accRepo,
                                 IMapper mapper,
                                 IConfiguration appConfig)
        {
            _repo = accRepo;
            _mapper = mapper;
            _appConfig = appConfig;
        }
        [HttpPost("signup")]
        public async Task<IActionResult> Register(SignUpDTO userDTO)
        {
            /*var user = new ApplicationUser()
            {
                FirstName = userDTO.FirstName,
                LastName = userDTO.LastName,
                Email = userDTO.Email,
                UserName = userDTO.Email
            };*/

            var user = _mapper.Map<ApplicationUser>(userDTO);

            var val = await _repo.SignUpUserAsync(user, userDTO.Password);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            // generate a token and return a token
            var issuer = _appConfig["JWT:Issuer"];
            var audience = _appConfig["JWT:Audience"];
            var key = _appConfig["JWT:Key"];

            if (ModelState.IsValid)
            {
                var loginResult = await _repo.SignInUserAsync(loginDTO);
                if (loginResult.Succeeded)
                {
                    // generate a token
                    var user = _repo.FindUserByEmailAsync(loginDTO.UserName);
                    if (user != null)
                    {
                        var keyBytes = Encoding.UTF8.GetBytes(key);
                        var theKey = new SymmetricSecurityKey(keyBytes); // 256 bits of key
                        var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(issuer, audience, null, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) }); // token 
                    }


                }
            }
            return BadRequest();
        }

    }
}
