using System;
using System.Threading;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

using MASFoundation;
using Foundation;


namespace MASxUnit.iOS.PCL
{
    public class AuthenticationTests
    {
        private readonly ITestOutputHelper output;

        public AuthenticationTests(ITestOutputHelper output){
            this.output = output;
        }


        [Fact]
        public void ThisShouldPass()
        {
            Assert.True(true);
        }

        //[Fact]
        //public void InvokeProtectedAPI(){
        //    MAS.GrantFlow = MASGrantFlow.ClientCredentials;
        //    MAS.SetConfigurationFileName("msso_config_public");

        //    MAS.StartWithDefaultConfiguration(true, (a, b) => {
                
        //        Assert.True((bool)a);

        //        MASRequest request = BuildListProductsRequest();

        //        //Invoke the API with builder
        //        MAS.Invoke(request, (aa, bb, error) => {

        //            var test = b;

        //            Assert.NotNull(error);
        //        });
        //    });
        //}


        //[Fact]
        //public async Task StartSdkAsync()
        //{
        //    MAS.GrantFlow = MASGrantFlow.ClientCredentials;
        //    MAS.SetConfigurationFileName("msso_config_public");

        //    var startSdkResult = await MAS.StartWithDefaultConfigurationAsync(true).ConfigureAwait(false);

        //    Assert.True(startSdkResult.Item1);
        //}


        [Fact]
        public async Task InvokeProtectedApiAsync()
        {
            MASRequest request = BuildListProductsRequest();
            output.WriteLine("Before try catch");

            try
            {
                MAS.GrantFlow = MASGrantFlow.ClientCredentials;
                MAS.SetConfigurationFileName("msso_config_public");
                MAS.SetGatewayNetworkActivityLogging(true);
                var startSdkResult = await MAS.StartWithDefaultConfigurationAsync(true).ConfigureAwait(false);

                MAS.GetFrom("/protected/resource/products", 
                            new NSDictionary("operation", "listProducts"), null, (a, b) => {
                                var x = a;
                });

                //Invoke the API with builder
                //InvokeResult invokeResult = await MAS.InvokeAsync(request).ConfigureAwait(false);

                //Assert.NotNull(invokeResult);
            }
            catch(Exception e){
                var x = e;
            }
        }

        private async Task<InvokeResult> InvokeAsync(){
            MAS.GrantFlow = MASGrantFlow.ClientCredentials;
            MAS.SetConfigurationFileName("msso_config_public");

            var startSdkResult = await MAS.StartWithDefaultConfigurationAsync(true).ConfigureAwait(false);

            Assert.True(startSdkResult.Item1); // SDK started succesfully

            MASRequest request = BuildListProductsRequest();

            //Invoke the API with builder
            return await MAS.InvokeAsync(request).ConfigureAwait(false);
        }

        // This is a helper method for building "listProduct" request 
        private MASRequest BuildListProductsRequest()
        {
            //  Create MASRequestBuilder with HTTP method 
            MASRequestBuilder requestBuilder = new MASRequestBuilder("GET");

            //
            //  Specify an endpoint path, any parameters or headers, and request/response type
            //
            requestBuilder.EndPoint = "/protected/resource/products";
            requestBuilder.Query = new NSDictionary("operation", "listProducts");
            requestBuilder.RequestType = MASRequestResponseType.WwwFormUrlEncoded;
            requestBuilder.ResponseType = MASRequestResponseType.Json;

            //  Build MASRequestBuilder to convert into MASRequest object
            return requestBuilder.Build();
        }
    }
}
