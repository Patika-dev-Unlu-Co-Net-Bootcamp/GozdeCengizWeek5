using BlogProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        readonly RoleManager<Role> _roleManager;
        readonly UserManager<User> _userManager;
        public RoleController(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> RoleAssign(string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            await _userManager.AddToRoleAsync(user, "Administrator");
            await _userManager.AddToRoleAsync(user, "Moderator");
            await _userManager.AddToRoleAsync(user, "Editor");
            return Ok();
        }
    }
}
