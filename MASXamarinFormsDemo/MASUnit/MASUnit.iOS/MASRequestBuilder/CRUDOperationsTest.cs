
using System;
using Foundation;
using MASFoundation;
using NUnit.Framework;

namespace MASUnit.iOS.MASRequestTests
{
    [TestFixture]
    public class CRUDOperationsTest : MASTestBase
    {
        [Test]
        [Description("Test getFrom:withParameters:andHeaders:completion:")]
        public void __01__GetFrom_with_param_and_header()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.GetFrom("/echo", queryParam, headerParam, completion: (response, error) =>
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

        [Test]
        [Description("Test getFrom:withParameters:andHeaders:requestType:responseType:completion:")]
        public void __02__GetFrom_with_requestType_and_responseType()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.GetFrom("/echo", queryParam, headerParam, MASRequestResponseType.Json, MASRequestResponseType.Json, completion: (response, error) =>
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

        [Test]
        [Description("Test getFrom:withParameters:andHeaders:requestType:responseType:isPublic:completion:")]
        public void __03__GetFrom_with_isPublicFalse()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.GetFrom("/echo", queryParam, headerParam, MASRequestResponseType.Json, MASRequestResponseType.Json, false, completion: (response, error) =>
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

        [Test]
        [Description("Test getFrom:withParameters:andHeaders:requestType:responseType:isPublic:completion:")]
        public void __04__GetFrom_with_isPublicTrue()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            // Note: this call is expected to fail, since all automatically injected credentials in SDK will be excluded from the request.
            MAS.GetFrom("/echo", queryParam, headerParam, MASRequestResponseType.Json, MASRequestResponseType.Json, true, completion: (response, error) =>
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

        [Test]
        [Description("Test postTo:withParameters:andHeaders:completion:")]
        public void __05__PostTo_with_param_and_header()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary bodyParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.PostTo("/echo", bodyParam, headerParam, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.PostTo: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test postTo:withParameters:andHeaders:requestType:responseType:completion:")]
        public void __06__PostTo_with_param_and_header_requestType_responseType()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary bodyParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.PostTo("/echo", bodyParam, headerParam, MASRequestResponseType.TextPlain, MASRequestResponseType.TextPlain, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.PostTo: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test postTo:withParameters:andHeaders:requestType:responseType:isPublic:completion:")]
        public void __07__PostTo_with_isPublicTrue()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary bodyParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            // Note: this call is expected to fail, since all automatically injected credentials in SDK will be excluded from the request.
            MAS.PostTo("/echo", bodyParam, headerParam, MASRequestResponseType.TextPlain, MASRequestResponseType.TextPlain, true, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.PostTo: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test putTo:withParameters:andHeaders:completion:")]
        public void __08__PutTo_with_param_and_header()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary bodyParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.PutTo("/echo", bodyParam, headerParam, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.PutTo: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test putTo:withParameters:andHeaders:requestType:responseType:completion:")]
        public void __09__PutTo_with_param_and_header_requestType_responseType()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary bodyParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.PutTo("/echo", bodyParam, headerParam, MASRequestResponseType.TextPlain, MASRequestResponseType.TextPlain, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.PutTo: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test putTo:withParameters:andHeaders:requestType:responseType:isPublic:completion:")]
        public void __10__PutTo_with_isPublicTrue()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary bodyParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            // Note: this call is expected to fail, since all automatically injected credentials in SDK will be excluded from the request.
            MAS.PutTo("/echo", bodyParam, headerParam, MASRequestResponseType.TextPlain, MASRequestResponseType.TextPlain, true, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.PutTo: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test deleteFrom:withParameters:andHeaders:completion:")]
        public void __11__DeleteFrom_with_param_and_header()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.DeleteFrom("/echo", queryParam, headerParam, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.DeleteFrom: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test deleteFrom:withParameters:andHeaders:requestType:responseType:completion:")]
        public void __12__DeleteFrom_with_requestType_and_responseType()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.DeleteFrom("/echo", queryParam, headerParam, MASRequestResponseType.Json, MASRequestResponseType.Json, completion: (response, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API with MAS.DeleteFrom: {0}", error.LocalizedDescription);
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

        [Test]
        [Description("Test deleteFrom:withParameters:andHeaders:requestType:responseType:isPublic:completion:")]
        public void __13__DeleteFrom_with_isPublicFalse()
        {
            Assume.That(MASUser.CurrentUser, Is.Not.Null);
            NSDictionary queryParam = new NSDictionary(NSObject.FromObject("operation"), NSObject.FromObject("listProducts"));
            NSDictionary headerParam = new NSDictionary(NSObject.FromObject("header"), NSObject.FromObject("value"));

            MAS.DeleteFrom("/echo", queryParam, headerParam, MASRequestResponseType.Json, MASRequestResponseType.Json, false, completion: (response, error) =>
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
