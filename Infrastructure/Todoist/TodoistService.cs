using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Todoist.Net;
using Todoist.Net.Models;

namespace Infrastructure.Todoist
{
    public class TodoistService : ITodoistService
    {
        private readonly IConfiguration _configuration;
        private readonly ITodoistClient _todoistClient;
        public TodoistService(IConfiguration configuration)
        {
            _configuration = configuration;
            _todoistClient = new TodoistClient(_configuration["TodoistApiKey"]);
        }

        public async Task<List<TaskItem>> GetActiveTasksAsync()
        {
            var todoistTasks = await _todoistClient.Items.GetAsync();

            return todoistTasks.Select(MapToDomain).ToList();
        }

        private TaskItem MapToDomain(Item item)
        {
            return new TaskItem(
                item.Id.ToString(),
                item.Content,
                (int?)item.Priority ?? 1,
                item.Deadline?.Date,
                item.IsChecked ?? false,
                item.Labels?.ToList()
            );
        }
    }
}
