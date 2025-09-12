using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api")]
public class ChatController : ControllerBase
{
    private readonly IConversationService _cvService;
    public ChatController(IConversationService cvService)
    {
        _cvService = cvService;
    }

    private record Conversation(int Id, string Name, string From, string To);

    [HttpGet("conversations")]
    public async Task<IActionResult> GetConversation()
    {
        var conversations = await _cvService.GetConversations();
        return Ok(conversations);
    }

}