using AutoMapper;
using ExaminationSystem.Core.Features.Exams.Commands.Models;
using ExaminationSystem.Core.Features.Exams.Queries.Dtos;

namespace ExaminationSystem.Core.Mapping
{
    public class ExamProfile : Profile
    {
        public ExamProfile()
        {
            //For Add Command
            CreateMap<AddExamCommand, Exam>().ReverseMap();
            //For Getting Exam details 
            CreateMap<GetExamHeadLinesDto, Exam>().ReverseMap();
        }
    }
}
