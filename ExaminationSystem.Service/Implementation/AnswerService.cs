using ExaminationSystem.Infrastructure.Repository.Interfaces;
using ExaminationSystem.Infrastructure.Specification.Answers;
using ExaminationSystem.Service.Abstracts;

namespace ExaminationSystem.Service.Implementation
{
    public class AnswerService : IAnswerService
    {

        #region Fields
        private readonly IUnitOfWork _UnitOfWork;


        #endregion
        #region Constructors
        public AnswerService(IUnitOfWork unitOfWork)
        {

            _UnitOfWork = unitOfWork;

        }


        #endregion
        #region Functions
        public async Task<List<int>> AddListofAnswers(List<Answer> answers)
        {
            try
            {
                foreach (Answer answer in answers)
                {
                    await _UnitOfWork.Repository<Answer, int>().AddAsync(answer);
                }
                await _UnitOfWork.CompelteAsync();
                List<int> answersIds = new List<int>();
                foreach (Answer answer in answers)
                {
                    answersIds.Add(answer.AnswerId);
                }
                return answersIds;
            }
            catch (Exception ex)
            {
                return new List<int>();
            }
        }

        public async Task<IReadOnlyList<Answer>> GetListofAnswersForQuestionAsync(int questionId)
        {
            //AnswersWithSpecification(AnswerSpecification
            var specs = new AnswersWithSpecification(new AnswerSpecification { QuestionId = questionId });
            return await _UnitOfWork.Repository<Answer, int>().GetAllWithSpecificationAsync(specs);
        }

        #endregion
    }
}
