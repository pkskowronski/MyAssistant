namespace Infrastructure.Todoist.Models
{
    public record TodoistTaskDto(
        string Id,
        string Content,
        int Priority,
        List<string> Labels,
        DueDateDto? Due
        );

    public record DueDateDto(DateTime DateTime);
}
