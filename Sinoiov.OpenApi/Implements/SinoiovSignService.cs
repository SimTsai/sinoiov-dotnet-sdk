using Microsoft.Extensions.Options;
using Sinoiov.OpenApi.Extensions;
using Sinoiov.OpenApi.Interfaces;
using Sinoiov.OpenApi.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sinoiov.OpenApi.Implements
{
    internal class SinoiovSignService : ISinoiovSignService
    {
        private readonly byte[] signatureKey;

        public SinoiovSignService(
            IOptions<SinoiovOptions> sinoiovOptions
            )
        {
            signatureKey = Encoding.UTF8.GetBytes(sinoiovOptions.Value.Account.Secret);
        }

        byte[] ToSignBuff(Dictionary<string, string> dict)
        {
            var toSignStr = string.Join("",
                 dict
                 .Select(s => $"{s.Key}{s.Value}")
                 .OrderBy(s => s)
             );
            var toSignBuff = Encoding.UTF8.GetBytes(toSignStr);
            return toSignBuff;
        }

        Stream ToSignStream(Dictionary<string, string> dict)
        {
            var toSignBuff = ToSignBuff(dict);
            var ms = new MemoryStream(toSignBuff, false);
            return ms;
        }

        string ToSign(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToUpper();
        }

        public string Sign(Dictionary<string, string> dict)
        {
            var toSignBuff = ToSignBuff(dict);
            using var hmacsha1 = new HMACSHA1(signatureKey);
            var hash = hmacsha1.ComputeHash(toSignBuff);
            return ToSign(hash);
        }

        public string Sign<TData>(TData data)
        {
            var dict = data.ToStringDictionary<TData>();
            return Sign(dict);
        }

#if NET5_0
        async public Task<string> SignAsync(Dictionary<string, string> dict)
        {
            using var toSignStream = ToSignStream(dict);
            using var hmacsha1 = new HMACSHA1(signatureKey);
            var hash = await hmacsha1.ComputeHashAsync(toSignStream).ConfigureAwait(false);
            return ToSign(hash);
        }

        async public Task<string> SignAsync<TData>(TData data)
        {
            var dict = data.ToStringDictionary<TData>();
            return await SignAsync(dict).ConfigureAwait(false);
        }
#endif
    }
}
