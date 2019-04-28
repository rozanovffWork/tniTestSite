using System;
using System.Net;

namespace tniTestSiteWeb.Services.Implementation
{
    /// <summary>
    ///     Ошибка обработки HttpClient
    /// </summary>
    public sealed class HttpClientException : Exception
    {
        
        
        /// <summary>
        /// 
        /// </summary>
        public readonly HttpStatusCode StatusCode;
        

        /// <summary>
        /// 
        /// </summary>
        public HttpClientException(string message, HttpStatusCode statusCode, Exception innerException = null)
            : base(message, innerException)
        {
            this.StatusCode = statusCode;
            this.Data["StatusCode"] = statusCode;
        }

        public override string ToString()
        {
            return "StatusCode:" + StatusCode + ", message:" + this.Message + ", base:" + base.ToString();
        }
    }
}
