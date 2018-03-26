
using Com.CA.Mas.Foundation;
using Android.App;
using Android.Net;
using Java.Lang;
using Org.Json;
using Android.Content;
using Com.CA.Mas.Foundation.Auth;

namespace MASUnit.Android
{
    public class Authentication
    {
        public void invoke()
        {
            MAS.SetAuthenticationListener(new MyAuthenticationListener());

            Uri.Builder uriBuilder = new Uri.Builder();
            uriBuilder.AppendEncodedPath("protected/resource/products?operation=listProducts");
            MASRequestBuilder builder = new MASRequestBuilder(uriBuilder.Build());
            builder.Header("test", "test");
            builder.ResponseBody(MASResponseBody.JsonBody());
            MAS.Invoke(builder.Build(), new ProtectAPICallback());

        }

        public string LoginDefaultUser()
        {
            //MASCallbackFuture future = new MASCallbackFuture();
            MASUser.Login("admin","7layer".ToCharArray(), new LoginCallback());
            return "Login completed successfully";
        }

        public string LogoutUser()
        {
            MASUser.CurrentUser.Logout(null);
            return null;
        }

        public string SetGrantFlowClientCredentials()
        {
            MAS.SetGrantFlow(MASConstants.MasGrantFlowClientCredentials);
            return "ClientCredentials";
        }

        public string SetGrantFlowPassword()
        {
            MAS.SetGrantFlow((MASConstants.MasGrantFlowPassword));
            return "Password";
        }

        public string StartWithDefaultConfiguration()
        {
            MAS.Start(Application.Context, true);
            return "MAS SDK started successfully";
        }

        private class LoginCallback : MASCallback
        {
            public override void OnError(Throwable e)
            {
                throw e;
            }

            public override void OnSuccess(Java.Lang.Object result)
            {
                System.Console.WriteLine("################### RESULT START ###################");
                System.Console.WriteLine(((MASUser)result).AsJSONObject.ToString(4));
                System.Console.WriteLine("################### RESULT END ###################");
            }
        }

        private class ProtectAPICallback : MASCallback
        {
            public override void OnError(Throwable p0)
            {
                throw p0;
            }

            public override void OnSuccess(Java.Lang.Object result)
            {
                IMASResponse response = (IMASResponse)result;
                JSONObject body = (JSONObject)response.Body.Content;
                System.Console.WriteLine("################### RESULT START ###################");
                System.Console.WriteLine(body.ToString(4));
                System.Console.WriteLine("################### RESULT END ###################");

            }
        }

        public class MyAuthenticationListener : Java.Lang.Object, IMASAuthenticationListener
        {
            public void OnAuthenticateRequest(Context context, long p1, MASAuthenticationProviders p2)
            {
                MASUser.Login("admin", "7layer".ToCharArray(), new LoginCallback());
            }

            public void OnOtpAuthenticateRequest(Context p0, MASOtpAuthenticationHandler p1)
            {
                
            }
        }
    }
}
