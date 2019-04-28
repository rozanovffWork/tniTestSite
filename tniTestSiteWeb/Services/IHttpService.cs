using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace tniTestSiteWeb.Services
{
    public interface IHttpService
    {
        /// <summary>
        ///     Осуществляет Get запрос по указанному адресу и возвращает результат (response) в виде строки.
        ///     В случае, если контент не пуст прибавляется через 
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        Task<string> GetAndReadAsStringAsync(string url,
            IEnumerable<KeyValuePair<string, string>> content,
            CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        ///     Осуществляет Get запрос по указанному адресу и возвращает результат (response) в виде строки.
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        string GetAndReadAsString(string url, IEnumerable<KeyValuePair<string, string>> content);

        /// <summary>
        ///     Осуществляет POST запрос по указанному адресу и возвращает результат (response) в виде строки.
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        string PostStringAndReadAsString(string url, string content);

        /// <summary>
        ///     Осуществляет POST запрос по указанному адресу и возвращает результат (response) в виде строки.
        /// </summary>
        /// <exception cref="HttpClientException"></exception>
        Task<string> PostStringAndReadAsStringAsync(string url, string content,
            CancellationToken cancellationToken = default(CancellationToken));
    }
}
