
using System;
using NUnit.Framework;
using MASFoundation;
using Foundation;

namespace MASUnit.iOS.MASUserTests
{
    [TestFixture]
    public class SessionLockUnlock : MASTestBase
    {
        [Test]
        public void Tc01LockSessionWithCompletion()
        {
            // Preconditions: 
            //StartMASPasswordGrantFlow();
            //LoginUser(validUser, validPassword);

            MASUser.CurrentUser.LockSessionWithCompletion(completion: (completed, error) =>
            {
                if (completed)
                    Console.WriteLine("Successfully locked current user's session.");
                if (error != null)
                    Console.WriteLine("Failed to lock current user session: {0}", error.LocalizedDescription);
            });

            // Attempt to consume protected API should fail
        }

        [Test]
        public void Tc02UnlockSessionWithCompletion()
        {
            MASUser.CurrentUser.UnlockSessionWithCompletion(completion: (completed, error) =>
            {
                if (completed)
                    Console.WriteLine("Successfully unlocked current user's session.");
                if (error != null)
                    Console.WriteLine("Failed to unlock current user session: {0}", error.LocalizedDescription);
            });

            // Attempt to consume protected API should pass
        }

        [Test]
        public void Tc03UnlockSessionWithUserOperationPromptMessage()
        {
            MASUser.CurrentUser.UnlockSessionWithUserOperationPromptMessage("Test unlock session message:", completion: (completed, error) =>
            {
                if (completed)
                    Console.WriteLine("Successfully unlocked current user's session.");
                if (error != null)
                    Console.WriteLine("Failed to unlock current user session: {0}", error.LocalizedDescription);
            });

            // Attempt to consume protected API should pass
        }

        [Test]
        public void Tc04IsSessionLocked()
        {
            Console.WriteLine("Session is locked: {0}", MASUser.CurrentUser.IsSessionLocked ? "Yes" : "No");
        }

        [Test]
        public void Tc05removeSessionLock()
        {
            MASUser.CurrentUser.RemoveSessionLock();

            // Need to verify that this actually worked
            // Maybe Assert.True(MASUser.CurrentUser.IsSessionLocked); 
        }
    }
}
