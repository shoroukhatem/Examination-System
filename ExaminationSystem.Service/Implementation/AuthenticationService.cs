using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Domain.Helper;
using ExaminationSystem.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExaminationSystem.Service.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        #region Fields
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly JwtSettings _JwtSettings;


        #endregion
        #region Constructors
        public AuthenticationService(UserManager<ApplicationUser> userManager, JwtSettings jwtSettings)
        {
            _UserManager = userManager;
            _JwtSettings = jwtSettings;
        }

        #endregion
        #region Handle Functions
        public async Task<string> GetJWTToken(ApplicationUser user)
        {
            var roles = await _UserManager.GetRolesAsync(user);
            var claims = new List<Claim>()
            {
                new Claim("UserName",user.UserName),
                new Claim("Email",user.Email),
                new Claim("Role",roles[0])

            };
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_JwtSettings.Secret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_JwtSettings.Issuer, _JwtSettings.Audience, claims, expires: DateTime.Now.AddDays(1), signingCredentials: signingCredentials);
            var accessToken = new JwtSecurityTokenHandler().WriteToken(token);
            return accessToken;
        }


        #endregion

    }
}
