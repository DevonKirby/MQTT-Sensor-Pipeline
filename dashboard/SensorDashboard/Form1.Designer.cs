namespace SensorDashboard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvLiveReadings = new DataGridView();
            tabPage2 = new TabPage();
            dgvAnomalyAlerts = new DataGridView();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            dgvSummary = new DataGridView();
            formsPlot1 = new ScottPlot.WinForms.FormsPlot();
            cmbMachine = new ComboBox();
            cmbSensor = new ComboBox();
            refreshTimer = new System.Windows.Forms.Timer(components);
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLiveReadings).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAnomalyAlerts).BeginInit();
            tabPage3.SuspendLayout();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSummary).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(776, 426);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvLiveReadings);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(768, 398);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Live Readings";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvLiveReadings
            // 
            dgvLiveReadings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLiveReadings.Dock = DockStyle.Fill;
            dgvLiveReadings.Location = new Point(3, 3);
            dgvLiveReadings.Name = "dgvLiveReadings";
            dgvLiveReadings.Size = new Size(762, 392);
            dgvLiveReadings.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvAnomalyAlerts);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(768, 398);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Anomaly Alerts";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvAnomalyAlerts
            // 
            dgvAnomalyAlerts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAnomalyAlerts.Dock = DockStyle.Fill;
            dgvAnomalyAlerts.Location = new Point(3, 3);
            dgvAnomalyAlerts.Name = "dgvAnomalyAlerts";
            dgvAnomalyAlerts.Size = new Size(762, 392);
            dgvAnomalyAlerts.TabIndex = 0;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(cmbSensor);
            tabPage3.Controls.Add(cmbMachine);
            tabPage3.Controls.Add(formsPlot1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Size = new Size(768, 398);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Historical Chart";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvSummary);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Size = new Size(768, 398);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Summary";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvSummary
            // 
            dgvSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSummary.Dock = DockStyle.Fill;
            dgvSummary.Location = new Point(0, 0);
            dgvSummary.Name = "dgvSummary";
            dgvSummary.Size = new Size(768, 398);
            dgvSummary.TabIndex = 0;
            // 
            // formsPlot1
            // 
            formsPlot1.DisplayScale = 1F;
            formsPlot1.Location = new Point(3, 51);
            formsPlot1.Name = "formsPlot1";
            formsPlot1.Size = new Size(762, 344);
            formsPlot1.TabIndex = 0;
            // 
            // cmbMachine
            // 
            cmbMachine.FormattingEnabled = true;
            cmbMachine.Location = new Point(27, 22);
            cmbMachine.Name = "cmbMachine";
            cmbMachine.Size = new Size(121, 23);
            cmbMachine.TabIndex = 1;
            // 
            // cmbSensor
            // 
            cmbSensor.FormattingEnabled = true;
            cmbSensor.Location = new Point(186, 22);
            cmbSensor.Name = "cmbSensor";
            cmbSensor.Size = new Size(121, 23);
            cmbSensor.TabIndex = 2;
            // 
            // refreshTimer
            // 
            refreshTimer.Interval = 5000;
            refreshTimer.Tick += refreshTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "Form1";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLiveReadings).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAnomalyAlerts).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSummary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private DataGridView dgvLiveReadings;
        private DataGridView dgvAnomalyAlerts;
        private DataGridView dgvSummary;
        private ComboBox cmbSensor;
        private ComboBox cmbMachine;
        private ScottPlot.WinForms.FormsPlot formsPlot1;
        private System.Windows.Forms.Timer refreshTimer;
    }
}
