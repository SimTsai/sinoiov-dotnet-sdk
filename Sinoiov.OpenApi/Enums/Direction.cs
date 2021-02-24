using System.ComponentModel;

namespace Sinoiov.OpenApi.Enums
{
    /// <summary>
    /// 方向
    /// </summary>
    public enum Direction
    {
        /// <summary>
        /// 未知
        /// </summary>
        [Description("未知")] Unknown,
        /// <summary>
        /// 正北
        /// </summary>
        [Description("正北")] North,
        /// <summary>
        /// 东北
        /// </summary>
        [Description("东北")] Northeast,
        /// <summary>
        /// 正东
        /// </summary>
        [Description("正东")] East,
        /// <summary>
        /// 东南
        /// </summary>
        [Description("东南")] Southeast,
        /// <summary>
        /// 正南
        /// </summary>
        [Description("正南")] South,
        /// <summary>
        /// 西南
        /// </summary>
        [Description("西南")] Southwest,
        /// <summary>
        /// 正西
        /// </summary>
        [Description("正西")] West,
        /// <summary>
        /// 西北
        /// </summary>
        [Description("西北")] Northwest,
    }
}
