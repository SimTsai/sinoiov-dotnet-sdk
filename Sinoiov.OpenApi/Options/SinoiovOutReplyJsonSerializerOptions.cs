using System.Text.Json;

namespace Sinoiov.OpenApi.Options
{
    internal static class SinoiovOutReplyJsonSerializerOptions
    {
        internal static JsonSerializerOptions Default => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
    }
}
