using Domain.Entities;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class ScheduleTaskHandler(ITodoistService todoistService)
    {
        private readonly ITodoistService _todoistService = todoistService;

        public async Task<List<TaskItem>> HandleAsync()
        {
            var tasks = await _todoistService.GetActiveTasksAsync();

            var scoredTasks = tasks
                .Where(t => !t.IsCompleted)
                .Select(t => new
                {
                    Task = t,
                    Score = CalculateTaskScore(t)
                })
                .OrderByDescending(tasks => tasks.Score)
                .Select(tasks => tasks.Task)
                .ToList();

            return scoredTasks;
        }

        private int CalculateTaskScore(TaskItem taskItem)
        {
            int score = 0;

            if (taskItem.DueDate?.Date == DateTime.Today)
            {
                score += 30;
            }
            if (taskItem.DueDate < DateTime.Now)
            {
                score += 50; //overdue
            }
            //TODO Subtract score for tasks that are due in the future
            if (taskItem.DueDate > DateTime.Now) 
            {

            }
            score += (1 + taskItem.Priority) * 10;

            return score;
        }
    }
}
