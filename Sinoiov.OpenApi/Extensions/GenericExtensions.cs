using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Sinoiov.OpenApi.Extensions
{
    /// <summary>
    /// 泛型扩展
    /// </summary>
    public static class GenericExtensions
    {
        private static Dictionary<Type, Dictionary<string, Delegate>> ToDictionaryCache = new Dictionary<Type, Dictionary<string, Delegate>>();

        /// <summary>
        /// 转换为字典
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="object"></param>
        /// <param name="includeNonPublic">包含非公有属性</param>
        /// <returns></returns>
        public static Dictionary<string, object> ToDictionary<TObject>(this TObject @object, bool includeNonPublic = false)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            var obejctType = typeof(TObject);

            Dictionary<string, Delegate> tObjectDelegateCache;
            if (ToDictionaryCache.ContainsKey(obejctType))
            {
                tObjectDelegateCache = ToDictionaryCache[obejctType];
            }
            else
            {
                tObjectDelegateCache = new Dictionary<string, Delegate>();
                var bindingFlasg = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public;
                if (includeNonPublic)
                {
                    bindingFlasg |= System.Reflection.BindingFlags.NonPublic;
                }
                foreach (var propertyInfo in obejctType.GetProperties(bindingFlasg))
                {
                    if (!propertyInfo.CanRead) continue;
                    if (propertyInfo.GetMethod.GetParameters().Length > 0) continue;
                    var param = Expression.Parameter(obejctType, "param");
                    var param_propertyInfo = Expression.MakeMemberAccess(param, propertyInfo);
                    var lambda = Expression.Lambda(
                        delegateType: typeof(Func<,>).MakeGenericType(obejctType, propertyInfo.PropertyType),
                        body: param_propertyInfo,
                        parameters: new[] { param }
                    );
                    var @delegate = lambda.Compile(
#if !NETFRAMEWORK
                        true
#endif
                        );
                    tObjectDelegateCache.Add(propertyInfo.Name, @delegate);
                }
                ToDictionaryCache.Add(obejctType, tObjectDelegateCache);
            }

            foreach (var item in tObjectDelegateCache)
            {
                var value = item.Value.DynamicInvoke(@object);
                var key = item.Key;
                result.Add(key, value);
            }

            return result;
        }

        /// <summary>
        /// 转换为字符串字典
        /// </summary>
        /// <typeparam name="TObject"></typeparam>
        /// <param name="object"></param>
        /// <param name="includeNonPublic">包含非公有属性</param>
        /// <returns></returns>
        public static Dictionary<string, string> ToStringDictionary<TObject>(this TObject @object, bool includeNonPublic = false)
        {
            var dict = @object.ToDictionary<TObject>(includeNonPublic);
            var strDict = dict.ToDictionary(ks => ks.Key, es => es.Value switch { null => null, _ => Convert.ToString(es.Value) });
            return strDict;
        }
    }
}
