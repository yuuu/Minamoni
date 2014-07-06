using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Minamoni.Comm
{
    /// <summary>
    /// SerialPortクラスのラッパー
    /// </summary>
    class WSerialPort : IComm
    {
        /// <summary>
        /// SerialPortの実体
        /// </summary>
        private SerialPort serialPort_;

        // ポート一覧取得
        public static string[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }

        /// <summary>
        /// 受信イベント
        /// </summary>
        public event SerialDataReceivedEventHandler DataReceived
        {
            add
            {
                serialPort_.DataReceived += value;
            }
            remove
            {
                serialPort_.DataReceived -= value;
            }
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="port"></param>
        public WSerialPort(String port)
        {
            serialPort_ = new SerialPort(port);
        }

        /// <summary>
        /// オープン
        /// </summary>
        public void Open()
        {
            serialPort_.Open();
        }

        /// <summary>
        /// クローズ
        /// </summary>
        public void Close()
        {
            serialPort_.Close();
        }

        /// <summary>
        /// 受信
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int Read(byte[] buffer, int offset, int count)
        {
            return serialPort_.Read(buffer, offset, count);
        }

        /// <summary>
        /// 送信
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        public void Write(byte[] buffer, int offset, int count)
        {
            serialPort_.Write(buffer, offset, count);
        }
    }
}
