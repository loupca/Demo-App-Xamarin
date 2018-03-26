
using System;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using MASFoundation;
using Foundation;

namespace MASUnit.iOS.Authentication 
{
    [TestFixture]
    public class ClientCredentialRegistrationFlow : MASTestBase
    {
        //[Test, Description("Make sure that MAS.GrantFlow can be set to 'ClientCredentials'")]
        //public void Tc01SetGrantFlowClientCredentials()
        //{
        //    MAS.GrantFlow = MASGrantFlow.ClientCredentials;
        //    Assert.AreEqual(MAS.GrantFlow, MASGrantFlow.ClientCredentials, "MAS GrantFlow set to ClientCredentials.");
        //}

        //[Test]
        //public async void Tc02StartWithDefaultConfiguration()
        //{
        //    // 1. Set grant flow of SDK to client credentials
        //    // SetGrantFlowClientCredentials();
        //    MAS.SetConfigurationFileName("msso_config_public");

        //    // 2. StartWithDefaultConfiguration
        //    var asyncTask = await MAS.StartWithDefaultConfigurationAsync(true);

        //    var current = Thread.CurrentThread;

        //    Assert.IsTrue(asyncTask.Item1);

        //}

        //[Test]
        //public void Tc03InvokeApiSuccessfully()
        //{
        //    // StartMASClientCredentialsGrantFlow();
        //    // Invoke protected endpoint using GET request when user is authenticated (expect successful consumption)
        //    MASRequest request = BuildListProductsRequest();
        //    MAS.Invoke(request, completion: (response, responsePayload, error) =>
        //    {
        //        // NO ASSERTIONS WORK... 
        //        // Assert.NotNull(response, "Got response upon consumption of protected API when using client credentials flow");
        //        // Assert.True(response.ContainsKey(new NSString("MASResponseInfoBodyInfoKey")), "Response contains MASResponseInfoBodyInfoKey key.");
        //        // Assert.Null(error, "No errors were reported.");

        //        // Manual verification:
        //        if (error != null)
        //        {
        //            Console.WriteLine("Error occured upon consumption of protected API: {0}", error.LocalizedDescription);
        //        }
        //        else if (response != null)
        //        {
        //            Console.WriteLine("Response body: {0}", responsePayload);
        //            // Assert.That(responseBody.Contains("products"));
        //        }
        //    });
        //}

        [Test]
        public async Task InvokeProtectedAPI(){
            MAS.GrantFlow = MASGrantFlow.ClientCredentials;
            MAS.SetConfigurationFileName("msso_config_public");

            var startSdkResult = await MAS.StartWithDefaultConfigurationAsync(true);

            Assert.IsTrue((bool)startSdkResult.Item1);

            MASRequest request = BuildListProductsRequest();

            //Invoke the API with builder
            InvokeResult requestResult = await MAS.InvokeAsync(request);

            Assert.IsNotNull(requestResult);

            //MAS.Invoke(request, (a, b, c) => {
            //    var x = b.ToString();
            //});
        }

        private async Task<string> TestAsyncSeparateMethod(){

            MAS.GrantFlow = MASGrantFlow.ClientCredentials;
            MAS.SetConfigurationFileName("msso_config_public");

            var startSdkResult = await MAS.StartWithDefaultConfigurationAsync(true);

            Assert.IsTrue((bool)startSdkResult.Item1);

            MASRequest request = BuildListProductsRequest();

            //Invoke the API with builder
            //return await MAS.InvokeAsync(request);

            return await WrapInvokeAsync2(request);
        }



        private Task<string> WrapInvokeAsync(MASRequest request){

            return Task.Run( () => {
                var completionDelegate = new TaskCompletionSource<string>();

                MAS.Invoke(request, (a, b, c) => completionDelegate.SetResult(b.ToString()));

                return completionDelegate.Task;
            });

            //MAS.Invoke(request, (req, response, error) => {
            //    return Task.FromResult(response);
            //});
        }

        private Task<string> WrapInvokeAsync2(MASRequest request)
        {
            var completionDelegate = new TaskCompletionSource<string>();

            MAS.Invoke(request, (a, b, c) =>
                      completionDelegate.SetResult(b.ToString())
            );

            return completionDelegate.Task;
        }


        [Test]
        public void AsyncTestMethod()
        {

            var test = WaitThreeSeconds().Result;

            Assert.IsTrue(test);

            //Thread.Sleep(1000);
            //var boolResult = await Task.FromResult(true);

            //Assert.IsTrue(boolResult);
        }

        private async Task<bool> WaitThreeSeconds()
        {

            Thread.Sleep(1000);

            return await Task.FromResult(true);

        }
    }
}
