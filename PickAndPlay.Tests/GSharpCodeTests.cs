using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using Newtonsoft.Json;
using PickAndPlay;

namespace PickAndPlay.Tests
{
    [TestClass]
    public class GSharpCodeTests
    {
        PickAndPlaySettings settings;
        
        [TestInitialize]
        public void Initialize()
        {
            string text = System.IO.File.ReadAllText(@"TestConfig.txt");
            settings = JsonConvert.DeserializeObject<PickAndPlaySettings>(text);

        }

        [TestMethod]
        public void GoHomeWorks()
        {
            GCoderSender myGCodeSender = new GCoderSender();
            myGCodeSender.Start();
            myGCodeSender.SendHome();
            myGCodeSender.Disconnect();
        }

        [TestMethod]
        public void TestGCodeSending()
        {
            double ChessBoardWidth = 152;
            double halfBoard = ChessBoardWidth / 2;
            double rodHeight = 43;
            double abovePieces = 120;
            GCoderSender myGCodeSender = new GCoderSender();
            myGCodeSender.Start();
            myGCodeSender.SendHome();
            int sleepLength = 3000;
            
            //Move Rook from h8 to a8
            myGCodeSender.GoTo(-halfBoard, halfBoard, rodHeight);
            myGCodeSender.Pick();
            System.Threading.Thread.Sleep(sleepLength);
            myGCodeSender.GoTo(-halfBoard, halfBoard, abovePieces);
            myGCodeSender.GoTo(halfBoard, halfBoard, abovePieces);
            myGCodeSender.GoTo(halfBoard, halfBoard, rodHeight);
            System.Threading.Thread.Sleep(sleepLength);
            myGCodeSender.Play();
            System.Threading.Thread.Sleep(2000);

            myGCodeSender.GoTo(halfBoard, halfBoard, abovePieces);
            myGCodeSender.GoTo(halfBoard, halfBoard, rodHeight);
            myGCodeSender.Pick();
            System.Threading.Thread.Sleep(sleepLength);

            myGCodeSender.GoTo(halfBoard, -halfBoard, abovePieces);
            //Move Knight from a1 to a8
            myGCodeSender.GoTo(halfBoard, -halfBoard, rodHeight);
            myGCodeSender.Pick();
            System.Threading.Thread.Sleep(sleepLength);
            myGCodeSender.GoTo(halfBoard, -halfBoard, abovePieces);
            myGCodeSender.GoTo(-halfBoard, -halfBoard, abovePieces);
            myGCodeSender.GoTo(-halfBoard, -halfBoard, rodHeight);
            System.Threading.Thread.Sleep(sleepLength);
            myGCodeSender.Play();
            myGCodeSender.Play();
            myGCodeSender.SendHome();
            myGCodeSender.Disconnect();
        }

        [TestMethod]
        public void CanGetTestConfig()
        {
            Assert.AreEqual(152, settings.BoardSize);
            //Trace.WriteLine(text);
        }

        [TestMethod]
        public void ServiceTests()
        {
            ReversibleNotationToGCodeService service = new ReversibleNotationToGCodeService(settings);
            service.IssueMove("Na1-h8");
            service.IssueMove("Nh1-a8");
            service.IssueMove("Na1-h8");
        }
    }
}
