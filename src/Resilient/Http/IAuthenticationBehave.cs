using System.Net.Http;

namespace Resilient.Http
{
    public interface IAuthenticationBehave
    {
        void Prepare(HttpRequestMessage request);
    }
}
