namespace Domain.Entities
{
    public record TaskItem(
        string Id,
        string Content,
        int Priority,
        DateTime? DueDate,
        bool IsCompleted,
        List<string> Labels
        );
}
