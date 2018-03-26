using System;
using System.Threading.Tasks;
using NUnit.Framework;

using Android.App;

using Com.CA.Mas.Foundation;
using Com.CA.Mas.Foundation.Auth;

namespace MASUnit3.Droid.Standard
{
    [TestFixture]
    public class DroidAuthenticationTests
    {
        [Test]
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
            Assert.IsTrue(invokeResponse.Body.Content.ToString().Contains("Red Stapler"));

        }
    }
}
