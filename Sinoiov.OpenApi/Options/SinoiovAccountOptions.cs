namespace Sinoiov.OpenApi.Options
{
    /// <summary>
    /// 中交兴路 账号 Options
    /// </summary>
    public partial class SinoiovAccountOptions
    {
        /// <summary>
        /// 默认Options名
        /// </summary>
        public const string DefaultOptionsName = "Sinoiov:Account";

        /// <summary>
        /// 用户名
        /// </summary>
        public virtual string User { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public virtual string Password { get; set; }
        /// <summary>
        /// clientId
        /// </summary>
        public virtual string ClientID { get; set; }
        /// <summary>
        /// 私钥
        /// </summary>
        public virtual string Secret { get; set; }
    }
}
