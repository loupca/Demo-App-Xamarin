using System;
using System.Threading;
using System.Threading.Tasks;

using NUnit;
using NUnit.Framework;

using MASFoundation;
using Foundation;

namespace MASUnit3.iOS.Standard
{
    [TestFixture]
    public class iOSAuthenticationTests
    {

        [Test]
        public void ShouldPass()
        {
            Assert.IsTrue(true);
        }

        [Test]
        public async Task InvokeAsyncApi(){
            MASRequest request = BuildListProductsRequest();

            MAS.GrantFlow = MASGrantFlow.ClientCredentials;
            MAS.SetConfigurationFileName("msso_config_public");
            var startSdkResult = await MAS.StartWithDefaultConfigurationAsync(true);

            MAS.Invoke(request, (a, b, error) =>
            {
                var copyB = b;
            });

            Assert.IsTrue(false);

            //Invoke the API with builder
            //InvokeResult invokeResult = await MAS.InvokeAsync(request);

            //Assert.IsNotNull(invokeResult);
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
            //requestBuilder.EndPoint = "/protected/resource/products?operation=listProducts";
            requestBuilder.Query = new NSDictionary("operation", "listProducts");
            requestBuilder.RequestType = MASRequestResponseType.WwwFormUrlEncoded;
            requestBuilder.ResponseType = MASRequestResponseType.Json;

            //  Build MASRequestBuilder to convert into MASRequest object
            return requestBuilder.Build();
        }
    }
}
