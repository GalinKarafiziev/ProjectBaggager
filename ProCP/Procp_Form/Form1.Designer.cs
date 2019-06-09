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
            this.chbBuildMode = new System.Windows.Forms.CheckBox();
            this.lblBagStatus = new System.Windows.Forms.Label();
            this.gbNodeInfo = new System.Windows.Forms.GroupBox();
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
            this.gbFlightsInfo = new System.Windows.Forms.GroupBox();
            this.cbCheckInFlight = new System.Windows.Forms.ComboBox();
            this.lblCheckIn = new System.Windows.Forms.Label();
            this.cbDropOffDest = new System.Windows.Forms.ComboBox();
            this.lblDropOff = new System.Windows.Forms.Label();
            this.btnDeleteFlight = new System.Windows.Forms.Button();
            this.lblBaggage = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.tbFlightTime = new System.Windows.Forms.DateTimePicker();
            this.lblDepTime = new System.Windows.Forms.Label();
            this.tbFlightBaggage = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbDropOffSettings = new System.Windows.Forms.GroupBox();
            this.cbEmployees = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbCapacity = new System.Windows.Forms.ComboBox();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.gbConveyorSpeed = new System.Windows.Forms.GroupBox();
            this.rbConvSpeed4 = new System.Windows.Forms.RadioButton();
            this.rbConvSpeed3 = new System.Windows.Forms.RadioButton();
            this.rbConvSpeed2 = new System.Windows.Forms.RadioButton();
            this.rbConvSpeed1 = new System.Windows.Forms.RadioButton();
            this.buttonSaveToFile = new System.Windows.Forms.Button();
            this.btnClearGrid = new System.Windows.Forms.Button();
            this.gbBuildType = new System.Windows.Forms.GroupBox();
            this.rbDropOff = new System.Windows.Forms.RadioButton();
            this.rbMPA = new System.Windows.Forms.RadioButton();
            this.rbSecurity = new System.Windows.Forms.RadioButton();
            this.rbConveyor = new System.Windows.Forms.RadioButton();
            this.rbCheckIn = new System.Windows.Forms.RadioButton();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnPause = new System.Windows.Forms.Button();
            this.chbDeleteMode = new System.Windows.Forms.CheckBox();
            this.buttonResume = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSimVisuals = new System.Windows.Forms.TabPage();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.buttonTransTimePerFlight = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.cartesianChartCompareTimes = new System.Windows.Forms.Integration.ElementHost();
            this.cartesianChartTimes = new LiveCharts.Wpf.CartesianChart();
            this.btnCompare = new System.Windows.Forms.Button();
            this.pieChartPercentageAllFailedBaggage = new LiveCharts.WinForms.PieChart();
            this.cartesianChartFailedToPassBaggage = new LiveCharts.WinForms.CartesianChart();
            this.cartesianChartBaggageProcessedByCheckin = new LiveCharts.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).BeginInit();
            this.gbNodeInfo.SuspendLayout();
            this.gbFlightsInfo.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbDropOffSettings.SuspendLayout();
            this.gbConveyorSpeed.SuspendLayout();
            this.gbBuildType.SuspendLayout();
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
            this.animationBox.Size = new System.Drawing.Size(1403, 899);
            this.animationBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.animationBox.TabIndex = 0;
            this.animationBox.TabStop = false;
            this.animationBox.Paint += new System.Windows.Forms.PaintEventHandler(this.AnimationBox_Paint);
            this.animationBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AnimationBox_MouseDown);
            this.animationBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AnimationBox_MouseMove);
            this.animationBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.AnimationBox_MouseUp);
            // 
            // chbBuildMode
            // 
            this.chbBuildMode.AutoSize = true;
            this.chbBuildMode.Location = new System.Drawing.Point(9, 17);
            this.chbBuildMode.Margin = new System.Windows.Forms.Padding(4);
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
            this.lblBagStatus.Size = new System.Drawing.Size(10, 13);
            this.lblBagStatus.TabIndex = 6;
            this.lblBagStatus.Text = "-";
            // 
            // gbNodeInfo
            // 
            this.gbNodeInfo.Controls.Add(this.label7);
            this.gbNodeInfo.Controls.Add(this.lblNextNode);
            this.gbNodeInfo.Controls.Add(this.label6);
            this.gbNodeInfo.Controls.Add(this.lblNodeType);
            this.gbNodeInfo.Controls.Add(this.label2);
            this.gbNodeInfo.Controls.Add(this.lblBagStatus);
            this.gbNodeInfo.Controls.Add(this.label1);
            this.gbNodeInfo.Controls.Add(this.lblColRow);
            this.gbNodeInfo.Location = new System.Drawing.Point(156, 85);
            this.gbNodeInfo.Name = "gbNodeInfo";
            this.gbNodeInfo.Size = new System.Drawing.Size(142, 136);
            this.gbNodeInfo.TabIndex = 7;
            this.gbNodeInfo.TabStop = false;
            this.gbNodeInfo.Text = "Node Info:";
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
            this.lblNextNode.Size = new System.Drawing.Size(10, 13);
            this.lblNextNode.TabIndex = 10;
            this.lblNextNode.Text = "-";
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
            this.lblNodeType.Size = new System.Drawing.Size(10, 13);
            this.lblNodeType.TabIndex = 8;
            this.lblNodeType.Text = "-";
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
            this.lblColRow.Size = new System.Drawing.Size(10, 13);
            this.lblColRow.TabIndex = 9;
            this.lblColRow.Text = "-";
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
            this.lbFlights.Margin = new System.Windows.Forms.Padding(2);
            this.lbFlights.Name = "lbFlights";
            this.lbFlights.Size = new System.Drawing.Size(282, 76);
            this.lbFlights.TabIndex = 10;
            // 
            // tbFlightNr
            // 
            this.tbFlightNr.Location = new System.Drawing.Point(56, 21);
            this.tbFlightNr.Margin = new System.Windows.Forms.Padding(2);
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
            // gbFlightsInfo
            // 
            this.gbFlightsInfo.Controls.Add(this.cbCheckInFlight);
            this.gbFlightsInfo.Controls.Add(this.lblCheckIn);
            this.gbFlightsInfo.Controls.Add(this.cbDropOffDest);
            this.gbFlightsInfo.Controls.Add(this.lblDropOff);
            this.gbFlightsInfo.Controls.Add(this.btnDeleteFlight);
            this.gbFlightsInfo.Controls.Add(this.lblBaggage);
            this.gbFlightsInfo.Controls.Add(this.label3);
            this.gbFlightsInfo.Controls.Add(this.btnAddFlight);
            this.gbFlightsInfo.Controls.Add(this.tbFlightTime);
            this.gbFlightsInfo.Controls.Add(this.lblDepTime);
            this.gbFlightsInfo.Controls.Add(this.tbFlightBaggage);
            this.gbFlightsInfo.Controls.Add(this.lblFlightNr);
            this.gbFlightsInfo.Controls.Add(this.lbFlights);
            this.gbFlightsInfo.Controls.Add(this.tbFlightNr);
            this.gbFlightsInfo.Location = new System.Drawing.Point(5, 354);
            this.gbFlightsInfo.Margin = new System.Windows.Forms.Padding(4);
            this.gbFlightsInfo.Name = "gbFlightsInfo";
            this.gbFlightsInfo.Padding = new System.Windows.Forms.Padding(2);
            this.gbFlightsInfo.Size = new System.Drawing.Size(294, 278);
            this.gbFlightsInfo.TabIndex = 14;
            this.gbFlightsInfo.TabStop = false;
            this.gbFlightsInfo.Text = "Flights Info";
            // 
            // cbCheckInFlight
            // 
            this.cbCheckInFlight.FormattingEnabled = true;
            this.cbCheckInFlight.Location = new System.Drawing.Point(113, 116);
            this.cbCheckInFlight.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnDeleteFlight.Margin = new System.Windows.Forms.Padding(2);
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
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(175, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 20;
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Enabled = false;
            this.btnAddFlight.Location = new System.Drawing.Point(8, 175);
            this.btnAddFlight.Margin = new System.Windows.Forms.Padding(2);
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
            this.tbFlightTime.Location = new System.Drawing.Point(75, 84);
            this.tbFlightTime.Margin = new System.Windows.Forms.Padding(4);
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
            this.tbFlightBaggage.Location = new System.Drawing.Point(75, 54);
            this.tbFlightBaggage.Margin = new System.Windows.Forms.Padding(4);
            this.tbFlightBaggage.Name = "tbFlightBaggage";
            this.tbFlightBaggage.Size = new System.Drawing.Size(100, 20);
            this.tbFlightBaggage.TabIndex = 21;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(187, 15);
            this.btnRun.Margin = new System.Windows.Forms.Padding(4);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 15;
            this.btnRun.Text = "▷ Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.gbDropOffSettings);
            this.panel1.Controls.Add(this.buttonLoad);
            this.panel1.Controls.Add(this.gbConveyorSpeed);
            this.panel1.Controls.Add(this.buttonSaveToFile);
            this.panel1.Controls.Add(this.btnClearGrid);
            this.panel1.Controls.Add(this.gbBuildType);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnPause);
            this.panel1.Controls.Add(this.chbDeleteMode);
            this.panel1.Controls.Add(this.buttonResume);
            this.panel1.Controls.Add(this.btnRun);
            this.panel1.Controls.Add(this.lblTest);
            this.panel1.Controls.Add(this.gbFlightsInfo);
            this.panel1.Controls.Add(this.chbBuildMode);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(405, 753);
            this.panel1.TabIndex = 16;
            // 
            // gbDropOffSettings
            // 
            this.gbDropOffSettings.Controls.Add(this.cbEmployees);
            this.gbDropOffSettings.Controls.Add(this.label5);
            this.gbDropOffSettings.Controls.Add(this.label4);
            this.gbDropOffSettings.Controls.Add(this.cbCapacity);
            this.gbDropOffSettings.Location = new System.Drawing.Point(165, 227);
            this.gbDropOffSettings.Name = "gbDropOffSettings";
            this.gbDropOffSettings.Size = new System.Drawing.Size(136, 77);
            this.gbDropOffSettings.TabIndex = 34;
            this.gbDropOffSettings.TabStop = false;
            this.gbDropOffSettings.Text = "DropOff Settings";
            this.gbDropOffSettings.UseWaitCursor = true;
            this.gbDropOffSettings.Visible = false;
            // 
            // cbEmployees
            // 
            this.cbEmployees.FormattingEnabled = true;
            this.cbEmployees.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.cbEmployees.Location = new System.Drawing.Point(76, 46);
            this.cbEmployees.Name = "cbEmployees";
            this.cbEmployees.Size = new System.Drawing.Size(51, 21);
            this.cbEmployees.TabIndex = 3;
            this.cbEmployees.UseWaitCursor = true;
            this.cbEmployees.SelectedIndexChanged += new System.EventHandler(this.cbEmployees_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Employees";
            this.label5.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Capacity";
            this.label4.UseWaitCursor = true;
            // 
            // cbCapacity
            // 
            this.cbCapacity.FormattingEnabled = true;
            this.cbCapacity.Items.AddRange(new object[] {
            "10",
            "20",
            "30"});
            this.cbCapacity.Location = new System.Drawing.Point(76, 19);
            this.cbCapacity.Name = "cbCapacity";
            this.cbCapacity.Size = new System.Drawing.Size(51, 21);
            this.cbCapacity.TabIndex = 0;
            this.cbCapacity.Text = "10";
            this.cbCapacity.UseWaitCursor = true;
            this.cbCapacity.SelectedIndexChanged += new System.EventHandler(this.cbCapacity_SelectedIndexChanged);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(291, 719);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 0;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // gbConveyorSpeed
            // 
            this.gbConveyorSpeed.Controls.Add(this.rbConvSpeed4);
            this.gbConveyorSpeed.Controls.Add(this.rbConvSpeed3);
            this.gbConveyorSpeed.Controls.Add(this.rbConvSpeed2);
            this.gbConveyorSpeed.Controls.Add(this.rbConvSpeed1);
            this.gbConveyorSpeed.Location = new System.Drawing.Point(9, 279);
            this.gbConveyorSpeed.Margin = new System.Windows.Forms.Padding(4);
            this.gbConveyorSpeed.Name = "gbConveyorSpeed";
            this.gbConveyorSpeed.Padding = new System.Windows.Forms.Padding(4);
            this.gbConveyorSpeed.Size = new System.Drawing.Size(204, 68);
            this.gbConveyorSpeed.TabIndex = 33;
            this.gbConveyorSpeed.TabStop = false;
            this.gbConveyorSpeed.Text = "Conveyor Speed";
            // 
            // rbConvSpeed4
            // 
            this.rbConvSpeed4.AutoSize = true;
            this.rbConvSpeed4.Location = new System.Drawing.Point(144, 24);
            this.rbConvSpeed4.Margin = new System.Windows.Forms.Padding(4);
            this.rbConvSpeed4.Name = "rbConvSpeed4";
            this.rbConvSpeed4.Size = new System.Drawing.Size(31, 17);
            this.rbConvSpeed4.TabIndex = 3;
            this.rbConvSpeed4.TabStop = true;
            this.rbConvSpeed4.Text = "4";
            this.rbConvSpeed4.UseVisualStyleBackColor = true;
            this.rbConvSpeed4.CheckedChanged += new System.EventHandler(this.ConveyorSpeed_CheckedChanged);
            // 
            // rbConvSpeed3
            // 
            this.rbConvSpeed3.AutoSize = true;
            this.rbConvSpeed3.Location = new System.Drawing.Point(101, 24);
            this.rbConvSpeed3.Margin = new System.Windows.Forms.Padding(4);
            this.rbConvSpeed3.Name = "rbConvSpeed3";
            this.rbConvSpeed3.Size = new System.Drawing.Size(31, 17);
            this.rbConvSpeed3.TabIndex = 2;
            this.rbConvSpeed3.TabStop = true;
            this.rbConvSpeed3.Text = "3";
            this.rbConvSpeed3.UseVisualStyleBackColor = true;
            this.rbConvSpeed3.CheckedChanged += new System.EventHandler(this.ConveyorSpeed_CheckedChanged);
            // 
            // rbConvSpeed2
            // 
            this.rbConvSpeed2.AutoSize = true;
            this.rbConvSpeed2.Location = new System.Drawing.Point(54, 24);
            this.rbConvSpeed2.Margin = new System.Windows.Forms.Padding(4);
            this.rbConvSpeed2.Name = "rbConvSpeed2";
            this.rbConvSpeed2.Size = new System.Drawing.Size(31, 17);
            this.rbConvSpeed2.TabIndex = 1;
            this.rbConvSpeed2.TabStop = true;
            this.rbConvSpeed2.Text = "2";
            this.rbConvSpeed2.UseVisualStyleBackColor = true;
            this.rbConvSpeed2.CheckedChanged += new System.EventHandler(this.ConveyorSpeed_CheckedChanged);
            // 
            // rbConvSpeed1
            // 
            this.rbConvSpeed1.AutoSize = true;
            this.rbConvSpeed1.Location = new System.Drawing.Point(11, 24);
            this.rbConvSpeed1.Margin = new System.Windows.Forms.Padding(4);
            this.rbConvSpeed1.Name = "rbConvSpeed1";
            this.rbConvSpeed1.Size = new System.Drawing.Size(31, 17);
            this.rbConvSpeed1.TabIndex = 0;
            this.rbConvSpeed1.TabStop = true;
            this.rbConvSpeed1.Text = "1";
            this.rbConvSpeed1.UseVisualStyleBackColor = true;
            this.rbConvSpeed1.CheckedChanged += new System.EventHandler(this.ConveyorSpeed_CheckedChanged);
            // 
            // buttonSaveToFile
            // 
            this.buttonSaveToFile.Location = new System.Drawing.Point(12, 719);
            this.buttonSaveToFile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSaveToFile.Name = "buttonSaveToFile";
            this.buttonSaveToFile.Size = new System.Drawing.Size(70, 24);
            this.buttonSaveToFile.TabIndex = 30;
            this.buttonSaveToFile.Text = "Save";
            this.buttonSaveToFile.UseVisualStyleBackColor = true;
            this.buttonSaveToFile.Click += new System.EventHandler(this.buttonSaveToFile_Click);
            // 
            // btnClearGrid
            // 
            this.btnClearGrid.Location = new System.Drawing.Point(77, 205);
            this.btnClearGrid.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearGrid.Name = "btnClearGrid";
            this.btnClearGrid.Size = new System.Drawing.Size(66, 19);
            this.btnClearGrid.TabIndex = 32;
            this.btnClearGrid.Text = "Clear Grid";
            this.btnClearGrid.UseVisualStyleBackColor = true;
            this.btnClearGrid.Click += new System.EventHandler(this.btnClearGrid_Click);
            // 
            // gbBuildType
            // 
            this.gbBuildType.Controls.Add(this.rbDropOff);
            this.gbBuildType.Controls.Add(this.rbMPA);
            this.gbBuildType.Controls.Add(this.rbSecurity);
            this.gbBuildType.Controls.Add(this.rbConveyor);
            this.gbBuildType.Controls.Add(this.rbCheckIn);
            this.gbBuildType.Location = new System.Drawing.Point(9, 105);
            this.gbBuildType.Margin = new System.Windows.Forms.Padding(4);
            this.gbBuildType.Name = "gbBuildType";
            this.gbBuildType.Padding = new System.Windows.Forms.Padding(4);
            this.gbBuildType.Size = new System.Drawing.Size(185, 167);
            this.gbBuildType.TabIndex = 29;
            this.gbBuildType.TabStop = false;
            this.gbBuildType.Text = "Build Type";
            this.gbBuildType.Visible = false;
            // 
            // rbDropOff
            // 
            this.rbDropOff.AutoSize = true;
            this.rbDropOff.Location = new System.Drawing.Point(8, 139);
            this.rbDropOff.Margin = new System.Windows.Forms.Padding(4);
            this.rbDropOff.Name = "rbDropOff";
            this.rbDropOff.Size = new System.Drawing.Size(65, 17);
            this.rbDropOff.TabIndex = 4;
            this.rbDropOff.TabStop = true;
            this.rbDropOff.Text = "Drop Off";
            this.rbDropOff.UseVisualStyleBackColor = true;
            this.rbDropOff.CheckedChanged += new System.EventHandler(this.BuildType_CheckedChanged);
            // 
            // rbMPA
            // 
            this.rbMPA.AutoSize = true;
            this.rbMPA.Location = new System.Drawing.Point(9, 111);
            this.rbMPA.Margin = new System.Windows.Forms.Padding(4);
            this.rbMPA.Name = "rbMPA";
            this.rbMPA.Size = new System.Drawing.Size(114, 17);
            this.rbMPA.TabIndex = 3;
            this.rbMPA.TabStop = true;
            this.rbMPA.Text = "Main Process Area";
            this.rbMPA.UseVisualStyleBackColor = true;
            this.rbMPA.CheckedChanged += new System.EventHandler(this.BuildType_CheckedChanged);
            // 
            // rbSecurity
            // 
            this.rbSecurity.AutoSize = true;
            this.rbSecurity.Location = new System.Drawing.Point(9, 82);
            this.rbSecurity.Margin = new System.Windows.Forms.Padding(4);
            this.rbSecurity.Name = "rbSecurity";
            this.rbSecurity.Size = new System.Drawing.Size(93, 17);
            this.rbSecurity.TabIndex = 2;
            this.rbSecurity.TabStop = true;
            this.rbSecurity.Text = "Security Block";
            this.rbSecurity.UseVisualStyleBackColor = true;
            this.rbSecurity.CheckedChanged += new System.EventHandler(this.BuildType_CheckedChanged);
            // 
            // rbConveyor
            // 
            this.rbConveyor.AutoSize = true;
            this.rbConveyor.Location = new System.Drawing.Point(9, 54);
            this.rbConveyor.Margin = new System.Windows.Forms.Padding(4);
            this.rbConveyor.Name = "rbConveyor";
            this.rbConveyor.Size = new System.Drawing.Size(70, 17);
            this.rbConveyor.TabIndex = 1;
            this.rbConveyor.TabStop = true;
            this.rbConveyor.Text = "Conveyor";
            this.rbConveyor.UseVisualStyleBackColor = true;
            this.rbConveyor.CheckedChanged += new System.EventHandler(this.BuildType_CheckedChanged);
            // 
            // rbCheckIn
            // 
            this.rbCheckIn.AutoSize = true;
            this.rbCheckIn.Location = new System.Drawing.Point(9, 23);
            this.rbCheckIn.Margin = new System.Windows.Forms.Padding(4);
            this.rbCheckIn.Name = "rbCheckIn";
            this.rbCheckIn.Size = new System.Drawing.Size(68, 17);
            this.rbCheckIn.TabIndex = 0;
            this.rbCheckIn.TabStop = true;
            this.rbCheckIn.Text = "Check In";
            this.rbCheckIn.UseVisualStyleBackColor = true;
            this.rbCheckIn.CheckedChanged += new System.EventHandler(this.BuildType_CheckedChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(301, 15);
            this.btnStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
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
            this.btnPause.Size = new System.Drawing.Size(75, 23);
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageSimVisuals);
            this.tabControl1.Controls.Add(this.tabPageStats);
            this.tabControl1.Location = new System.Drawing.Point(505, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1419, 936);
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
            this.tabPageSimVisuals.Size = new System.Drawing.Size(1411, 907);
            this.tabPageSimVisuals.TabIndex = 1;
            this.tabPageSimVisuals.Text = "Simulation Visualisation";
            this.tabPageSimVisuals.UseVisualStyleBackColor = true;
            // 
            // tabPageStats
            // 
            this.tabPageStats.Controls.Add(this.buttonTransTimePerFlight);
            this.tabPageStats.Controls.Add(this.button2);
            this.tabPageStats.Controls.Add(this.button1);
            this.tabPageStats.Controls.Add(this.cartesianChartCompareTimes);
            this.tabPageStats.Controls.Add(this.btnCompare);
            this.tabPageStats.Controls.Add(this.pieChartPercentageAllFailedBaggage);
            this.tabPageStats.Controls.Add(this.cartesianChartFailedToPassBaggage);
            this.tabPageStats.Controls.Add(this.cartesianChartBaggageProcessedByCheckin);
            this.tabPageStats.Location = new System.Drawing.Point(4, 25);
            this.tabPageStats.Margin = new System.Windows.Forms.Padding(4);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Size = new System.Drawing.Size(1411, 907);
            this.tabPageStats.TabIndex = 2;
            this.tabPageStats.Text = "Statistics";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // buttonTransTimePerFlight
            // 
            this.buttonTransTimePerFlight.Location = new System.Drawing.Point(485, 413);
            this.buttonTransTimePerFlight.Margin = new System.Windows.Forms.Padding(4);
            this.buttonTransTimePerFlight.Name = "buttonTransTimePerFlight";
            this.buttonTransTimePerFlight.Size = new System.Drawing.Size(165, 28);
            this.buttonTransTimePerFlight.TabIndex = 35;
            this.buttonTransTimePerFlight.Text = "TransTime per Flight";
            this.buttonTransTimePerFlight.UseVisualStyleBackColor = true;
            this.buttonTransTimePerFlight.Click += new System.EventHandler(this.buttonTransTimePerFlight_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(520, 793);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 28);
            this.button2.TabIndex = 34;
            this.button2.Text = "Bags Percentage";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1163, 403);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 28);
            this.button1.TabIndex = 33;
            this.button1.Text = "Bags in Security";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cartesianChartCompareTimes
            // 
            this.cartesianChartCompareTimes.Location = new System.Drawing.Point(788, 468);
            this.cartesianChartCompareTimes.Name = "cartesianChartCompareTimes";
            this.cartesianChartCompareTimes.Size = new System.Drawing.Size(509, 319);
            this.cartesianChartCompareTimes.TabIndex = 32;
            this.cartesianChartCompareTimes.Text = "elementHost1";
            this.cartesianChartCompareTimes.Child = this.cartesianChartTimes;
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(1131, 793);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(166, 26);
            this.btnCompare.TabIndex = 31;
            this.btnCompare.Text = "Est / Actual Dep Time";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // pieChartPercentageAllFailedBaggage
            // 
            this.pieChartPercentageAllFailedBaggage.Location = new System.Drawing.Point(41, 480);
            this.pieChartPercentageAllFailedBaggage.Margin = new System.Windows.Forms.Padding(4);
            this.pieChartPercentageAllFailedBaggage.Name = "pieChartPercentageAllFailedBaggage";
            this.pieChartPercentageAllFailedBaggage.Size = new System.Drawing.Size(579, 326);
            this.pieChartPercentageAllFailedBaggage.TabIndex = 28;
            this.pieChartPercentageAllFailedBaggage.Text = "pieChart1";
            // 
            // cartesianChartFailedToPassBaggage
            // 
            this.cartesianChartFailedToPassBaggage.Location = new System.Drawing.Point(760, 0);
            this.cartesianChartFailedToPassBaggage.Margin = new System.Windows.Forms.Padding(5);
            this.cartesianChartFailedToPassBaggage.Name = "cartesianChartFailedToPassBaggage";
            this.cartesianChartFailedToPassBaggage.Size = new System.Drawing.Size(547, 427);
            this.cartesianChartFailedToPassBaggage.TabIndex = 26;
            this.cartesianChartFailedToPassBaggage.Text = "FailedToPassBaggageThroughSecurity";
            // 
            // cartesianChartBaggageProcessedByCheckin
            // 
            this.cartesianChartBaggageProcessedByCheckin.Location = new System.Drawing.Point(4, 4);
            this.cartesianChartBaggageProcessedByCheckin.Margin = new System.Windows.Forms.Padding(4);
            this.cartesianChartBaggageProcessedByCheckin.Name = "cartesianChartBaggageProcessedByCheckin";
            this.cartesianChartBaggageProcessedByCheckin.Size = new System.Drawing.Size(655, 427);
            this.cartesianChartBaggageProcessedByCheckin.TabIndex = 0;
            this.cartesianChartBaggageProcessedByCheckin.Text = "BaggageProcessedByCheckin";
            // 
            // Baggager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1924, 936);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Baggager";
            this.RightToLeftLayout = true;
            this.Text = "Baggager";
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).EndInit();
            this.gbNodeInfo.ResumeLayout(false);
            this.gbNodeInfo.PerformLayout();
            this.gbFlightsInfo.ResumeLayout(false);
            this.gbFlightsInfo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDropOffSettings.ResumeLayout(false);
            this.gbDropOffSettings.PerformLayout();
            this.gbConveyorSpeed.ResumeLayout(false);
            this.gbConveyorSpeed.PerformLayout();
            this.gbBuildType.ResumeLayout(false);
            this.gbBuildType.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageSimVisuals.ResumeLayout(false);
            this.tabPageStats.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox animationBox;
        private System.Windows.Forms.CheckBox chbBuildMode;
        private System.Windows.Forms.Label lblBagStatus;
        private System.Windows.Forms.GroupBox gbNodeInfo;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblColRow;
        private System.Windows.Forms.Label lblNodeType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbFlights;
        private System.Windows.Forms.TextBox tbFlightNr;
        private System.Windows.Forms.Label lblFlightNr;
        private System.Windows.Forms.GroupBox gbFlightsInfo;
        private System.Windows.Forms.DateTimePicker tbFlightTime;
        private System.Windows.Forms.Label lblDepTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFlightBaggage;
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
        private LiveCharts.WinForms.PieChart pieChartPercentageAllFailedBaggage;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.ComboBox cbDropOffDest;
        private System.Windows.Forms.Label lblDropOff;
        private System.Windows.Forms.ComboBox cbCheckInFlight;
        private System.Windows.Forms.Label lblCheckIn;
        private System.Windows.Forms.GroupBox gbBuildType;
        private System.Windows.Forms.RadioButton rbConveyor;
        private System.Windows.Forms.RadioButton rbCheckIn;
        private System.Windows.Forms.RadioButton rbDropOff;
        private System.Windows.Forms.RadioButton rbMPA;
        private System.Windows.Forms.RadioButton rbSecurity;
        private System.Windows.Forms.Button buttonSaveToFile;
        private System.Windows.Forms.Button btnClearGrid;
        private System.Windows.Forms.GroupBox gbConveyorSpeed;
        private System.Windows.Forms.RadioButton rbConvSpeed4;
        private System.Windows.Forms.RadioButton rbConvSpeed3;
        private System.Windows.Forms.RadioButton rbConvSpeed2;
        private System.Windows.Forms.RadioButton rbConvSpeed1;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button btnCompare;
        private System.Windows.Forms.Integration.ElementHost cartesianChartCompareTimes;
        private LiveCharts.Wpf.CartesianChart cartesianChartTimes;
        private System.Windows.Forms.GroupBox gbDropOffSettings;
        private System.Windows.Forms.ComboBox cbEmployees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbCapacity;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonTransTimePerFlight;
    }
}

