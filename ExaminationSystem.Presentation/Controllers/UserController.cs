using ExaminationSystem.Core.Features.User.Commands.Models;
using ExaminationSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExaminationSystem.Presentation.Controllers
{
    public class UserController : Controller
    {
        private readonly IMediator _Mediator;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;

        public UserController(IMediator mediator, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _Mediator = mediator;
            _RoleManager = roleManager;
            _SignInManager = signInManager;
        }
        public async Task<IActionResult> Register()
        {
            var Roles = _RoleManager.Roles.ToList();

            var selectList = new List<SelectListItem>();
            foreach (var role in Roles)
            {
                selectList.Add(new SelectListItem(role.Name, role.Id.ToString()));
            }
            var user = new AddUserCommandDto()
            {
                Roles = selectList

            };
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Register(AddUserCommandDto UserDto)
        {
            if (ModelState.IsValid)
            {
                var role = await _RoleManager.FindByIdAsync(UserDto.RoleName);
                UserDto.RoleName = role.Name;
                var response = await _Mediator.Send(UserDto);
                if (response.Succeeded)
                {
                    return RedirectToAction("SignIn");

                }
                ViewData["Error"] = response.Message;
            }
            var Roles = _RoleManager.Roles.ToList();

            var selectList = new List<SelectListItem>();
            foreach (var role in Roles)
            {
                selectList.Add(new SelectListItem(role.Name, role.Id.ToString()));
            }
            UserDto.Roles = selectList;
            return View(UserDto);
        }
        public async Task<IActionResult> SignIn()
        {
            return View(new SignInCommandDto());
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInCommandDto userDto)
        {
            if (ModelState.IsValid)
            {
                var response = await _Mediator.Send(userDto);
                if (response.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { token = response.Data.ToString() });
                    //
                }
            }
            return View(userDto);
        }
        public async Task<IActionResult> SignOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("SignIn");
        }
    }
}
