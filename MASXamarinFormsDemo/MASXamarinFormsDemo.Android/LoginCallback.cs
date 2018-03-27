using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.CA.Mas.Foundation;
using Java.Lang;

namespace MASXamarinFormsDemo.Droid
{
    public class LoginCallback : MASCallback
    {

        public bool LoginSuccess { get; set; } = false;

        public bool LoginErrorOccurred { get; set; } = false;

        public string LoginErrorDetails { get; set; } = null;

        public override Handler Handler => new Handler(Looper.MainLooper);

        /// <summary>
        /// Handle an error occurring, including invalid login.
        /// </summary>
        /// <param name="e"></param>
        public override void OnError(Throwable e)
        {
            LoginErrorDetails = e.ToString();
            LoginErrorOccurred = true;
            MAS.CancelAllRequests();
        }

        /// <summary>
        /// Handle successful login attempt.
        /// </summary>
        /// <param name="result"></param>
        public override void OnSuccess(Java.Lang.Object result)
        {
            Console.WriteLine("Success Login!!");
            LoginSuccess = true;
        }
    }
}