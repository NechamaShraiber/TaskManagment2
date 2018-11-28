namespace TaskManagment.Forms
{
    partial class WorkerHome
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblClock = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_beginningTime = new System.Windows.Forms.Label();
            this.btn_task = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.btn_sendEmail = new System.Windows.Forms.Button();
            this.dgv_task = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lbl_message = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_logOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblClock.Location = new System.Drawing.Point(67, 25);
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(0, 20);
            this.lblClock.TabIndex = 0;
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(67, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beginning time:";
            // 
            // lbl_beginningTime
            // 
            this.lbl_beginningTime.AutoSize = true;
            this.lbl_beginningTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_beginningTime.Location = new System.Drawing.Point(191, 28);
            this.lbl_beginningTime.Name = "lbl_beginningTime";
            this.lbl_beginningTime.Size = new System.Drawing.Size(0, 20);
            this.lbl_beginningTime.TabIndex = 1;
            // 
            // btn_task
            // 
            this.btn_task.Location = new System.Drawing.Point(71, 71);
            this.btn_task.Name = "btn_task";
            this.btn_task.Size = new System.Drawing.Size(158, 61);
            this.btn_task.TabIndex = 2;
            this.btn_task.Text = "start task";
            this.btn_task.UseVisualStyleBackColor = true;
            this.btn_task.Click += new System.EventHandler(this.btn_task_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(67, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "you work:";
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_timer.Location = new System.Drawing.Point(191, 48);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(22, 20);
            this.lbl_timer.TabIndex = 1;
            this.lbl_timer.Text = "0 ";
            // 
            // btn_sendEmail
            // 
            this.btn_sendEmail.Location = new System.Drawing.Point(562, 352);
            this.btn_sendEmail.Name = "btn_sendEmail";
            this.btn_sendEmail.Size = new System.Drawing.Size(184, 55);
            this.btn_sendEmail.TabIndex = 3;
            this.btn_sendEmail.Text = "send Email";
            this.btn_sendEmail.UseVisualStyleBackColor = true;
            this.btn_sendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // dgv_task
            // 
            this.dgv_task.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_task.Location = new System.Drawing.Point(326, 27);
            this.dgv_task.Name = "dgv_task";
            this.dgv_task.Size = new System.Drawing.Size(462, 191);
            this.dgv_task.TabIndex = 4;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(28, 222);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "allocated hours";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "worked hours";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(349, 184);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(65, 149);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(0, 13);
            this.lbl_message.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "choose project to start:";
            // 
            // btn_logOut
            // 
            this.btn_logOut.Location = new System.Drawing.Point(562, 411);
            this.btn_logOut.Name = "btn_logOut";
            this.btn_logOut.Size = new System.Drawing.Size(183, 38);
            this.btn_logOut.TabIndex = 8;
            this.btn_logOut.Text = "Log Out";
            this.btn_logOut.UseVisualStyleBackColor = true;
            this.btn_logOut.Click += new System.EventHandler(this.btn_logOut_Click);
            // 
            // WorkerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_logOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_message);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dgv_task);
            this.Controls.Add(this.btn_sendEmail);
            this.Controls.Add(this.btn_task);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.lbl_beginningTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblClock);
            this.Name = "WorkerHome";
            this.Text = "WorkerHome";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WorkerHome_FormClosing);
            this.Load += new System.EventHandler(this.WorkerHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_task)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_beginningTime;
        private System.Windows.Forms.Button btn_task;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Button btn_sendEmail;
        private System.Windows.Forms.DataGridView dgv_task;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_logOut;
    }
}