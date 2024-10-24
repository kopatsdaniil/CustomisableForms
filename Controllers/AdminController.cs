using CustomisableForms.Models.ViewModels;
using CustomisableForms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CustomisableForms.Data;

namespace CustomisableForms.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public AdminController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();
            var userRolesViewModel = new List<UserRolesViewModel>();

            foreach (var user in users)
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
                    // Проверка на удаление пользователя
                    if (user.Delete)
                    {
                        // Получаем все роли пользователя
                        var roles = await _userManager.GetRolesAsync(identityUser);

                        // Удаляем пользователя из всех ролей
                        foreach (var role in roles)
                        {
                            var roleRemovalResult = await _userManager.RemoveFromRoleAsync(identityUser, role);
                            if (!roleRemovalResult.Succeeded)
                            {
                                // Обработка ошибок при удалении ролей
                                ModelState.AddModelError("", $"Error removing role {role} from user {identityUser.UserName}");
                                continue;
                            }
                        }

                        // Удаляем пользователя
                        var userRemovalResult = await _userManager.DeleteAsync(identityUser);
                        if (!userRemovalResult.Succeeded)
                        {
                            // Обработка ошибок при удалении пользователя
                            ModelState.AddModelError("", $"Error deleting user {identityUser.UserName}");
                            continue;
                        }
                    }
                    else
                    {
                        // Управление ролями (добавление/удаление роли Admin)
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
            }

            return RedirectToAction("Index");
        }
    }
}
