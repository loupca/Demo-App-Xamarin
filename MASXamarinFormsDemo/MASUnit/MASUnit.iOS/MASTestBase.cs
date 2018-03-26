
using System;
using NUnit.Framework;
using MASFoundation;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Net.Http.Headers;
using System.Collections.Generic;
using Foundation;

namespace MASUnit.iOS
{
    public class MASTestBase
    {
        protected static string validUser = "spock";
        protected static string validPassword = "StRonG5^)";

        [SetUp]
        public void SetUp()
        {   
        }

        [TearDown]
        public void TearDown()
        {
            // LogoutUser();
            // DeregisterDevice();
            // StopMAS();
        }

        // Helper methods:

        //
        //  Usage: 
        //  string result = this.GetEnrollmentURLAsync("https://mobile-staging-iosautomation.l7tech.com:8443", "3d6fcaf7-2146-4bf7-8f57-0a8c8e425198");
        //
        public string GetEnrollmentURLAsync(string gatewayUrl, string clientId)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
            (sender, cert, chain, sslPolicyErrors) =>
            {
                if (cert != null) System.Diagnostics.Debug.WriteLine(cert);
                return true;
            };

            string responseString = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(gatewayUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", "admin"),
                    new KeyValuePair<string, string>("sub", "administrator"),
                    new KeyValuePair<string, string>("client_id", clientId)
                });
                var response = client.PostAsync("/connect/device/enrollment", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = response.Content;
                    responseString = responseContent.ReadAsStringAsync().Result;
                }
            }

            return responseString;
        }

        // Set grant flow "Password"
        protected void SetGrantFlowPassword()
        {
            MAS.GrantFlow = MASGrantFlow.Password;
        }

        // Set grant flow "ClientCredentials"
        protected void SetGrantFlowClientCredentials()
        {
            MAS.GrantFlow = MASGrantFlow.ClientCredentials;
        }

        // Start MAS with password grant flow:
        protected void StartMASPasswordGrantFlow()
        {
            SetGrantFlowPassword();

            MAS.StartWithDefaultConfiguration(true, completion: (completed, error) =>
            {
                if (completed)
                    Console.WriteLine("MAS started successfully.");
                if (error != null)
                    Console.WriteLine("Failed to start MAS: {0}", error.LocalizedDescription);
            });
        }

        // Start MAS with client credentials grant flow:
        protected void StartMASClientCredentialsGrantFlow()
        {
            SetGrantFlowClientCredentials();

            MAS.StartWithDefaultConfiguration(true, completion: (completed, error) =>
            {
                if (completed)
                    Console.WriteLine("MAS started successfully.");
                if (error != null)
                    Console.WriteLine("Failed to start MAS: {0}", error.LocalizedDescription);
            });
        }

        // Login
        protected void LoginUser(string user, string password)
        {
            MASUser.LoginWithUserName(user, password, completion: (completed, error) =>
            {
                if (completed)
                    Console.WriteLine("Successfully logged in as {0}", user);
                if (error != null)
                    Console.WriteLine("Failed to login as {0} with password {1}", user, password);
            });
        }

        // Logout
        protected void LogoutUser()
        {
            if (MASUser.CurrentUser != null)
            {
                MASUser.CurrentUser.LogoutWithCompletion(completion: (completed, error) =>
                {
                    if (completed)
                        Console.WriteLine("Successfully logout current user");
                    if (error != null)
                        Console.WriteLine("Failed to logout current user: {0}", error.LocalizedDescription);
                });
            }
        }

        // This is a helper method for building "listProduct" request 
        protected MASRequest BuildListProductsRequest()
        {
            //  Create MASRequestBuilder with HTTP method 
            MASRequestBuilder requestBuilder = new MASRequestBuilder("GET");

            //
            //  Specify an endpoint path, any parameters or headers, and request/response type
            //
            requestBuilder.EndPoint = "/protected/resource/products";
            requestBuilder.Query = new NSDictionary("operation", "listProducts");
            //requestBuilder.RequestType = MASRequestResponseType.WwwFormUrlEncoded;
            //requestBuilder.ResponseType = MASRequestResponseType.Json;

            //  Build MASRequestBuilder to convert into MASRequest object
            return requestBuilder.Build();
        }

        // Deregister device
        protected void DeregisterDevice()
        {
            if (MASDevice.CurrentDevice() != null)
            {
                MASDevice.CurrentDevice().DeregisterWithCompletion(completion: (deregisteredSuccessfully, error) =>
                {
                    if (deregisteredSuccessfully)
                        Console.WriteLine("Device deregistered successfully.");
                    if (error != null)
                        Console.WriteLine("Failed to deregister device: {0}", error.LocalizedDescription);
                });

            }
        }

        // Stop MAS
        protected void StopMAS()
        {
            MAS.Stop(completion: (stoppedSuccessfully, error) =>
            {
                if (stoppedSuccessfully)
                    Console.WriteLine("MAS stopped successfully.");
                if (error != null)
                    Console.WriteLine("Failed to stop MAS: {0}", error.LocalizedDescription);
            });
        }
    }
}
