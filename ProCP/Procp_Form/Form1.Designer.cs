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
            this.lblFlightNr = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbDropOffDest = new System.Windows.Forms.ComboBox();
            this.lblDropOff = new System.Windows.Forms.Label();
            this.btnDeleteFlight = new System.Windows.Forms.Button();
            this.lblBaggage = new System.Windows.Forms.Label();
            this.btnEditFlight = new System.Windows.Forms.Button();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.tbFlightTime = new System.Windows.Forms.DateTimePicker();
            this.lblDepTime = new System.Windows.Forms.Label();
            this.tbFlightBaggage = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.chbDeleteMode = new System.Windows.Forms.CheckBox();
            this.buttonResume = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSimVisuals = new System.Windows.Forms.TabPage();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.buttonRefreshPercentageFailedBags = new System.Windows.Forms.Button();
            this.pieChartPercentageAllFailedBaggage = new LiveCharts.WinForms.PieChart();
            this.buttonFailedSecurityCheck = new System.Windows.Forms.Button();
            this.cartesianChartFailedToPassBaggage = new LiveCharts.WinForms.CartesianChart();
            this.buttonLoadChartBaggageThroughCheckin = new System.Windows.Forms.Button();
            this.cartesianChartBaggageProcessedByCheckin = new LiveCharts.WinForms.CartesianChart();
            this.cbCheckInFlight = new System.Windows.Forms.ComboBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
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
            this.animationBox.Location = new System.Drawing.Point(3, 3);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(1715, 926);
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
            this.cmBoxNodeToBuild.Location = new System.Drawing.Point(7, 64);
            this.cmBoxNodeToBuild.Name = "cmBoxNodeToBuild";
            this.cmBoxNodeToBuild.Size = new System.Drawing.Size(117, 21);
            this.cmBoxNodeToBuild.TabIndex = 2;
            this.cmBoxNodeToBuild.SelectedIndexChanged += new System.EventHandler(this.CmBoxNodeToBuild_SelectedIndexChanged);
            // 
            // chbBuildMode
            // 
            this.chbBuildMode.AutoSize = true;
            this.chbBuildMode.Location = new System.Drawing.Point(7, 14);
            this.chbBuildMode.Name = "chbBuildMode";
            this.chbBuildMode.Size = new System.Drawing.Size(79, 17);
            this.chbBuildMode.TabIndex = 4;
            this.chbBuildMode.Text = "Build Mode";
            this.chbBuildMode.UseVisualStyleBackColor = true;
            this.chbBuildMode.CheckedChanged += new System.EventHandler(this.ChbBuildMode_CheckedChanged);
            // 
            // lblBagStatus
            // 
            this.lblBagStatus.AutoSize = true;
            this.lblBagStatus.Location = new System.Drawing.Point(94, 66);
            this.lblBagStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBagStatus.Name = "lblBagStatus";
            this.lblBagStatus.Size = new System.Drawing.Size(35, 13);
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
            this.groupBox1.Location = new System.Drawing.Point(10, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(142, 118);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Info:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Type:";
            // 
            // lblNextNode
            // 
            this.lblNextNode.AutoSize = true;
            this.lblNextNode.Location = new System.Drawing.Point(64, 87);
            this.lblNextNode.Name = "lblNextNode";
            this.lblNextNode.Size = new System.Drawing.Size(35, 13);
            this.lblNextNode.TabIndex = 10;
            this.lblNextNode.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Next Node:";
            // 
            // lblNodeType
            // 
            this.lblNodeType.AutoSize = true;
            this.lblNodeType.Location = new System.Drawing.Point(44, 24);
            this.lblNodeType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNodeType.Name = "lblNodeType";
            this.lblNodeType.Size = new System.Drawing.Size(35, 13);
            this.lblNodeType.TabIndex = 8;
            this.lblNodeType.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baggage status:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Column and Row:";
            // 
            // lblColRow
            // 
            this.lblColRow.AutoSize = true;
            this.lblColRow.Location = new System.Drawing.Point(100, 46);
            this.lblColRow.Name = "lblColRow";
            this.lblColRow.Size = new System.Drawing.Size(35, 13);
            this.lblColRow.TabIndex = 9;
            this.lblColRow.Text = "label2";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(82, 15);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(27, 13);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "[Off]";
            // 
            // lbFlights
            // 
            this.lbFlights.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFlights.FormattingEnabled = true;
            this.lbFlights.ItemHeight = 18;
            this.lbFlights.Location = new System.Drawing.Point(6, 198);
            this.lbFlights.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lbFlights.Name = "lbFlights";
            this.lbFlights.Size = new System.Drawing.Size(282, 76);
            this.lbFlights.TabIndex = 10;
            // 
            // tbFlightNr
            // 
            this.tbFlightNr.Location = new System.Drawing.Point(56, 21);
            this.tbFlightNr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbFlightNr.Name = "tbFlightNr";
            this.tbFlightNr.Size = new System.Drawing.Size(100, 20);
            this.tbFlightNr.TabIndex = 12;
            // 
            // lblFlightNr
            // 
            this.lblFlightNr.AutoSize = true;
            this.lblFlightNr.Location = new System.Drawing.Point(5, 24);
            this.lblFlightNr.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFlightNr.Name = "lblFlightNr";
            this.lblFlightNr.Size = new System.Drawing.Size(46, 13);
            this.lblFlightNr.TabIndex = 13;
            this.lblFlightNr.Text = "FlightNr.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbCheckInFlight);
            this.groupBox2.Controls.Add(this.lblCheckIn);
            this.groupBox2.Controls.Add(this.cbDropOffDest);
            this.groupBox2.Controls.Add(this.lblDropOff);
            this.groupBox2.Controls.Add(this.btnDeleteFlight);
            this.groupBox2.Controls.Add(this.lblBaggage);
            this.groupBox2.Controls.Add(this.btnEditFlight);
            this.groupBox2.Controls.Add(this.btnAddFlight);
            this.groupBox2.Controls.Add(this.tbFlightTime);
            this.groupBox2.Controls.Add(this.lblDepTime);
            this.groupBox2.Controls.Add(this.tbFlightBaggage);
            this.groupBox2.Controls.Add(this.lblFlightNr);
            this.groupBox2.Controls.Add(this.lbFlights);
            this.groupBox2.Controls.Add(this.tbFlightNr);
            this.groupBox2.Location = new System.Drawing.Point(10, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(294, 278);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flights Info";
            // 
            // cbDropOffDest
            // 
            this.cbDropOffDest.FormattingEnabled = true;
            this.cbDropOffDest.Location = new System.Drawing.Point(85, 121);
            this.cbDropOffDest.Name = "cbDropOffDest";
            this.cbDropOffDest.Size = new System.Drawing.Size(206, 21);
            this.cbDropOffDest.TabIndex = 29;
            // 
            // lblDropOff
            // 
            this.lblDropOff.AutoSize = true;
            this.lblDropOff.Location = new System.Drawing.Point(6, 123);
            this.lblDropOff.Name = "lblDropOff";
            this.lblDropOff.Size = new System.Drawing.Size(73, 13);
            this.lblDropOff.TabIndex = 24;
            this.lblDropOff.Text = "Drop-off Dest.";
            // 
            // btnDeleteFlight
            // 
            this.btnDeleteFlight.Enabled = false;
            this.btnDeleteFlight.Location = new System.Drawing.Point(234, 175);
            this.btnDeleteFlight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDeleteFlight.Name = "btnDeleteFlight";
            this.btnDeleteFlight.Size = new System.Drawing.Size(54, 19);
            this.btnDeleteFlight.TabIndex = 23;
            this.btnDeleteFlight.Text = "Delete";
            this.btnDeleteFlight.UseVisualStyleBackColor = true;
            this.btnDeleteFlight.Click += new System.EventHandler(this.btnDeleteFlight_Click);
            // 
            // lblBaggage
            // 
            this.lblBaggage.AutoSize = true;
            this.lblBaggage.Location = new System.Drawing.Point(5, 46);
            this.lblBaggage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBaggage.Name = "lblBaggage";
            this.lblBaggage.Size = new System.Drawing.Size(50, 13);
            this.lblBaggage.TabIndex = 22;
            this.lblBaggage.Text = "Baggage";
            // 
            // btnEditFlight
            // 
            this.btnEditFlight.Enabled = false;
            this.btnEditFlight.Location = new System.Drawing.Point(168, 175);
            this.btnEditFlight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditFlight.Name = "btnEditFlight";
            this.btnEditFlight.Size = new System.Drawing.Size(62, 19);
            this.btnEditFlight.TabIndex = 19;
            this.btnEditFlight.Text = "Edit";
            this.btnEditFlight.UseVisualStyleBackColor = true;
            this.btnEditFlight.Click += new System.EventHandler(this.btnEditFlight_Click);
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Enabled = false;
            this.btnAddFlight.Location = new System.Drawing.Point(8, 175);
            this.btnAddFlight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(68, 19);
            this.btnAddFlight.TabIndex = 18;
            this.btnAddFlight.Text = "Add";
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // tbFlightTime
            // 
            this.tbFlightTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tbFlightTime.Location = new System.Drawing.Point(56, 68);
            this.tbFlightTime.Name = "tbFlightTime";
            this.tbFlightTime.Size = new System.Drawing.Size(100, 20);
            this.tbFlightTime.TabIndex = 17;
            // 
            // lblDepTime
            // 
            this.lblDepTime.AutoSize = true;
            this.lblDepTime.Location = new System.Drawing.Point(3, 70);
            this.lblDepTime.Name = "lblDepTime";
            this.lblDepTime.Size = new System.Drawing.Size(53, 13);
            this.lblDepTime.TabIndex = 16;
            this.lblDepTime.Text = "Dep.Time";
            // 
            // tbFlightBaggage
            // 
            this.tbFlightBaggage.Location = new System.Drawing.Point(56, 44);
            this.tbFlightBaggage.Name = "tbFlightBaggage";
            this.tbFlightBaggage.Size = new System.Drawing.Size(100, 20);
            this.tbFlightBaggage.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(188, 291);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 20;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(140, 12);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
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
            this.panel1.Controls.Add(this.buttonResume);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.cmBoxNodeToBuild);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.lblTest);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.chbBuildMode);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(308, 725);
            this.panel1.TabIndex = 16;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(226, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 28;
            this.btnStop.Text = "◼ Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(140, 56);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 27;
            this.btnPause.Text = "❚❚ Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // chbDeleteMode
            // 
            this.chbDeleteMode.AutoSize = true;
            this.chbDeleteMode.Location = new System.Drawing.Point(7, 41);
            this.chbDeleteMode.Name = "chbDeleteMode";
            this.chbDeleteMode.Size = new System.Drawing.Size(82, 17);
            this.chbDeleteMode.TabIndex = 19;
            this.chbDeleteMode.Text = "Delete Tiles";
            this.chbDeleteMode.UseVisualStyleBackColor = true;
            this.chbDeleteMode.CheckedChanged += new System.EventHandler(this.ChbDeleteMode_CheckedChanged);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(226, 56);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(75, 23);
            this.buttonResume.TabIndex = 23;
            this.buttonResume.Text = " ⟳ Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.buttonResume_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSimVisuals);
            this.tabControl1.Controls.Add(this.tabPageStats);
            this.tabControl1.Location = new System.Drawing.Point(307, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1729, 958);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 17;
            // 
            // tabPageSimVisuals
            // 
            this.tabPageSimVisuals.Controls.Add(this.animationBox);
            this.tabPageSimVisuals.Location = new System.Drawing.Point(4, 22);
            this.tabPageSimVisuals.Name = "tabPageSimVisuals";
            this.tabPageSimVisuals.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.tabPageSimVisuals.Size = new System.Drawing.Size(1721, 932);
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
            this.tabPageStats.Location = new System.Drawing.Point(4, 22);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Size = new System.Drawing.Size(1721, 932);
            this.tabPageStats.TabIndex = 2;
            this.tabPageStats.Text = "Statistics";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // buttonRefreshPercentageFailedBags
            // 
            this.buttonRefreshPercentageFailedBags.Location = new System.Drawing.Point(286, 652);
            this.buttonRefreshPercentageFailedBags.Name = "buttonRefreshPercentageFailedBags";
            this.buttonRefreshPercentageFailedBags.Size = new System.Drawing.Size(75, 23);
            this.buttonRefreshPercentageFailedBags.TabIndex = 29;
            this.buttonRefreshPercentageFailedBags.Text = "Refresh";
            this.buttonRefreshPercentageFailedBags.UseVisualStyleBackColor = true;
            this.buttonRefreshPercentageFailedBags.Click += new System.EventHandler(this.buttonRefreshPercentageFailedBags_Click);
            // 
            // pieChartPercentageAllFailedBaggage
            // 
            this.pieChartPercentageAllFailedBaggage.Location = new System.Drawing.Point(28, 431);
            this.pieChartPercentageAllFailedBaggage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pieChartPercentageAllFailedBaggage.Name = "pieChartPercentageAllFailedBaggage";
            this.pieChartPercentageAllFailedBaggage.Size = new System.Drawing.Size(326, 215);
            this.pieChartPercentageAllFailedBaggage.TabIndex = 28;
            this.pieChartPercentageAllFailedBaggage.Text = "pieChart1";
            // 
            // buttonFailedSecurityCheck
            // 
            this.buttonFailedSecurityCheck.Location = new System.Drawing.Point(1068, 376);
            this.buttonFailedSecurityCheck.Name = "buttonFailedSecurityCheck";
            this.buttonFailedSecurityCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonFailedSecurityCheck.TabIndex = 27;
            this.buttonFailedSecurityCheck.Text = "Load";
            this.buttonFailedSecurityCheck.UseVisualStyleBackColor = true;
            this.buttonFailedSecurityCheck.Click += new System.EventHandler(this.buttonFailedSecurityCheck_Click);
            // 
            // cartesianChartFailedToPassBaggage
            // 
            this.cartesianChartFailedToPassBaggage.Location = new System.Drawing.Point(589, 3);
            this.cartesianChartFailedToPassBaggage.Name = "cartesianChartFailedToPassBaggage";
            this.cartesianChartFailedToPassBaggage.Size = new System.Drawing.Size(572, 347);
            this.cartesianChartFailedToPassBaggage.TabIndex = 26;
            this.cartesianChartFailedToPassBaggage.Text = "FailedToPassBaggageThroughSecurity";
            // 
            // buttonLoadChartBaggageThroughCheckin
            // 
            this.buttonLoadChartBaggageThroughCheckin.Location = new System.Drawing.Point(500, 376);
            this.buttonLoadChartBaggageThroughCheckin.Name = "buttonLoadChartBaggageThroughCheckin";
            this.buttonLoadChartBaggageThroughCheckin.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadChartBaggageThroughCheckin.TabIndex = 25;
            this.buttonLoadChartBaggageThroughCheckin.Text = "Load";
            this.buttonLoadChartBaggageThroughCheckin.UseVisualStyleBackColor = true;
            this.buttonLoadChartBaggageThroughCheckin.Click += new System.EventHandler(this.buttonLoadChartBaggageThroughCheckin_Click);
            // 
            // cartesianChartBaggageProcessedByCheckin
            // 
            this.cartesianChartBaggageProcessedByCheckin.Location = new System.Drawing.Point(3, 3);
            this.cartesianChartBaggageProcessedByCheckin.Name = "cartesianChartBaggageProcessedByCheckin";
            this.cartesianChartBaggageProcessedByCheckin.Size = new System.Drawing.Size(572, 347);
            this.cartesianChartBaggageProcessedByCheckin.TabIndex = 0;
            this.cartesianChartBaggageProcessedByCheckin.Text = "BaggageProcessedByCheckin";
            // 
            // cbCheckInFlight
            // 
            this.cbCheckInFlight.FormattingEnabled = true;
            this.cbCheckInFlight.Location = new System.Drawing.Point(85, 94);
            this.cbCheckInFlight.Name = "cbCheckInFlight";
            this.cbCheckInFlight.Size = new System.Drawing.Size(206, 21);
            this.cbCheckInFlight.TabIndex = 31;
            // 
            // lblCheckIn
            // 
            this.lblCheckIn.AutoSize = true;
            this.lblCheckIn.Location = new System.Drawing.Point(6, 96);
            this.lblCheckIn.Name = "lblCheckIn";
            this.lblCheckIn.Size = new System.Drawing.Size(49, 13);
            this.lblCheckIn.TabIndex = 30;
            this.lblCheckIn.Text = "Check-in";
            // 
            // Baggager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1370, 725);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
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
        private System.Windows.Forms.Label lblFlightNr;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker tbFlightTime;
        private System.Windows.Forms.Label lblDepTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFlightBaggage;
        private System.Windows.Forms.Button btnEditFlight;
        private System.Windows.Forms.Button btnAddFlight;
        private System.Windows.Forms.Label lblNextNode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.CheckBox chbDeleteMode;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSimVisuals;
        private System.Windows.Forms.TabPage tabPageStats;
        private LiveCharts.WinForms.CartesianChart cartesianChartBaggageProcessedByCheckin;
        private System.Windows.Forms.Button buttonLoadChartBaggageThroughCheckin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblBaggage;
        private System.Windows.Forms.Button btnDeleteFlight;
        private LiveCharts.WinForms.CartesianChart cartesianChartFailedToPassBaggage;
        private System.Windows.Forms.Button buttonFailedSecurityCheck;
        private System.Windows.Forms.Button buttonRefreshPercentageFailedBags;
        private LiveCharts.WinForms.PieChart pieChartPercentageAllFailedBaggage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ComboBox cbDropOffDest;
        private System.Windows.Forms.Label lblDropOff;
        private System.Windows.Forms.ComboBox cbCheckInFlight;
        private System.Windows.Forms.Label lblCheckIn;
    }
}

