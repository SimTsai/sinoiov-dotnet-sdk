namespace Sinoiov.OpenApi.Options
{
    public partial class SinoiovAccountOptions
    {
        public const string DefaultOptionsName = "Sinoiov:Account";

        public virtual string User { get; set; }
        public virtual string Password { get; set; }
        public virtual string ClientID { get; set; }
        public virtual string Secret { get; set; }
    }
}
