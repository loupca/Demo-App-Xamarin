
using System;
using System.Text;
//using Com.CA.Mas.Core.Storage.Sharedstorage;
using Com.CA.Mas.Foundation;
using Java.Lang;
using NUnit.Framework;
using Android.Accounts;

namespace Test
{
    //[TestFixture]
    //public class MASSharedStorageTest : MASTestBase
    //{
    //    //private MASSharedStorage storage;

    //    private string testAccountName = "TEST_NAME";
    //    private string testKey = "KEY";
    //    private string testStringValue = "STRING_VALUE";
    //    private byte[] testByteValue = Encoding.ASCII.GetBytes("BYTE_VALUE");

    //    [SetUp]
    //    public void SetUpMASSharedStorageTest()
    //    {
    //        if (SdkIsStarted())
    //        {
    //            //storage = new MASSharedStorage(testAccountName);
    //        }
    //    }

    //    [TearDown]
    //    public void TearDownMASSharedStorageTest()
    //    {
    //        if (SdkIsStarted())
    //        {
    //            //storage.Delete(testKey);
    //        }
    //    }

    //    [Test]
    //    public void TestStoreString()
    //    {
    //        //storage.Save(testKey, testStringValue);
    //        //var getString = storage.GetString(testKey);

    //        //Assert.IsTrue(testStringValue.Equals(getString));
    //    }

    //    [Test]
    //    public void TestStoreByte()
    //    {
    //        //storage.Save(testKey, testByteValue);
    //        //var getByte = storage.GetBytes(testKey);

    //        //Assert.IsTrue("BYTE_VALUE".Equals(Encoding.ASCII.GetString(getByte)));
    //    }

    //    [Test]
    //    public void TestDeleteString()
    //    {
    //        TestStoreString();
    //        //storage.Delete(testKey);
    //        //var getString = storage.GetString(testKey);

    //        //Assert.IsNull(getString);
    //    }

    //    [Test]
    //    public void TestDeleteByte()
    //    {
    //        TestStoreByte();
    //        //storage.Delete(testKey);
    //        //var getString = storage.GetBytes(testKey);

    //        //Assert.IsNull(getString);
    //    }

    //    [Test]
    //    public void TestStoreStringWithCustomConfiguration()
    //    {
    //        //storage.Save(testKey, testStringValue);
    //        StartWithCustomMssoConfig(ANDROID_CONFIG);
    //        //var getString = storage.GetString(testKey);

    //        //Assert.IsTrue(testStringValue.Equals(getString));

    //        MASDevice.CurrentDevice.Deregister(null);
    //        StartWithCustomMssoConfig(MSSO_CONFIG);

    //    }

    //    [Test]
    //    [ExpectedException(typeof(IllegalStateException))]
    //    public void TestMakeSharedStorageWhenSdkNotInitiated()
    //    {
    //        //storage = new MASSharedStorage(testAccountName);
    //    }

    //    [Test]
    //    [ExpectedException( typeof (NullPointerException))]
    //    public void TestStoreNullKey()
    //    {
    //        //storage.Save(null, testStringValue);
    //    }

    //    [Test]
    //    [ExpectedException(typeof(NullPointerException))]

    //    public void TestDeleteNullKey()
    //    {
    //        //storage.Delete(null);
    //    }

    //    [Test]
    //    [ExpectedException(typeof(NullPointerException))]
    //    public void TestRetrieveNullKey()
    //    {
    //        //storage.GetString(null);
    //    }

    //    [Test]
    //    public void TestRetrieveStringAfterDeregistration() {
    //        //storage = new MASSharedStorage(testAccountName);

    //        //storage.Save(testKey, testStringValue);

    //        MASDevice.CurrentDevice.Deregister(null);

    //        //var getString = storage.GetString(testKey);
    //        //Assert.IsTrue(testStringValue.Equals(getString));
    //    }
    //}
}