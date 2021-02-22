namespace Sinoiov.OpenApi.Models.Auth
{
    internal partial record SinoiovLoginOutReply : SinoiovOutReplyWrapper<string>
    {
        public virtual string Token => base.Result;
    }
}
