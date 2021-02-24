using System.Threading.Tasks;
using Sinoiov.OpenApi.Models.Location;

namespace Sinoiov.OpenApi.Interfaces
{
    /// <summary>
    /// 位置信息类接口
    /// </summary>
    public interface ISinoiovLocationService
    {
        /// <summary>
        /// 多车最新位置查询
        /// </summary>
        /// <returns></returns>
        Task<VLastLocationMultiV4Reply> VLastLocationMultiV4Async(VLastLocationMultiV4Request request);
    }
}
