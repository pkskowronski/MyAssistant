using Application.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using System.Threading.Tasks;

namespace MyAssistant.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlaygroundController(IChatService chatService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var metaPrompt = "You are a helpful assistant. Answer the user's questions to the best of your ability.";
            var chatHistory = chatService.CreateChatHistory(metaPrompt);
            var answer = await chatService.GetChatCompletionAsync(chatHistory);
            return Ok(answer);
        }
    }
}
