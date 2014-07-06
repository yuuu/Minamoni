using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Minamoni.RecvMessage.Logfile
{
    /// <summary>
    /// レコード構造体
    /// </summary>
    public struct Record
    {
        public UInt32 index;
        public UInt32 time;
        public UInt32 vattery;
        public Int32 rMotorEnc;
        public Int32 lMotorEnc;
        public Int32 sMotorEnc;
        public UInt32 lightSensor;
        public Int32 gyroSensor;
        public UInt32 sonarSensor;
        public Int32 rMotorPWM;
        public Int32 lMotorPWM;
        public Int32 sMotorPWM;
    };

    /// <summary>
    /// ログ追加通知先デリゲート
    /// </summary>
    /// <param name="recent"></param>
    public delegate void LogAddEventHandler(Record recent);

    /// <summary>
    /// ログファイルインターフェース
    /// </summary>
    public interface ILogfile
    {
        /// <summary>
        /// ログ追加通知先
        /// </summary>
        event LogAddEventHandler logAddHandler;

        /// <summary>
        /// 保存する
        /// </summary>
        void Save();

        /// <summary>
        /// 取得する
        /// </summary>
        /// <param name="num"></param>
        List<Record> GetRecoad(int num);

        /// <summary>
        /// 最新のレコードを取得する
        /// </summary>
        /// <returns></returns>
        Record? GetRecentRecord();
    }
}
