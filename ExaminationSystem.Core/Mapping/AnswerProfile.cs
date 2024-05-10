using AutoMapper;
using ExaminationSystem.Core.Features.Answers.Commands.Dtos;

namespace ExaminationSystem.Core.Mapping
{
    public class AnswerProfile : Profile
    {
        #region Constructor
        public AnswerProfile()
        {
            CreateMap<AnswerDto, Answer>().ReverseMap();
        }
        #endregion
    }
}
