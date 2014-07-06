using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Inamoni.Comm
{
    /// <summary>
    /// 通信方式インターフェース
    /// </summary>
    public interface IComm
    {
        /// <summary>
        /// 受信イベント
        /// </summary>
        event SerialDataReceivedEventHandler DataReceived;

        /// <summary>
        /// オープン
        /// </summary>
        void Open();

        /// <summary>
        /// クローズ
        /// </summary>
        void Close();

        /// <summary>
        /// 受信
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        int Read(byte[] buffer, int offset, int count);

        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        void Write(byte[] buffer, int offset, int count);
    }
}
