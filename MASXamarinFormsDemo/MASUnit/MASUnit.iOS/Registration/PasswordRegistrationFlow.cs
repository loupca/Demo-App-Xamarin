using System;
using NUnit.Framework;
using MASFoundation;
using Foundation;

namespace MASUnit.iOS.Registration
{
    //[TestFixture]
    //public class PasswordRegistrationFlow : MASTestBase
    //{
    //    [Test]
    //    public void Tc01SetGrantFlowPassword()
    //    {
    //        MAS.GrantFlow = MASGrantFlow.Password;
    //        Assert.AreEqual(MAS.GrantFlow, MASGrantFlow.Password, "MAS GrantFlow set to Password.");
    //    }

    //    [Test]
    //    public void Tc02StartWithDefaultConfiguration()
    //    {
    //        // 1. Set password grant flow
    //        // SetGrantFlowPassword();

    //        // 2. StartWithDefaultConfiguration
    //        MAS.StartWithDefaultConfiguration(true, completion: (startCompletedSuccessfully, error) =>
    //        {
    //            Console.WriteLine("MAS Started successfully.");
    //            // Assert.That(startCompletedSuccessfully, "MAS started successfully.");
    //        });
    //    }

    //    [Test]
    //    public void Tc03LoginSuccessfully()
    //    {
    //        // StartMASPasswordGrantFlow();

    //        // Login (expect succeess)
    //        MASUser.LoginWithUserName(validUser, validPassword, completion: (loginResult, error) =>
    //        {
    //            Console.WriteLine("Login result: {0}", loginResult);
    //            // Assert.True(loginResult, "Successfully logged in with valid user and password.");
    //            if (error != null)
    //                Console.WriteLine(error.LocalizedDescription);
    //        });
    //    }

    //    [Test]
    //    public void Tc04CurrentUserIsAuthenticated()
    //    {
    //        // LoginUser(validUser, validPassword);
    //        Assert.That(MASUser.CurrentUser.IsAuthenticated, "The current user is authenticated");
    //    }

    //    [Test, Description("http://apim-testrail.l7tech.com/index.php?/cases/view/146165")]
    //    public void Tc05InvokeApiSuccessfully()
    //    {
    //        // LoginUser(validUser, validPassword);

    //        // Invoke protected endpoint using GET request when user is authenticated (expect successful consumption)
    //        MASRequest request = BuildListProductsRequest();

    //        MAS.Invoke(request, completion: (response, responsePayload, error) =>
    //        {
    //            // NO ASSERTIONS WORK... 
    //            // Assert.NotNull(response, "Got response upon consumption of protected API with valid user and password.");
    //            // Assert.True(response.ContainsKey(new NSString("MASResponseInfoBodyInfoKey")), "Response contains MASResponseInfoBodyInfoKey key.");
    //            // Assert.Null(error, "No errors were reported.");

    //            // Manual verification:
    //            if (error != null)
    //            {
    //                Console.WriteLine("Error occured upon consumption of protected API: {0}", error.LocalizedDescription);
    //            }
    //            else if (response != null)
    //            {
    //                Console.WriteLine("======> NO ERROR!");

    //                Console.WriteLine("Response body: {0}", responsePayload);
    //                // Assert.That(responseBody.Contains("products"));
    //            }
    //        });
    //    }

    //    [Test, Description("http://apim-testrail.l7tech.com/index.php?/cases/view/146165")]
    //    public void Tc06Logout()
    //    {
    //        // LoginUser(validUser, validPassword);

    //        MASUser.CurrentUser.LogoutWithCompletion(completion: (logoutResult, error) =>
    //        {
    //            if (error != null)
    //                Console.WriteLine("Logout failed with error: {0}", error.LocalizedDescription);

    //            Console.WriteLine("Logout was successful: {0}", logoutResult);

    //            // Assert.True(logoutResult, "Logout was successful.");
    //            // Assert.Null(MASUser.CurrentUser, "MASUser.CurrentUser is null");

    //        });
    //    }

    //    [Test]
    //    public void Tc07InvokeProtectedApiWhenUserIsNotAuthenticated()
    //    {
    //        // StartMASPasswordGrantFlow();
    //        // LogoutUser();

    //        // Invoke protected endpoint using GET request when user is NOT authenticated (expect failure)
    //        MASRequest request = BuildListProductsRequest();
    //        MAS.Invoke(request, completion: (response, responsePayload, error) =>
    //        {
    //            // NO ASSERTIONS WORK... 
    //            // Assert.NotNull(response, "Got response upon consumption of protected API with valid user and password.");
    //            // Assert.True(response.ContainsKey(new NSString("MASResponseInfoBodyInfoKey")), "Response contains MASResponseInfoBodyInfoKey key.");
    //            // Assert.Null(error, "No errors were reported.");

    //            // Manual verification:
    //            if (error != null)
    //            {
    //                Console.WriteLine("Error occured upon consumption of protected API: {0}", error.LocalizedDescription);
    //            }
    //            if (response != null)
    //            {   
    //                Console.WriteLine("Response body: {0}", responsePayload);
    //                // Assert.That(responseBody.Contains("products"));
    //            }
    //        });
    //    }

    //    [Test]
    //    public void Tc08RegisterAuthCredentialBlock()
    //    {
    //        MAS.SetUserAuthCredentials((authCredentialsBlock) =>
    //        {

    //            //  Build MASAuthCredentialsPassword with username and password
    //            MASAuthCredentialsPassword passwordCredentials = MASAuthCredentialsPassword.InitWithUsername(validUser, validPassword);

    //            //  Invoke callback block, authCredentialsBlock, with MASAuthCredentialsPassword object
    //            authCredentialsBlock(passwordCredentials, false, (bool completed, NSError error) =>
    //            {
    //                if (error != null)
    //                {
    //                    Console.WriteLine("MAS.SetUserAuthCredentials failed with error {0}", error.LocalizedDescription);
    //                }
    //                else
    //                {
    //                    Console.WriteLine("MAS.SetUserAuthCredentials Success (user login)");
    //                }
    //            });
    //        });
    //    }

    //    [Test]
    //    public void Tc09InvokeProtectedApiWhenUserIsNotAuthenticatedAndAuthCredentialBlockExists()
    //    {
    //        // Invoke protected endpoint using GET request when user is NOT authenticated should trigger the registered authCredentialsBlock
    //        // ... i.e. consumption should be successful.
    //        MASRequest request = BuildListProductsRequest();
    //        MAS.Invoke(request, completion: (response, responsePayload, error) =>
    //        {
    //            // NO ASSERTIONS WORK... 
    //            // Assert.NotNull(response, "Got response upon consumption of protected API with valid user and password.");
    //            // Assert.True(response.ContainsKey(new NSString("MASResponseInfoBodyInfoKey")), "Response contains MASResponseInfoBodyInfoKey key.");
    //            // Assert.Null(error, "No errors were reported.");

    //            // Manual verification:
    //            if (error != null)
    //            {
    //                Console.WriteLine("Error occured upon consumption of protected API: {0}", error.LocalizedDescription);
    //            }
    //            if (response != null)
    //            {
    //                Console.WriteLine("Response body: {0}", responsePayload);
    //                // Assert.That(responseBody.Contains("products"));
    //            }
    //        });
    //    }

    //    [Test]
    //    public void Tc10StartWithJSON()
    //    {
    //        var file = System.IO.File.Open("msso_config.json", System.IO.FileMode.Open);

    //        NSString mssoString;
    //        using (System.IO.StreamReader reader = new System.IO.StreamReader(file))
    //        {
    //            mssoString = new NSString(reader.ReadToEnd());
    //        }
    //        NSData mssoData = NSData.FromString(mssoString);
    //        NSError parsingError;
    //        NSDictionary thisobject = (NSDictionary)NSJsonSerialization.Deserialize(mssoData, NSJsonReadingOptions.MutableLeaves, out parsingError);

    //        MAS.StartWithJSON(thisobject, completion: (startCompletedSuccessfully, error) =>
    //        {
    //            if (startCompletedSuccessfully)
    //                Console.WriteLine("MAS Started successfully with msso_config.json.");
    //            // Assert.That(startCompletedSuccessfully, "MAS started successfully.");
    //            else
    //                Console.WriteLine("MAS Started did not start successfully." + error);
    //        });
    //    }

    //    [Test]
    //    public void Tc11StartWithURL()
    //    {
    //        NSUrl nSUrl = new NSUrl("msso_config2.json", false);
    //        MAS.StartWithURL(nSUrl, completion: (startCompletedSuccessfully, error) =>
    //        {
    //            if (startCompletedSuccessfully)
    //                Console.WriteLine("MAS Started successfully with msso_config2.json.");
    //            // Assert.That(startCompletedSuccessfully, "MAS started successfully.");
    //            else
    //                Console.WriteLine("MAS Started did not start successfully." + error);
    //        });
    //    }

    //    [Test]
    //    public void Tc12ChangeDefaultConfiguration()
    //    {
    //        MAS.SetConfigurationFileName("msso_config2");
    //    }

    //    [Test]
    //    public void Tc13StartWithEnrollmentURL()
    //    {
    //            NSUrl nsUrl = new NSUrl(GetEnrollmentURLAsync("https://mobile-staging-xamarinautomation.l7tech.com:8443",
    //                                                          // This client id must match the client id of the config you are using
    //                                                          "44fd840b-45e6-439f-9ff9-9976947d9e26"));

    //            MAS.StartWithURL(nsUrl, completion: (startCompletedSuccessfully, error) =>
    //            {
    //                if (startCompletedSuccessfully)
    //                {
    //                    //  SDK initialized without an error
    //                    Console.WriteLine("CA Mobile SDK started successfully with enrolment URL!!");
    //                }
    //                if (error != null)
    //                {
    //                    //  SDK initialized with an error
    //                    Console.WriteLine("ERROR: " + error.LocalizedDescription);
    //                }
    //            });
    //    }

    //    // MAS.Stop()
    //    [Test]
    //    public void Tc88Stop()
    //    {
    //        // LoginUser(validUser, validPassword);
    //        MAS.Stop(completion: (stoppedSuccessfully, error) =>
    //        {
    //            // Assert.True(stoppedSuccessfully, "MAS.Stop succeeded.");
    //            // Assert.Null(error);
    //            if (stoppedSuccessfully)
    //                Console.WriteLine("MAS stopped successfully.");
    //            if (error != null)
    //                Console.WriteLine("Failed to stop MAS: {0}", error.LocalizedDescription);
    //        });
    //    }

    //    // Deregister device
    //    [Test]
    //    public void Tc99DeregisterDevice()
    //    {
    //        // LoginUser(validUser, validPassword);
    //        MASDevice.CurrentDevice().DeregisterWithCompletion(completion: (deregisteredSuccessfully, error) =>
    //        {
    //            // Assert.True(deregisteredSuccessfully, "Device was successfully deregistered.");
    //            // Assert.Null(error, "No errors were reported.");
    //            if (deregisteredSuccessfully)
    //                Console.WriteLine("Device deregistered successfully.");
    //            if (error != null)
    //                Console.WriteLine("Failed to deregister device: {0}", error.LocalizedDescription);
    //        });
    //    }

    //    // 
    //    [Test]
    //    public void Tc99ResetLocally()
    //    {
    //        // LoginUser(validUser, validPassword);
    //        Assume.That(MASUser.CurrentUser, Is.Not.Null); // make sure that we have an active current user.

    //        // Save some data in the shared storage:
    //        NSError error = null;
    //        MASSharedStorage.SaveData("Test data", "key", out error);

    //        // reset...
    //        MASDevice.CurrentDevice().ResetLocally();
           
    //        // make sure that the data in the shared storage was not deleted (see DE350386)
    //        Assert.AreEqual("Test data", MASSharedStorage.FindStringUsingKey("key", out error));
    //        Assert.IsNull(error); // no error upon retrieval from the shared storage.
    //        //Console.WriteLine("Shared data: {0}", MASSharedStorage.FindStringUsingKey("key", out error));
    //        //    if (error != null)
    //        //Console.WriteLine("Unable to retrieve data from the shared storage: {0}", error.LocalizedDescription);

    //        // Make sure that the active user has been logged off
    //        Assert.That(MASUser.CurrentUser, Is.Null);
    //        // Remove local & shared keychains
    //        Assert.That(MASApplication.CurrentApplication.IsAuthenticated, Is.False);
    //        Assert.That(MASDevice.CurrentDevice().IsRegistered, Is.False);

    //        // Ensure that the MASConfiguration.CurrentConfiguration was reset (DE350392)
    //        // Assert.IsNull(MASConfiguration.CurrentConfiguration);
    //        Console.WriteLine("ApplicationName: {0}", MASConfiguration.CurrentConfiguration.ApplicationName);
    //        Console.WriteLine("GatewayHostName: {0}", MASConfiguration.CurrentConfiguration.GatewayHostName);
    //    }
    //}
}

