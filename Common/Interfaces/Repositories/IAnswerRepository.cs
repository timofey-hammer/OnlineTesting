using Common.DTOs;

namespace Common.Interfaces;

public interface IAnswerRepository
{
    Task<NextQuestionResultDto> SubmitAnswerAsync(AnswerSubmission submission);
}