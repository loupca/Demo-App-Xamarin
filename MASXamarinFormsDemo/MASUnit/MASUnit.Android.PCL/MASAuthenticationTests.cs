using System;
using System.Threading.Tasks;
using Xunit;

using Android.App;

using Com.CA.Mas.Foundation;
using Com.CA.Mas.Foundation.Auth;

namespace MASxUnit.Droid.PCL
{
    public class MASAuthenticationTests
    {

        [Fact]
        public async Task TestGetInvoke()
        {
            MAS.SetGrantFlow(MASConstants.MasGrantFlowClientCredentials);
            MAS.SetConfigurationFileName("msso_config_public.json");
            MAS.Start(Application.Context, true);

            Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
            uriBuilder.AppendEncodedPath("protected/resource/products?operation=listProducts");

            MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
            builder.ResponseBody(MASResponseBody.JsonBody());
            IMASRequest request = builder.Build();

            IMASResponse invokeResponse = await MAS.Invoke(request);

            Assert.NotNull(invokeResponse);
            Assert.Contains("Red Stapler", invokeResponse.Body.Content.ToString());

        }
    }
}
