using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.User.Commands.Models;
using ExaminationSystem.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExaminationSystem.Core.Features.User.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommandDto, Response<string>>
    {
        #region Fields
        private readonly IMapper _Mapper;
        private readonly UserManager<ApplicationUser> _UserManager;

        #endregion
        #region Constructor
        public UserCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _Mapper = mapper;
            _UserManager = userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<string>> Handle(AddUserCommandDto request, CancellationToken cancellationToken)
        {
            //Checking if Email Exists
            /* var CheckUserEmail = _UserManager.FindByEmailAsync(request.Email);
             if (CheckUserEmail.Result != null)
             {
                 return "Email Exists";
             }
             //Checking if UserName Exists
             var CheckUserName = _UserManager.FindByNameAsync(request.UserName);
             if (CheckUserEmail.Result != null)
             {
                 return "UserName Exists";
             }*/
            //Mapping
            var user = _Mapper.Map<ApplicationUser>(request);
            //Creating User
            var CreatingeResult = await _UserManager.CreateAsync(user, request.Password);
            if (!CreatingeResult.Succeeded)
            {
                return BadRequest<string>("Error Creating The User");
            }
            var RoleCreatingResult = await _UserManager.AddToRoleAsync(user, request.RoleName);
            if (!RoleCreatingResult.Succeeded)
            {
                await _UserManager.DeleteAsync(user);
                return BadRequest<string>("Error Assigning User To Role");
            }
            return Created("");

        }
        #endregion
    }
}
