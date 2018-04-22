using System;
using System.Net.Http;

namespace Resilient.Http
{
    public class BearerAuthenticateBehave : IBearerAuthenticateBehave
    {
        public void Prepare(HttpRequestMessage request)
        {
            throw new NotImplementedException();
        }
    }
}
