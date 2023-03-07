using FluentValidation;
using Koncertomaniak.Api.Module.Event.Core.Models;

namespace Koncertomaniak.Api.Module.Event.Core.Validators;

public class AddEventValidator : AbstractValidator<AddEventModel>
{
    public AddEventValidator()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().MinimumLength(8);
        RuleFor(x => x.Description).NotEmpty().NotNull().MinimumLength(20);
        RuleFor(x => x.HappeningDate).NotEmpty().NotNull();
        RuleFor(x => x.ImageUrl).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.ImageUrl));
        RuleFor(x => x.TicketUrl).Must(uri => Uri.TryCreate(uri, UriKind.Absolute, out _)).When(x => !string.IsNullOrEmpty(x.TicketUrl));
        RuleFor(x => x.TickerProvider).NotEmpty().NotNull();
    }
}