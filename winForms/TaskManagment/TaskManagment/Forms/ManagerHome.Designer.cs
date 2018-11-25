namespace TaskManagment.Forms
{
    partial class ManagerHome
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
            this.tab_manager = new System.Windows.Forms.TabControl();
            this.tab_addProject = new System.Windows.Forms.TabPage();
            this.dgvAddWorkers = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_team_name = new System.Windows.Forms.ComboBox();
            this.data_end = new System.Windows.Forms.DateTimePicker();
            this.data_start = new System.Windows.Forms.DateTimePicker();
            this.txt_UIUX_hours = new System.Windows.Forms.TextBox();
            this.txt_developer_hours = new System.Windows.Forms.TextBox();
            this.txt_QI_houers = new System.Windows.Forms.TextBox();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.txt_projName = new System.Windows.Forms.TextBox();
            this.btn_addProject = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tab_reports = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tab_user_managment = new System.Windows.Forms.TabPage();
            this.panelControlls = new System.Windows.Forms.Panel();
            this.btn_edit = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_add_worker = new System.Windows.Forms.Button();
            this.tab_workerDeatrails = new System.Windows.Forms.TabPage();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmb_manager = new System.Windows.Forms.ComboBox();
            this.cmb_job = new System.Windows.Forms.ComboBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_user_name = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.btn_Action = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tab_manager.SuspendLayout();
            this.tab_addProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddWorkers)).BeginInit();
            this.tab_reports.SuspendLayout();
            this.tab_user_managment.SuspendLayout();
            this.tab_workerDeatrails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_manager
            // 
            this.tab_manager.Controls.Add(this.tab_addProject);
            this.tab_manager.Controls.Add(this.tab_reports);
            this.tab_manager.Controls.Add(this.tab_user_managment);
            this.tab_manager.Controls.Add(this.tab_workerDeatrails);
            this.tab_manager.Location = new System.Drawing.Point(3, 1);
            this.tab_manager.Name = "tab_manager";
            this.tab_manager.SelectedIndex = 0;
            this.tab_manager.Size = new System.Drawing.Size(798, 450);
            this.tab_manager.TabIndex = 3;
            this.tab_manager.ClientSizeChanged += new System.EventHandler(this.btn_add_worker_Click);
            // 
            // tab_addProject
            // 
            this.tab_addProject.Controls.Add(this.dgvAddWorkers);
            this.tab_addProject.Controls.Add(this.label16);
            this.tab_addProject.Controls.Add(this.txt_team_name);
            this.tab_addProject.Controls.Add(this.data_end);
            this.tab_addProject.Controls.Add(this.data_start);
            this.tab_addProject.Controls.Add(this.txt_UIUX_hours);
            this.tab_addProject.Controls.Add(this.txt_developer_hours);
            this.tab_addProject.Controls.Add(this.txt_QI_houers);
            this.tab_addProject.Controls.Add(this.txt_customer_name);
            this.tab_addProject.Controls.Add(this.txt_projName);
            this.tab_addProject.Controls.Add(this.btn_addProject);
            this.tab_addProject.Controls.Add(this.label9);
            this.tab_addProject.Controls.Add(this.label8);
            this.tab_addProject.Controls.Add(this.label7);
            this.tab_addProject.Controls.Add(this.label6);
            this.tab_addProject.Controls.Add(this.label5);
            this.tab_addProject.Controls.Add(this.label4);
            this.tab_addProject.Controls.Add(this.label3);
            this.tab_addProject.Controls.Add(this.label2);
            this.tab_addProject.Controls.Add(this.label1);
            this.tab_addProject.Location = new System.Drawing.Point(4, 22);
            this.tab_addProject.Name = "tab_addProject";
            this.tab_addProject.Padding = new System.Windows.Forms.Padding(3);
            this.tab_addProject.Size = new System.Drawing.Size(790, 424);
            this.tab_addProject.TabIndex = 0;
            this.tab_addProject.Text = "Add project";
            this.tab_addProject.UseVisualStyleBackColor = true;
            // 
            // dgvAddWorkers
            // 
            this.dgvAddWorkers.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvAddWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddWorkers.GridColor = System.Drawing.Color.DarkGray;
            this.dgvAddWorkers.Location = new System.Drawing.Point(411, 91);
            this.dgvAddWorkers.Name = "dgvAddWorkers";
            this.dgvAddWorkers.Size = new System.Drawing.Size(185, 168);
            this.dgvAddWorkers.TabIndex = 38;
            this.dgvAddWorkers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAddWorkers_RowHeaderMouseClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(450, 49);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "add workers:";
            // 
            // txt_team_name
            // 
            this.txt_team_name.FormattingEnabled = true;
            this.txt_team_name.Location = new System.Drawing.Point(177, 103);
            this.txt_team_name.Name = "txt_team_name";
            this.txt_team_name.Size = new System.Drawing.Size(121, 21);
            this.txt_team_name.TabIndex = 36;
            this.txt_team_name.SelectedIndexChanged += new System.EventHandler(this.txt_team_name_SelectedIndexChanged);
            // 
            // data_end
            // 
            this.data_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_end.Location = new System.Drawing.Point(177, 240);
            this.data_end.Name = "data_end";
            this.data_end.Size = new System.Drawing.Size(200, 20);
            this.data_end.TabIndex = 35;
            // 
            // data_start
            // 
            this.data_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_start.Location = new System.Drawing.Point(177, 212);
            this.data_start.Name = "data_start";
            this.data_start.Size = new System.Drawing.Size(200, 20);
            this.data_start.TabIndex = 34;
            // 
            // txt_UIUX_hours
            // 
            this.txt_UIUX_hours.Location = new System.Drawing.Point(177, 188);
            this.txt_UIUX_hours.Name = "txt_UIUX_hours";
            this.txt_UIUX_hours.Size = new System.Drawing.Size(100, 20);
            this.txt_UIUX_hours.TabIndex = 33;
            this.txt_UIUX_hours.TextChanged += new System.EventHandler(this.checkValidUIUXHours);
            // 
            // txt_developer_hours
            // 
            this.txt_developer_hours.Location = new System.Drawing.Point(177, 161);
            this.txt_developer_hours.Name = "txt_developer_hours";
            this.txt_developer_hours.Size = new System.Drawing.Size(100, 20);
            this.txt_developer_hours.TabIndex = 32;
            this.txt_developer_hours.TextChanged += new System.EventHandler(this.checkValidDeveloperHours);
            // 
            // txt_QI_houers
            // 
            this.txt_QI_houers.Location = new System.Drawing.Point(177, 134);
            this.txt_QI_houers.Name = "txt_QI_houers";
            this.txt_QI_houers.Size = new System.Drawing.Size(100, 20);
            this.txt_QI_houers.TabIndex = 31;
            this.txt_QI_houers.TextChanged += new System.EventHandler(this.checkValidQAHours);
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(177, 77);
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.Size = new System.Drawing.Size(100, 20);
            this.txt_customer_name.TabIndex = 30;
            this.txt_customer_name.TextChanged += new System.EventHandler(this.checkValidCustomerName);
            // 
            // txt_projName
            // 
            this.txt_projName.Location = new System.Drawing.Point(177, 49);
            this.txt_projName.Name = "txt_projName";
            this.txt_projName.Size = new System.Drawing.Size(100, 20);
            this.txt_projName.TabIndex = 29;
            this.txt_projName.TextChanged += new System.EventHandler(this.checkValidProjName);
            // 
            // btn_addProject
            // 
            this.btn_addProject.Location = new System.Drawing.Point(283, 275);
            this.btn_addProject.Name = "btn_addProject";
            this.btn_addProject.Size = new System.Drawing.Size(75, 23);
            this.btn_addProject.TabIndex = 28;
            this.btn_addProject.Text = "ADD";
            this.btn_addProject.UseVisualStyleBackColor = true;
            this.btn_addProject.Click += new System.EventHandler(this.btn_addProject_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(52, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "End date";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(52, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Start date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Hours to UI/UX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(52, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hours to developer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hours to QA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(52, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "TeamLeader name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Customur name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Project name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(274, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "ADD PROJECT";
            // 
            // tab_reports
            // 
            this.tab_reports.Controls.Add(this.treeView1);
            this.tab_reports.Location = new System.Drawing.Point(4, 22);
            this.tab_reports.Name = "tab_reports";
            this.tab_reports.Padding = new System.Windows.Forms.Padding(3);
            this.tab_reports.Size = new System.Drawing.Size(790, 424);
            this.tab_reports.TabIndex = 1;
            this.tab_reports.Text = "Reports";
            this.tab_reports.UseVisualStyleBackColor = true;
            // 
            // btnExportToExecl
            // 
         
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.treeView1.Location = new System.Drawing.Point(3, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(646, 397);
            this.treeView1.TabIndex = 1;
            // 
            // tab_user_managment
            // 
            this.tab_user_managment.Controls.Add(this.panelControlls);
            this.tab_user_managment.Controls.Add(this.btn_edit);
            this.tab_user_managment.Controls.Add(this.btn_delete);
            this.tab_user_managment.Controls.Add(this.btn_add_worker);
            this.tab_user_managment.Location = new System.Drawing.Point(4, 22);
            this.tab_user_managment.Name = "tab_user_managment";
            this.tab_user_managment.Padding = new System.Windows.Forms.Padding(3);
            this.tab_user_managment.Size = new System.Drawing.Size(790, 424);
            this.tab_user_managment.TabIndex = 2;
            this.tab_user_managment.Text = "Users managment";
            this.tab_user_managment.UseVisualStyleBackColor = true;
            // 
            // panelControlls
            // 
            this.panelControlls.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelControlls.Location = new System.Drawing.Point(50, 94);
            this.panelControlls.Name = "panelControlls";
            this.panelControlls.Size = new System.Drawing.Size(532, 218);
            this.panelControlls.TabIndex = 6;
            // 
            // btn_edit
            // 
            this.btn_edit.Location = new System.Drawing.Point(111, 55);
            this.btn_edit.Name = "btn_edit";
            this.btn_edit.Size = new System.Drawing.Size(97, 23);
            this.btn_edit.TabIndex = 4;
            this.btn_edit.Text = "edit worker";
            this.btn_edit.UseVisualStyleBackColor = true;
            this.btn_edit.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(228, 55);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(97, 23);
            this.btn_delete.TabIndex = 5;
            this.btn_delete.Text = "Delete worker";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_add_worker
            // 
            this.btn_add_worker.Location = new System.Drawing.Point(351, 55);
            this.btn_add_worker.Name = "btn_add_worker";
            this.btn_add_worker.Size = new System.Drawing.Size(87, 23);
            this.btn_add_worker.TabIndex = 3;
            this.btn_add_worker.Text = "Add worker";
            this.btn_add_worker.UseVisualStyleBackColor = true;
            this.btn_add_worker.Click += new System.EventHandler(this.btn_add_worker_Click);
            // 
            // tab_workerDeatrails
            // 
            this.tab_workerDeatrails.Controls.Add(this.txt_password);
            this.tab_workerDeatrails.Controls.Add(this.lblPassword);
            this.tab_workerDeatrails.Controls.Add(this.cmb_manager);
            this.tab_workerDeatrails.Controls.Add(this.cmb_job);
            this.tab_workerDeatrails.Controls.Add(this.txt_email);
            this.tab_workerDeatrails.Controls.Add(this.txt_user_name);
            this.tab_workerDeatrails.Controls.Add(this.txt_name);
            this.tab_workerDeatrails.Controls.Add(this.btn_Action);
            this.tab_workerDeatrails.Controls.Add(this.label10);
            this.tab_workerDeatrails.Controls.Add(this.label11);
            this.tab_workerDeatrails.Controls.Add(this.label12);
            this.tab_workerDeatrails.Controls.Add(this.label14);
            this.tab_workerDeatrails.Controls.Add(this.label15);
            this.tab_workerDeatrails.Controls.Add(this.lblTitle);
            this.tab_workerDeatrails.Location = new System.Drawing.Point(4, 22);
            this.tab_workerDeatrails.Name = "tab_workerDeatrails";
            this.tab_workerDeatrails.Padding = new System.Windows.Forms.Padding(3);
            this.tab_workerDeatrails.Size = new System.Drawing.Size(790, 424);
            this.tab_workerDeatrails.TabIndex = 3;
            this.tab_workerDeatrails.UseVisualStyleBackColor = true;
            this.tab_workerDeatrails.Click += new System.EventHandler(this.tab_workerDeatrails_Click);
            this.tab_workerDeatrails.Leave += new System.EventHandler(this.tab_workerDeatrails_Leave);
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(339, 252);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(100, 20);
            this.txt_password.TabIndex = 51;
            this.txt_password.TextChanged += new System.EventHandler(this.checkValidPassword);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(214, 252);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 50;
            this.lblPassword.Text = "Password";
            // 
            // cmb_manager
            // 
            this.cmb_manager.FormattingEnabled = true;
            this.cmb_manager.Location = new System.Drawing.Point(339, 224);
            this.cmb_manager.Name = "cmb_manager";
            this.cmb_manager.Size = new System.Drawing.Size(100, 21);
            this.cmb_manager.TabIndex = 49;
            // 
            // cmb_job
            // 
            this.cmb_job.FormattingEnabled = true;
            this.cmb_job.Location = new System.Drawing.Point(339, 196);
            this.cmb_job.Name = "cmb_job";
            this.cmb_job.Size = new System.Drawing.Size(100, 21);
            this.cmb_job.TabIndex = 48;
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(339, 169);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(100, 20);
            this.txt_email.TabIndex = 47;
            this.txt_email.TextChanged += new System.EventHandler(this.checkValidEmail);
            this.txt_email.Validated += new System.EventHandler(this.checkValidEmail);
            // 
            // txt_user_name
            // 
            this.txt_user_name.Location = new System.Drawing.Point(339, 143);
            this.txt_user_name.Name = "txt_user_name";
            this.txt_user_name.Size = new System.Drawing.Size(100, 20);
            this.txt_user_name.TabIndex = 45;
            this.txt_user_name.TextChanged += new System.EventHandler(this.checkValidUserName);
            this.txt_user_name.Validated += new System.EventHandler(this.checkValidUserName);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(339, 115);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 44;
            this.txt_name.TextChanged += new System.EventHandler(this.checkValidName);
            // 
            // btn_Action
            // 
            this.btn_Action.Location = new System.Drawing.Point(359, 297);
            this.btn_Action.Name = "btn_Action";
            this.btn_Action.Size = new System.Drawing.Size(75, 23);
            this.btn_Action.TabIndex = 43;
            this.btn_Action.UseVisualStyleBackColor = true;
            this.btn_Action.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(214, 222);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Manager";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(214, 195);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 41;
            this.label11.Text = "Job";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(214, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "E-mail";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(214, 143);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "User name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(214, 115);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Name";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(292, 81);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 36;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // ManagerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab_manager);
            this.Name = "ManagerHome";
            this.Text = "Manager";
            this.tab_manager.ResumeLayout(false);
            this.tab_addProject.ResumeLayout(false);
            this.tab_addProject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddWorkers)).EndInit();
            this.tab_reports.ResumeLayout(false);
            this.tab_user_managment.ResumeLayout(false);
            this.tab_workerDeatrails.ResumeLayout(false);
            this.tab_workerDeatrails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tab_manager;
        private System.Windows.Forms.TabPage tab_addProject;
        private System.Windows.Forms.TabPage tab_reports;
        private System.Windows.Forms.ComboBox txt_team_name;
        private System.Windows.Forms.DateTimePicker data_end;
        private System.Windows.Forms.DateTimePicker data_start;
        private System.Windows.Forms.TextBox txt_UIUX_hours;
        private System.Windows.Forms.TextBox txt_developer_hours;
        private System.Windows.Forms.TextBox txt_QI_houers;
        private System.Windows.Forms.TextBox txt_customer_name;
        private System.Windows.Forms.TextBox txt_projName;
        private System.Windows.Forms.Button btn_addProject;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TabPage tab_user_managment;
        private System.Windows.Forms.Panel panelControlls;
        private System.Windows.Forms.Button btn_edit;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_add_worker;
        private System.Windows.Forms.TabPage tab_workerDeatrails;
        private System.Windows.Forms.ComboBox cmb_manager;
        private System.Windows.Forms.ComboBox cmb_job;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_user_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Button btn_Action;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridView dgvAddWorkers;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnExportToExecl;
    }
}