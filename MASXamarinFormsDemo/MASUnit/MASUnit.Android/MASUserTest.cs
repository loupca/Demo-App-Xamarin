using System;
using NUnit.Framework;
using Com.CA.Mas.Foundation;
using Com.CA.Mas.Foundation.Auth;
using Android.App;
using Java.Util.Concurrent;
using Java.Lang;
using Org.Json;
using Android.Content;

namespace Test
{
    //[TestFixture]
    //public class MASUserTest : MASTestBase
    //{
    //    public MASUserTest()
    //    {
    //    }

    //    [Test]
    //    public void login()
    //    {
    //        LoginCallback loginCallback = new LoginCallback();
    //        MASUser.Login("admin", "7layer".ToCharArray(), loginCallback);
    //    }

    //    [Test]
    //    public void logout()
    //    {
    //        MASUser.CurrentUser.Logout(new GenericCallback("Logout"));
    //    }

    //    [Test]
    //    public void lockSession()
    //    {
    //        MASUser.CurrentUser.LockSession(new GenericCallback("lockSession"));
    //    }

    //    [Test]
    //    public void UnlockSession()
    //    {
    //        MASUser.CurrentUser.UnlockSession(new UnlockCallback());
    //    }

    //    private class UnlockCallback : MASSessionUnlockCallback
    //    {
    //        public override void OnError(Throwable e)
    //        {
    //            Console.WriteLine("############### Session unlocked Failed!! ############### ");
    //        }

    //        public override void OnSuccess(Java.Lang.Object result)
    //        {
    //            Console.WriteLine("############### Session unlocked Success!! ############### ");
    //        }

    //        public override void OnUserAuthenticationRequired()
    //        {
    //            KeyguardManager keyguardManager = (KeyguardManager)Application.Context.GetSystemService(Context.KeyguardService);
    //            Intent intent = keyguardManager.CreateConfirmDeviceCredentialIntent("Title","key");
    //            Application.Context.StartActivity(intent);
    //        }
    //    }

    //    [Test]
    //    public void IsSessionLocked()
    //    {
    //        if (MASUser.CurrentUser.IsSessionLocked) {
    //            Console.WriteLine("############### Session Locked!! ############### ");
    //        } else {
    //            Console.WriteLine("############### Session unLocked!! ############### ");
    //        }
    //    }

    //    private class LoginCallback : MASCallback
    //    {
    //        public override void OnError(Throwable e)
    //        {
    //            Console.WriteLine("############### Fail Login!! ############### ");
    //            Console.WriteLine(e);
    //            MAS.CancelAllRequests();
    //        }

    //        public override void OnSuccess(Java.Lang.Object user)
    //        {
    //            Console.WriteLine("############### Success Login!! ############### ");
    //            Console.WriteLine(((MASUser)user).AsJSONObject.ToString(4));
    //        }
    //    }
    //}
}
