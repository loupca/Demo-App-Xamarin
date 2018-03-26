using System;
using Foundation;
using MASFoundation;
using NUnit.Framework;

namespace MASUnit.iOS.MASRequestTests
{
    [TestFixture]
    public class GeolocationTest : MASTestBase
    {
        [Test]
        public void __01__Geolocation_Required()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"),
                                                        NSObject.FromObject("value"));
            MAS.GetFrom("/geoprotected", queryParam, headerParam, MASRequestResponseType.Json, MASRequestResponseType.Json, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.GetFrom: {0}", error.LocalizedDescription);
                }
                else if (response != null)
                {
                    if (response.ContainsKey(new NSString("MASResponseInfoBodyInfoKey")))
                    {
                        NSDictionary responseValues = response;
                        var responseBody = responseValues[NSObject.FromObject("MASResponseInfoBodyInfoKey")].ToString();
                        Console.WriteLine("Response body: {0}", responseBody);

                        // Assert.That(responseBody.Contains("products"));
                    }
                    else
                    {
                        Console.WriteLine("Response body does not contain 'MASResponseInfoBodyInfoKey' key!");
                    }
                }
            });
        }
    }
}
