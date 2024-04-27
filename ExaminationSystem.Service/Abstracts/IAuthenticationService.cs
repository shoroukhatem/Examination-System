using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<string> GetJWTToken(ApplicationUser user);
    }
}
