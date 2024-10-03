namespace Common.Models;

public class Result
{
    public int ResultId { get; set; }
    public int InterviewId { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }

    public required Answer Answer { get; set; }
    public required Interview Interview { get; set; }
    public required Question Question { get; set; }
}