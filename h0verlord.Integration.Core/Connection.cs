using NUnit.Framework;
using RestSharp;
using System;
using System.Configuration;

using System.Net;


namespace h0verlord.Integration.Core
{
    class Connection
    {
        public enum ClientType
        {
            Proxy,
            General
        }
        private string ProxyUrl { get; set; }
        private string Login { get; set; }
        private string Password { get; set; }
        private string BaseUrl { get; set; }
        private RestClient Client { get; set; }

        public Connection(ClientType type)
        {
            BaseUrl = ConfigurationManager.AppSettings["api"];
            ProxyUrl = ConfigurationManager.AppSettings["proxy"];
            Login = ConfigurationManager.AppSettings["username"];
            Password = ConfigurationManager.AppSettings["password"];
            CreateClient(type);
        }

        /// <summary>
        /// Method for creating a RestClient. Possibility of choosing
        /// between using proxy and not using proxy. Depends on the
        /// project.
        /// </summary>
        /// <param name="type">Enum value specifying if proxy should be
        /// used.</param>
        /// <returns>New instance of RestClient</returns>
        private RestClient CreateClient(ClientType type)
        {
            Client = new RestClient
            {
                BaseUrl = new Uri(BaseUrl),
            };            
            Client.AddDefaultHeader("Content-type", "application/json");

            switch (type)
            {
                case ClientType.Proxy:
                    Client.Proxy = new WebProxy(ProxyUrl)
                    {
                        Credentials = new NetworkCredential(Login, Password)
                    };
                    return Client;
                default:
                    return Client;
            }
        }

        /// <summary>
        /// Default method for executing a request. Certificate 
        /// and Client configuration are handled in this method.
        /// </summary>
        /// <typeparam name="T">Generic return type. POCO object is 
        /// specified in separate methods for requests.</typeparam>
        /// <param name="request">Request variable of type 
        /// RestRequest</param>
        /// <param name="code">HTTPStatusCode value that is expected to be
        /// the response. If not specified, 200 is used.
        /// </param>
        /// <returns></returns>
        public T Execute<T>(RestRequest request, HttpStatusCode code = HttpStatusCode.OK) where T : new()
        {
            //Solves the issue with self-signed certificates.
            //Without this it throws an error about not being
            //able to establish a trusted secure connection.
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, errors) => true;

            var response = Client.Execute<T>(request);
            Assert.IsTrue(response.StatusCode.Equals(code),
                "Unexpected StatusCode {0}, expected {1}", response.StatusCode, code);

            //Exception handling. There is a special 500 excpetion message,
            //because this error kept happening randomly at the time
            //this was written.
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                const string invalidCredentials = "The credentials you entered are invalid";
                throw new UnauthorizedAccessException(invalidCredentials);
            }
            //if (response.StatusCode == HttpStatusCode.InternalServerError)
            //{
            //    const string message = "Resulted in Internal Server Error 500.";
            //    throw new ApplicationException(message, response.ErrorException);
            //}
            //if (response.ErrorException != null || response.StatusCode != HttpStatusCode.OK)
            //{
            //    const string message = "Error retrieving response from KB API.";
            //    throw new ApplicationException(message, response.ErrorException);
            //}

            return response.Data;
        }

        //private bool CheckStatusCode<T>(IRestResponse<T> response) where T : new()
        //{
        //    return response.StatusCode.Equals(String.Empty); 
        //}
    }
}
