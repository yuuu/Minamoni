using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inamoni.RecvMessage
{
    // メッセージタイプ
    public enum MessageType
    {
        LOG
    };

    /// <summary>
    /// 受信メッセージ
    /// </summary>
    public interface IRecvMessage
    {
        /// <summary>
        /// 受信する
        /// </summary>
        /// <param name="data"></param>
        void Receive(byte[] data);
    }
}
