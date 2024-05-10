using ExaminationSystem.Infrastructure.Repository.Interfaces;
using ExaminationSystem.Infrastructure.Specification.Questions;
using ExaminationSystem.Service.Abstracts;

namespace ExaminationSystem.Service.Implementation
{
    public class QuestionService : IQuestionService
    {

        #region Fields
        private readonly IUnitOfWork _UnitOfWork;


        #endregion
        #region Constructors
        public QuestionService(IUnitOfWork unitOfWork)
        {

            _UnitOfWork = unitOfWork;

        }


        #endregion
        #region Functions
        //Could not make instance from Question
        public async Task<int> AddAsync(Question question)
        {
            try
            {
                await _UnitOfWork.Repository<Question, int>().AddAsync(question);
                await _UnitOfWork.CompelteAsync();
                return question.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }


        public async Task<IReadOnlyList<Question>> GetAllQuestionsForEachExamAsync(int examId)
        {
            var specs = new QuestionWithSpecification(new QuestionSpecification { examId = examId });
            return await _UnitOfWork.Repository<Question, int>().GetAllWithSpecificationAsync(specs);
        }

        public async Task<Question> GetQuestionByIdAsync(int questionId)
        {
            var specs = new QuestionWithSpecification(questionId);
            return await _UnitOfWork.Repository<Question, int>().GetByIdWithSpecificationAsync(specs);
        }

        public async Task<int> UpdateAsync(Question question)
        {
            _UnitOfWork.Repository<Question, int>().Update(question);
            int rows = await _UnitOfWork.CompelteAsync();
            return rows;
        }
        #endregion
    }
}
