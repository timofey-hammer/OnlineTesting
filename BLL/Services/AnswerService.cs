using Common.DTOs;
using Common.Interfaces;

namespace BLL.Services;

public class AnswerService(IAnswerRepository answerRepository) : IAnswerService
{
    public async Task<object> SubmitAnswerAsync(AnswerSubmission submission)
    {
        return await answerRepository.SubmitAnswerAsync(submission);
    }
}