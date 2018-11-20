namespace TaskManagment.Forms
{
    partial class TeamLeaderProjectDeatails
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_projectEndDate = new System.Windows.Forms.Label();
            this.lbl_projectStartDate = new System.Windows.Forms.Label();
            this.lbl_projectUxUiHours = new System.Windows.Forms.Label();
            this.lbl_projectQAHours = new System.Windows.Forms.Label();
            this.lbl_projectDeveloperHours = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_projectCustomer = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_projectName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgv_workersHours = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_workersHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "name:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(61, 4);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_projectEndDate);
            this.panel1.Controls.Add(this.lbl_projectStartDate);
            this.panel1.Controls.Add(this.lbl_projectUxUiHours);
            this.panel1.Controls.Add(this.lbl_projectQAHours);
            this.panel1.Controls.Add(this.lbl_projectDeveloperHours);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.lbl_projectCustomer);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.lbl_projectName);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(496, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 172);
            this.panel1.TabIndex = 4;
            // 
            // lbl_projectEndDate
            // 
            this.lbl_projectEndDate.AutoSize = true;
            this.lbl_projectEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectEndDate.Location = new System.Drawing.Point(130, 126);
            this.lbl_projectEndDate.Name = "lbl_projectEndDate";
            this.lbl_projectEndDate.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectEndDate.TabIndex = 1;
            this.lbl_projectEndDate.Text = " ";
            // 
            // lbl_projectStartDate
            // 
            this.lbl_projectStartDate.AutoSize = true;
            this.lbl_projectStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectStartDate.Location = new System.Drawing.Point(130, 109);
            this.lbl_projectStartDate.Name = "lbl_projectStartDate";
            this.lbl_projectStartDate.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectStartDate.TabIndex = 1;
            this.lbl_projectStartDate.Text = " ";
            // 
            // lbl_projectUxUiHours
            // 
            this.lbl_projectUxUiHours.AutoSize = true;
            this.lbl_projectUxUiHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectUxUiHours.Location = new System.Drawing.Point(130, 92);
            this.lbl_projectUxUiHours.Name = "lbl_projectUxUiHours";
            this.lbl_projectUxUiHours.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectUxUiHours.TabIndex = 1;
            this.lbl_projectUxUiHours.Text = " ";
            // 
            // lbl_projectQAHours
            // 
            this.lbl_projectQAHours.AutoSize = true;
            this.lbl_projectQAHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectQAHours.Location = new System.Drawing.Point(130, 75);
            this.lbl_projectQAHours.Name = "lbl_projectQAHours";
            this.lbl_projectQAHours.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectQAHours.TabIndex = 1;
            this.lbl_projectQAHours.Text = " ";
            // 
            // lbl_projectDeveloperHours
            // 
            this.lbl_projectDeveloperHours.AutoSize = true;
            this.lbl_projectDeveloperHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectDeveloperHours.Location = new System.Drawing.Point(130, 58);
            this.lbl_projectDeveloperHours.Name = "lbl_projectDeveloperHours";
            this.lbl_projectDeveloperHours.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectDeveloperHours.TabIndex = 1;
            this.lbl_projectDeveloperHours.Text = " ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label14.Location = new System.Drawing.Point(12, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(68, 17);
            this.label14.TabIndex = 0;
            this.label14.Text = "end date:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label12.Location = new System.Drawing.Point(12, 108);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 0;
            this.label12.Text = "start date:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label10.Location = new System.Drawing.Point(12, 91);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "UX/UI houres:";
            // 
            // lbl_projectCustomer
            // 
            this.lbl_projectCustomer.AutoSize = true;
            this.lbl_projectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectCustomer.Location = new System.Drawing.Point(130, 41);
            this.lbl_projectCustomer.Name = "lbl_projectCustomer";
            this.lbl_projectCustomer.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectCustomer.TabIndex = 1;
            this.lbl_projectCustomer.Text = " ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label8.Location = new System.Drawing.Point(12, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "QA houres:";
            // 
            // lbl_projectName
            // 
            this.lbl_projectName.AutoSize = true;
            this.lbl_projectName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbl_projectName.Location = new System.Drawing.Point(130, 22);
            this.lbl_projectName.Name = "lbl_projectName";
            this.lbl_projectName.Size = new System.Drawing.Size(12, 17);
            this.lbl_projectName.TabIndex = 1;
            this.lbl_projectName.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label6.Location = new System.Drawing.Point(12, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "develop houres:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "customer:";
            // 
            // dgv_workersHours
            // 
            this.dgv_workersHours.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_workersHours.Location = new System.Drawing.Point(28, 34);
            this.dgv_workersHours.Name = "dgv_workersHours";
            this.dgv_workersHours.Size = new System.Drawing.Size(430, 149);
            this.dgv_workersHours.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(25, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "workers hours";
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(108, 250);
            this.chart1.Name = "chart1";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "allocated hours";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "worker hours";
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            this.chart1.Size = new System.Drawing.Size(388, 173);
            this.chart1.TabIndex = 9;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // TeamLeaderProjectDeatails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgv_workersHours);
            this.Controls.Add(this.panel1);
            this.Name = "TeamLeaderProjectDeatails";
            this.Text = "ProjectDeatails";
            this.Load += new System.EventHandler(this.ProjectDeatails_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_workersHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_projectName;
        private System.Windows.Forms.Label lbl_projectDeveloperHours;
        private System.Windows.Forms.Label lbl_projectCustomer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_projectEndDate;
        private System.Windows.Forms.Label lbl_projectStartDate;
        private System.Windows.Forms.Label lbl_projectUxUiHours;
        private System.Windows.Forms.Label lbl_projectQAHours;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dgv_workersHours;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}