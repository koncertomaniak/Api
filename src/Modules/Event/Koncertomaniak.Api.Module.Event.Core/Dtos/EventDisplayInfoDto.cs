namespace Koncertomaniak.Api.Module.Event.Core.Dtos;

public class EventDisplayInfoDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset HappeningDate { get; set; }
}