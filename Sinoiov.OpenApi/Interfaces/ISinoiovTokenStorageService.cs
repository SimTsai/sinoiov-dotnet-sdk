using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Interfaces
{
    internal interface ISinoiovTokenStorageService
    {
        Task SaveTokenAsync(string token);
        Task<string> LoadTokenAsync();
    }
}
