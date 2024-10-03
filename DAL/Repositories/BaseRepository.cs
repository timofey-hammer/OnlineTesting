using DAL.Contexts;
using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public abstract class BaseRepository(OnlineTestingDbContext context)
{
    protected async Task<Question> GetQuestionFromDbAsync(int questionId)
    {
        var question = await context.Questions
            .Include(q => q.Answers)
            .FirstOrDefaultAsync(q => q.QuestionId == questionId);

        return question ?? throw new Exception($"Question with ID {questionId} not found.");
    }
}