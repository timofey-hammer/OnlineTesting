using Common.DTOs;

namespace Common.Interfaces;

public interface IQuestionRepository
{
    Task<QuestionDto> GetQuestionAsync(int questionId);
}