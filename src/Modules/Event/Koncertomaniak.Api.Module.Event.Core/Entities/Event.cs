using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Module.Event.Core.Rules;
using Koncertomaniak.Api.Shared.Abstractions;

namespace Koncertomaniak.Api.Module.Event.Core.Entities;

[Table("Events")]
public class Event : BaseEntity
{
    public Event(string name, string imageUrl, string description, DateTimeOffset happeningDate)
    {
        Id = Guid.NewGuid();
        Name = name;
        ImageUrl = imageUrl;
        Description = description;
        HappeningDate = happeningDate;
    }

    public Event()
    {
    }

    [MaxLength(EventEntityRules.MaxNameLenght)]
    [MinLength(EventEntityRules.MinNameLenght)]
    public string Name { get; set; } = null!;

    [Url] public string ImageUrl { get; set; } = null!;

    [MinLength(EventEntityRules.MinDescriptionLenght)]
    public string Description { get; set; } = null!;

    public DateTimeOffset HappeningDate { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}