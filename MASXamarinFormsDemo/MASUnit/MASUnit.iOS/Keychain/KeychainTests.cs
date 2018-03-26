
using System;
using NUnit.Framework;
using MASFoundation;

namespace MASUnit.iOS.Keychain
{
    [TestFixture]
    public class KeychainTests
    {
        [Test, Description("http://apim-testrail.l7tech.com/index.php?/cases/view/2072308")]
        public void Tc01IsKeychainSynchronizable()
        {
            Assert.False(MAS.IsKeychainSynchronizable, "Check if Keychain is synchronizable upon SDK initialization");

            MAS.SetKeychainSynchronizable(true);

            Assert.True(MAS.IsKeychainSynchronizable, "Check if Keychain is synchronizable after set it to True");
        }

    }
}
