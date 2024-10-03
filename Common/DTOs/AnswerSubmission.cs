namespace Common.DTOs;

public class AnswerSubmission
{
    public int QuestionId { get; set; }
    public int SelectedAnswerId { get; set; }
    public string InterviewerName { get; set; } = string.Empty;
}