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
        public void BishopsFromCenterToCorners()
        {
            PickAndPlayService service = new PickAndPlayService(settings);
            service.IssueMove("Bd4-a1");
            service.IssueMove("Be4-h1");
            service.IssueMove("Bd5-a8");
            service.IssueMove("Be5-h8");
        }
        [TestMethod]
        public void SquareLocationTester()
        {
            PickAndPlayService service = new PickAndPlayService(settings);
            service.Sender.Pick();
            System.Threading.Thread.Sleep(5000);
            service.Sender.GoTo(0, 0, settings.PieceHeight);
            System.Threading.Thread.Sleep(5000);
            service.TestPosition("a1");
            System.Threading.Thread.Sleep(5000);
            service.TestPosition("h1");
            System.Threading.Thread.Sleep(5000);
            service.TestPosition("a8");
            System.Threading.Thread.Sleep(5000);
            service.TestPosition("h8");
            System.Threading.Thread.Sleep(6000);
            service.TestPosition("a1");
            service.Sender.SendHome();
            service.Sender.Play();
            service.Sender.MotorsOff();
            service.Sender.Disconnect();

        }
    }
}
