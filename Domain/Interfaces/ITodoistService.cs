using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITodoistService
    {
        Task<List<TaskItem>> GetActiveTasksAsync();
    }
}
