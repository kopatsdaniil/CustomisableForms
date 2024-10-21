using CustomisableForms.Models.ViewModels;
using CustomisableForms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CustomisableForms.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();

            foreach (ApplicationUser user in users)
            {
                var thisViewModel = new UserRolesViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName ?? throw new NullReferenceException(),
                    Email = user.Email ?? throw new NullReferenceException(),
                    Roles = await GetUserRoles(user),
                    IsAdmin = await _userManager.IsInRoleAsync(user, "Admin")
                };

                userRolesViewModel.Add(thisViewModel);
            }
            return View(userRolesViewModel);
        }

        private async Task<List<string>> GetUserRoles(ApplicationUser user)
        {
            return new List<string>(await _userManager.GetRolesAsync(user));
        }

        [HttpPost]
        public async Task<IActionResult> ManageRoles(List<UserRolesViewModel> users)
        {
            foreach (var user in users)
            {
                var identityUser = await _userManager.FindByIdAsync(user.UserId);

                if (identityUser != null)
                {
                    if (user.IsAdmin)
                    {
                        if (!await _userManager.IsInRoleAsync(identityUser, "Admin"))
                        {
                            await _userManager.AddToRoleAsync(identityUser, "Admin");
                        }
                    }
                    else
                    {
                        if (await _userManager.IsInRoleAsync(identityUser, "Admin"))
                        {
                            await _userManager.RemoveFromRoleAsync(identityUser, "Admin");
                        }
                    }
                }
            }

            return RedirectToAction("Index");
        }
    }
}
