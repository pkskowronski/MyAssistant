using Application.Abstractions;
using Microsoft.Extensions.Configuration;
using Todoist.Net;

namespace Application.Services
{
    internal class TodoistService : ITodoistService
    {
        private readonly IConfiguration _configuration;
        private readonly ITodoistClient _todoistClient;
        public TodoistService(IConfiguration configuration)
        {
            _configuration = configuration;
            _todoistClient = new TodoistClient(_configuration["TodoistApiKey"]);
        }

        public async Task<string> GetTodoistTasksAsync()
        {
            var tasks = await _todoistClient.Projects.GetAsync();
            return string.Join(Environment.NewLine, tasks.Select(t => $"{t.Content} (ID: {t.Id})"));
        }
    }
}
