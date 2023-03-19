using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Koncertomaniak.Api.Shared.Infrastructure.Filters;

public class AdminIpWhitelistFilter : ActionFilterAttribute
{
    private readonly IEnumerable<byte[]> _whitelist;

    public AdminIpWhitelistFilter()
    {
        _whitelist = Environments.AdminIpWhitelist.Split(";")
            .Select(x => IPAddress.Parse(x).GetAddressBytes());
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!Environments.RunningEnvironment.Equals("test"))
        {
            var remoteIp = context.HttpContext.Connection.RemoteIpAddress;
            var bytes = remoteIp?.GetAddressBytes();

            var unauthorizedIp = _whitelist.Select(address => address.SequenceEqual(bytes))
                .All(ip => !ip);

            if (unauthorizedIp)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return;
            }
        }

        base.OnActionExecuting(context);
    }
}