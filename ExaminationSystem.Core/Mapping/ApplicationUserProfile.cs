using AutoMapper;
using ExaminationSystem.Core.Features.User.Commands.Models;
using ExaminationSystem.Domain.Entities;

namespace ExaminationSystem.Core.Mapping
{
    public class ApplicationUserProfile : Profile
    {
        public ApplicationUserProfile()
        {
            //Register Command Dto Mapping
            CreateMap<AddUserCommandDto, ApplicationUser>().ReverseMap();
        }
    }
}
