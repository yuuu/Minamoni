using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minamoni.RecvMessage
{
    /// <summary>
    /// メッセージタイプ
    /// </summary>
    public enum MessageType
    {
        LOG
    };

    /// <summary>
    /// 受信メッセージインターフェース
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
