using System.Net;
using Koncertomaniak.Api.IntegrationTests.Fixtures;
using Koncertomaniak.Api.Shared.Abstractions;
using Newtonsoft.Json;

namespace Koncertomaniak.Api.IntegrationTests.Controllers.Events;

public class SearchEventsControllerTests
{
    [Fact]
    public async Task SearchEvents_200_OK_NoEmpty()
    {
        await using var application = new WebServerFactoryFixture();
        using var client = application.CreateClient();
        using var response = await client.GetAsync("events/SearchEvents?term=koncert&page=0");

        var deserializedResponse =
            JsonConvert.DeserializeObject<BaseResponseModel>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(HttpStatusCode.OK, deserializedResponse?.StatusCode);
        Assert.Null(deserializedResponse?.ErrorMessage);
        Assert.NotNull(deserializedResponse?.Data);
    }
}