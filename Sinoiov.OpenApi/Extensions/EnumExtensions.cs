using System;
using System.Reflection;

namespace Sinoiov.OpenApi.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// 获取描述
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static string GetDescription<TEnum>(this TEnum @enum)
            where TEnum : struct, Enum
        {
            var enumItem = typeof(TEnum).GetField(@enum.ToString(), BindingFlags.Static | BindingFlags.Public);
            if (enumItem is not null)
            {
                var attr = enumItem.GetCustomAttribute<System.ComponentModel.DescriptionAttribute>();
                if (attr is not null)
                {
                    return attr.Description;
                }
            }
            return string.Empty;
        }
    }
}
