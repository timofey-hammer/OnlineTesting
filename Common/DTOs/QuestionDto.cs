namespace Common.DTOs;

public class QuestionDto
{
    public int QuestionId { get; set; }
    public string Text { get; set; } = string.Empty;
    public required List<AnswerDto> Answers { get; set; }
}