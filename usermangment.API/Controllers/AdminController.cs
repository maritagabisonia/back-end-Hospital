using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using User.Management.Service.Services;
using usermangment.Data.Models;

namespace usermangment.API.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly UserManager<AplicationUser> _userManager;

        public AdminController(UserManager<AplicationUser> userManager)
        {
            _userManager = userManager;
            
        }

        [HttpGet("employees")]
        [HttpDelete("DeleteDoctorByEmail/{email}")]
        public async Task<IActionResult> DeleteDoctorByEmail(string email)
        {
            // Normalize the email if your setup requires normalization
            var normalizedEmail = _userManager.NormalizeEmail(email);
            var user = await _userManager.FindByEmailAsync(normalizedEmail);
            if (user == null)
            {
                return NotFound($"No doctor found with email {email}");
            }

            // Check if the user is a doctor
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Doctor"))
            {
                return BadRequest("The specified user is not a doctor");
            }

            // Proceed to delete the user
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok($"Doctor with email {email} has been deleted successfully.");
            }
            else
            {
                return BadRequest("Failed to delete the doctor");
            }
        }

    }
}
