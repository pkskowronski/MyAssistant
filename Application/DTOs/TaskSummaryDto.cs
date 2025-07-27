namespace Application.DTOs
{
    public record TaskSummaryDto(
        string Id,
        string Content,
        DateTime? DueDate,
        int Priority
        );
}
