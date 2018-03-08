using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $rootnamespace$
{
    public static class CreateRequest
    {
        private static Connection Api;

        static CreateRequest()
        {
            Api = new Connection(Connection.ClientType.Proxy);
        }

        /// <summary>
        /// Creates a GET request on the endpoint specified in the parameter.
        /// </summary>
        /// <typeparam name="T">POCO of the response object</typeparam>
        /// <param name="resource">Specific endpoint</param>
        /// <returns></returns>
        public static T Get<T>(string resource) where T : new()
        {
            var request = new RestRequest(Method.GET)
            {
                Resource = ConfigurationManager.AppSettings[resource]
            };
            return Api.Execute<T>(request);
        }

        /// <summary>
        /// Creates a POST request on the specified endpoint and returns data
        /// </summary>
        /// <typeparam name="T">POCO of the response object</typeparam>
        /// <param name="resource">Specific endpoint</param>
        /// <param name="json">Object added to the body of the request</param>
        /// <returns></returns>
        public static T Post<T>(string resource, object json) where T : new()
        {
            var request = new RestRequest(Method.POST)
            {
                Resource = ConfigurationManager.AppSettings[resource]
            };
            request.AddJsonBody(json);

            return Api.Execute<T>(request);
        }
    }
}
