using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Minamoni.RecvMessage.Logfile
{
    /// <summary>
    /// ログクラス
    /// </summary>
    public class IOLog : IRecvMessage, ILogfile
    {
        /// <summary>
        /// ログリスト
        /// </summary>
        private List<Record> log_;

        /// <summary>
        /// パス名
        /// </summary>
        String path_;

        /// <summary>
        /// ファイル名
        /// </summary>
        String fileName_;

        // 受信メッセージサイズ
        const UInt32 DATASIZE = 64;

        /// <summary>
        /// ログ追加通知先
        /// </summary>
        public event LogAddEventHandler logAddHandler;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public IOLog(String path, String fileName)
        {
            log_ = new List<Record>();
            fileName_ = fileName;
            path_ = path;
        }

        /// <summary>
        /// 受信する
        /// </summary>
        /// <param name="data"></param>
        public void Receive(byte[] data)
        {
            MessageType type = (MessageType)BitConverter.ToUInt32(data, 0);
            UInt32 size = BitConverter.ToUInt32(data, 4);

            if ((type == MessageType.LOG) && (size == DATASIZE))
            {
                // ログを追加する
                Record record = new Record();
                record.index = BitConverter.ToUInt32(data, 8);
                record.time = BitConverter.ToUInt32(data, 12);
                record.vattery = BitConverter.ToUInt32(data, 16);
                record.rMotorEnc = BitConverter.ToInt32(data, 20);
                record.lMotorEnc = BitConverter.ToInt32(data, 24);
                record.sMotorEnc = BitConverter.ToInt32(data, 28);
                record.lightSensor = BitConverter.ToUInt32(data, 32);
                record.gyroSensor = BitConverter.ToInt32(data, 36);
                record.sonarSensor = BitConverter.ToUInt32(data, 40);
                record.rMotorPWM = BitConverter.ToInt32(data, 44);
                record.lMotorPWM = BitConverter.ToInt32(data, 48);
                record.sMotorPWM = BitConverter.ToInt32(data, 52);
                
                log_.Add(record);

                // ログ追加を通知する
                if(logAddHandler != null)
                {
                    logAddHandler(record);
                }
            }
        }

        /// <summary>
        /// 保存する
        /// </summary>
        public void Save()
        {
            // ログが存在するか？
            if (log_.Count > 0)
            {
                // フォルダ生成
                if (!Directory.Exists(path_))
                {
                    Directory.CreateDirectory(path_);
                }

                // ファイル出力
                save_sub();
            }
        }

        /// <summary>
        /// 取得する
        /// </summary>
        /// <param name="num"></param>
        public List<Record> GetRecoad(int num)
        {
            List<Record> recordList = new List<Record>();

            if(log_.Count > num)
            {
                for(int i = (log_.Count - num) ; i < log_.Count ; i++)
                {
                    recordList.Add(log_[i]);
                }
            }
            else
            {
                for(int i = 0 ; i < log_.Count ; i++)
                {
                    recordList.Add(log_[i]);
                }
            }

            return recordList;
        }

        /// <summary>
        /// 最新のレコードを取得する
        /// </summary>
        /// <param name="num"></param>
        public Record? GetRecentRecord()
        {
            Record? record = null;

            if(log_.Count > 0)
            {
                record = log_[log_.Count - 1];
            }

            return record;
        }

        /// <summary>
        /// 保存する(サブ)
        /// </summary>
        private void save_sub()
        {
            StreamWriter stream = null;

            // ファイルにテキストを書き出し。
            try
            {
                stream = new StreamWriter(path_ + @"\" + fileName_, false, Encoding.UTF8);
                
                // ヘッダを出力
                outputHeader(stream);

                // レコードを出力
                foreach (Record record in log_)
                {
                    outputRecord(stream, record);
                }
            }
            catch(Exception e)
            {
                // 保存失敗した
            }
            finally
            {
                // クローズ
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        /// <summary>
        /// ヘッダを出力する
        /// </summary>
        private void outputHeader(StreamWriter stream)
        {
            stream.Write("No." + ", ");
            stream.Write("時間" + ", ");
            stream.Write("電圧" + ", ");
            stream.Write("右モータEnc" + ", ");
            stream.Write("左モータEnc" + ", ");
            stream.Write("ステアモータEnc" + ", ");
            stream.Write("光センサ" + ", ");
            stream.Write("ジャイロセンサ" + ", ");
            stream.Write("超音波センサ" + ", ");
            stream.Write("右モータPWM" + ", ");
            stream.Write("左モータPWM" + ", ");
            stream.Write("ステアモータPWM" + ", ");
            stream.WriteLine();
        }

        /// <summary>
        /// レコードを出力する
        /// </summary>
        private void outputRecord(StreamWriter stream, Record record)
        {
            stream.Write(record.index.ToString() + ", ");
            stream.Write(record.time.ToString() + ", ");
            stream.Write(record.vattery.ToString() + ", ");
            stream.Write(record.rMotorEnc.ToString() + ", ");
            stream.Write(record.lMotorEnc.ToString() + ", ");
            stream.Write(record.sMotorEnc.ToString() + ", ");
            stream.Write(record.lightSensor.ToString() + ", ");
            stream.Write(record.gyroSensor.ToString() + ", ");
            stream.Write(record.sonarSensor.ToString() + ", ");
            stream.Write(record.rMotorPWM.ToString() + ", ");
            stream.Write(record.lMotorPWM.ToString() + ", ");
            stream.Write(record.sMotorPWM.ToString() + ", ");
            stream.WriteLine();
        }
    }
}
