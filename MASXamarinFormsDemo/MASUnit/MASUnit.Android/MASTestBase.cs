using System;
using NUnit.Framework;
using Com.CA.Mas.Foundation;
using Com.CA.Mas.Foundation.Auth;
using Android.App;
using Java.Util.Concurrent;
using Java.Lang;
using Org.Json;
using Android.Content;
using System.Net;
using System.IO;

namespace Test
{
    public class MASTestBase
    {
        public static string MSSO_CONFIG = "msso_config.json";
        public static string CUSTOM_CONFIG = "custom.json";
        public static string ANDROID_CONFIG = "android_config.json";

        public MASTestBase()
        {
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
            string thisUri = gatewayUrl + "/connect/device/enrollment";
            string postData = "username=admin&sub=administrator&client_id="+clientId;

            string responseString = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(thisUri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";

            byte[] data = System.Text.Encoding.ASCII.GetBytes(postData);
            request.ContentLength = data.Length;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(data, 0, data.Length);
            requestStream.Close();

            //request

            HttpWebResponse myResp = (HttpWebResponse)request.GetResponse();

            using (var response = request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }

            return responseString;
        }

        public void StartWithCustomMssoConfig(string msso) {
            MAS.SetConfigurationFileName(msso);
            MAS.Start(MAS.Context, true);
        }

        public bool SdkIsStarted() {
            return MAS.GetState(Application.Context) == MASConstants.MasStateStarted;
        }

        protected class GenericCallback : MASCallback
        {
            private string action;
            public GenericCallback(string action)
            {
                this.action = action;
            }
            public override void OnError(Throwable e)
            {
                Console.WriteLine("############### Failed " + action + " !! ############### ");
                Console.WriteLine(e);
            }

            public override void OnSuccess(Java.Lang.Object obj)
            {
                Console.WriteLine("############### Success!!" + action + " !!###############");
                if (obj!= null) {
                    Console.WriteLine(obj.ToString());
                }
            }
        }
    }
}
