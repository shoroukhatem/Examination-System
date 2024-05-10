using AutoMapper;
using ExaminationSystem.Core.Features.Questions.Commands.Models;
using ExaminationSystem.Core.Features.Questions.Queries.Dtos;

namespace ExaminationSystem.Core.Mapping
{
    public class QuestionProfile : Profile
    {
        #region Constructor
        public QuestionProfile()
        {
            CreateMap<AddQuestionCommand, TOrF>().ReverseMap();
            CreateMap<AddQuestionCommand, MCQ>().ReverseMap();
            CreateMap<GetQuestionWithAnswersDto, Question>().ReverseMap();
            CreateMap<MCQ, Question>().ReverseMap();
            CreateMap<TOrF, Question>().ReverseMap();

        }
        #endregion
    }
}
