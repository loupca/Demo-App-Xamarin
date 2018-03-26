using System;
using NUnit.Framework;
using MASFoundation;
using Foundation;

namespace MASUnit.iOS.SharedStorage
{
    

    [TestFixture]
    public class SharedStorageTests : MASTestBase
    {
        // http://apim-testrail.l7tech.com/index.php?/cases/view/2155482
        [Test]
        public void Tc01StorageSaveGetString()
        {
            String key = "testKey123";
            String data = "testValue123";

            MASSharedStorage storage = new MASSharedStorage();

            NSError error;
            MASSharedStorage.SaveString(data, key, out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the string can be retrieved from the shared storage
            String dataFromStorage = MASSharedStorage.FindStringUsingKey("testKey123", out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the extracted from the storage string is the expected one
            Assert.That(dataFromStorage, Is.EqualTo(data));

            Console.WriteLine("String extracted from shared storage: {0}", dataFromStorage);
        }

        // Store Byte Data into Shared Storage
        // http://apim-testrail.l7tech.com/index.php?/cases/view/2155483

        [Test]
        public void Tc02StorageSaveGetByteData()
        {
            String key = "testByteData";
            NSData data = "testData";

            MASSharedStorage storage = new MASSharedStorage();

            NSError error;
            MASSharedStorage.SaveData(data, key, out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the string can be retrieved from the shared storage
            NSData dataFromStorage = MASSharedStorage.FindDataUsingKey("testByteData", out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the extracted from the storage string is the expected one
            Assert.That(dataFromStorage, Is.EqualTo(data));
        }

        // Delete String Data from Shared Storage
        // http://apim-testrail.l7tech.com/index.php?/cases/view/2161457
        [Test]
        public void Tc03DeleteStringFromStorage()
        {
            String key = "testKeyDeleteMe";
            String data = "DeleteMe";

            MASSharedStorage storage = new MASSharedStorage();

            NSError error;
            MASSharedStorage.SaveString(data, key, out error);
            Assert.Null(error);

            MASSharedStorage.DeleteForKey("testKeyDeleteMe", out error);
            Assert.Null(error);


            // Make sure that this entry has been removed from the storage
            String dataFromStorage = MASSharedStorage.FindStringUsingKey("testKeyDeleteMe", out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the extracted from the storage string is NULL
            Assert.That(dataFromStorage, Is.Null);
        }

        // Delete Byte Data from Shared Storage
        // http://apim-testrail.l7tech.com/index.php?/cases/view/2161458
        [Test]
        public void Tc04DeleteByteDataFromStorage()
        {
            String key = "testKeyDeleteMeBytes";
            String data = "DeleteMeBytes";

            MASSharedStorage storage = new MASSharedStorage();

            NSError error;
            MASSharedStorage.SaveData(data, key, out error);
            Assert.Null(error);

            MASSharedStorage.DeleteForKey("testKeyDeleteMeBytes", out error);
            Assert.Null(error);

            // Make sure that this entry has been removed from the storage
            NSData dataFromStorage = MASSharedStorage.FindDataUsingKey("testKeyDeleteMe", out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the extracted from the storage bytes data is NULL
            Assert.That(dataFromStorage, Is.Null);
        }

        // Store String Data into Shared Storage with Different Configuration
        // http://apim-testrail.l7tech.com/index.php?/cases/view/2155485
        // [Test] // not ready from prime time. 
        public void Tc05SharedStorageDifferentConfig()
        {
            MAS.StartWithDefaultConfiguration(true, completion: (startCompletedSuccessfully, startError) =>
            {
                Console.WriteLine("MAS Started successfully.");
                // Assert.That(startCompletedSuccessfully, "MAS started successfully.");
            });

            Assume.That(MAS.MASState, Is.EqualTo(MASFoundation.MASState.DidStart));
            long timeIntervalSince1970 = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            String stringData = "oAF8iWkV91nooIB3DCCAUWgAwIBAgIRAPOemXBJ3EXNuj-" + timeIntervalSince1970;
            String stringKey = "testSharedStorage-" + timeIntervalSince1970;

            MASSharedStorage storage = new MASSharedStorage();

            NSError error;
            MASSharedStorage.SaveString(stringData, stringKey, out error);
            Assert.Null(error);

            // Start MAS with different configuration
            MAS.Stop(completion: (stoppedSuccessfully, stopError) =>
            {
                // Assert.True(stoppedSuccessfully, "MAS.Stop succeeded.");
                // Assert.Null(error);
                if (stoppedSuccessfully)
                    Console.WriteLine("MAS stopped successfully.");
                if (error != null)
                    Console.WriteLine("Failed to stop MAS: {0}", stopError.LocalizedDescription);
            });

            NSUrl nSUrl = new NSUrl("msso_config2.json", false);
            MAS.StartWithURL(nSUrl, completion: (startCompletedSuccessfully, startError) =>
            {
                if (startCompletedSuccessfully)
                    Console.WriteLine("MAS Started successfully with msso_config2.json.");
                // Assert.That(startCompletedSuccessfully, "MAS started successfully.");
                else
                    Console.WriteLine("MAS Started did not start successfully." + startError);
            });

            //  http://apim-testrail.l7tech.com/index.php?/cases/view/2155485
            //  Checking if the data can be retrieved and are equal after switching gateway
            String dataFromStorage = MASSharedStorage.FindStringUsingKey("testKey123", out error);

            // Ensure that no error occurs
            Assert.Null(error);

            // Make sure that the extracted from the storage string is the expected one
            Assert.That(dataFromStorage, Is.EqualTo(stringData));
        }

        // http://apim-testrail.l7tech.com/index.php?/cases/view/2155486
        [Test]
        public void Tc06SharedStorageErrorHandling()
        {
            Assume.That(MAS.MASState, Is.EqualTo(MASFoundation.MASState.NotInitialized));

            // Test case for handling non-initialized SDK error handling
            String key = "test";
            String data = "test";

            MASSharedStorage storage = new MASSharedStorage();

            NSError error;
            MASSharedStorage.SaveString(data, key, out error);

            // Ensure that the expected error occurs
            Assert.NotNull(error);
            Assert.That(error.Code, Is.EqualTo(100004));
            Assert.That(error.LocalizedDescription, Is.EqualTo("MAS SDK has not been started."));
        }

    }
}
