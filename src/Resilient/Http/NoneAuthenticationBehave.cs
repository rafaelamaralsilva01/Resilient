using System.Net.Http;

namespace Resilient.Http
{
    public class NoneAuthenticationBehave : IAuthenticationBehave
    {
        public static NoneAuthenticationBehave Instance = new NoneAuthenticationBehave();

        public void Prepare(HttpRequestMessage request)
        {
            // Do nothing.
        }
    }
}
