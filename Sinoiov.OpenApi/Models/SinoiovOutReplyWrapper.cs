using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Sinoiov.OpenApi.Enums;
using Sinoiov.OpenApi.Extensions;
using Sinoiov.OpenApi.Options;

namespace Sinoiov.OpenApi.Models
{
    internal partial record SinoiovOutReplyWrapper<TReply>
    {
        public virtual SinoiovOutReplyStatus Status { get; init; }

        [JsonPropertyName("Result")]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        [System.Diagnostics.DebuggerHidden]
        public virtual JsonElement RawResult { get; init; }

        [JsonIgnore]
        public virtual TReply Result => OnGetResult is not null ? OnGetResult(this.RawResult) : DefaultResultGetter(this.RawResult);

        internal virtual Func<JsonElement, TReply> OnGetResult { get; set; }

        internal static TReply DefaultResultGetter(JsonElement jsonElement)
        {
            var tReplyType = typeof(TReply);
            switch (jsonElement.ValueKind)
            {
                default:
                case JsonValueKind.Undefined:
                case JsonValueKind.Null:
                    return default;
                case JsonValueKind.Object:
                case JsonValueKind.Array:
                    {
                        var subJson = jsonElement.GetRawText();
                        try
                        {
                            return JsonSerializer.Deserialize<TReply>(subJson, SinoiovOutReplyJsonSerializerOptions.Default);
                        }
                        catch (Exception)
                        {
                        }
                    }
                    break;
                case JsonValueKind.String:
                    {
                        if (tReplyType == typeof(string) && jsonElement.GetString() is TReply stringValue)
                        {
                            return stringValue;
                        }
                    }
                    break;
                case JsonValueKind.Number:
                    {
                        if (tReplyType == typeof(byte) && jsonElement.GetByte() is TReply byteValue)
                        {
                            return byteValue;
                        }
                        if (tReplyType == typeof(sbyte) && jsonElement.GetSByte() is TReply sbyteValue)
                        {
                            return sbyteValue;
                        }

                        if (tReplyType == typeof(short) && jsonElement.GetInt16() is TReply int16Value)
                        {
                            return int16Value;
                        }
                        if (tReplyType == typeof(ushort) && jsonElement.GetUInt16() is TReply uint16Value)
                        {
                            return uint16Value;
                        }

                        if (tReplyType == typeof(int) && jsonElement.GetInt32() is TReply int32Value)
                        {
                            return int32Value;
                        }
                        if (tReplyType == typeof(uint) && jsonElement.GetUInt32() is TReply uint32Value)
                        {
                            return uint32Value;
                        }

                        if (tReplyType == typeof(long) && jsonElement.GetInt64() is TReply int64Value)
                        {
                            return int64Value;
                        }
                        if (tReplyType == typeof(ulong) && jsonElement.GetUInt64() is TReply uint64Value)
                        {
                            return uint64Value;
                        }

                        if (tReplyType == typeof(float) && jsonElement.GetSingle() is TReply singleValue)
                        {
                            return singleValue;
                        }
                        if (tReplyType == typeof(double) && jsonElement.GetDouble() is TReply doubleValue)
                        {
                            return doubleValue;
                        }

                        if (tReplyType == typeof(decimal) && jsonElement.GetDecimal() is TReply decimalValue)
                        {
                            return decimalValue;
                        }
                    }
                    break;
                case JsonValueKind.True:
                case JsonValueKind.False:
                    {
                        if (tReplyType == typeof(bool) && jsonElement.GetBoolean() is TReply boolValue)
                        {
                            return boolValue;
                        }
                    }
                    break;
            }

            if (tReplyType == typeof(Guid) && jsonElement.TryGetGuid(out var _guidValue) && _guidValue is TReply guidValue)
            {
                return guidValue;
            }

            if (tReplyType == typeof(DateTime) && jsonElement.TryGetDateTime(out var _dtValue) && _dtValue is TReply dtValue)
            {
                return dtValue;
            }

            if (tReplyType == typeof(DateTimeOffset) && jsonElement.TryGetDateTimeOffset(out var _dtoValue) && _dtoValue is TReply dtoValue)

            {
                return dtoValue;
            }

            if (tReplyType == typeof(byte[]) && jsonElement.TryGetBytesFromBase64(out var _bfbValue) && _bfbValue is TReply bfbValue)
            {
                return bfbValue;
            }

            if (tReplyType == typeof(string) && jsonElement.GetRawText() is TReply rawValue)
            {
                return rawValue;
            }

            throw new InvalidCastException($"无法从 json 内容 【{jsonElement.GetRawText()}】 转换为 {tReplyType.FullName} 类型");
        }

        [JsonIgnore]
        internal virtual string ErrorMessage => this.Status switch
        {
            SinoiovOutReplyStatus.OK => null,
            _ => $"{this.Status.ToMessage()}[{this.RawResult.GetString()}]",
        };
    }
}
