using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    public interface ISinoiovSignService
    {
        string Sign(Dictionary<string, string> dict);
        string Sign<TData>(TData data);
#if NET5_0
        Task<string> SignAsync(Dictionary<string, string> dict);
        Task<string> SignAsync<TData>(TData data);
#endif
    }
}
