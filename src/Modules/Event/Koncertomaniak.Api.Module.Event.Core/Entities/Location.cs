using System.ComponentModel.DataAnnotations.Schema;
using Koncertomaniak.Api.Shared.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Koncertomaniak.Api.Module.Event.Core.Entities;

[Table("Locations")]
[Index(nameof(City), nameof(Place))]
public class Location : BaseEntity
{
    public Location(string city, string place)
    {
        City = city;
        Place = place;
        CreatedAt = DateTimeOffset.Now;
        UpdatedAt = DateTimeOffset.Now;
    }

    public string City { get; set; }
    public string Place { get; set; }
}