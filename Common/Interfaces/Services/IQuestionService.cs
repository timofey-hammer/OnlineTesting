using Common.DTOs;

namespace Common.Interfaces;

public interface IQuestionService
{
    Task<QuestionDto> GetQuestionAsync(int questionId);
}