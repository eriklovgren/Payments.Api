namespace Payments.Api.Extensions;

public static class ClientIdExtension
{
    public static string? ClientIdFromHeader(this HttpRequest request)
    {
        request.Headers.TryGetValue("Client-ID", out var headerValue); 
        return headerValue;
    }
}