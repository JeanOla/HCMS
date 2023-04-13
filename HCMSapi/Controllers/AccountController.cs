using AutoMapper;
using HCMSapi.Models;
using HCMSapi.DTO;
using HCMSapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HCMSapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public IConfiguration _appConfig { get; }
        public IMapper _mapper { get; }
        
        IAccountRepository _repo;
        private UserManager<ApplicationUser> _userManager { get; }
        // login user details 
        private SignInManager<ApplicationUser> _signInManager { get; }

        private RoleManager<IdentityRole> _roleManager { get; }
        public AccountController(IAccountRepository accRepo,
                                 IMapper mapper,
                                 IConfiguration appConfig,UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> RoleManager)
        {
            _repo = accRepo;
            _mapper = mapper;
            _appConfig = appConfig;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = RoleManager;
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

        [HttpPost("Add {roles} Doctor/Admin")]
        public async Task<IActionResult> Register(AddDoctorDTO userViewModel, [FromRoute] string roles)
        {
            if (roles == "Doctor")
            {
                if (ModelState.IsValid)
                {
                    var userMode = new ApplicationUser
                    {
                        UserName = userViewModel.Email,
                        Email = userViewModel.Email,
                        firstName = userViewModel.firstName,
                        lastName = userViewModel.lastName,
                        middleName = userViewModel.middleName,
                        dob = userViewModel.dob,
                        address = userViewModel.address,
                        specialityId = userViewModel.specialityId,
                        Gender = userViewModel.gender,
                        PhoneNumber = userViewModel.PhoneNumber,


                    };
                    //_userManager= crud opedration for user
                    //_signInManager=manages signins
                    var result = await _userManager.CreateAsync(userMode, userViewModel.password);
                    if (result.Succeeded)
                    {
                        var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "Doctor");
                        if (role != null)
                        {
                            var roleResult = await _userManager.AddToRoleAsync(userMode, role.Name);
                            if (!roleResult.Succeeded)
                            {
                                return BadRequest("Role not assigned.");
                            }
                        }
                    }
                }
                return Ok();
            }
            else if (roles == "Admin")
            {
                if (ModelState.IsValid)
                {
                    var userMode = new ApplicationUser
                    {
                        UserName = userViewModel.Email,
                        Email = userViewModel.Email,
                        firstName = userViewModel.firstName,
                        lastName = userViewModel.lastName,
                        middleName = userViewModel.middleName,
                        dob = userViewModel.dob,
                        address = userViewModel.address,
                        specialityId = null,
                        Gender = userViewModel.gender,
                        PhoneNumber = userViewModel.PhoneNumber,


                    };
                    //_userManager= crud opedration for user
                    //_signInManager=manages signins
                    var result = await _userManager.CreateAsync(userMode, userViewModel.password);
                    if (result.Succeeded)
                    {
                        var role = _roleManager.Roles.FirstOrDefault(r => r.Name == "Admin");
                        if (role != null)
                        {
                            var roleResult = await _userManager.AddToRoleAsync(userMode, role.Name);
                            if (!roleResult.Succeeded)
                            {
                                return BadRequest("Role not assigned.");
                            }
                        }
                    }
                }
                return Ok();
            }
            else { BadRequest("Role Entered is invalid."); }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.getAllUser());
        }
        [HttpGet("Get user via {email}")]
        public IActionResult GetUserByEmail([FromRoute] string email) 
        {
            if (email == "")
                return BadRequest();
            ApplicationUser user;
            try
            {
                user = _repo.getUserByEmail(email);
                if (user == null)
                    return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(user); 
        }
        [HttpDelete("{email}Delete User")]
        public IActionResult Delete([FromRoute] string email) 
        {
            if (email == "")
                return BadRequest();
            var todo = _repo.getUserByEmail(email);
            if (todo == null)
                return NotFound("No resource found");
            _repo.DeleteUser(email);
            return Ok(_repo.getAllUser());
        }
    }





}
