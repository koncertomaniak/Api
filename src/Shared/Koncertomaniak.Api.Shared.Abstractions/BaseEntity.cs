using System.ComponentModel.DataAnnotations;

namespace Koncertomaniak.Api.Shared.Abstractions;

public abstract class BaseEntity
{
    [Key] public Guid Id { get; set; }
}