using System;
using System.Collections.Generic;
using Sinoiov.OpenApi.Enums;

namespace Sinoiov.OpenApi.Extensions
{
    internal static class SinoiovOutReplyStatusExtensions
    {
        private static readonly Dictionary<string, string> StatusCodeMapper = new Dictionary<string, string>
        {
            { "1001","接口执行成功" },
            { "1002","参数不正确（参数为空、查询时间范围不正确、参数数量不正确）" },
            { "1003","车辆调用数量已达上限" },
            { "1004","接口调用次数已达上限" },
            { "1005","该API 账号未授权指定所属行政区划数据范围" },
            { "1006","无结果" },
            { "1010","用户名或密码不正确" },
            { "1011","IP 不在白名单列表" },
            { "1012","账号已禁用" },
            { "1013","账号已过有效期" },
            { "1014","无接口权限" },
            { "1015","用户认证系统已升级，请使用令牌访问" },
            { "1016","令牌失效" },
            { "1017","账号欠费" },
            { "1018","授权的接口已禁用" },
            { "1019","授权的接口已过期" },
            { "1020","该车调用次数已达上限" },
            { "1021","client_id 不正确" },
            { "1031","签名验证失败" },
            { "9001","系统异常" }
        };

        public static string ToMessage(this SinoiovOutReplyStatus? replayStatus)
        {
            if (replayStatus is not null) return ToMessage(replayStatus);
            return string.Empty;
        }

        public static string ToMessage(this SinoiovOutReplyStatus replayStatus)
        {
            var key = Convert.ToString((int)replayStatus);
            if (StatusCodeMapper.ContainsKey(key))
            {
                return StatusCodeMapper[key];
            }
            else
            {
                return "未知的状态码";
            }
        }
    }
}
