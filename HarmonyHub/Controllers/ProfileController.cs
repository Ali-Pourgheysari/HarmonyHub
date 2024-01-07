using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HarmonyHub.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IUserService userService;

        public ProfileController(IUserService userService)
        {
            this.userService = userService;
        }
        // GET: Profile
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var userName = User.Identity?.Name;
            if (userName != null)
            {
                var user = await userService.GetUserByEmailAsync(userName);
                var profile = user.ToProfileModel();
                return View(profile);
            }
            return NotFound();
        }

        public ActionResult Edit()
        {
            return View();
        }
    }
}
