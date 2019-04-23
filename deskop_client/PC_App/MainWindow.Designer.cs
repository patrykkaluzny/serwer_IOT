namespace PC_App
{
    partial class MainWindow
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.dataTab = new System.Windows.Forms.TabPage();
            this.dataList = new System.Windows.Forms.ListView();
            this.chartTab = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.colorTab = new System.Windows.Forms.TabPage();
            this.turnoffButton = new System.Windows.Forms.Button();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.colorTable = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.colorText = new System.Windows.Forms.TextBox();
            this.chooseButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.setTab = new System.Windows.Forms.TabPage();
            this.refreshText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.setButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.timeText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.urlBox = new System.Windows.Forms.TextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.mainTab.SuspendLayout();
            this.dataTab.SuspendLayout();
            this.chartTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.colorTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorTable)).BeginInit();
            this.setTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(380, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.dataTab);
            this.mainTab.Controls.Add(this.chartTab);
            this.mainTab.Controls.Add(this.colorTab);
            this.mainTab.Controls.Add(this.setTab);
            this.mainTab.Location = new System.Drawing.Point(12, 12);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(760, 371);
            this.mainTab.TabIndex = 1;
            // 
            // dataTab
            // 
            this.dataTab.Controls.Add(this.dataList);
            this.dataTab.Location = new System.Drawing.Point(4, 22);
            this.dataTab.Name = "dataTab";
            this.dataTab.Padding = new System.Windows.Forms.Padding(3);
            this.dataTab.Size = new System.Drawing.Size(752, 345);
            this.dataTab.TabIndex = 0;
            this.dataTab.Text = "Data";
            this.dataTab.UseVisualStyleBackColor = true;
            // 
            // dataList
            // 
            this.dataList.Location = new System.Drawing.Point(-4, -5);
            this.dataList.Name = "dataList";
            this.dataList.Size = new System.Drawing.Size(760, 354);
            this.dataList.TabIndex = 0;
            this.dataList.UseCompatibleStateImageBehavior = false;
            // 
            // chartTab
            // 
            this.chartTab.Controls.Add(this.label1);
            this.chartTab.Controls.Add(this.comboBox1);
            this.chartTab.Controls.Add(this.chart1);
            this.chartTab.Location = new System.Drawing.Point(4, 22);
            this.chartTab.Name = "chartTab";
            this.chartTab.Padding = new System.Windows.Forms.Padding(3);
            this.chartTab.Size = new System.Drawing.Size(752, 345);
            this.chartTab.TabIndex = 1;
            this.chartTab.Text = "Chart";
            this.chartTab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(625, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select data";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(625, 79);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Enabled = false;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(607, 345);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // colorTab
            // 
            this.colorTab.Controls.Add(this.turnoffButton);
            this.colorTab.Controls.Add(this.modeComboBox);
            this.colorTab.Controls.Add(this.label7);
            this.colorTab.Controls.Add(this.colorTable);
            this.colorTab.Controls.Add(this.label6);
            this.colorTab.Controls.Add(this.colorText);
            this.colorTab.Controls.Add(this.chooseButton);
            this.colorTab.Controls.Add(this.sendButton);
            this.colorTab.Location = new System.Drawing.Point(4, 22);
            this.colorTab.Name = "colorTab";
            this.colorTab.Size = new System.Drawing.Size(752, 345);
            this.colorTab.TabIndex = 2;
            this.colorTab.Text = "Set color";
            this.colorTab.UseVisualStyleBackColor = true;
            // 
            // turnoffButton
            // 
            this.turnoffButton.Location = new System.Drawing.Point(146, 246);
            this.turnoffButton.Name = "turnoffButton";
            this.turnoffButton.Size = new System.Drawing.Size(101, 23);
            this.turnoffButton.TabIndex = 8;
            this.turnoffButton.Text = "Turn off LED matrix";
            this.turnoffButton.UseVisualStyleBackColor = true;
            this.turnoffButton.Click += new System.EventHandler(this.turnoffButton_Click);
            // 
            // modeComboBox
            // 
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Location = new System.Drawing.Point(146, 69);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(98, 21);
            this.modeComboBox.TabIndex = 7;
            this.modeComboBox.SelectionChangeCommitted += new System.EventHandler(this.modeComboBox_SelectionChangeCommitted);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Select display mode";
            // 
            // colorTable
            // 
            this.colorTable.AllowUserToAddRows = false;
            this.colorTable.AllowUserToDeleteRows = false;
            this.colorTable.AllowUserToResizeColumns = false;
            this.colorTable.AllowUserToResizeRows = false;
            this.colorTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.colorTable.ColumnHeadersVisible = false;
            this.colorTable.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.colorTable.GridColor = System.Drawing.SystemColors.Control;
            this.colorTable.Location = new System.Drawing.Point(434, 30);
            this.colorTable.MultiSelect = false;
            this.colorTable.Name = "colorTable";
            this.colorTable.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.colorTable.RowHeadersVisible = false;
            this.colorTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.colorTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.colorTable.Size = new System.Drawing.Size(240, 240);
            this.colorTable.TabIndex = 5;
            this.colorTable.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.colorTable_CellClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(143, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Current color";
            // 
            // colorText
            // 
            this.colorText.Location = new System.Drawing.Point(146, 127);
            this.colorText.Name = "colorText";
            this.colorText.Size = new System.Drawing.Size(101, 20);
            this.colorText.TabIndex = 3;
            // 
            // chooseButton
            // 
            this.chooseButton.Location = new System.Drawing.Point(146, 153);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(101, 23);
            this.chooseButton.TabIndex = 2;
            this.chooseButton.Text = "Choose color";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(489, 284);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(136, 23);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "Send to Sense Hat";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // setTab
            // 
            this.setTab.Controls.Add(this.refreshText);
            this.setTab.Controls.Add(this.label5);
            this.setTab.Controls.Add(this.label4);
            this.setTab.Controls.Add(this.setButton);
            this.setTab.Controls.Add(this.label3);
            this.setTab.Controls.Add(this.timeText);
            this.setTab.Controls.Add(this.label2);
            this.setTab.Location = new System.Drawing.Point(4, 22);
            this.setTab.Name = "setTab";
            this.setTab.Size = new System.Drawing.Size(752, 345);
            this.setTab.TabIndex = 3;
            this.setTab.Text = "Settings";
            this.setTab.UseVisualStyleBackColor = true;
            // 
            // refreshText
            // 
            this.refreshText.Location = new System.Drawing.Point(423, 182);
            this.refreshText.Name = "refreshText";
            this.refreshText.Size = new System.Drawing.Size(71, 20);
            this.refreshText.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(152, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Current refresh time is equel to:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(197, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Note: Mininmal value is equel to 100ms! ";
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(406, 146);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(88, 23);
            this.setButton.TabIndex = 3;
            this.setButton.Text = "Set";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(380, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "ms";
            // 
            // timeText
            // 
            this.timeText.Location = new System.Drawing.Point(274, 148);
            this.timeText.Name = "timeText";
            this.timeText.Size = new System.Drawing.Size(100, 20);
            this.timeText.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(271, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Set update time:";
            // 
            // connectButton
            // 
            this.connectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectButton.Location = new System.Drawing.Point(618, 389);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(150, 26);
            this.connectButton.TabIndex = 2;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // urlBox
            // 
            this.urlBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.urlBox.HideSelection = false;
            this.urlBox.Location = new System.Drawing.Point(12, 389);
            this.urlBox.Name = "urlBox";
            this.urlBox.Size = new System.Drawing.Size(450, 26);
            this.urlBox.TabIndex = 3;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.urlBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.button1);
            this.Name = "MainWindow";
            this.Text = "PcApp";
            this.mainTab.ResumeLayout(false);
            this.dataTab.ResumeLayout(false);
            this.chartTab.ResumeLayout(false);
            this.chartTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.colorTab.ResumeLayout(false);
            this.colorTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorTable)).EndInit();
            this.setTab.ResumeLayout(false);
            this.setTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage dataTab;
        private System.Windows.Forms.TabPage chartTab;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.ListView dataList;
        private System.Windows.Forms.TextBox urlBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage colorTab;
        private System.Windows.Forms.TabPage setTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox timeText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox refreshText;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox colorText;
        private System.Windows.Forms.Button chooseButton;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.DataGridView colorTable;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Button turnoffButton;
    }
}

