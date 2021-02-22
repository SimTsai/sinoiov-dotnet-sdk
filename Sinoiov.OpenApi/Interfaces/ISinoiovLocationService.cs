using Sinoiov.OpenApi.Models.Location;
using System;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    public interface ISinoiovLocationService
    {
        /// <summary>
        /// 多车最新位置查询
        /// </summary>
        /// <returns></returns>
        Task<object> VLastLocationMultiV4Async(VLastLocationMultiV4Request request);
    }
}
