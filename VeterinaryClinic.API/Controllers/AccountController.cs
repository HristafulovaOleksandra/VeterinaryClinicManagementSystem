using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.API.Controllers.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VeterinaryClinic.DAL.Data;
using System.Security.Claims;
namespace VeterinaryClinic.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly VeterinaryClinicManagmentContext _context;

        public AccountController(UserManager<ApplicationUser> um, IConfiguration cfg, VeterinaryClinicManagmentContext ctx)
        {
            _userManager = um; _config = cfg; _context = ctx;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest req)
        {
            var user = new ApplicationUser { Email = req.Email, UserName = req.Email };
            var res = await _userManager.CreateAsync(user, req.Password);
            if (!res.Succeeded) return BadRequest(res.Errors);

            return Ok();
        }

    }

}
