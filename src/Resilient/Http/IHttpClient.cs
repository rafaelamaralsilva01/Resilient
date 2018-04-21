using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Resilient.Http
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer);

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer);

        Task<HttpResponseMessage> DeleteAsync(string uri, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer);

        Task<HttpResponseMessage> PutAsync<T>(string uri, T item, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer);
    }
}
