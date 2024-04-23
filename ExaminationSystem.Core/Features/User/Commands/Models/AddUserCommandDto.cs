using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace ExaminationSystem.Core.Features.User.Commands.Models
{
    public class AddUserCommandDto : IRequest<string>
    {
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public List<SelectListItem>? Roles { get; set; }
        public string RoleName { get; set; }
        public bool IsAgree { get; set; }

    }
}
