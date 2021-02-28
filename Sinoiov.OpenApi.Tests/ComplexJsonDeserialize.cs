using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Sinoiov.OpenApi.Models;
using Sinoiov.OpenApi.Models.Location;
using Xunit;

namespace Sinoiov.OpenApi.Tests
{
    public class ComplexJsonDeserialize
    {
        const string objectJson = "{\"result\":[{\"vno\":\"陕YH0008\",\"mil\":\"\",\"lon\":\"69852009\",\"adr\":\"北京市丰台区芳群园一区12永发生活超市芳群园店,东南方向,10.2米\",\"vco\":\"2\",\"utc\":\"1614390717000\",\"state\":1001,\"province\":\"北京市\",\"spd\":\"4.8\",\"lat\":\"23917345\",\"drc\":\"328\",\"country\":\"丰台区\",\"city\":\"北京市\"}],\"status\":1001}";
        const string stringJson = "{\"result\":\"vclNs 不合法\",\"status\":1002}";

        [Fact]
        public void ConvertToObjectTest1()
        {
            var obj = JsonSerializer.Deserialize<SinoiovOutReplyWrapper<string>>(objectJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
            var r = obj.Result;

            var obj2 = JsonSerializer.Deserialize<SinoiovOutReplyWrapper<List<bool>>>(stringJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            });
        }
    }
}
