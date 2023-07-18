using System.ComponentModel.DataAnnotations;

namespace Koncertomaniak.Api.Shared.Abstractions;

public abstract class BaseEntity
{
    public BaseEntity()
    {
        CreatedAt = DateTimeOffset.Now;
        UpdatedAt = DateTimeOffset.Now;
    }

    [Key] public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
}