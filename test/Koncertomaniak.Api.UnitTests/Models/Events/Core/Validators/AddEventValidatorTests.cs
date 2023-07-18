using FluentAssertions;
using FluentValidation.TestHelper;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Module.Event.Core.Validators;

namespace Koncertomaniak.Api.UnitTests.Models.Events.Core.Validators;

public class AddEventValidatorTests
{
    [Fact]
    public async Task TryValidateAddEvent_Valid()
    {
        var locations = new List<LocationModel>
        {
            new()
            {
                City = "Warszawa",
                Place = "COS Torwar"
            },
            new()
            {
                City = "Lublin",
                Place = "Plac Zamkowy"
            }
        };
        var addEventModel = new AddEventModel("Test 123456", "http://example.com/image.jpg",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", DateTimeOffset.Now.AddDays(1), "Empik",
            "http://example.com", locations);

        var result = await new AddEventValidator().TestValidateAsync(addEventModel);

        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public async Task TryValidateAddEvent_NotValid()
    {
        var addEventModel = new AddEventModel("", "",
            null, DateTimeOffset.Now.AddDays(1), "Empik",
            null, null);

        var result = await new AddEventValidator().TestValidateAsync(addEventModel);

        result.IsValid.Should().BeFalse();
    }
}