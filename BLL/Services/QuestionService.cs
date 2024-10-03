using Common.DTOs;
using Common.Interfaces;

namespace BLL.Services;

public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
{
    public async Task<QuestionDto> GetQuestionAsync(int questionId)
    {
        return await questionRepository.GetQuestionAsync(questionId);
    }
}