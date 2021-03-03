using System.ComponentModel;

namespace Sinoiov.OpenApi.Enums
{
    /// <summary>
    /// 中交兴路Token存储位置
    /// </summary>
    public enum SinoiovTokenStorageType
    {
        /// <summary>
        /// 进程内
        /// </summary>
        [Description("进程内")] InMemory,
        /// <summary>
        /// Redis
        /// </summary>
        [Description("Redis")] Redis,
        /// <summary>
        /// 自定义， 需要传入ISinoiovTokenStorageService
        /// </summary>
        [Description("Custom")] Custom,
    }
}
