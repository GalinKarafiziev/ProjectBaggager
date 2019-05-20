namespace Procp_Form
{
    partial class Baggager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.animationBox = new System.Windows.Forms.PictureBox();
            this.cmBoxNodeToBuild = new System.Windows.Forms.ComboBox();
            this.chbBuildMode = new System.Windows.Forms.CheckBox();
            this.lblBagStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNextNode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNodeType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColRow = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.lbFlights = new System.Windows.Forms.ListBox();
            this.tbFlightNr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDropOffDest = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDeleteFlight = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnEditFlight = new System.Windows.Forms.Button();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.tbFlightTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.tbFlightBaggage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.chbDeleteMode = new System.Windows.Forms.CheckBox();
            this.buttonShowQueuedBaggage = new System.Windows.Forms.Button();
            this.buttonShowProcessedBaggage = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSimVisuals = new System.Windows.Forms.TabPage();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.buttonFailedSecurityCheck = new System.Windows.Forms.Button();
            this.cartesianChartFailedToPassBaggage = new LiveCharts.WinForms.CartesianChart();
            this.buttonLoadChartBaggageThroughCheckin = new System.Windows.Forms.Button();
            this.cartesianChartBaggageProcessedByCheckin = new LiveCharts.WinForms.CartesianChart();
            this.pieChartPercentageAllFailedBaggage = new LiveCharts.WinForms.PieChart();
            this.buttonRefreshPercentageFailedBags = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSimVisuals.SuspendLayout();
            this.tabPageStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // animationBox
            // 
            this.animationBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.animationBox.Location = new System.Drawing.Point(4, 4);
            this.animationBox.Margin = new System.Windows.Forms.Padding(4);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(2289, 1142);
            this.animationBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animationBox.TabIndex = 0;
            this.animationBox.TabStop = false;
            this.animationBox.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationBox_Paint);
            this.animationBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnimationBox_MouseDown);
            this.animationBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnimationBox_MouseMove);
            this.animationBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnimationBox_MouseUp);
            // 
            // cmBoxNodeToBuild
            // 
            this.cmBoxNodeToBuild.FormattingEnabled = true;
            this.cmBoxNodeToBuild.Items.AddRange(new object[] {
            "Conveyor",
            "CheckIn",
            "DropOff",
            "Security Scanner",
            "MPA"});
            this.cmBoxNodeToBuild.Location = new System.Drawing.Point(9, 79);
            this.cmBoxNodeToBuild.Margin = new System.Windows.Forms.Padding(4);
            this.cmBoxNodeToBuild.Name = "cmBoxNodeToBuild";
            this.cmBoxNodeToBuild.Size = new System.Drawing.Size(155, 24);
            this.cmBoxNodeToBuild.TabIndex = 2;
            this.cmBoxNodeToBuild.SelectedIndexChanged += new System.EventHandler(this.CmBoxNodeToBuild_SelectedIndexChanged);
            // 
            // chbBuildMode
            // 
            this.chbBuildMode.AutoSize = true;
            this.chbBuildMode.Location = new System.Drawing.Point(9, 17);
            this.chbBuildMode.Margin = new System.Windows.Forms.Padding(4);
            this.chbBuildMode.Name = "chbBuildMode";
            this.chbBuildMode.Size = new System.Drawing.Size(100, 21);
            this.chbBuildMode.TabIndex = 4;
            this.chbBuildMode.Text = "Build Mode";
            this.chbBuildMode.UseVisualStyleBackColor = true;
            this.chbBuildMode.CheckedChanged += new System.EventHandler(this.ChbBuildMode_CheckedChanged);
            // 
            // lblBagStatus
            // 
            this.lblBagStatus.AutoSize = true;
            this.lblBagStatus.Location = new System.Drawing.Point(126, 81);
            this.lblBagStatus.Name = "lblBagStatus";
            this.lblBagStatus.Size = new System.Drawing.Size(46, 17);
            this.lblBagStatus.TabIndex = 6;
            this.lblBagStatus.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblNextNode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblNodeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBagStatus);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblColRow);
            this.groupBox1.Location = new System.Drawing.Point(13, 141);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(190, 145);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Info:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 30);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 11;
            this.label7.Text = "Type:";
            // 
            // lblNextNode
            // 
            this.lblNextNode.AutoSize = true;
            this.lblNextNode.Location = new System.Drawing.Point(85, 107);
            this.lblNextNode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNextNode.Name = "lblNextNode";
            this.lblNextNode.Size = new System.Drawing.Size(46, 17);
            this.lblNextNode.TabIndex = 10;
            this.lblNextNode.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 107);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Next Node:";
            // 
            // lblNodeType
            // 
            this.lblNodeType.AutoSize = true;
            this.lblNodeType.Location = new System.Drawing.Point(59, 30);
            this.lblNodeType.Name = "lblNodeType";
            this.lblNodeType.Size = new System.Drawing.Size(46, 17);
            this.lblNodeType.TabIndex = 8;
            this.lblNodeType.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baggage status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Column and Row:";
            // 
            // lblColRow
            // 
            this.lblColRow.AutoSize = true;
            this.lblColRow.Location = new System.Drawing.Point(134, 57);
            this.lblColRow.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColRow.Name = "lblColRow";
            this.lblColRow.Size = new System.Drawing.Size(46, 17);
            this.lblColRow.TabIndex = 9;
            this.lblColRow.Text = "label2";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(110, 18);
            this.lblTest.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(35, 17);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "[Off]";
            // 
            // lbFlights
            // 
            this.lbFlights.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlights.FormattingEnabled = true;
            this.lbFlights.ItemHeight = 22;
            this.lbFlights.Location = new System.Drawing.Point(10, 206);
            this.lbFlights.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lbFlights.Name = "lbFlights";
            this.lbFlights.Size = new System.Drawing.Size(375, 92);
            this.lbFlights.TabIndex = 10;
            // 
            // tbFlightNr
            // 
            this.tbFlightNr.Location = new System.Drawing.Point(75, 26);
            this.tbFlightNr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFlightNr.Name = "tbFlightNr";
            this.tbFlightNr.Size = new System.Drawing.Size(132, 22);
            this.tbFlightNr.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "FlightNr.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbDropOffDest);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.btnDeleteFlight);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnEditFlight);
            this.groupBox2.Controls.Add(this.btnAddFlight);
            this.groupBox2.Controls.Add(this.tbFlightTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tbFlightBaggage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbFlights);
            this.groupBox2.Controls.Add(this.tbFlightNr);
            this.groupBox2.Location = new System.Drawing.Point(13, 294);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(392, 302);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flights Info";
            // 
            // cbDropOffDest
            // 
            this.cbDropOffDest.FormattingEnabled = true;
            this.cbDropOffDest.Location = new System.Drawing.Point(112, 118);
            this.cbDropOffDest.Margin = new System.Windows.Forms.Padding(4);
            this.cbDropOffDest.Name = "cbDropOffDest";
            this.cbDropOffDest.Size = new System.Drawing.Size(273, 24);
            this.cbDropOffDest.TabIndex = 29;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 121);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(97, 17);
            this.label9.TabIndex = 24;
            this.label9.Text = "Drop-off Dest.";
            // 
            // btnDeleteFlight
            // 
            this.btnDeleteFlight.Enabled = false;
            this.btnDeleteFlight.Location = new System.Drawing.Point(313, 179);
            this.btnDeleteFlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDeleteFlight.Name = "btnDeleteFlight";
            this.btnDeleteFlight.Size = new System.Drawing.Size(72, 23);
            this.btnDeleteFlight.TabIndex = 23;
            this.btnDeleteFlight.Text = "Delete";
            this.btnDeleteFlight.UseVisualStyleBackColor = true;
            this.btnDeleteFlight.Click += new System.EventHandler(this.btnDeleteFlight_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 22;
            this.label8.Text = "Baggage";
            // 
            // btnEditFlight
            // 
            this.btnEditFlight.Enabled = false;
            this.btnEditFlight.Location = new System.Drawing.Point(224, 179);
            this.btnEditFlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnEditFlight.Name = "btnEditFlight";
            this.btnEditFlight.Size = new System.Drawing.Size(83, 23);
            this.btnEditFlight.TabIndex = 19;
            this.btnEditFlight.Text = "Edit";
            this.btnEditFlight.UseVisualStyleBackColor = true;
            this.btnEditFlight.Click += new System.EventHandler(this.btnEditFlight_Click);
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Enabled = false;
            this.btnAddFlight.Location = new System.Drawing.Point(11, 179);
            this.btnAddFlight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(90, 23);
            this.btnAddFlight.TabIndex = 18;
            this.btnAddFlight.Text = "Add";
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // tbFlightTime
            // 
            this.tbFlightTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tbFlightTime.Location = new System.Drawing.Point(75, 84);
            this.tbFlightTime.Margin = new System.Windows.Forms.Padding(4);
            this.tbFlightTime.Name = "tbFlightTime";
            this.tbFlightTime.Size = new System.Drawing.Size(132, 22);
            this.tbFlightTime.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 86);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Dep.Time";
            // 
            // tbFlightBaggage
            // 
            this.tbFlightBaggage.Location = new System.Drawing.Point(75, 54);
            this.tbFlightBaggage.Margin = new System.Windows.Forms.Padding(4);
            this.tbFlightBaggage.Name = "tbFlightBaggage";
            this.tbFlightBaggage.Size = new System.Drawing.Size(132, 22);
            this.tbFlightBaggage.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(250, 358);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 28);
            this.label3.TabIndex = 20;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(187, 15);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(100, 28);
            this.btnRun.TabIndex = 15;
            this.btnRun.Text = "▷ Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.chbDeleteMode);
            this.panel1.Controls.Add(this.buttonShowQueuedBaggage);
            this.panel1.Controls.Add(this.buttonShowProcessedBaggage);
            this.panel1.Controls.Add(this.buttonResume);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.cmBoxNodeToBuild);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.lblTest);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.chbBuildMode);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 1055);
            this.panel1.TabIndex = 16;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(301, 15);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(100, 28);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "◼ Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(187, 69);
            this.btnPause.Margin = new System.Windows.Forms.Padding(4);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(100, 28);
            this.btnPause.TabIndex = 27;
            this.btnPause.Text = "❚❚ Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // chbDeleteMode
            // 
            this.chbDeleteMode.AutoSize = true;
            this.chbDeleteMode.Location = new System.Drawing.Point(9, 50);
            this.chbDeleteMode.Margin = new System.Windows.Forms.Padding(4);
            this.chbDeleteMode.Name = "chbDeleteMode";
            this.chbDeleteMode.Size = new System.Drawing.Size(105, 21);
            this.chbDeleteMode.TabIndex = 19;
            this.chbDeleteMode.Text = "Delete Tiles";
            this.chbDeleteMode.UseVisualStyleBackColor = true;
            this.chbDeleteMode.CheckedChanged += new System.EventHandler(this.ChbDeleteMode_CheckedChanged);
            // 
            // buttonShowQueuedBaggage
            // 
            this.buttonShowQueuedBaggage.Location = new System.Drawing.Point(13, 804);
            this.buttonShowQueuedBaggage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowQueuedBaggage.Name = "buttonShowQueuedBaggage";
            this.buttonShowQueuedBaggage.Size = new System.Drawing.Size(251, 28);
            this.buttonShowQueuedBaggage.TabIndex = 24;
            this.buttonShowQueuedBaggage.Text = "Show queued baggage";
            this.buttonShowQueuedBaggage.UseVisualStyleBackColor = true;
            this.buttonShowQueuedBaggage.Click += new System.EventHandler(this.buttonShowQueuedBaggage_Click);
            // 
            // buttonShowProcessedBaggage
            // 
            this.buttonShowProcessedBaggage.Location = new System.Drawing.Point(12, 754);
            this.buttonShowProcessedBaggage.Margin = new System.Windows.Forms.Padding(4);
            this.buttonShowProcessedBaggage.Name = "buttonShowProcessedBaggage";
            this.buttonShowProcessedBaggage.Size = new System.Drawing.Size(252, 28);
            this.buttonShowProcessedBaggage.TabIndex = 20;
            this.buttonShowProcessedBaggage.Text = "Show processed baggage";
            this.buttonShowProcessedBaggage.UseVisualStyleBackColor = true;
            this.buttonShowProcessedBaggage.Click += new System.EventHandler(this.buttonShowProcessedBaggage_Click);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(301, 69);
            this.buttonResume.Margin = new System.Windows.Forms.Padding(4);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(100, 28);
            this.buttonResume.TabIndex = 23;
            this.buttonResume.Text = " ⟳ Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(13, 604);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(249, 132);
            this.listBox1.TabIndex = 16;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSimVisuals);
            this.tabControl1.Controls.Add(this.tabPageStats);
            this.tabControl1.Location = new System.Drawing.Point(409, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(2305, 1179);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 17;
            // 
            // tabPageSimVisuals
            // 
            this.tabPageSimVisuals.Controls.Add(this.animationBox);
            this.tabPageSimVisuals.Location = new System.Drawing.Point(4, 25);
            this.tabPageSimVisuals.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageSimVisuals.Name = "tabPageSimVisuals";
            this.tabPageSimVisuals.Padding = new System.Windows.Forms.Padding(4);
            this.tabPageSimVisuals.Size = new System.Drawing.Size(2297, 1150);
            this.tabPageSimVisuals.TabIndex = 1;
            this.tabPageSimVisuals.Text = "Simulation Visualisation";
            this.tabPageSimVisuals.UseVisualStyleBackColor = true;
            // 
            // tabPageStats
            // 
            this.tabPageStats.Controls.Add(this.buttonRefreshPercentageFailedBags);
            this.tabPageStats.Controls.Add(this.pieChartPercentageAllFailedBaggage);
            this.tabPageStats.Controls.Add(this.buttonFailedSecurityCheck);
            this.tabPageStats.Controls.Add(this.cartesianChartFailedToPassBaggage);
            this.tabPageStats.Controls.Add(this.buttonLoadChartBaggageThroughCheckin);
            this.tabPageStats.Controls.Add(this.cartesianChartBaggageProcessedByCheckin);
            this.tabPageStats.Location = new System.Drawing.Point(4, 25);
            this.tabPageStats.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Size = new System.Drawing.Size(2297, 1150);
            this.tabPageStats.TabIndex = 2;
            this.tabPageStats.Text = "Statistics";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // buttonFailedSecurityCheck
            // 
            this.buttonFailedSecurityCheck.Location = new System.Drawing.Point(1424, 463);
            this.buttonFailedSecurityCheck.Margin = new System.Windows.Forms.Padding(4);
            this.buttonFailedSecurityCheck.Name = "buttonFailedSecurityCheck";
            this.buttonFailedSecurityCheck.Size = new System.Drawing.Size(100, 28);
            this.buttonFailedSecurityCheck.TabIndex = 27;
            this.buttonFailedSecurityCheck.Text = "Load";
            this.buttonFailedSecurityCheck.UseVisualStyleBackColor = true;
            this.buttonFailedSecurityCheck.Click += new System.EventHandler(this.buttonFailedSecurityCheck_Click);
            // 
            // cartesianChartFailedToPassBaggage
            // 
            this.cartesianChartFailedToPassBaggage.Location = new System.Drawing.Point(785, 4);
            this.cartesianChartFailedToPassBaggage.Margin = new System.Windows.Forms.Padding(4);
            this.cartesianChartFailedToPassBaggage.Name = "cartesianChartFailedToPassBaggage";
            this.cartesianChartFailedToPassBaggage.Size = new System.Drawing.Size(763, 427);
            this.cartesianChartFailedToPassBaggage.TabIndex = 26;
            this.cartesianChartFailedToPassBaggage.Text = "FailedToPassBaggageThroughSecurity";
            // 
            // buttonLoadChartBaggageThroughCheckin
            // 
            this.buttonLoadChartBaggageThroughCheckin.Location = new System.Drawing.Point(667, 463);
            this.buttonLoadChartBaggageThroughCheckin.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoadChartBaggageThroughCheckin.Name = "buttonLoadChartBaggageThroughCheckin";
            this.buttonLoadChartBaggageThroughCheckin.Size = new System.Drawing.Size(100, 28);
            this.buttonLoadChartBaggageThroughCheckin.TabIndex = 25;
            this.buttonLoadChartBaggageThroughCheckin.Text = "Load";
            this.buttonLoadChartBaggageThroughCheckin.UseVisualStyleBackColor = true;
            this.buttonLoadChartBaggageThroughCheckin.Click += new System.EventHandler(this.buttonLoadChartBaggageThroughCheckin_Click);
            // 
            // cartesianChartBaggageProcessedByCheckin
            // 
            this.cartesianChartBaggageProcessedByCheckin.Location = new System.Drawing.Point(4, 4);
            this.cartesianChartBaggageProcessedByCheckin.Margin = new System.Windows.Forms.Padding(4);
            this.cartesianChartBaggageProcessedByCheckin.Name = "cartesianChartBaggageProcessedByCheckin";
            this.cartesianChartBaggageProcessedByCheckin.Size = new System.Drawing.Size(763, 427);
            this.cartesianChartBaggageProcessedByCheckin.TabIndex = 0;
            this.cartesianChartBaggageProcessedByCheckin.Text = "BaggageProcessedByCheckin";
            // 
            // pieChartPercentageAllFailedBaggage
            // 
            this.pieChartPercentageAllFailedBaggage.Location = new System.Drawing.Point(38, 531);
            this.pieChartPercentageAllFailedBaggage.Name = "pieChartPercentageAllFailedBaggage";
            this.pieChartPercentageAllFailedBaggage.Size = new System.Drawing.Size(434, 265);
            this.pieChartPercentageAllFailedBaggage.TabIndex = 28;
            this.pieChartPercentageAllFailedBaggage.Text = "pieChart1";
            // 
            // buttonRefreshPercentageFailedBags
            // 
            this.buttonRefreshPercentageFailedBags.Location = new System.Drawing.Point(381, 803);
            this.buttonRefreshPercentageFailedBags.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRefreshPercentageFailedBags.Name = "buttonRefreshPercentageFailedBags";
            this.buttonRefreshPercentageFailedBags.Size = new System.Drawing.Size(100, 28);
            this.buttonRefreshPercentageFailedBags.TabIndex = 29;
            this.buttonRefreshPercentageFailedBags.Text = "Refresh";
            this.buttonRefreshPercentageFailedBags.UseVisualStyleBackColor = true;
            this.buttonRefreshPercentageFailedBags.Click += new System.EventHandler(this.buttonRefreshPercentageFailedBags_Click);
            // 
            // Baggager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 1055);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Baggager";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSimVisuals.ResumeLayout(false);
            this.tabPageStats.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox animationBox;
        private System.Windows.Forms.ComboBox cmBoxNodeToBuild;
        private System.Windows.Forms.CheckBox chbBuildMode;
        private System.Windows.Forms.Label lblBagStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblColRow;
        private System.Windows.Forms.Label lblNodeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbFlights;
        private System.Windows.Forms.TextBox tbFlightNr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker tbFlightTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFlightBaggage;
        private System.Windows.Forms.Button btnEditFlight;
        private System.Windows.Forms.Button btnAddFlight;
        private System.Windows.Forms.Label lblNextNode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonShowQueuedBaggage;
        private System.Windows.Forms.Button buttonShowProcessedBaggage;
        private System.Windows.Forms.CheckBox chbDeleteMode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSimVisuals;
        private System.Windows.Forms.TabPage tabPageStats;
        private LiveCharts.WinForms.CartesianChart cartesianChartBaggageProcessedByCheckin;
        private System.Windows.Forms.Button buttonLoadChartBaggageThroughCheckin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDeleteFlight;
        private LiveCharts.WinForms.CartesianChart cartesianChartFailedToPassBaggage;
        private System.Windows.Forms.Button buttonFailedSecurityCheck;
        private System.Windows.Forms.Button buttonRefreshPercentageFailedBags;
        private LiveCharts.WinForms.PieChart pieChartPercentageAllFailedBaggage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ComboBox cbDropOffDest;
        private System.Windows.Forms.Label label9;
    }
}

