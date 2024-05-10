using ExaminationSystem.Domain.Dtos;

namespace ExaminationSystem.Domain.Factories
{
    public static class QuestionFactory
    {

        public static Question CreateTrueFalseQuestion(QuestionDto question)
        {
            TOrF TOrFQuestion = new TOrF
            {
                Header = question.Header,
                Body = question.Body,
                ExamId = question.ExamId,
                Mark = question.Mark,
                QuestionType = question.QuestionType,
                TrueAnswer = question.TrueAnswer,
                Correct = question.Correct
            };
            return TOrFQuestion;
        }

        // Method to create Multiple Choice questions
        public static Question CreateMultipleChoiceQuestion(QuestionDto question)
        {
            MCQ MCQquestion = new MCQ
            {
                Header = question.Header,
                Body = question.Body,
                ExamId = question.ExamId,
                Mark = question.Mark,
                QuestionType = question.QuestionType,
                TrueAnswer = question.TrueAnswer,
                Correct = question.Correct
            };
            MCQquestion.Answers = new List<Answer>(4);
            return MCQquestion;
        }
    }
}
