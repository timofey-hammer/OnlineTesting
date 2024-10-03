using Common.DTOs;
using DAL.Contexts;
using Common.Models;
using Common.Interfaces;

namespace DAL.Repositories;
public class QuestionRepository : BaseRepository, IQuestionRepository
{
    public QuestionRepository(OnlineTestingDbContext context) : base(context) { }

    public async Task<QuestionDto> GetQuestionAsync(int questionId)
    {
        var question = await GetQuestionFromDbAsync(questionId);
        return MapQuestionToDto(question);
    }

    private static QuestionDto MapQuestionToDto(Question question)
    {
        return new QuestionDto
        {
            QuestionId = question.QuestionId,
            Text = question.Text,
            Answers = question.Answers.Select(a => new AnswerDto
            {
                AnswerId = a.AnswerId,
                Text = a.Text
            }).ToList()
        };
    }
}