using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UsedGoodsStoreApp.Shared
{
    public class RequestResult
    {
        [JsonConstructor]
        public RequestResult(string successCode, string errorCode)
        {
            SuccessCode = successCode;
            ErrorCode = errorCode;
        }
        public string SuccessCode { get; }
        public bool Succeded => SuccessCode != null;
        public string ErrorCode { get; }
        public bool Failed => ErrorCode != null;

        public static RequestResult Failure(Exception ex) => Failure(ex.InnerException?.Message ?? ex.Message);
        public static RequestResult Failure(string errorCode) => new RequestResult(null, errorCode);
        public static RequestResult Success() => Success("OK");
        public static RequestResult Success(string successCode) => new RequestResult(successCode, null);
    }
}
