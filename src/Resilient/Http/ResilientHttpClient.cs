using Polly;
using Polly.Wrap;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Resilient.Http
{
    public class ResilientHttpClient : IHttpClient
    {
        private readonly AuthenticationBehaveFactory authenticationBehaveFactory;
        private ConcurrentDictionary<string, PolicyWrap> policyWrappers;

        public ResilientHttpClient() : this(DefaultFactory)
        {
        }

        public ResilientHttpClient(AuthenticationBehaveFactory authenticationBehaveFactory)
        {
            this.authenticationBehaveFactory = authenticationBehaveFactory;
            this.policyWrappers = new ConcurrentDictionary<string, PolicyWrap>();
        }

        public Task<HttpResponseMessage> DeleteAsync(string uri, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetStringAsync(string uri, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PostAsync<T>(string uri, T item, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<T>(string uri, T item, AuthenticationMethodTypes authorizationMethod = AuthenticationMethodTypes.Bearer)
        {
            throw new NotImplementedException();
        }

        private async Task<T> HttpInvoker<T>(string origin, Func<Task<T>> action)
        {
            var normalizedOrigin = NormalizeOrigin(origin);

            //if (!_policyWrappers.TryGetValue(normalizedOrigin, out PolicyWrap policyWrap))
            //{
            //    policyWrap = Policy.WrapAsync(_policyCreator(normalizedOrigin).ToArray());
            //    _policyWrappers.TryAdd(normalizedOrigin, policyWrap);
            //}

            // Executes the action applying all 
            // the policies defined in the wrapper
            // return await policyWrap.ExecuteAsync(action, new Context(normalizedOrigin));
            throw new NotImplementedException();
        }

        private static string NormalizeOrigin(string origin)
        {
            return origin?.Trim()?.ToLower();
        }

        private static string GetOriginFromUri(string uri)
        {
            var url = new Uri(uri);

            var origin = $"{url.Scheme}://{url.DnsSafeHost}:{url.Port}";

            return origin;
        }

        private static IAuthenticationBehave DefaultFactory(AuthenticationMethodTypes type)
        {
            switch (type)
            {
                case AuthenticationMethodTypes.Bearer:
                    return new BearerAuthenticateBehave();
                case AuthenticationMethodTypes.OpenId:
                    return null;
                default:
                    throw new NotSupportedException(type.ToString());
            }
        }
    }

    public class PolicyManager
    {
        private ConcurrentDictionary<string, PolicyWrap> policyWrappers;

        public void AddPolicy(string origin, PolicyWrap policy)
        {

        }
    }

    public delegate IAuthenticationBehave AuthenticationBehaveFactory(AuthenticationMethodTypes authenticationMethodType);
}
