
using System;
using NUnit.Framework;
using MASFoundation;

namespace MASUnit.iOS
{
    [TestFixture]
    public class NetworkReachabilityTests
    {
        [Test]
        [Description("http://apim-testrail.l7tech.com/index.php?/cases/view/1119772")]
        public void Tc01GatewayIsReachable()
        {
            Assume.That(MAS.MASState, Is.EqualTo(MASFoundation.MASState.DidStart));
            Assert.True(MAS.GatewayIsReachable, "GatewayIsReachable=true when network is reachable.");

            Console.WriteLine("========= GatewayIsReachable: {0}", MAS.GatewayIsReachable);
            Console.WriteLine("========= GatewayMonitoringStatusAsString: {0}", MAS.GatewayMonitoringStatusAsString);
        }

        [Test]
        public void Tc02GatewayMonitoringStatusAsStringReachableViaWiFi()
        {
            Console.WriteLine("========= GatewayMonitoringStatusAsString: {0}", MAS.GatewayMonitoringStatusAsString);
            Assert.That(MAS.GatewayMonitoringStatusAsString.Equals("Reachable Via WiFi"), "GatewayMonitoringStatusAsString when network is reachable.");
        }

        [Test]
        [Description("http://apim-testrail.l7tech.com/index.php?/cases/view/1119771")]
        public void Tc03GatewayIsNotReachable()
        {
            // Assume.That(device is in airplane mode)
            Assert.False(MAS.GatewayIsReachable, "======== GatewayIsReachable=false when network is NOT reachable.");
        } 

        [Test]
        public void Tc04GatewayMonitoringStatusAsStringNotReachableViaWiFi()
        {
            // Assume.That(device is in airplane mode) 
            Console.WriteLine("========= GatewayMonitoringStatusAsString: {0}", MAS.GatewayMonitoringStatusAsString);
            Assert.That(MAS.GatewayMonitoringStatusAsString.Equals("Not Reachable"), "GatewayMonitoringStatusAsString when network is NOT reachable.");
        }

        [Test]
        public void Tc05SetGatewayMonitor()
        {   
            MAS.SetGatewayMonitor(monitor: (status) =>
            {
                Console.WriteLine("======== Gateway Monitor Status {0}", status);
            });
        }
    }
}
