using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Models
{
    internal partial record SinoiovOutReplyWrapper<TReply>
    {
        public virtual SinoiovOutReplyStatus Status { get; init; }
        public virtual TReply Result { get; init; }
    }
}
