using Microsoft.Extensions.Caching.Distributed;

namespace Sinoiov.OpenApi.Interfaces
{
    internal interface ISinoiovCacheProviderFactory
    {
        IDistributedCache GetProvider();
    }
}
