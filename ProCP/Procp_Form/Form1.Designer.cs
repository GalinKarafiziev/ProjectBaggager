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
            this.components = new System.ComponentModel.Container();
            this.animationBox = new System.Windows.Forms.PictureBox();
            this.cmBoxNodeToBuild = new System.Windows.Forms.ComboBox();
            this.chbBuildMode = new System.Windows.Forms.CheckBox();
            this.lblBagStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblNextNode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblNodeType = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTest = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblColRow = new System.Windows.Forms.Label();
            this.lbFlights = new System.Windows.Forms.ListBox();
            this.tbFlightNr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnEditFlight = new System.Windows.Forms.Button();
            this.btnAddFlight = new System.Windows.Forms.Button();
            this.tbFlightTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFlightBaggage = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonPause = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnBaggageInCheckIn = new System.Windows.Forms.Button();
            this.btnBaggageInQueue = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // animationBox
            // 
            this.animationBox.Location = new System.Drawing.Point(315, 0);
            this.animationBox.Name = "animationBox";
            this.animationBox.Size = new System.Drawing.Size(1573, 815);
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
            "DropOff"});
            this.cmBoxNodeToBuild.Location = new System.Drawing.Point(3, 68);
            this.cmBoxNodeToBuild.Name = "cmBoxNodeToBuild";
            this.cmBoxNodeToBuild.Size = new System.Drawing.Size(121, 24);
            this.cmBoxNodeToBuild.TabIndex = 2;
            this.cmBoxNodeToBuild.SelectedIndexChanged += new System.EventHandler(this.CmBoxNodeToBuild_SelectedIndexChanged);
            // 
            // chbBuildMode
            // 
            this.chbBuildMode.AutoSize = true;
            this.chbBuildMode.Location = new System.Drawing.Point(3, 41);
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
            this.lblBagStatus.Location = new System.Drawing.Point(125, 65);
            this.lblBagStatus.Name = "lblBagStatus";
            this.lblBagStatus.Size = new System.Drawing.Size(46, 17);
            this.lblBagStatus.TabIndex = 6;
            this.lblBagStatus.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblNextNode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblNodeType);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblBagStatus);
            this.groupBox1.Location = new System.Drawing.Point(0, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(204, 118);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Node Info:";
            // 
            // lblNextNode
            // 
            this.lblNextNode.AutoSize = true;
            this.lblNextNode.Location = new System.Drawing.Point(109, 95);
            this.lblNextNode.Name = "lblNextNode";
            this.lblNextNode.Size = new System.Drawing.Size(46, 17);
            this.lblNextNode.TabIndex = 10;
            this.lblNextNode.Text = "label7";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Next Node:";
            // 
            // lblNodeType
            // 
            this.lblNodeType.AutoSize = true;
            this.lblNodeType.Location = new System.Drawing.Point(7, 33);
            this.lblNodeType.Name = "lblNodeType";
            this.lblNodeType.Size = new System.Drawing.Size(46, 17);
            this.lblNodeType.TabIndex = 8;
            this.lblNodeType.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Baggage status:";
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(78, 0);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(46, 17);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Column and Row:";
            // 
            // lblColRow
            // 
            this.lblColRow.AutoSize = true;
            this.lblColRow.Location = new System.Drawing.Point(125, 110);
            this.lblColRow.Name = "lblColRow";
            this.lblColRow.Size = new System.Drawing.Size(46, 17);
            this.lblColRow.TabIndex = 9;
            this.lblColRow.Text = "label2";
            // 
            // lbFlights
            // 
            this.lbFlights.FormattingEnabled = true;
            this.lbFlights.ItemHeight = 16;
            this.lbFlights.Location = new System.Drawing.Point(10, 146);
            this.lbFlights.Name = "lbFlights";
            this.lbFlights.Size = new System.Drawing.Size(184, 84);
            this.lbFlights.TabIndex = 10;
            // 
            // tbFlightNr
            // 
            this.tbFlightNr.Location = new System.Drawing.Point(74, 26);
            this.tbFlightNr.Name = "tbFlightNr";
            this.tbFlightNr.Size = new System.Drawing.Size(100, 22);
            this.tbFlightNr.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "FlightNr.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnEditFlight);
            this.groupBox2.Controls.Add(this.btnAddFlight);
            this.groupBox2.Controls.Add(this.tbFlightTime);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.tbFlightBaggage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lbFlights);
            this.groupBox2.Controls.Add(this.tbFlightNr);
            this.groupBox2.Location = new System.Drawing.Point(0, 255);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 259);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Flights Info";
            // 
            // btnEditFlight
            // 
            this.btnEditFlight.Location = new System.Drawing.Point(112, 117);
            this.btnEditFlight.Name = "btnEditFlight";
            this.btnEditFlight.Size = new System.Drawing.Size(82, 23);
            this.btnEditFlight.TabIndex = 19;
            this.btnEditFlight.Text = "Edit";
            this.btnEditFlight.UseVisualStyleBackColor = true;
            this.btnEditFlight.Click += new System.EventHandler(this.btnEditFlight_Click);
            // 
            // btnAddFlight
            // 
            this.btnAddFlight.Location = new System.Drawing.Point(10, 117);
            this.btnAddFlight.Name = "btnAddFlight";
            this.btnAddFlight.Size = new System.Drawing.Size(84, 23);
            this.btnAddFlight.TabIndex = 18;
            this.btnAddFlight.Text = "Add";
            this.btnAddFlight.UseVisualStyleBackColor = true;
            this.btnAddFlight.Click += new System.EventHandler(this.btnAddFlight_Click);
            // 
            // tbFlightTime
            // 
            this.tbFlightTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.tbFlightTime.Location = new System.Drawing.Point(74, 84);
            this.tbFlightTime.Name = "tbFlightTime";
            this.tbFlightTime.Size = new System.Drawing.Size(100, 22);
            this.tbFlightTime.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Dep.Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Baggage";
            // 
            // tbFlightBaggage
            // 
            this.tbFlightBaggage.Location = new System.Drawing.Point(74, 54);
            this.tbFlightBaggage.Name = "tbFlightBaggage";
            this.tbFlightBaggage.Size = new System.Drawing.Size(100, 22);
            this.tbFlightBaggage.TabIndex = 14;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "Run";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.buttonResume);
            this.panel1.Controls.Add(this.buttonStop);
            this.panel1.Controls.Add(this.buttonPause);
            this.panel1.Controls.Add(this.btnBaggageInQueue);
            this.panel1.Controls.Add(this.btnBaggageInCheckIn);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.cmBoxNodeToBuild);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblTest);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.chbBuildMode);
            this.panel1.Controls.Add(this.lblColRow);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(304, 815);
            this.panel1.TabIndex = 16;
            // 
            // 
            // buttonPause
            // 
            this.buttonPause.Location = new System.Drawing.Point(140, 56);
            this.buttonPause.Name = "buttonPause";
            this.buttonPause.Size = new System.Drawing.Size(75, 23);
            this.buttonPause.TabIndex = 21;
            this.buttonPause.Text = "Pause";
            this.buttonPause.UseVisualStyleBackColor = true;
            this.buttonPause.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(226, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 22;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click_1);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(226, 56);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(75, 23);
            this.buttonResume.TabIndex = 23;
            this.buttonResume.Text = "Resume";
            this.buttonResume.UseVisualStyleBackColor = true;
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(10, 491);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(188, 116);
            this.listBox1.TabIndex = 16;
            // 
            // btnBaggageInCheckIn
            // 
            this.btnBaggageInCheckIn.Location = new System.Drawing.Point(10, 613);
            this.btnBaggageInCheckIn.Name = "btnBaggageInCheckIn";
            this.btnBaggageInCheckIn.Size = new System.Drawing.Size(119, 23);
            this.btnBaggageInCheckIn.TabIndex = 17;
            this.btnBaggageInCheckIn.Text = "Show Check-Ins";
            this.btnBaggageInCheckIn.UseVisualStyleBackColor = true;
            // 
            // btnBaggageInQueue
            // 
            this.btnBaggageInQueue.Location = new System.Drawing.Point(9, 642);
            this.btnBaggageInQueue.Name = "btnBaggageInQueue";
            this.btnBaggageInQueue.Size = new System.Drawing.Size(119, 23);
            this.btnBaggageInQueue.TabIndex = 18;
            this.btnBaggageInQueue.Text = "Show Queues";
            this.btnBaggageInQueue.UseVisualStyleBackColor = true;
            // 
            // Baggager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1888, 815);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.animationBox);
            this.Name = "Baggager";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.animationBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonPause;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnBaggageInCheckIn;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnBaggageInQueue;
    }
}

