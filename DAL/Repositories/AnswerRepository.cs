using Common.DTOs;
using DAL.Contexts;
using Common.Models;
using Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class AnswerRepository(OnlineTestingDbContext context) : BaseRepository(context), IAnswerRepository
{
    private readonly OnlineTestingDbContext _context = context;

    public async Task<NextQuestionResultDto> SubmitAnswerAsync(AnswerSubmission submission)
    {
        var interview = await GetOrCreateInterviewAsync(submission.InterviewerName, submission.QuestionId);
        var question = await GetQuestionFromDbAsync(submission.QuestionId);
        var answer = GetAnswerFromQuestion(question, submission.SelectedAnswerId);

        await SaveResultAsync(interview, question, answer);

        return await GetNextQuestionAsync(submission.QuestionId, interview);
    }

    private async Task<Interview> GetOrCreateInterviewAsync(string interviewerName, int questionId)
    {
        var interview = await _context.Interviews
            .FirstOrDefaultAsync(i => i.InterviewerName == interviewerName);

        if (interview == null)
        {
            var firstQuestionId = await _context.Questions
                .OrderBy(q => q.QuestionId)
                .Select(q => q.QuestionId)
                .FirstOrDefaultAsync();

            if (questionId == firstQuestionId)
            {
                interview = new Interview
                {
                    InterviewerName = interviewerName,
                    DateCompleted = null
                };

                _context.Interviews.Add(interview);
                await _context.SaveChangesAsync();
            }
        }

        if (interview == null)
        {
            throw new Exception($"Interview could not be found or created for interviewer '{interviewerName}'.");
        }

        return interview;
    }

    private Answer GetAnswerFromQuestion(Question question, int selectedAnswerId)
    {
        var answer = question.Answers.FirstOrDefault(a => a.AnswerId == selectedAnswerId);

        if (answer == null)
        {
            throw new Exception($"Answer with ID {selectedAnswerId} not found or invalid.");
        }

        return answer;
    }

    private async Task<Result> SaveResultAsync(Interview interview, Question question, Answer answer)
    {
        var result = new Result
        {
            InterviewId = interview.InterviewId,
            QuestionId = question.QuestionId,
            AnswerId = answer.AnswerId,
            Answer = answer,
            Interview = interview,
            Question = question
        };

        _context.Results.Add(result);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An unexpected error occurred while saving the result.", ex);
        }

        return result;
    }

    private async Task<NextQuestionResultDto> GetNextQuestionAsync(int questionId, Interview interview)
    {
        var nextQuestion = await _context.Questions
            .Where(q => q.QuestionId > questionId)
            .OrderBy(q => q.QuestionId)
            .FirstOrDefaultAsync();

        if (nextQuestion == null)
        {
            interview.DateCompleted = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return new NextQuestionResultDto
            {
                NextQuestionId = null
            };
        }

        return new NextQuestionResultDto
        {
            NextQuestionId = nextQuestion.QuestionId,
        };
    }
}