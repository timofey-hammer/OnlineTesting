namespace Common.Models;

public class Answer
{
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;

    public required Question Question { get; set; }
}