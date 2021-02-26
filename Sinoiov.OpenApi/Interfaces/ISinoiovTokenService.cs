using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    /// <summary>
    /// 中交兴路 Token服务
    /// </summary>
    public interface ISinoiovTokenService
    {
        /// <summary>
        /// 获取Token
        /// </summary>
        /// <returns></returns>
        Task<string> GetTokenAsync();
    }
}
