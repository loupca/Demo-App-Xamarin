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
    //public class MASDeviceTest : MASTestBase
    //{

    //    [Test]
    //    public void TestDeRegister()
    //    {
    //        Assume.That(MASDevice.CurrentDevice, Is.Not.Null);
    //        Assume.That(MASDevice.CurrentDevice.IsRegistered, Is.True);
    //        Assume.That(MASUser.CurrentUser, Is.Not.Null);
    //        Assume.That(MASUser.CurrentUser.IsAuthenticated, Is.True);

    //        MASDevice.CurrentDevice.Deregister(new GenericCallback("Deregister"));
    //        Console.WriteLine("############### Deregistered Device!! ###############");

    //        // Make sure that the device is no longer registered
    //        // Assert.That(MASDevice.CurrentDevice.IsRegistered, Is.False);

    //        // Make sure that the current user object has been removed
    //        // Assume.That(MASUser.CurrentUser, Is.Null);
    //    }

    //    [Test]
    //    public void TestResetLocally()
    //    {
    //        Assume.That(MASDevice.CurrentDevice, Is.Not.Null);
    //        Assume.That(MASDevice.CurrentDevice.IsRegistered, Is.True);
    //        Assume.That(MASUser.CurrentUser, Is.Not.Null);
    //        Assume.That(MASUser.CurrentUser.IsAuthenticated, Is.True);

    //        MASDevice.CurrentDevice.ResetLocally();
    //        Console.WriteLine("############### Reset Locally Called!! ###############");

    //        // Make sure that the device is no longer registered
    //        Assert.That(MASDevice.CurrentDevice.IsRegistered, Is.False);

    //        // Make sure that the current user object has been removed
    //        Assume.That(MASUser.CurrentUser, Is.Null);

    //        // Make sure that the current configuration has NOT been removed (DE350392)
    //        Assert.That(MASConfiguration.CurrentConfiguration, Is.Not.Null);
    //    }
    //}
}
