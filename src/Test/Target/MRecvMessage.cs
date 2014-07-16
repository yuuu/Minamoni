using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Minamoni.RecvMessage;

namespace MinamoniTest.Target
{
    class MRecvMessage : IRecvMessage
    {
        public bool Received { get; set; }

        public MRecvMessage()
        {
            Received = false;
        }

        /// <summary>
        /// 受信する
        /// </summary>
        /// <param name="data"></param>
        public void Receive(byte[] data)
        {
            Received = true;
        }
    }
}
