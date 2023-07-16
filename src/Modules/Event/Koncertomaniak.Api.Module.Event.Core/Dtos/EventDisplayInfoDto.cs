namespace Koncertomaniak.Api.Module.Event.Core.Dtos;

public class EventDisplayInfoDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? ImageUrl { get; set; }
    public string? Description { get; set; }
    public DateTimeOffset HappeningDate { get; set; }
    public List<LocationDto>? Locations { get; set; }
}

public class LocationDto
{
    public string? City { get; set; }
    public string? Place { get; set; }
}