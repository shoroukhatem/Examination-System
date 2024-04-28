using ExaminationSystem.Core.Bases;
using MediatR;

namespace ExaminationSystem.Core.Features.User.Commands.Models
{
    public class SignInCommandDto : IRequest<Response<string>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; } = false;
    }
}
