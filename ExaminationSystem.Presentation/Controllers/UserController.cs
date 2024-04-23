using ExaminationSystem.Core.Features.User.Commands.Models;
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

        public UserController(IMediator mediator, RoleManager<IdentityRole> roleManager)
        {
            _Mediator = mediator;
            _RoleManager = roleManager;
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
                    return Redirect("/Home/Index");

                }
            }
            return View(UserDto);
        }
    }
}
