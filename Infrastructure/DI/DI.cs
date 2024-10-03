using BLL.Services;
using DAL.Repositories;
using Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DI;

public static class DI
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IAnswerService, AnswerService>();
        services.AddScoped<IAnswerRepository, AnswerRepository>();

        services.AddScoped<IQuestionService, QuestionService>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
    }
}