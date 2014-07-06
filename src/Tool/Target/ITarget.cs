using Minamoni.Comm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minamoni.Target
{
    /// <summary>
    /// 接続通知のデリゲート 
    /// </summary>
    public delegate void ConnectEventHandler();

    /// <summary>
    /// 切断通知のデリゲート
    /// </summary>
    public delegate void DisconnectEventHandler();

    /// <summary>
    /// 異常通知のデリゲート
    /// </summary>
    public delegate void CommErrorEventHandler();

    /// <summary>
    /// 監視ターゲットインターフェース
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// 接続通知先
        /// </summary>
        event ConnectEventHandler connectHandler;

        /// <summary>
        /// 切断通知先
        /// </summary>
        event DisconnectEventHandler disconnectHandler;

        /// <summary>
        /// 異常通知先
        /// </summary>
        event CommErrorEventHandler errorHandler;

        /// <summary>
        /// 接続する
        /// </summary>
        /// <param name="comm"></param>
        void Connect(IComm comm);

        /// <summary>
        /// 切断する
        /// </summary>
        void Disconnect();
    }
}
