using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Text;
using JetBrains.Annotations;

namespace tniTestSiteWeb.Services.Implementation
{

    public class HttpService : IHttpService
    {
        /// <summary>
        ///     Осуществляет Get запрос по указанному адресу и возвращает результат (response) в виде строки.
        ///     В случае, если контент не пуст прибавляется через 
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        public async Task<string> GetAndReadAsStringAsync(string url,
            IEnumerable<KeyValuePair<string, string>> content,
            CancellationToken cancellationToken = default(CancellationToken))
        {

            var urlParams = string.Join("&", content.Select(s => string.Concat(s.Key, "=", HttpUtility.UrlEncode(s.Value))).ToArray()); //content.ToQueryStringParameters(url.Contains("?") ? "&" : "?");

            url = url + (url.Contains("?") ? "&" : "?") + urlParams;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url, cancellationToken).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                    throw new HttpClientException(response.ReasonPhrase, response.StatusCode);

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }


        /// <summary>
        ///     Осуществляет Get запрос по указанному адресу и возвращает результат (response) в виде строки.
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        public string GetAndReadAsString(string url, IEnumerable<KeyValuePair<string, string>> content)
        {
            return GetAsyncHttpClientResultSynchronously(this.GetAndReadAsStringAsync(url, content));
        }

        /// <summary>
        ///     Осуществляет POST запрос по указанному адресу и возвращает результат (response) в виде строки.
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        public async Task<string> PostStringAndReadAsStringAsync(string url, string content, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = new HttpClient())
            {

                var response = await client.PostAsync(url, new StringContent(content, Encoding.UTF8, "application/json"), cancellationToken).ConfigureAwait(false);

                if (!response.IsSuccessStatusCode)
                    throw new HttpClientException(response.ReasonPhrase, response.StatusCode);

                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }

        /// <summary>
        ///     Осуществляет POST запрос по указанному адресу и возвращает результат (response) в виде строки.
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        public string PostStringAndReadAsString(string url, string content)
        {
            return GetAsyncHttpClientResultSynchronously(this.PostStringAndReadAsStringAsync(url, content));
        }

        private static T GetAsyncHttpClientResultSynchronously<T>(Task<T> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
