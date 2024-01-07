
﻿using HarmonyHub.Data.EntityMappings;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
﻿using HarmonyHub.Data.Models;
using HarmonyHub.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HarmonyHub.Data.Entities;

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

        public async Task<ActionResult> Edit()
        {
            var currentUserEmail = User.Identity.Name;
            var user = await userService.GetUserByEmailAsync(currentUserEmail.ToString());
            EditProfileModel profile = new EditProfileModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
            };
            return View(profile);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(EditProfileModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userService.GetUserByIdAsync(model.Id);
                int changed = await userService.UpdateUserAsync(user.UpdateFields(model));
                if (changed > 0)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
    }
}
