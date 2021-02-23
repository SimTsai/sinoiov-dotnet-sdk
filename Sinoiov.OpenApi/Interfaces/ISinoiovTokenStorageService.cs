using System;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    internal interface ISinoiovTokenStorageService : IDisposable
    {
        Task SaveTokenAsync(string token);
        Task<string> LoadTokenAsync();
    }
}
