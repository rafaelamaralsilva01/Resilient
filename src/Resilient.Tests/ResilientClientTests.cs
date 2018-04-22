using Microsoft.VisualStudio.TestTools.UnitTesting;
using Polly;
using Resilient.Http;
using System;
using System.Diagnostics;
using System.Net.Http;

namespace Resilient.Tests
{
    [TestClass]
    public class ResilientClientTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var retryCount = 2;

            var policy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetry(
                    retryCount,
                    retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    (exception, time, retry, context) => Debug.WriteLine(exception.Message)
                );

            var origin = "http://localhost:8080/api/values";

            var client = new ResilientHttpClient();

            client.GetStringAsync(origin);
        }
    }
}
