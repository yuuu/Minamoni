using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Minamoni.Comm;

namespace InamoniTest.Target
{
    class MSerialPort : IComm
    {
        public event SerialDataReceivedEventHandler DataReceived;

        public MSerialPort()
        {

        }

        public void Open()
        {

        }

        public void Close()
        {

        }

        public int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }


        public void Write(byte[] buffer, int offset, int count)
        {
            
        }
    }
}
