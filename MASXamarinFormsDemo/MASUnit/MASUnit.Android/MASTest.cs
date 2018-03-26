using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Com.CA.Mas.Foundation;
using Com.CA.Mas.Foundation.Auth;
using Android.App;
using Java.Lang;
using Org.Json;
using Android.Content;
using System.Collections.Generic;
using Android.Util;

namespace Test
{
    [NUnit.Framework.TestFixture]
    public class MASTest : MASTestBase
    {

        [SetUp]
        public void Setup()
        {
        }


        [TearDown]
        public void Tear()
        {
        }
        #region More Disabled tests
        //[Test]
        //public void TestMASStart()
        //{
        //    MAS.Start(Application.Context, true);
        //    Assert.AreEqual(MASConstants.MasStateStarted, MAS.GetState(Application.Context));
        //}

        //[Test]
        //public void SetClientCredentialFlow()
        //{
        //    MAS.SetGrantFlow(MASConstants.MasGrantFlowClientCredentials);
        //}

        //[Test]
        //public void SetPasswordFlow()
        //{
        //    MAS.SetGrantFlow(MASConstants.MasGrantFlowPassword);
        //}
        #endregion

        [Test]
        public async Task TestGetInvoke()
        {
            //MAS.SetAuthenticationListener(new MyAuthenticationListener());
            MAS.SetGrantFlow(MASConstants.MasGrantFlowClientCredentials);
            MAS.SetConfigurationFileName("msso_config_public.json");
            MAS.Start(Application.Context, true);

            Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
            uriBuilder.AppendEncodedPath("protected/resource/products?operation=listProducts");
            var encodedUri = uriBuilder.Build();

            MASRequestBuilder builder = new MASRequestBuilder(encodedUri);
            builder.ResponseBody(MASResponseBody.JsonBody());
            IMASRequest request = builder.Build();

            //MAS.Invoke(builder.Build(), new ProtectAPICallback());

            Console.WriteLine("-- Before await.");
            //var invokeResponse = await MAS.Invoke(request);
            var invokeResponse = await InvokeAsync(request);

            Assert.IsNotNull(invokeResponse);


            /** Async does not work
            System.Threading.Tasks.Task<IMASResponse> responseTask = MAS.Invoke(builder.Build());
            responseTask.Wait();
            JSONObject jsonObject = (JSONObject)responseTask.Result.Body.Content;
            Console.WriteLine("############### Invoke API Success!! ############### ");
            Console.WriteLine(jsonObject.ToString(4));
            **/

        }

        public Task<IMASResponse> InvokeAsync(IMASRequest request)
        {
            Console.WriteLine("-- Inside Invoke Async");

            var tcs = new TaskCompletionSource<IMASResponse>();
            MAS.Invoke(request, new MASTaskCompletionSource<IMASResponse>(tcs));

            return tcs.Task;
        }

        #region disabled tests

        //[Test]
        //public void TestPostInvoke()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());
        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("httpPost");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
        //    builder.Post(MASRequestBody.JsonBody(new JSONObject()));
        //    MAS.Invoke(builder.Build(), new ProtectAPICallback());
        //}

        //[Test]
        //public void TestDeleteInvoke()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());
        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("httpDelete");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
        //    builder.Delete(null);
        //    MAS.Invoke(builder.Build(), new ProtectAPICallback());
        //    IMASRequest thisrequest = builder.Build();
        //}

        //[Test]
        //public void TestPutInvoke()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());
        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("httpPut");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
        //    builder.Put(MASRequestBody.JsonBody(new JSONObject()));
        //    MAS.Invoke(builder.Build(), new ProtectAPICallback());
        //}

        //[Test]
        //public void TestCustomResponse()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());

        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("protected/resource/products?operation=listProducts");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
        //    builder.Header("test", "test");
        //    builder.ResponseBody(new JSONArrayReponse());
        //    MAS.Invoke(builder.Build(), new ProtectAPICallbackJSONArray());
        //}

        //[Test]
        //public void TestStringPostInvoke()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());
        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("httpPost");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
        //    builder.Post(MASRequestBody.StringBody("Test String"));
        //    MAS.Invoke(builder.Build(), new ProtectAPICallback());
        //}

        //[Test]
        //public void TestURLPostInvoke()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());
        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("httpPost");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());

        //    Pair pair1 = new Pair("var1", "one");
        //    Pair pair2 = new Pair("var2", "two");
        //    List<Pair> encodedList = new List<Pair>();
        //    encodedList.Add(pair1);
        //    encodedList.Add(pair2);

        //    builder.Post(MASRequestBody.UrlEncodedFormBody(encodedList));
        //    MAS.Invoke(builder.Build(), new ProtectAPICallback());
        //}

        //[Test]
        //public void TestBytePostInvoke()
        //{
        //    MAS.SetAuthenticationListener(new MyAuthenticationListener());
        //    Android.Net.Uri.Builder uriBuilder = new Android.Net.Uri.Builder();
        //    uriBuilder.AppendEncodedPath("httpPost");
        //    MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
        //    builder.Post(MASRequestBody.ByteArrayBody(System.Text.Encoding.ASCII.GetBytes("Test byte array")));
        //    MAS.Invoke(builder.Build(), new ProtectAPICallback());
        //}

        //private class JSONArrayReponse : MASResponseBody
        //{
        //    public override Java.Lang.Object Content
        //    {
        //        get
        //        {
        //            JSONObject jObject = (JSONObject)base.Content;
        //            JSONArray jArray = jObject.GetJSONArray("products");
        //            return jArray;
        //        }
        //    }
        //}

        //[Test]
        //public void TestStartWithCustomJSON()
        //{
        //    string mssoString = "";
        //    System.IO.Stream inputStream = Application.Context.Assets.Open("msso_config.json");
        //    using (System.IO.StreamReader reader = new System.IO.StreamReader(inputStream))
        //    {
        //        mssoString = reader.ReadToEnd();
        //    }
        //    JSONObject mssoJson = new JSONObject(mssoString);
        //    MAS.Start(Application.Context, mssoJson);

        //    Assert.AreEqual(MASConstants.MasStateStarted, MAS.GetState(Application.Context));
        //}

        //[Test]
        //public void TestStartWithChangedDefaultConfig()
        //{
        //    MAS.SetConfigurationFileName("custom.json");
        //    MAS.Start(Application.Context, true);
        //}

        //[Test]
        //public void TestStartWithUrl()
        //{
        //    string mssoString = "";
        //    System.IO.Stream inputStream = Application.Context.Assets.Open("msso_config.json");
        //    using (System.IO.StreamReader reader = new System.IO.StreamReader(inputStream))
        //    {
        //        mssoString = reader.ReadToEnd();
        //    }
        //    JSONObject mssoJson = new JSONObject(mssoString);

        //    var path = System.IO.Path.Combine(Application.Context.FilesDir.Path, "test.json");
        //    var fs = new System.IO.FileStream(path, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite);
        //    var outputWriter = new Java.IO.OutputStreamWriter(fs);   
        //    outputWriter.Write(mssoString);
        //    outputWriter.Close();

        //    MAS.Start(Application.Context, new Java.Net.URL("file:" + path));
        //}

        //[Test]
        //public void TestStartWithEnrolmentUrl()
        //{
        //    Java.Net.URL enrolmentUrl = new Java.Net.URL(this.GetEnrollmentURLAsync("https://mobile-staging-xamarinautomation.l7tech.com:8443", "65437eae-a3fb-4c9c-843c-16a876064e07"));
        //    MAS.Start(Application.Context, enrolmentUrl, new StartWithEnrollmentCallback());
        //}

        //[Test]
        //public void EnableDebug()
        //{
        //    MAS.Debug();
        //}


        //[Test]
        //public void GatewayIsReachable()
        //{
        //    MAS.GatewayIsReachable(new GatewayIsReachableCallback());
        //}

        //private class MyAuthenticationListener : Java.Lang.Object, IMASAuthenticationListener
        //{

        //    public void OnAuthenticateRequest(Context context, long requestId, MASAuthenticationProviders providers)
        //    {
        //        Console.WriteLine("############### Implicit Login ############### ");
        //        MASUser.Login("admin", "7layer".ToCharArray(), null);
        //    }

        //    public void OnOtpAuthenticateRequest(Context context, MASOtpAuthenticationHandler handler)
        //    {
        //        throw new NotImplementedException();
        //    }
        //}

        //private class StartWithEnrollmentCallback : MASCallback
        //{
        //    public override void OnError(Throwable e)
        //    {
        //        Console.WriteLine(e.StackTrace);      
        //    }

        //    public override void OnSuccess(Java.Lang.Object result)
        //    {
        //        Console.WriteLine("############### MAS Started With Enrolment URL ###############");
        //    }
        //}

        //private class ProtectAPICallback : MASCallback
        //{

        //    public override void OnError(Throwable p0)
        //    {
        //        Console.WriteLine("############### Invoke API Failed!! ############### ");
        //        Console.WriteLine(p0);
        //    }

        //    public override void OnSuccess(Java.Lang.Object result)
        //    {
        //        IMASResponse response = (IMASResponse)result;
        //        JSONObject jsonObject = (JSONObject)response.Body.Content;
        //        Console.WriteLine("############### Invoke API Success!! ############### ");
        //        Console.WriteLine(jsonObject.ToString(4));
        //    }
        //}

        //private class ProtectAPICallbackJSONArray : MASCallback
        //{
        //    public override void OnError(Throwable p0)
        //    {
        //        Console.WriteLine("############### Invoke API Failed!! ############### ");
        //        Console.WriteLine(p0);
        //    }

        //    public override void OnSuccess(Java.Lang.Object result)
        //    {
        //        IMASResponse response = (IMASResponse)result;
        //        JSONArray jsonObject = (JSONArray)response.Body.Content;
        //        Console.WriteLine("############### Invoke API Success!! ############### ");
        //        Console.WriteLine(jsonObject.ToString(4));
        //    }
        //}

        //private class GatewayIsReachableCallback : MASCallback
        //{
        //    public override void OnError(Throwable p0)
        //    {
        //        Console.WriteLine("############### GatewayIsReachable Failed!! ############### ");
        //        Console.WriteLine(p0);
        //    }

        //    public override void OnSuccess(Java.Lang.Object result)
        //    {
        //        Console.WriteLine("############### GatewayIsReachable result ############### ");
        //        Console.WriteLine(result);
        //    }
        //}

        #endregion

    }

    public class MASTaskCompletionSource<T> : MASCallback where T : class
    {
        private readonly TaskCompletionSource<T> _tcs;

        public MASTaskCompletionSource(TaskCompletionSource<T> tcs)
        {
            Console.WriteLine("-- Inside MASTaskCompletionSource constructor");
            _tcs = tcs;
        }

		public override void OnSuccess(Java.Lang.Object result)
		{
            _tcs.SetResult(result as T);
		}

		public override void OnError(Throwable e)
		{
            _tcs.SetException(e);
		}
	}
}
