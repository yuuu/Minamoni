using Minamoni.Comm;
using Minamoni.RecvMessage;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Minamoni.Target
{
    /// <summary>
    /// 接続状態
    /// </summary>
    public enum CommStatus
    {
        INITIALIZED,
        CONNECTED,
        DISCONNECTED
    };

    /// <summary>
    /// NXTクラス
    /// </summary>
    public class Nxt : ITarget
    {
        /// <summary>
        /// データサイズ
        /// </summary>
        const int DATASIZE = 64;

        /// <summary>
        /// シリアルポート
        /// </summary>
        private IComm comm_;
        public IComm comm
        {
            get { return this.comm_; }
        }

        /// <summary>
        /// 接続状態
        /// </summary>
        private CommStatus commStatus_;
        public CommStatus commStatus
        {
            get { return this.commStatus_; }
        }

        /// <summary>
        /// 排他オブジェクト
        /// </summary>
        private Object lockObject_;

        /// <summary>
        /// 受信メッセージ一覧
        /// </summary>
        private IRecvMessage[] recvMes_;

        /// <summary>
        /// 接続通知先
        /// </summary>
        public event ConnectEventHandler connectHandler;

        /// <summary>
        /// 切断通知先
        /// </summary>
        public event DisconnectEventHandler disconnectHandler;

        /// <summary>
        /// 異常通知先
        /// </summary>
        public event CommErrorEventHandler errorHandler;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Nxt(IRecvMessage[] mes)
        {
            commStatus_ = CommStatus.INITIALIZED;
            comm_ = null;
            connectHandler = null;
            disconnectHandler = null;
            errorHandler = null;
            lockObject_ = new Object();
            recvMes_ = mes;
        }

        /// <summary>
        /// 接続する
        /// </summary>
        /// <param name="comm"></param>
        public void Connect(IComm comm)
        {
            lock (lockObject_)
            {
                connect_sub(comm);
            }
        }

        /// <summary>
        /// 切断する
        /// </summary>
        public void Disconnect()
        {
            lock (lockObject_)
            {
                close_sub();
            }
        }

        /// <summary>
        /// 受信する
        /// </summary>
        private void receive(Object sender, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[DATASIZE];

            lock (lockObject_)
            {
                receive_sub(data);
            }
        }

        /// <summary>
        /// 接続する(サブ関数)
        /// </summary>
        private void connect_sub(IComm comm)
        {
            // 接続済でないか？
            if (commStatus_ != CommStatus.CONNECTED)
            {
                comm_ = comm;
                try
                {
                    comm_.Open();
                    comm_.DataReceived += new SerialDataReceivedEventHandler(receive);
                }
                catch
                {
                    // 異常を通知する
                    if (null != errorHandler)
                    {
                        errorHandler();
                    }
                    close_sub();
                    return;
                }

                // 接続を通知する
                if (null != connectHandler)
                {
                    connectHandler();
                }

                // 接続状態へ遷移
                commStatus_ = CommStatus.CONNECTED;
            }
        }

        /// <summary>
        /// 切断する(サブ関数)
        /// </summary>
        private void close_sub()
        {
            if (commStatus_ == CommStatus.CONNECTED)
            {
                comm_.Close();

                // 切断状態へ遷移
                commStatus_ = CommStatus.DISCONNECTED;
            }

            // 切断を通知する
            if (null != disconnectHandler)
            {
                disconnectHandler();
            }
        }

        /// <summary>
        /// 受信する(サブ関数)
        /// </summary>
        /// <param name="data"></param>
        private void receive_sub(byte[] data)
        {
            // コマンドを読み出す
            comm_.Read(data, 0, DATASIZE);

            // 受信データを処理する
            foreach(IRecvMessage mes in recvMes_)
            {
                mes.Receive(data);
            }
        }
    }
}
