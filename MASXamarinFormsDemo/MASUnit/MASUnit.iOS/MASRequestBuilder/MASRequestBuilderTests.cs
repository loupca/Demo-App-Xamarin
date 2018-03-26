
using System;
using NUnit.Framework;
using MASFoundation;
using Foundation;

namespace MASUnit.iOS.MASRequestBuilderTest
{
    [TestFixture]
    public class MASRequestBuilderTests : MASTestBase
    {
        private static MASRequestBuilder requestBuilder = null;
        private static MASRequest request = null;
        private static string httpMethod;

        static object[] HttpMethods =
        {
            new object[] { "GET" },
            new object[] { "PUT" },
            new object[] { "POST" },
            new object[] { "DELETE" },
            new object[] { "INVALID" }
        };

        static object[] EndPoints =
        {
            new object[] { "/protected/resource/products" },
            new object[] { "/echo" },
            new object[] { "https://invalid.com:8443/protected/resource/products" }
        };

        static object[] QueryParams =
        {
            new object[] { "operation", "listProducts" },
            new object[] { "param1", "value" },
            new object[] { "operation", null },
            new object[] { "i must be", "%escaped[]{}" }
        };

        static object[] HeaderParams =
        {
            new object[] { "header1", "value1" },
            new object[] { "header2", "value2" },
            new object[] { "header3", null },
            new object[] { "i must be", "%escaped[]{}" }
        };

        static object[] RequestBodies =
        {
            new object[] { "text", "value1" },
            new object[] { "json", "{\"param1\": \"value1\", \"param2\": \"value2\"}" }
        };

        static object[] ContentTypes =
        {
            new object[] { "Unknown" },
            new object[] { "Json" },
            new object[] { "ScimJson" },
            new object[] { "TextPlain" },
            new object[] { "WwwFormUrlEncoded" },
            new object[] { "Xml" },
            new object[] { "Count" }
        };

        static object[] IsPublic =
        {
            new object[] { true },
            new object[] { false }
        };

        static object[] Sign =
        {
            new object[] { true },
            new object[] { false }
        };

        static object[] Claims =
        {
            new object[] { "claim1, claim2" },
            new object[] { "claim3, claim4" }
        };

        [Test]
        public void __dump__MASRequestBuilder()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("HttpMethod: {0}", requestBuilder.HttpMethod);
            Console.WriteLine("EndPoint: {0}", requestBuilder.EndPoint);
            Console.WriteLine("IsPublic: {0}", requestBuilder.IsPublic);
            Console.WriteLine("Sign: {0}", requestBuilder.Sign);
            Console.WriteLine("Claims: {0}", requestBuilder.Claims);
            Console.WriteLine("PrivateKey: {0}", requestBuilder.PrivateKey);
            Console.WriteLine("Header: {0}", requestBuilder.Header);
            Console.WriteLine("Query: {0}", requestBuilder.Query);
            Console.WriteLine("Body: {0}", requestBuilder.Body);
            Console.WriteLine("RequestType: {0}", requestBuilder.RequestType);
            Console.WriteLine("ResponseType: {0}", requestBuilder.ResponseType);
            Console.WriteLine("===========================");
        }

        [Test]
        public void __dump__MASRequest()
        {
            Console.WriteLine("===========================");
            Console.WriteLine("HttpMethod: {0}", request.HttpMethod);
            Console.WriteLine("EndPoint: {0}", request.EndPoint);
            Console.WriteLine("IsPublic: {0}", request.IsPublic);
            Console.WriteLine("Sign: {0}", request.Sign);
            Console.WriteLine("PrivateKey: {0}", request.PrivateKey);
            Console.WriteLine("Header: {0}", request.Header);
            Console.WriteLine("Query: {0}", request.Query);
            Console.WriteLine("Body: {0}", request.Body);
            Console.WriteLine("RequestType: {0}", request.RequestType);
            Console.WriteLine("ResponseType: {0}", request.ResponseType);
            Console.WriteLine("===========================");
        }


        [Test, TestCaseSource("HttpMethods")]
        public void __01__Set_HTTP_Method(String httpMethod) => MASRequestBuilderTests.httpMethod = httpMethod;

        [Test]
        public void __02__MASRequestBuilder_New() 
        {
            // Ensure that the default constructor creates new Object with expected default values.
            requestBuilder = new MASRequestBuilder(MASRequestBuilderTests.httpMethod);

            Assert.That(requestBuilder.HttpMethod, Is.Not.Null);
            Assert.That(requestBuilder.HttpMethod, Is.InstanceOf<string>());
            Assert.That(requestBuilder.HttpMethod.Equals(MASRequestBuilderTests.httpMethod));

            Assert.That(requestBuilder.IsPublic, Is.False);
            Assert.That(requestBuilder.IsPublic, Is.InstanceOf<bool>());

            Assert.That(requestBuilder.Sign, Is.False);
            Assert.That(requestBuilder.Sign, Is.InstanceOf<bool>());

            Assert.That(requestBuilder.EndPoint, Is.Null);
            //Assert.That(requestBuilder.EndPoint, Is.InstanceOf<NSString>());

            Assert.That(requestBuilder.Claims, Is.Null);
            //Assert.That(requestBuilder.Claims, Is.InstanceOf<MASClaims>());

            Assert.That(requestBuilder.PrivateKey, Is.Null);
            //Assert.That(requestBuilder.PrivateKey, Is.InstanceOf<NSData>());

            Assert.That(requestBuilder.Header, Is.Null);
            //Assert.That(requestBuilder.Header, Is.InstanceOf<NSDictionary>());

            Assert.That(requestBuilder.Body, Is.Null);
            //Assert.That(requestBuilder.Body, Is.InstanceOf<NSDictionary>());

            Assert.That(requestBuilder.Query, Is.Null);
            //Assert.That(requestBuilder.Query, Is.InstanceOf<NSDictionary>());

            Assert.That(requestBuilder.RequestType, Is.Not.Null);
            Assert.That(requestBuilder.RequestType, Is.InstanceOf<MASRequestResponseType>());
            Assert.That(requestBuilder.RequestType.Equals(MASRequestResponseType.Json));

            Assert.That(requestBuilder.ResponseType, Is.Not.Null);
            Assert.That(requestBuilder.ResponseType, Is.InstanceOf<MASRequestResponseType>());
            Assert.That(requestBuilder.ResponseType.Equals(MASRequestResponseType.Json));
        }

        [Test, TestCaseSource("EndPoints")]
        public void __03__MASRequestBuilder_SetEndPoint(string endPoint)
        {
            Assume.That(requestBuilder, Is.Not.Null);
            requestBuilder.EndPoint = endPoint;
        }

        [Test, TestCaseSource("QueryParams")]
        public void __04__MASRequestBuilder_SetQueryParameter(string param, string value)
        {
            Assume.That(requestBuilder, Is.Not.Null);

            requestBuilder.Query = new NSDictionary(param, value);
            Assert.That(requestBuilder.Query, Is.Not.Null);
            Assert.That(requestBuilder.Query, Is.InstanceOf<NSDictionary>());
        }

        [Test, TestCaseSource("RequestBodies")]
        public void __05__MASRequestBuilder_SetBodyParameter(string key, string value)
        {
            Assume.That(requestBuilder, Is.Not.Null);

            requestBuilder.Body = new NSDictionary(key, value);
            Assert.That(requestBuilder.Body, Is.Not.Null);
            Assert.That(requestBuilder.Body, Is.InstanceOf<NSDictionary>());
        }

        [Test, TestCaseSource("ContentTypes")]
        public void __06__MASRequestBuilder_SetRequestType(string contentType)
        {
            Assume.That(requestBuilder, Is.Not.Null);

            switch (contentType)
            {
                case "Unknown": requestBuilder.RequestType = MASRequestResponseType.Unknown; break;
                case "Json": requestBuilder.RequestType = MASRequestResponseType.Json; break;
                case "ScimJson": requestBuilder.RequestType = MASRequestResponseType.ScimJson; break;
                case "TextPlain": requestBuilder.RequestType = MASRequestResponseType.TextPlain; break;
                case "WwwFormUrlEncoded": requestBuilder.RequestType = MASRequestResponseType.WwwFormUrlEncoded; break;
                case "Xml": requestBuilder.RequestType = MASRequestResponseType.Xml; break;
                case "Count": requestBuilder.RequestType = MASRequestResponseType.Count; break;
            }
            Assert.That(requestBuilder.RequestType, Is.Not.Null);
        }

        [Test, TestCaseSource("ContentTypes")]
        public void __07__MASRequestBuilder_SetResponseType(string contentType)
        {
            Assume.That(requestBuilder, Is.Not.Null);

            switch (contentType)
            {
                case "Unknown": requestBuilder.ResponseType = MASRequestResponseType.Unknown; break;
                case "Json": requestBuilder.ResponseType = MASRequestResponseType.Json; break;
                case "ScimJson": requestBuilder.ResponseType = MASRequestResponseType.ScimJson; break;
                case "TextPlain": requestBuilder.ResponseType = MASRequestResponseType.TextPlain; break;
                case "WwwFormUrlEncoded": requestBuilder.ResponseType = MASRequestResponseType.WwwFormUrlEncoded; break;
                case "Xml": requestBuilder.ResponseType = MASRequestResponseType.Xml; break;
                case "Count": requestBuilder.ResponseType = MASRequestResponseType.Count; break;
            }
            Assert.That(requestBuilder.ResponseType, Is.Not.Null);
        }

        [Test, TestCaseSource("HeaderParams")]
        public void __08__MASRequestBuilder_SetHeaderParameter(string param, string value)
        {
            Assume.That(requestBuilder, Is.Not.Null);

            requestBuilder.Header = new NSDictionary(param, value);
            Assert.That(requestBuilder.Header, Is.Not.Null);
            Assert.That(requestBuilder.Header, Is.InstanceOf<NSDictionary>());
        }

        //[Test, TestCaseSource("RequestBodies")]
        //public void __07__MASRequestBuilder_SetBodyParameter(string key, string value)
        //{
        //    requestBuilder.SetBodyParameter(key, value);
        //    Assert.That(requestBuilder.Body, Is.Not.Null);
        //}

        [Test, TestCaseSource("IsPublic")]
        public void __09__MASRequestBuilder_SetIsPublic(bool isPublic)
        {
            Assume.That(requestBuilder, Is.Not.Null);
            requestBuilder.IsPublic = isPublic;
        }

        //[Test, TestCaseSource("Sign")] 
        //public void __09__MASRequestBuilder_Sign(bool sign)
        //{
        //    Assume.That(requestBuilder, Is.Not.Null);
        //    requestBuilder.Sign = sign;
        //}

        [Test, TestCaseSource("Claims")]
        public void __10__MASRequestBuilder_Sign(string claims)
        {
            Assume.That(requestBuilder, Is.Not.Null);
            MASClaims masClaims = new MASClaims();
            masClaims.Content = NSObject.FromObject("{\"claims\" : \"" + claims + "\"}");
            masClaims.ContentType = "application/json";
        }

        [Test]
        public void __11__MASRequestBuilder_Build()
        {
            request = requestBuilder.Build();
        }

        [Test]
        public void __12__MAS_Invoke()
        {
            MAS.Invoke(request, completion: (response, responsePayload, error) =>
            {
                if (error != null)
                {
                    Console.WriteLine("Error occured upon consumption of protected API: {0}", error.LocalizedDescription);
                }
                else if (response != null)
                {
                    Console.WriteLine("======> NO ERROR!");
                    Console.WriteLine("Response body: {0}", responsePayload);

                    // Assert.That(responseBody.Contains("products"));
                }
            });
        }

        //[Test]
        //public void __09__MASRequestResponseType()
        //{
        //    // ToDo: Make sure that the MASRequestResponseType enum contains exactly 7 options:
        //    // Assert.That(MASRequestResponseType.Count, Is.EqualTo(7));
        //    // ToDo: How to check each of them?
        //}
    }
}