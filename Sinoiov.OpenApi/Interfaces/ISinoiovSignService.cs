using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    /// <summary>
    /// 中交兴路签名服务接口
    /// </summary>
    public interface ISinoiovSignService
    {
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        string Sign(Dictionary<string, string> dict);
        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        string Sign<TData>(TData data);
#if NET5_0
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        Task<string> SignAsync(Dictionary<string, string> dict);
        /// <summary>
        /// 签名
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<string> SignAsync<TData>(TData data);
#endif
    }
}
