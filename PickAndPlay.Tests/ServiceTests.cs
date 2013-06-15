using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Diagnostics;

namespace PickAndPlay.Tests
{
    [TestClass]
    public class ServiceTests
    {
        PickAndPlaySettings Settings;
        PickAndPlayService Service;
        [TestInitialize]
        public void Initialize()
        {
            string text = System.IO.File.ReadAllText(@"TestConfig.txt");
            Settings = JsonConvert.DeserializeObject<PickAndPlaySettings>(text);
            Service = new PickAndPlayService(Settings);
        }

        [TestMethod]
        public void GetProperMove()
        {

            Service.IssueMove("Nc1-Nd3");

        }
    }
}
