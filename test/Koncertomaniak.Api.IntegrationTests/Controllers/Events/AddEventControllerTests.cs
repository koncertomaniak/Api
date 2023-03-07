using System.Net;
using System.Text;
using Koncertomaniak.Api.IntegrationTests.Fixtures;
using Koncertomaniak.Api.Module.Event.Core.Models;
using Koncertomaniak.Api.Shared.Abstractions;
using Newtonsoft.Json;

namespace Koncertomaniak.Api.IntegrationTests.Controllers.Events;

public class AddEventControllerTests
{
    [Fact]
    public async Task AddEvents_200_OK()
    {
        var addEventModel = new AddEventModel("Test Koncert", "http://example.com/image.jpg",
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit.", DateTimeOffset.Now.AddDays(1), "Empik",
            "http://example.com");
        
        await using var application = new WebServerFactoryFixture();
        using var client = application.CreateClient();
        using var httpContent = new StringContent(JsonConvert.SerializeObject(addEventModel), Encoding.UTF8, "application/json");
        using var response = await client.PostAsync("events/AddEvent", httpContent);

        var deserializedResponse =
            JsonConvert.DeserializeObject<BaseResponseModel>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(HttpStatusCode.Created, deserializedResponse?.StatusCode);
        Assert.Null(deserializedResponse?.ErrorMessage);
        Assert.Null(deserializedResponse?.Data);
    }
}