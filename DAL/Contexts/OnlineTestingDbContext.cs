using Common.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts;

public class OnlineTestingDbContext(DbContextOptions<OnlineTestingDbContext> options) : DbContext(options)
{
    public DbSet<Survey> Surveys { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Interview> Interviews { get; set; }
    public DbSet<Result> Results { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Survey>()
            .HasIndex(s => s.DateCreated);

        modelBuilder.Entity<Question>()
            .HasIndex(q => q.SurveyId);

        modelBuilder.Entity<Answer>()
            .HasIndex(a => a.QuestionId);

        modelBuilder.Entity<Interview>()
            .HasIndex(i => i.DateCompleted);

        modelBuilder.Entity<Result>()
            .HasIndex(r => new { r.InterviewId, r.QuestionId });

        modelBuilder.Entity<Result>()
            .HasIndex(r => r.AnswerId);

        base.OnModelCreating(modelBuilder);
    }
}