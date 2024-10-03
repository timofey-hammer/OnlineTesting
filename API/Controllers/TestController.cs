using Common.DTOs;
using Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class TestController(IQuestionService questionService, IAnswerService answerService) : Controller
{
    [HttpGet("questions/{questionId}")]
    public async Task<IActionResult> GetQuestionAsync(int questionId)
    {
        var question = await questionService.GetQuestionAsync(questionId);
        return Ok(question);
    }

    [HttpPost("questions/answer")]
    public async Task<IActionResult> SubmitAnswerAsync([FromBody] AnswerSubmission submission)
    {
        var result = await answerService.SubmitAnswerAsync(submission);
        return Ok(result);
    }
}