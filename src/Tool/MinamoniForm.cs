using Minamoni.Comm;
using Minamoni.RecvMessage;
using Minamoni.RecvMessage.Logfile;
using Minamoni.Target;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Minamoni
{

    public partial class MinamoniForm : Form
    {
        /// <summary>
        /// グラフデータ
        /// </summary>
        Queue<Record?> graphData;
        const int GRAPH_DATA_NUM = 2000;

        /// <summary>
        /// グラフ更新タイマー
        /// </summary>
        private Timer graphTimer;
        const int GRAPH_UPDATE_PERIOD = 100;

        /// <summary>
        /// ログ値更新タイマー
        /// </summary>
        private Timer logvalueTimer;
        const int LOGVALUE_UPDATE_PERIOD = 500;

        /// <summary>
        /// 接続先
        /// </summary>
        ITarget target_;

        /// <summary>
        /// ログファイル
        /// </summary>
        ILogfile logfile_;

        /// <summary>
        /// 初期化
        /// </summary>
        public MinamoniForm()
        {
            InitializeComponent();

            // ログ格納先パスを設定
            dirPathTextBox.Text = Directory.GetCurrentDirectory();

            // グラフ表示データの初期化
            graphData = new Queue<Record?>();

            // グラフ更新タイマーの初期化
            graphTimer = new Timer();
            graphTimer.Tick += new EventHandler(updateGraphDisp);
            graphTimer.Interval = GRAPH_UPDATE_PERIOD;

            // ログ値更新タイマー
            logvalueTimer = new Timer();
            logvalueTimer.Tick += new EventHandler(updateRecordValue);
            logvalueTimer.Interval = LOGVALUE_UPDATE_PERIOD;

            // ポート一覧をComboBoxへセット
            foreach (String item in WSerialPort.GetPortNames())
            {
                portComboBox.Items.Add(item);
                portComboBox.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 参照ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dirPathRefButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                dirPathTextBox.Text = folderBrowserDialog.SelectedPath;
            }
        }

        /// <summary>
        /// 接続ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            // 各UIを接続中の表示とする
            updateUiAtConnecting();

            // UI更新完了を待つ
            Application.DoEvents();

            // ログファイルを生成
            IOLog ioLog = new IOLog(dirPathTextBox.Text, fileNameTextBox.Text);
            List<IRecvMessage> recvMessageList = new List<IRecvMessage>();
            recvMessageList.Add(ioLog);
            logfile_ = ioLog;

            // 接続する
            target_ = new Nxt(recvMessageList.ToArray());
            target_.connectHandler += new ConnectEventHandler(updateUiAtConnect);
            target_.disconnectHandler += new DisconnectEventHandler(updateUiAtDisconnect);
            target_.errorHandler += new CommErrorEventHandler(errorNotify);
            target_.Connect(new WSerialPort(portComboBox.SelectedItem.ToString()));
        }

        /// <summary>
        /// 切断ボタンクリック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            // 切断する
            target_.Disconnect();
        }

        /// <summary>
        /// 接続時のUI更新
        /// </summary>
        private void updateUiAtConnect()
        {
            Invoke((Action)delegate()
            {
                connectButton.Enabled = false;
                disconnectButton.Enabled = true;

                timeRadioButton.Enabled = true;
                vatteryRadioButton.Enabled = true;
                rMotorEncRadioButton.Enabled = true;
                lMotorEncRadioButton.Enabled = true;
                sMotorEncRadioButton.Enabled = true;
                lightSensorRadioButton.Enabled = true;
                gyroSensorRadioButton.Enabled = true;
                sonarSensorRadioButton.Enabled = true;
                rMotorPWMRadioButton.Enabled = true;
                lMotorPWMRadioButton.Enabled = true;
                sMotorPWMRadioButton.Enabled = true;

                timeTextBox.Enabled = true;
                vatteryTextBox.Enabled = true;
                rMotorEncTextBox.Enabled = true;
                lMotorEncTextBox.Enabled = true;
                sMotorEncTextBox.Enabled = true;
                lightSensorTextBox.Enabled = true;
                gyroSensorTextBox.Enabled = true;
                sonarSensorTextBox.Enabled = true;
                rMotorPWMTextBox.Enabled = true;
                lMotorPWMTextBox.Enabled = true;
                sMotorPWMTextBox.Enabled = true;

                portComboBox.Enabled = false;
                fileNameTextBox.Enabled = false;
                dirPathRefButton.Enabled = false;

                // 更新タイマーを開始する
                graphTimer.Start();
                logvalueTimer.Start();
            });
        }

        /// <summary>
        /// 接続中のUI更新
        /// </summary>
        private void updateUiAtConnecting()
        {
            Invoke((Action)delegate()
            {
                connectButton.Enabled = false;
                disconnectButton.Enabled = false;

                timeRadioButton.Enabled = false;
                vatteryRadioButton.Enabled = false;
                rMotorEncRadioButton.Enabled = false;
                lMotorEncRadioButton.Enabled = false;
                sMotorEncRadioButton.Enabled = false;
                lightSensorRadioButton.Enabled = false;
                gyroSensorRadioButton.Enabled = false;
                sonarSensorRadioButton.Enabled = false;
                rMotorPWMRadioButton.Enabled = false;
                lMotorPWMRadioButton.Enabled = false;
                sMotorPWMRadioButton.Enabled = false;

                timeTextBox.Enabled = false;
                vatteryTextBox.Enabled = false;
                rMotorEncTextBox.Enabled = false;
                lMotorEncTextBox.Enabled = false;
                sMotorEncTextBox.Enabled = false;
                lightSensorTextBox.Enabled = false;
                gyroSensorTextBox.Enabled = false;
                sonarSensorTextBox.Enabled = false;
                rMotorPWMTextBox.Enabled = false;
                lMotorPWMTextBox.Enabled = false;
                sMotorPWMTextBox.Enabled = false;

                portComboBox.Enabled = false;
                fileNameTextBox.Enabled = false;
                dirPathRefButton.Enabled = false;
            });
        }

        /// <summary>
        /// 切断時のUI更新
        /// </summary>
        private void updateUiAtDisconnect()
        {
            Invoke((Action)delegate()
            {
                connectButton.Enabled = true;
                disconnectButton.Enabled = false;

                timeRadioButton.Enabled = false;
                vatteryRadioButton.Enabled = false;
                rMotorEncRadioButton.Enabled = false;
                lMotorEncRadioButton.Enabled = false;
                sMotorEncRadioButton.Enabled = false;
                lightSensorRadioButton.Enabled = false;
                gyroSensorRadioButton.Enabled = false;
                sonarSensorRadioButton.Enabled = false;
                rMotorPWMRadioButton.Enabled = false;
                lMotorPWMRadioButton.Enabled = false;
                sMotorPWMRadioButton.Enabled = false;

                timeTextBox.Enabled = false;
                vatteryTextBox.Enabled = false;
                rMotorEncTextBox.Enabled = false;
                lMotorEncTextBox.Enabled = false;
                sMotorEncTextBox.Enabled = false;
                lightSensorTextBox.Enabled = false;
                gyroSensorTextBox.Enabled = false;
                sonarSensorTextBox.Enabled = false;
                rMotorPWMTextBox.Enabled = false;
                lMotorPWMTextBox.Enabled = false;
                sMotorPWMTextBox.Enabled = false;

                portComboBox.Enabled = true;
                fileNameTextBox.Enabled = true;
                dirPathRefButton.Enabled = true;

                // ログファイルを保存する
                logfile_.Save();

                // 更新タイマーを終了する
                graphTimer.Stop();
                logvalueTimer.Stop();
            });
        }

        /// <summary>
        /// ログ受信時のUI更新
        /// </summary>
        private void updateRecordValue(object sender, EventArgs e)
        {
            Invoke((Action)delegate()
            {
                Record? recent = logfile_.GetRecentRecord();

                if (recent != null)
                {
                    timeTextBox.Text = recent.Value.time.ToString();
                    vatteryTextBox.Text = recent.Value.vattery.ToString();
                    rMotorEncTextBox.Text = recent.Value.rMotorEnc.ToString();
                    lMotorEncTextBox.Text = recent.Value.lMotorEnc.ToString();
                    sMotorEncTextBox.Text = recent.Value.sMotorEnc.ToString();
                    lightSensorTextBox.Text = recent.Value.lightSensor.ToString();
                    gyroSensorTextBox.Text = recent.Value.gyroSensor.ToString();
                    sonarSensorTextBox.Text = recent.Value.sonarSensor.ToString();
                    rMotorPWMTextBox.Text = recent.Value.rMotorPWM.ToString();
                    lMotorPWMTextBox.Text = recent.Value.lMotorPWM.ToString();
                    sMotorPWMTextBox.Text = recent.Value.sMotorPWM.ToString();
                }
            });
        }

        /// <summary>
        /// エラー通知
        /// </summary>
        private void errorNotify()
        {
            Invoke((Action)delegate()
            {
                MessageBox.Show("通信に失敗しました", "通信失敗", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        /// <summary>
        /// グラフ表示更新
        /// </summary>
        private void updateGraphDisp(object sender, EventArgs e)
        {
            // グラフデータを更新する
            updateGraphData();

            // グラフデータをセットする
            graphChart.Series[0].Points.Clear();
            foreach(Record? record in graphData)
            {
                setGraphValue(record, graphChart.Series[0]);
            }
        }

        /// <summary>
        /// グラフデータ更新
        /// </summary>
        private void updateGraphData()
        {
            List<Record> recordList = logfile_.GetRecoad(GRAPH_DATA_NUM);

            graphData.Clear();
            for (int i = 0; i < GRAPH_DATA_NUM; i++ )
            {
                graphData.Enqueue(null);
            }

            foreach (Record record in recordList)
            {
                graphData.Enqueue(record);
            }

            while (graphData.Count > GRAPH_DATA_NUM)
            {
                graphData.Dequeue();
            }
        }

        /// <summary>
        /// グラフ表示値取得
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        private void setGraphValue(Record? record, Series series)
        {
            if (record == null)
            {
                series.Points.Add(new DataPoint(0, 0));
            }
            else
            {
                if (timeRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.time)); }
                if (vatteryRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.vattery)); }
                if (rMotorEncRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.rMotorEnc)); }
                if (lMotorEncRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.lMotorEnc)); }
                if (sMotorEncRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.sMotorEnc)); }
                if (lightSensorRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.lightSensor)); }
                if (gyroSensorRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.gyroSensor)); }
                if (sonarSensorRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.sonarSensor)); }
                if (rMotorPWMRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.rMotorPWM)); }
                if (lMotorPWMRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.lMotorPWM)); }
                if (sMotorPWMRadioButton.Checked) { series.Points.Add(new DataPoint(0, record.Value.sMotorPWM)); }
            }
        }
    }
}
