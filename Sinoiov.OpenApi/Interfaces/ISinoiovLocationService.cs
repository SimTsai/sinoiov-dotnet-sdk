
/* 项目“Sinoiov.OpenApi (netstandard2.0)”的未合并的更改
在此之前:
using Sinoiov.OpenApi.Models.Location;
using System;
using System.Threading.Tasks;
在此之后:
using System;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Threading.Tasks;
*/

/* 项目“Sinoiov.OpenApi (netstandard2.1)”的未合并的更改
在此之前:
using Sinoiov.OpenApi.Models.Location;
using System;
using System.Threading.Tasks;
在此之后:
using System;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Threading.Tasks;
*/

/* 项目“Sinoiov.OpenApi (net461)”的未合并的更改
在此之前:
using Sinoiov.OpenApi.Models.Location;
using System;
using System.Threading.Tasks;
在此之后:
using System;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Threading.Tasks;
*/
using System.Threading.Tasks;
using Sinoiov.OpenApi.Models.Location;

namespace Sinoiov.OpenApi.Interfaces
{
    public interface ISinoiovLocationService
    {
        /// <summary>
        /// 多车最新位置查询
        /// </summary>
        /// <returns></returns>
        Task<VLastLocationMultiV4Reply> VLastLocationMultiV4Async(VLastLocationMultiV4Request request);
    }
}
