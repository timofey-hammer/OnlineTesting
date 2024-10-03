namespace Common.Models;

public class Interview
{
    public int InterviewId { get; set; }
    public string InterviewerName { get; set; } = string.Empty;
    public DateTime? DateCompleted { get; set; }

    public ICollection<Result> Results { get; set; } = new List<Result>();
}