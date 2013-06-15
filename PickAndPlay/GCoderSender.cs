using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PickAndPlay
{
    public class GCoderSender
    {
        SerialPort port = new SerialPort("COM4", 250000);
        double LastX;
        double LastY;
        double LastZ;

        public void SendHome()
        {
            // port.Open();
            port.WriteLine("G28");
            LastX = 0;
            LastY = 0;
            LastZ = 172;
        }
        public void Start()
        {
            port.Open();
            port.WriteLine("start");
        }
        public void GoTo(double x, double y, double z)
        {
            x = -x;
            port.WriteLine("G1 X" + x + "Y" + y + "Z" + z);
            LastX = x;
            LastY = y;
            LastZ = z;
        }
        public void Disconnect()
        {
            port.WriteLine("M84");
            port.Close();
        }
        public void Pick()
        {
            port.WriteLine("M106");
        }
        public void Play()
        {
            port.WriteLine("M107");
        }
        public void MotorsOff()
        {
            port.WriteLine("M84");
        }
        public void SetSepeed(double speed)
        {
            port.WriteLine("M220 S" + speed);
        }

    }
}
