namespace Common.Models;

public class Question
{
    public int QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;

    public int SurveyId { get; set; }
    public required Survey Survey { get; set; }
    
    public ICollection<Answer> Answers { get; set; } = new List<Answer>();
}