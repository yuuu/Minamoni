namespace Minamoni
{
    partial class MinamoniForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinamoniForm));
            this.outputValueBox = new System.Windows.Forms.GroupBox();
            this.sMotorPWMRadioButton = new System.Windows.Forms.RadioButton();
            this.lMotorPWMRadioButton = new System.Windows.Forms.RadioButton();
            this.rMotorPWMRadioButton = new System.Windows.Forms.RadioButton();
            this.sMotorPWMTextBox = new System.Windows.Forms.TextBox();
            this.lMotorPWMTextBox = new System.Windows.Forms.TextBox();
            this.rMotorPWMTextBox = new System.Windows.Forms.TextBox();
            this.inputValueBox = new System.Windows.Forms.GroupBox();
            this.sonarSensorRadioButton = new System.Windows.Forms.RadioButton();
            this.gyroSensorRadioButton = new System.Windows.Forms.RadioButton();
            this.lightSensorRadioButton = new System.Windows.Forms.RadioButton();
            this.sMotorEncRadioButton = new System.Windows.Forms.RadioButton();
            this.lMotorEncRadioButton = new System.Windows.Forms.RadioButton();
            this.rMotorEncRadioButton = new System.Windows.Forms.RadioButton();
            this.vatteryRadioButton = new System.Windows.Forms.RadioButton();
            this.timeRadioButton = new System.Windows.Forms.RadioButton();
            this.sonarSensorTextBox = new System.Windows.Forms.TextBox();
            this.gyroSensorTextBox = new System.Windows.Forms.TextBox();
            this.lightSensorTextBox = new System.Windows.Forms.TextBox();
            this.sMotorEncTextBox = new System.Windows.Forms.TextBox();
            this.lMotorEncTextBox = new System.Windows.Forms.TextBox();
            this.rMotorEncTextBox = new System.Windows.Forms.TextBox();
            this.vatteryTextBox = new System.Windows.Forms.TextBox();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.logfileBox = new System.Windows.Forms.GroupBox();
            this.dirPathRefButton = new System.Windows.Forms.Button();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.dirPathTextBox = new System.Windows.Forms.TextBox();
            this.fileNameLabel = new System.Windows.Forms.Label();
            this.dirPathLabel = new System.Windows.Forms.Label();
            this.graphBox = new System.Windows.Forms.GroupBox();
            this.graphChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.portLabel = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.connectBox = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.outputValueBox.SuspendLayout();
            this.inputValueBox.SuspendLayout();
            this.logfileBox.SuspendLayout();
            this.graphBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.graphChart)).BeginInit();
            this.connectBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // outputValueBox
            // 
            this.outputValueBox.Controls.Add(this.sMotorPWMRadioButton);
            this.outputValueBox.Controls.Add(this.lMotorPWMRadioButton);
            this.outputValueBox.Controls.Add(this.rMotorPWMRadioButton);
            this.outputValueBox.Controls.Add(this.sMotorPWMTextBox);
            this.outputValueBox.Controls.Add(this.lMotorPWMTextBox);
            this.outputValueBox.Controls.Add(this.rMotorPWMTextBox);
            this.outputValueBox.Location = new System.Drawing.Point(12, 327);
            this.outputValueBox.Name = "outputValueBox";
            this.outputValueBox.Size = new System.Drawing.Size(197, 200);
            this.outputValueBox.TabIndex = 2;
            this.outputValueBox.TabStop = false;
            this.outputValueBox.Text = "出力値";
            // 
            // sMotorPWMRadioButton
            // 
            this.sMotorPWMRadioButton.AutoSize = true;
            this.sMotorPWMRadioButton.Location = new System.Drawing.Point(10, 70);
            this.sMotorPWMRadioButton.Name = "sMotorPWMRadioButton";
            this.sMotorPWMRadioButton.Size = new System.Drawing.Size(102, 16);
            this.sMotorPWMRadioButton.TabIndex = 8;
            this.sMotorPWMRadioButton.TabStop = true;
            this.sMotorPWMRadioButton.Text = "ステアモータPWM";
            this.sMotorPWMRadioButton.UseVisualStyleBackColor = true;
            // 
            // lMotorPWMRadioButton
            // 
            this.lMotorPWMRadioButton.AutoSize = true;
            this.lMotorPWMRadioButton.Location = new System.Drawing.Point(10, 45);
            this.lMotorPWMRadioButton.Name = "lMotorPWMRadioButton";
            this.lMotorPWMRadioButton.Size = new System.Drawing.Size(87, 16);
            this.lMotorPWMRadioButton.TabIndex = 7;
            this.lMotorPWMRadioButton.TabStop = true;
            this.lMotorPWMRadioButton.Text = "左モータPWM";
            this.lMotorPWMRadioButton.UseVisualStyleBackColor = true;
            // 
            // rMotorPWMRadioButton
            // 
            this.rMotorPWMRadioButton.AutoSize = true;
            this.rMotorPWMRadioButton.Location = new System.Drawing.Point(10, 20);
            this.rMotorPWMRadioButton.Name = "rMotorPWMRadioButton";
            this.rMotorPWMRadioButton.Size = new System.Drawing.Size(87, 16);
            this.rMotorPWMRadioButton.TabIndex = 6;
            this.rMotorPWMRadioButton.TabStop = true;
            this.rMotorPWMRadioButton.Text = "右モータPWM";
            this.rMotorPWMRadioButton.UseVisualStyleBackColor = true;
            // 
            // sMotorPWMTextBox
            // 
            this.sMotorPWMTextBox.Enabled = false;
            this.sMotorPWMTextBox.Location = new System.Drawing.Point(126, 69);
            this.sMotorPWMTextBox.Name = "sMotorPWMTextBox";
            this.sMotorPWMTextBox.Size = new System.Drawing.Size(65, 19);
            this.sMotorPWMTextBox.TabIndex = 5;
            // 
            // lMotorPWMTextBox
            // 
            this.lMotorPWMTextBox.Enabled = false;
            this.lMotorPWMTextBox.Location = new System.Drawing.Point(126, 44);
            this.lMotorPWMTextBox.Name = "lMotorPWMTextBox";
            this.lMotorPWMTextBox.Size = new System.Drawing.Size(65, 19);
            this.lMotorPWMTextBox.TabIndex = 4;
            // 
            // rMotorPWMTextBox
            // 
            this.rMotorPWMTextBox.Enabled = false;
            this.rMotorPWMTextBox.Location = new System.Drawing.Point(126, 19);
            this.rMotorPWMTextBox.Name = "rMotorPWMTextBox";
            this.rMotorPWMTextBox.Size = new System.Drawing.Size(65, 19);
            this.rMotorPWMTextBox.TabIndex = 3;
            // 
            // inputValueBox
            // 
            this.inputValueBox.Controls.Add(this.sonarSensorRadioButton);
            this.inputValueBox.Controls.Add(this.gyroSensorRadioButton);
            this.inputValueBox.Controls.Add(this.lightSensorRadioButton);
            this.inputValueBox.Controls.Add(this.sMotorEncRadioButton);
            this.inputValueBox.Controls.Add(this.lMotorEncRadioButton);
            this.inputValueBox.Controls.Add(this.rMotorEncRadioButton);
            this.inputValueBox.Controls.Add(this.vatteryRadioButton);
            this.inputValueBox.Controls.Add(this.timeRadioButton);
            this.inputValueBox.Controls.Add(this.sonarSensorTextBox);
            this.inputValueBox.Controls.Add(this.gyroSensorTextBox);
            this.inputValueBox.Controls.Add(this.lightSensorTextBox);
            this.inputValueBox.Controls.Add(this.sMotorEncTextBox);
            this.inputValueBox.Controls.Add(this.lMotorEncTextBox);
            this.inputValueBox.Controls.Add(this.rMotorEncTextBox);
            this.inputValueBox.Controls.Add(this.vatteryTextBox);
            this.inputValueBox.Controls.Add(this.timeTextBox);
            this.inputValueBox.Location = new System.Drawing.Point(12, 96);
            this.inputValueBox.Name = "inputValueBox";
            this.inputValueBox.Size = new System.Drawing.Size(197, 225);
            this.inputValueBox.TabIndex = 1;
            this.inputValueBox.TabStop = false;
            this.inputValueBox.Text = "入力値";
            // 
            // sonarSensorRadioButton
            // 
            this.sonarSensorRadioButton.AutoSize = true;
            this.sonarSensorRadioButton.Location = new System.Drawing.Point(10, 196);
            this.sonarSensorRadioButton.Name = "sonarSensorRadioButton";
            this.sonarSensorRadioButton.Size = new System.Drawing.Size(88, 16);
            this.sonarSensorRadioButton.TabIndex = 23;
            this.sonarSensorRadioButton.Text = "超音波センサ";
            this.sonarSensorRadioButton.UseVisualStyleBackColor = true;
            // 
            // gyroSensorRadioButton
            // 
            this.gyroSensorRadioButton.AutoSize = true;
            this.gyroSensorRadioButton.Location = new System.Drawing.Point(10, 170);
            this.gyroSensorRadioButton.Name = "gyroSensorRadioButton";
            this.gyroSensorRadioButton.Size = new System.Drawing.Size(88, 16);
            this.gyroSensorRadioButton.TabIndex = 22;
            this.gyroSensorRadioButton.Text = "ジャイロセンサ";
            this.gyroSensorRadioButton.UseVisualStyleBackColor = true;
            // 
            // lightSensorRadioButton
            // 
            this.lightSensorRadioButton.AutoSize = true;
            this.lightSensorRadioButton.Location = new System.Drawing.Point(10, 144);
            this.lightSensorRadioButton.Name = "lightSensorRadioButton";
            this.lightSensorRadioButton.Size = new System.Drawing.Size(88, 16);
            this.lightSensorRadioButton.TabIndex = 21;
            this.lightSensorRadioButton.Text = "赤外線センサ";
            this.lightSensorRadioButton.UseVisualStyleBackColor = true;
            // 
            // sMotorEncRadioButton
            // 
            this.sMotorEncRadioButton.AutoSize = true;
            this.sMotorEncRadioButton.Location = new System.Drawing.Point(10, 119);
            this.sMotorEncRadioButton.Name = "sMotorEncRadioButton";
            this.sMotorEncRadioButton.Size = new System.Drawing.Size(96, 16);
            this.sMotorEncRadioButton.TabIndex = 20;
            this.sMotorEncRadioButton.Text = "ステアモータEnc";
            this.sMotorEncRadioButton.UseVisualStyleBackColor = true;
            // 
            // lMotorEncRadioButton
            // 
            this.lMotorEncRadioButton.AutoSize = true;
            this.lMotorEncRadioButton.Location = new System.Drawing.Point(10, 94);
            this.lMotorEncRadioButton.Name = "lMotorEncRadioButton";
            this.lMotorEncRadioButton.Size = new System.Drawing.Size(81, 16);
            this.lMotorEncRadioButton.TabIndex = 19;
            this.lMotorEncRadioButton.Text = "左モータEnc";
            this.lMotorEncRadioButton.UseVisualStyleBackColor = true;
            // 
            // rMotorEncRadioButton
            // 
            this.rMotorEncRadioButton.AutoSize = true;
            this.rMotorEncRadioButton.Location = new System.Drawing.Point(10, 69);
            this.rMotorEncRadioButton.Name = "rMotorEncRadioButton";
            this.rMotorEncRadioButton.Size = new System.Drawing.Size(81, 16);
            this.rMotorEncRadioButton.TabIndex = 18;
            this.rMotorEncRadioButton.Text = "右モータEnc";
            this.rMotorEncRadioButton.UseVisualStyleBackColor = true;
            // 
            // vatteryRadioButton
            // 
            this.vatteryRadioButton.AutoSize = true;
            this.vatteryRadioButton.Location = new System.Drawing.Point(10, 46);
            this.vatteryRadioButton.Name = "vatteryRadioButton";
            this.vatteryRadioButton.Size = new System.Drawing.Size(71, 16);
            this.vatteryRadioButton.TabIndex = 17;
            this.vatteryRadioButton.Text = "電源電圧";
            this.vatteryRadioButton.UseVisualStyleBackColor = true;
            // 
            // timeRadioButton
            // 
            this.timeRadioButton.AutoSize = true;
            this.timeRadioButton.Checked = true;
            this.timeRadioButton.Location = new System.Drawing.Point(10, 19);
            this.timeRadioButton.Name = "timeRadioButton";
            this.timeRadioButton.Size = new System.Drawing.Size(47, 16);
            this.timeRadioButton.TabIndex = 16;
            this.timeRadioButton.TabStop = true;
            this.timeRadioButton.Text = "時間";
            this.timeRadioButton.UseVisualStyleBackColor = true;
            // 
            // sonarSensorTextBox
            // 
            this.sonarSensorTextBox.Enabled = false;
            this.sonarSensorTextBox.Location = new System.Drawing.Point(126, 195);
            this.sonarSensorTextBox.Name = "sonarSensorTextBox";
            this.sonarSensorTextBox.Size = new System.Drawing.Size(65, 19);
            this.sonarSensorTextBox.TabIndex = 15;
            // 
            // gyroSensorTextBox
            // 
            this.gyroSensorTextBox.Enabled = false;
            this.gyroSensorTextBox.Location = new System.Drawing.Point(126, 169);
            this.gyroSensorTextBox.Name = "gyroSensorTextBox";
            this.gyroSensorTextBox.Size = new System.Drawing.Size(65, 19);
            this.gyroSensorTextBox.TabIndex = 14;
            // 
            // lightSensorTextBox
            // 
            this.lightSensorTextBox.Enabled = false;
            this.lightSensorTextBox.Location = new System.Drawing.Point(126, 143);
            this.lightSensorTextBox.Name = "lightSensorTextBox";
            this.lightSensorTextBox.Size = new System.Drawing.Size(65, 19);
            this.lightSensorTextBox.TabIndex = 13;
            // 
            // sMotorEncTextBox
            // 
            this.sMotorEncTextBox.Enabled = false;
            this.sMotorEncTextBox.Location = new System.Drawing.Point(126, 118);
            this.sMotorEncTextBox.Name = "sMotorEncTextBox";
            this.sMotorEncTextBox.Size = new System.Drawing.Size(65, 19);
            this.sMotorEncTextBox.TabIndex = 12;
            // 
            // lMotorEncTextBox
            // 
            this.lMotorEncTextBox.Enabled = false;
            this.lMotorEncTextBox.Location = new System.Drawing.Point(126, 93);
            this.lMotorEncTextBox.Name = "lMotorEncTextBox";
            this.lMotorEncTextBox.Size = new System.Drawing.Size(65, 19);
            this.lMotorEncTextBox.TabIndex = 11;
            // 
            // rMotorEncTextBox
            // 
            this.rMotorEncTextBox.Enabled = false;
            this.rMotorEncTextBox.Location = new System.Drawing.Point(126, 68);
            this.rMotorEncTextBox.Name = "rMotorEncTextBox";
            this.rMotorEncTextBox.Size = new System.Drawing.Size(65, 19);
            this.rMotorEncTextBox.TabIndex = 10;
            // 
            // vatteryTextBox
            // 
            this.vatteryTextBox.Enabled = false;
            this.vatteryTextBox.Location = new System.Drawing.Point(126, 43);
            this.vatteryTextBox.Name = "vatteryTextBox";
            this.vatteryTextBox.Size = new System.Drawing.Size(65, 19);
            this.vatteryTextBox.TabIndex = 9;
            // 
            // timeTextBox
            // 
            this.timeTextBox.Enabled = false;
            this.timeTextBox.Location = new System.Drawing.Point(126, 18);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(65, 19);
            this.timeTextBox.TabIndex = 8;
            // 
            // logfileBox
            // 
            this.logfileBox.Controls.Add(this.dirPathRefButton);
            this.logfileBox.Controls.Add(this.fileNameTextBox);
            this.logfileBox.Controls.Add(this.dirPathTextBox);
            this.logfileBox.Controls.Add(this.fileNameLabel);
            this.logfileBox.Controls.Add(this.dirPathLabel);
            this.logfileBox.Location = new System.Drawing.Point(215, 12);
            this.logfileBox.Name = "logfileBox";
            this.logfileBox.Size = new System.Drawing.Size(565, 77);
            this.logfileBox.TabIndex = 4;
            this.logfileBox.TabStop = false;
            this.logfileBox.Text = "ログファイル";
            // 
            // dirPathRefButton
            // 
            this.dirPathRefButton.Location = new System.Drawing.Point(484, 17);
            this.dirPathRefButton.Name = "dirPathRefButton";
            this.dirPathRefButton.Size = new System.Drawing.Size(75, 23);
            this.dirPathRefButton.TabIndex = 4;
            this.dirPathRefButton.Text = "参照";
            this.dirPathRefButton.UseVisualStyleBackColor = true;
            this.dirPathRefButton.Click += new System.EventHandler(this.dirPathRefButton_Click);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(63, 47);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(415, 19);
            this.fileNameTextBox.TabIndex = 3;
            this.fileNameTextBox.Text = "Log.csv";
            // 
            // dirPathTextBox
            // 
            this.dirPathTextBox.Location = new System.Drawing.Point(63, 18);
            this.dirPathTextBox.Name = "dirPathTextBox";
            this.dirPathTextBox.ReadOnly = true;
            this.dirPathTextBox.Size = new System.Drawing.Size(415, 19);
            this.dirPathTextBox.TabIndex = 2;
            // 
            // fileNameLabel
            // 
            this.fileNameLabel.AutoSize = true;
            this.fileNameLabel.Location = new System.Drawing.Point(6, 50);
            this.fileNameLabel.Name = "fileNameLabel";
            this.fileNameLabel.Size = new System.Drawing.Size(51, 12);
            this.fileNameLabel.TabIndex = 1;
            this.fileNameLabel.Text = "ファイル名";
            // 
            // dirPathLabel
            // 
            this.dirPathLabel.AutoSize = true;
            this.dirPathLabel.Location = new System.Drawing.Point(6, 22);
            this.dirPathLabel.Name = "dirPathLabel";
            this.dirPathLabel.Size = new System.Drawing.Size(41, 12);
            this.dirPathLabel.TabIndex = 0;
            this.dirPathLabel.Text = "保存先";
            // 
            // graphBox
            // 
            this.graphBox.Controls.Add(this.graphChart);
            this.graphBox.Location = new System.Drawing.Point(215, 96);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(565, 431);
            this.graphBox.TabIndex = 3;
            this.graphBox.TabStop = false;
            this.graphBox.Text = "グラフビュー";
            // 
            // graphChart
            // 
            this.graphChart.AntiAliasing = System.Windows.Forms.DataVisualization.Charting.AntiAliasingStyles.None;
            this.graphChart.BackColor = System.Drawing.Color.Black;
            chartArea1.AxisX.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisX.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(66)))));
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(66)))));
            chartArea1.AxisX.TitleForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelStyle.ForeColor = System.Drawing.Color.White;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(66)))));
            chartArea1.AxisY.MinorGrid.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(130)))), ((int)(((byte)(66)))));
            chartArea1.AxisY.TitleForeColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.InnerPlotPosition.Auto = false;
            chartArea1.InnerPlotPosition.Height = 94F;
            chartArea1.InnerPlotPosition.Width = 92F;
            chartArea1.InnerPlotPosition.X = 6F;
            chartArea1.Name = "ChartArea1";
            this.graphChart.ChartAreas.Add(chartArea1);
            this.graphChart.Location = new System.Drawing.Point(6, 19);
            this.graphChart.Name = "graphChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.Lime;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            this.graphChart.Series.Add(series1);
            this.graphChart.Size = new System.Drawing.Size(553, 417);
            this.graphChart.TabIndex = 0;
            this.graphChart.Text = "chart1";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(8, 22);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(33, 12);
            this.portLabel.TabIndex = 0;
            this.portLabel.Text = "ポート";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(35, 45);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 1;
            this.connectButton.Text = "接続";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Enabled = false;
            this.disconnectButton.Location = new System.Drawing.Point(116, 45);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(75, 23);
            this.disconnectButton.TabIndex = 2;
            this.disconnectButton.Text = "切断";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // portComboBox
            // 
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(47, 19);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(144, 20);
            this.portComboBox.TabIndex = 3;
            // 
            // connectBox
            // 
            this.connectBox.Controls.Add(this.portComboBox);
            this.connectBox.Controls.Add(this.disconnectButton);
            this.connectBox.Controls.Add(this.connectButton);
            this.connectBox.Controls.Add(this.portLabel);
            this.connectBox.Location = new System.Drawing.Point(12, 12);
            this.connectBox.Name = "connectBox";
            this.connectBox.Size = new System.Drawing.Size(197, 78);
            this.connectBox.TabIndex = 0;
            this.connectBox.TabStop = false;
            this.connectBox.Text = "接続";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 535);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(780, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip";
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(32, 18);
            this.connectionStatusLabel.Text = "切断";
            // 
            // MinamoniForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 558);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.graphBox);
            this.Controls.Add(this.connectBox);
            this.Controls.Add(this.logfileBox);
            this.Controls.Add(this.outputValueBox);
            this.Controls.Add(this.inputValueBox);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MinamoniForm";
            this.Text = "ETロボコンみんなのモニタリングツール by ETロボコン関西連合";
            this.outputValueBox.ResumeLayout(false);
            this.outputValueBox.PerformLayout();
            this.inputValueBox.ResumeLayout(false);
            this.inputValueBox.PerformLayout();
            this.logfileBox.ResumeLayout(false);
            this.logfileBox.PerformLayout();
            this.graphBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.graphChart)).EndInit();
            this.connectBox.ResumeLayout(false);
            this.connectBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox outputValueBox;
        private System.Windows.Forms.GroupBox inputValueBox;
        private System.Windows.Forms.TextBox sonarSensorTextBox;
        private System.Windows.Forms.TextBox gyroSensorTextBox;
        private System.Windows.Forms.TextBox lightSensorTextBox;
        private System.Windows.Forms.TextBox sMotorEncTextBox;
        private System.Windows.Forms.TextBox lMotorEncTextBox;
        private System.Windows.Forms.TextBox rMotorEncTextBox;
        private System.Windows.Forms.TextBox vatteryTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.GroupBox logfileBox;
        private System.Windows.Forms.GroupBox graphBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.GroupBox connectBox;
        private System.Windows.Forms.TextBox sMotorPWMTextBox;
        private System.Windows.Forms.TextBox lMotorPWMTextBox;
        private System.Windows.Forms.TextBox rMotorPWMTextBox;
        private System.Windows.Forms.TextBox dirPathTextBox;
        private System.Windows.Forms.Label fileNameLabel;
        private System.Windows.Forms.Label dirPathLabel;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Button dirPathRefButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatusLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart graphChart;
        private System.Windows.Forms.RadioButton timeRadioButton;
        private System.Windows.Forms.RadioButton vatteryRadioButton;
        private System.Windows.Forms.RadioButton sMotorPWMRadioButton;
        private System.Windows.Forms.RadioButton lMotorPWMRadioButton;
        private System.Windows.Forms.RadioButton rMotorPWMRadioButton;
        private System.Windows.Forms.RadioButton sonarSensorRadioButton;
        private System.Windows.Forms.RadioButton gyroSensorRadioButton;
        private System.Windows.Forms.RadioButton lightSensorRadioButton;
        private System.Windows.Forms.RadioButton sMotorEncRadioButton;
        private System.Windows.Forms.RadioButton lMotorEncRadioButton;
        private System.Windows.Forms.RadioButton rMotorEncRadioButton;

    }
}

