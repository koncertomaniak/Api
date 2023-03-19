using Koncertomaniak.Api.Module.Auth.Infrastructure.Dal.Repositories;
using Koncertomaniak.Api.Shared.Infrastructure.QueueMessages;
using Koncertomaniak.Api.Shared.Infrastructure.QueueReponses;
using MassTransit;

namespace Koncertomaniak.Api.Module.Auth.Application.Commands.VerifyApiKey;

public class VerifyApiKeyConsumer : IConsumer<VerifyApiKeyMessage>
{
    private readonly IApiClientRepository _apiClientRepository;

    public VerifyApiKeyConsumer(IApiClientRepository apiClientRepository)
    {
        _apiClientRepository = apiClientRepository;
    }

    public async Task Consume(ConsumeContext<VerifyApiKeyMessage> context)
    {
        var apiClient = await _apiClientRepository.GetApiClientByApiKey(context.Message.ApiKey);

        if (apiClient == null)
        {
            await context.RespondAsync(new VerifyApiKeyResponse(Guid.Empty, string.Empty));
            return;
        }

        await context.RespondAsync(new VerifyApiKeyResponse(apiClient.Id, apiClient.ProviderName));
    }
}