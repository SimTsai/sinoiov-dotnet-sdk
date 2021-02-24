using System.ComponentModel;

namespace Sinoiov.OpenApi.Enums
{
    /// <summary>
    /// 中交兴路环境
    /// </summary>
    public enum SinoiovEnvironment
    {
        /// <summary>
        /// 测试环境
        /// </summary>
        [Description("测试环境")] Test,
        /// <summary>
        /// 产品环境
        /// </summary>
        [Description("产品环境")] Production,
        /// <summary>
        /// 自定义
        /// </summary>
        [Description("自定义")] Custom
    }
}
