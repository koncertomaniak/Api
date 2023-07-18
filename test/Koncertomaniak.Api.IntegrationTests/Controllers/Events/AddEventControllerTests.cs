using System.Net;
using System.Text;
using Koncertomaniak.Api.IntegrationTests.Fixtures;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Shared.Abstractions;
using Newtonsoft.Json;

namespace Koncertomaniak.Api.IntegrationTests.Controllers.Events;

public class AddEventControllerTests
{
    private const string ApiKey = "a9e55c31010f49babdce7753fa251b7c";

    [Fact]
    public async Task AddEvents_200_OK()
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
        var addEventModel = new AddEventModel("Test Koncert", "http://example.com/image.jpg",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", DateTimeOffset.Now.AddDays(1), "Empik",
            "http://example.com", locations);

        await using var application = new WebServerFactoryFixture();
        using var client = application.CreateClient();
        using var httpContent =
            new StringContent(JsonConvert.SerializeObject(addEventModel), Encoding.UTF8, "application/json");
        httpContent.Headers.Add("X-API-KEY", ApiKey);
        using var response = await client.PostAsync("events/AddEvent", httpContent);

        var deserializedResponse =
            JsonConvert.DeserializeObject<BaseResponseModel>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(HttpStatusCode.Created, deserializedResponse?.StatusCode);
        Assert.Null(deserializedResponse?.ErrorMessage);
        Assert.Null(deserializedResponse?.Data);
    }
}