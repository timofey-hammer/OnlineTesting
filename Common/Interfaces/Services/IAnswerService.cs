using Common.DTOs;

namespace Common.Interfaces;

public interface IAnswerService
{
    Task<object> SubmitAnswerAsync(AnswerSubmission submission);
}