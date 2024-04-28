using AutoMapper;
using ExaminationSystem.Core.Features.Subject.Commands.Models;
using ExaminationSystem.Core.Features.Subject.Queries.Dtos;

namespace ExaminationSystem.Core.Mapping
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, AddSubjectCommand>().ReverseMap();
            CreateMap<Subject, GetSubjectDto>().ReverseMap();
        }
    }
}
