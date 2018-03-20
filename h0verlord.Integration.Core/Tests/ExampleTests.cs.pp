using NUnit.Framework;
using System;
using h0verlord.Integration.Core;
using $rootNamespace$.Objects;

namespace $rootNamespace$.Tests
{
    public class ExampleTests
    {
        [Test]
        public void When_CallEndpoint_Expect_DataReturned()
        {
            /*
             * Create a GET request on the API endpoint.
             * Verify that there are data returned.
             */

            var response = CreateRequest.Get<SampleResponseObject>("endpoint");			
            Assert.IsTrue(!response.Equals(String.Empty));

        }
    }
}
