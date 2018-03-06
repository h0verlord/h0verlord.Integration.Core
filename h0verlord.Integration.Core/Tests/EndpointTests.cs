﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using h0verlord.Integration.Core.Objects;

namespace h0verlord.Integration.Core
{
    public class EndpointTests
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
