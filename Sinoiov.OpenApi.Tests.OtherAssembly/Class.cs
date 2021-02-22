namespace Sinoiov.OpenApi.Tests
{
    public class Class
    {
        public Class()
        {
            PrivateProperty = "I am a Private Property!";
            ProtectedProperty = "I am a Protected Property!!";
            InternalProperty = "I am a Internal Property!!!";
        }

        private bool setProperty;
        public bool SetProperty { set => setProperty = value; }

        public string GetProperty => "!no set!";
        public int GetSetProperty { get; set; }
        public decimal GetInitProperty { get; init; }

        private string PrivateProperty { get; set; }
        protected string ProtectedProperty { get; set; }
        internal string InternalProperty { get; set; }

        private protected string PrivateProtectedProperty { get; set; } = "Private Protected Property@";
        internal protected string InternalProtectedProperty { get; set; } = "Internal Protected Property@@";


        public static string StaticProperty { get; set; } = "@StaticProperty@";
    }
}
