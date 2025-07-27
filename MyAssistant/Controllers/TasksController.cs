using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace MyAssistant.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController(ScheduleTaskHandler handler) : ControllerBase
    {
        private readonly ScheduleTaskHandler _handler = handler;

        [HttpGet("recommend-order")]
        public async Task<IActionResult> GetRecommendedOrder()
        {
            var orderedTasks = await _handler.HandleAsync();
            return Ok(orderedTasks);
        }
    }
}
