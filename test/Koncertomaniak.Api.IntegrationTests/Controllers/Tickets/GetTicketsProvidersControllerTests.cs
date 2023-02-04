using System.Net;
using Koncertomaniak.Api.IntegrationTests.Fixtures;
using Koncertomaniak.Api.Shared.Abstractions;
using Newtonsoft.Json;

namespace Koncertomaniak.Api.IntegrationTests.Controllers.Tickets;

public class GetTicketsProvidersControllerTests
{
    [Fact]
    public async Task GetTicketsProviders_200_OK()
    {
        await using var application = new WebServerFactoryFixture();
        using var client = application.CreateClient();
        using var response =
            await client.GetAsync("tickets/GetEventTickets?eventId=20dfe252-7f79-4fe1-86de-e757524e35be");

        var deserializedResponse =
            JsonConvert.DeserializeObject<BaseResponseModel>(await response.Content.ReadAsStringAsync());

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.Equal(HttpStatusCode.OK, deserializedResponse?.StatusCode);
        Assert.Null(deserializedResponse?.ErrorMessage);
        Assert.NotNull(deserializedResponse?.Data);
    }
}