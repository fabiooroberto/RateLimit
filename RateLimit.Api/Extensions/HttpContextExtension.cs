using RateLimit.Api.Decorators;

namespace RateLimit.Api.Extensions
{
    public static class HttpContextExtension
    {
        public static bool HasRateLimitAttribute(this HttpContext context, out RateLimitAttribute? rateLimitAttribute)
        {
            rateLimitAttribute = context.GetEndpoint()?.Metadata.GetMetadata<RateLimitAttribute>();
            return rateLimitAttribute is not null;
        }

        public static string GetCustomerKey(this HttpContext context)
        => $"{context.Request.Path}_{context.Request.Method}_{context.Connection.RemoteIpAddress}";
    }
}
