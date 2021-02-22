namespace Sinoiov.OpenApi.Models
{
    public abstract record SinoiovReplyBase
    {
        public bool Success { get; init; }
        public string Message { get; init; }
    }
}
