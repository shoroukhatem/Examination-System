using AutoMapper;
using ExaminationSystem.Core.Bases;
using ExaminationSystem.Core.Features.User.Commands.Models;
using ExaminationSystem.Domain.Entities;
using ExaminationSystem.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace ExaminationSystem.Core.Features.User.Commands.Handler
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommandDto, Response<string>>
                                                    , IRequestHandler<SignInCommandDto, Response<string>>

    {
        #region Fields
        private readonly IMapper _Mapper;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly IAuthenticationService _AuthenticationService;

        #endregion
        #region Constructor
        public UserCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IAuthenticationService authenticationService)
        {
            _Mapper = mapper;
            _UserManager = userManager;
            _SignInManager = signInManager;
            _AuthenticationService = authenticationService;
        }
        #endregion
        #region Handle Functions
        //Register Handler
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
                return BadRequest<string>(CreatingeResult.Errors.FirstOrDefault().Code);
            }
            //Adding Role To User
            var RoleCreatingResult = await _UserManager.AddToRoleAsync(user, request.RoleName);
            if (!RoleCreatingResult.Succeeded)
            {
                await _UserManager.DeleteAsync(user);
                return BadRequest<string>(RoleCreatingResult.Errors.FirstOrDefault().Code);
            }
            return Created("");

        }
        //SignIn Handler
        public async Task<Response<string>> Handle(SignInCommandDto request, CancellationToken cancellationToken)
        {
            //Searching For User
            var user = await _UserManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return NotFound<string>("User Not Found");
            }
            //if User Found and Password is Correct then sign in 
            if (user != null && await _UserManager.CheckPasswordAsync(user, request.Password)) ;
            {
                var result = await _SignInManager.PasswordSignInAsync(user, request.Password, request.RememberMe, false);
                if (result.Succeeded)
                {
                    //Generate Token
                    var AccessToken = await _AuthenticationService.GetJWTToken(user);
                    //Return Token
                    return Success(AccessToken);
                }
            }
            return BadRequest<string>("");
        }


        #endregion
    }
}
