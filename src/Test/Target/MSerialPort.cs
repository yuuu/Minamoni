using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using Minamoni.Comm;

namespace MinamoniTest.Target
{
    class MSerialPort : IComm
    {
        public event SerialDataReceivedEventHandler DataReceived;

        public bool Readed { get; set; }
        public bool Error { get; set; }

        public MSerialPort()
        {
            Readed = false;
            Error = false;
        }

        public void Open()
        {
            if(Error)
            {
                throw new Exception();
            }
        }

        public void Close()
        {

        }

        public int Read(byte[] buffer, int offset, int count)
        {
            Readed = true;

            for (int i = 0 ; i < count ; i ++)
            {
                buffer[i] = (byte)i;
            }

                return 0;
        }


        public void Write(byte[] buffer, int offset, int count)
        {
            
        }

        public void Received()
        {
            if(DataReceived != null)
            {
                DataReceived(null, null);
            }
        }
    }
}
