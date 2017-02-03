using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Automile.Net;
using System.Collections.Generic;

namespace Automile.Net.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAuthenticationAndRefreshToken()
        {
            AutomileClient client = new AutomileClient("username", "password", "api client identifier", "api client secret");
            client.RefreshAccessToken();
        }
    }
}
