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
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.addProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userManagmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteWorkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnl_add_project = new System.Windows.Forms.Panel();
            this.pnl_report = new System.Windows.Forms.Panel();
            this.dgv_presence = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.pnl_delete = new System.Windows.Forms.Panel();
            this.panelControlls = new System.Windows.Forms.Panel();
            this.dgvAddWorkers = new System.Windows.Forms.DataGridView();
            this.label16 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_team_name = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.data_end = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.data_start = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_UIUX_hours = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_developer_hours = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_QI_houers = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_customer_name = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_projName = new System.Windows.Forms.TextBox();
            this.btn_addProject = new System.Windows.Forms.Button();
            this.pnl_add_worker = new System.Windows.Forms.Panel();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.txt_user_name = new System.Windows.Forms.TextBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmb_manager = new System.Windows.Forms.ComboBox();
            this.cmb_job = new System.Windows.Forms.ComboBox();
            this.btn_Action = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.pnl_add_project.SuspendLayout();
            this.pnl_report.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presence)).BeginInit();
            this.pnl_delete.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddWorkers)).BeginInit();
            this.pnl_add_worker.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addProjectToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.userManagmentToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1149, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // addProjectToolStripMenuItem
            // 
            this.addProjectToolStripMenuItem.Name = "addProjectToolStripMenuItem";
            this.addProjectToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.addProjectToolStripMenuItem.Text = "Add project";
            this.addProjectToolStripMenuItem.Click += new System.EventHandler(this.addProjectToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byWorkerToolStripMenuItem,
            this.byProjectToolStripMenuItem,
            this.preToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // byWorkerToolStripMenuItem
            // 
            this.byWorkerToolStripMenuItem.Name = "byWorkerToolStripMenuItem";
            this.byWorkerToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.byWorkerToolStripMenuItem.Text = "by worker";
            this.byWorkerToolStripMenuItem.Click += new System.EventHandler(this.byWorkerToolStripMenuItem_Click);
            // 
            // byProjectToolStripMenuItem
            // 
            this.byProjectToolStripMenuItem.Name = "byProjectToolStripMenuItem";
            this.byProjectToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.byProjectToolStripMenuItem.Text = "by project";
            this.byProjectToolStripMenuItem.Click += new System.EventHandler(this.byProjectToolStripMenuItem_Click);
            // 
            // preToolStripMenuItem
            // 
            this.preToolStripMenuItem.Name = "preToolStripMenuItem";
            this.preToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.preToolStripMenuItem.Text = "presence";
            this.preToolStripMenuItem.Click += new System.EventHandler(this.preToolStripMenuItem_Click);
            // 
            // userManagmentToolStripMenuItem
            // 
            this.userManagmentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWorkerToolStripMenuItem,
            this.updateWorkerToolStripMenuItem,
            this.deleteWorkerToolStripMenuItem});
            this.userManagmentToolStripMenuItem.Name = "userManagmentToolStripMenuItem";
            this.userManagmentToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.userManagmentToolStripMenuItem.Text = "User managment";
            // 
            // addWorkerToolStripMenuItem
            // 
            this.addWorkerToolStripMenuItem.Name = "addWorkerToolStripMenuItem";
            this.addWorkerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.addWorkerToolStripMenuItem.Text = "Add worker";
            this.addWorkerToolStripMenuItem.Click += new System.EventHandler(this.addWorkerToolStripMenuItem_Click);
            // 
            // updateWorkerToolStripMenuItem
            // 
            this.updateWorkerToolStripMenuItem.Name = "updateWorkerToolStripMenuItem";
            this.updateWorkerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.updateWorkerToolStripMenuItem.Text = "Update worker";
            this.updateWorkerToolStripMenuItem.Click += new System.EventHandler(this.updateWorkerToolStripMenuItem_Click);
            // 
            // deleteWorkerToolStripMenuItem
            // 
            this.deleteWorkerToolStripMenuItem.Name = "deleteWorkerToolStripMenuItem";
            this.deleteWorkerToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.deleteWorkerToolStripMenuItem.Text = "Delete Worker";
            this.deleteWorkerToolStripMenuItem.Click += new System.EventHandler(this.deleteWorkerToolStripMenuItem_Click);
            // 
            // pnl_add_project
            // 
            this.pnl_add_project.Controls.Add(this.dgvAddWorkers);
            this.pnl_add_project.Controls.Add(this.label16);
            this.pnl_add_project.Controls.Add(this.label1);
            this.pnl_add_project.Controls.Add(this.label2);
            this.pnl_add_project.Controls.Add(this.txt_team_name);
            this.pnl_add_project.Controls.Add(this.label3);
            this.pnl_add_project.Controls.Add(this.data_end);
            this.pnl_add_project.Controls.Add(this.label4);
            this.pnl_add_project.Controls.Add(this.data_start);
            this.pnl_add_project.Controls.Add(this.label5);
            this.pnl_add_project.Controls.Add(this.txt_UIUX_hours);
            this.pnl_add_project.Controls.Add(this.label6);
            this.pnl_add_project.Controls.Add(this.txt_developer_hours);
            this.pnl_add_project.Controls.Add(this.label7);
            this.pnl_add_project.Controls.Add(this.txt_QI_houers);
            this.pnl_add_project.Controls.Add(this.label8);
            this.pnl_add_project.Controls.Add(this.txt_customer_name);
            this.pnl_add_project.Controls.Add(this.label9);
            this.pnl_add_project.Controls.Add(this.txt_projName);
            this.pnl_add_project.Controls.Add(this.btn_addProject);
            this.pnl_add_project.Controls.Add(this.pnl_delete);
            this.pnl_add_project.Location = new System.Drawing.Point(18, 36);
            this.pnl_add_project.Name = "pnl_add_project";
            this.pnl_add_project.Size = new System.Drawing.Size(1113, 517);
            this.pnl_add_project.TabIndex = 5;
            this.pnl_add_project.Visible = false;
            // 
            // pnl_report
            // 
            this.pnl_report.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_report.Controls.Add(this.dgv_presence);
            this.pnl_report.Controls.Add(this.button1);
            this.pnl_report.Controls.Add(this.treeView1);
            this.pnl_report.Location = new System.Drawing.Point(21, 33);
            this.pnl_report.Name = "pnl_report";
            this.pnl_report.Size = new System.Drawing.Size(1119, 517);
            this.pnl_report.TabIndex = 6;
            this.pnl_report.Visible = false;
            // 
            // dgv_presence
            // 
            this.dgv_presence.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_presence.Location = new System.Drawing.Point(32, 65);
            this.dgv_presence.Name = "dgv_presence";
            this.dgv_presence.Size = new System.Drawing.Size(1045, 421);
            this.dgv_presence.TabIndex = 4;
            this.dgv_presence.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(54, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "export to excel";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.AllowDrop = true;
            this.treeView1.BackColor = System.Drawing.SystemColors.Control;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.treeView1.Location = new System.Drawing.Point(28, 63);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(1050, 424);
            this.treeView1.TabIndex = 2;
            this.treeView1.Visible = false;
            // 
            // pnl_delete
            // 
            this.pnl_delete.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_delete.Controls.Add(this.panelControlls);
            this.pnl_delete.Location = new System.Drawing.Point(3, 3);
            this.pnl_delete.Name = "pnl_delete";
            this.pnl_delete.Size = new System.Drawing.Size(1097, 495);
            this.pnl_delete.TabIndex = 40;
            this.pnl_delete.Visible = false;
            // 
            // panelControlls
            // 
            this.panelControlls.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelControlls.Location = new System.Drawing.Point(244, 100);
            this.panelControlls.Name = "panelControlls";
            this.panelControlls.Size = new System.Drawing.Size(532, 218);
            this.panelControlls.TabIndex = 7;
            // 
            // dgvAddWorkers
            // 
            this.dgvAddWorkers.BackgroundColor = System.Drawing.Color.DarkGray;
            this.dgvAddWorkers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAddWorkers.GridColor = System.Drawing.Color.DarkGray;
            this.dgvAddWorkers.Location = new System.Drawing.Point(482, 92);
            this.dgvAddWorkers.Name = "dgvAddWorkers";
            this.dgvAddWorkers.Size = new System.Drawing.Size(185, 168);
            this.dgvAddWorkers.TabIndex = 38;
            this.dgvAddWorkers.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAddWorkers_RowHeaderMouseClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(521, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(68, 13);
            this.label16.TabIndex = 37;
            this.label16.Text = "add workers:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "ADD PROJECT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Project name";
            // 
            // txt_team_name
            // 
            this.txt_team_name.FormattingEnabled = true;
            this.txt_team_name.Location = new System.Drawing.Point(141, 103);
            this.txt_team_name.Name = "txt_team_name";
            this.txt_team_name.Size = new System.Drawing.Size(121, 21);
            this.txt_team_name.TabIndex = 36;
            this.txt_team_name.SelectedIndexChanged += new System.EventHandler(this.txt_team_name_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Customur name";
            // 
            // data_end
            // 
            this.data_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_end.Location = new System.Drawing.Point(141, 240);
            this.data_end.Name = "data_end";
            this.data_end.Size = new System.Drawing.Size(200, 20);
            this.data_end.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 22;
            this.label4.Text = "TeamLeader name";
            // 
            // data_start
            // 
            this.data_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.data_start.Location = new System.Drawing.Point(141, 212);
            this.data_start.Name = "data_start";
            this.data_start.Size = new System.Drawing.Size(200, 20);
            this.data_start.TabIndex = 34;
            this.data_start.ValueChanged += new System.EventHandler(this.data_start_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hours to QA";
            // 
            // txt_UIUX_hours
            // 
            this.txt_UIUX_hours.Location = new System.Drawing.Point(141, 188);
            this.txt_UIUX_hours.Name = "txt_UIUX_hours";
            this.txt_UIUX_hours.Size = new System.Drawing.Size(100, 20);
            this.txt_UIUX_hours.TabIndex = 33;
            this.txt_UIUX_hours.TextChanged += new System.EventHandler(this.checkProjectValidation);
            this.txt_UIUX_hours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyNumbers);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Hours to developer";
            // 
            // txt_developer_hours
            // 
            this.txt_developer_hours.Location = new System.Drawing.Point(141, 161);
            this.txt_developer_hours.Name = "txt_developer_hours";
            this.txt_developer_hours.Size = new System.Drawing.Size(100, 20);
            this.txt_developer_hours.TabIndex = 32;
            this.txt_developer_hours.TextChanged += new System.EventHandler(this.checkProjectValidation);
            this.txt_developer_hours.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyNumbers);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Hours to UI/UX";
            // 
            // txt_QI_houers
            // 
            this.txt_QI_houers.Location = new System.Drawing.Point(141, 134);
            this.txt_QI_houers.Name = "txt_QI_houers";
            this.txt_QI_houers.Size = new System.Drawing.Size(100, 20);
            this.txt_QI_houers.TabIndex = 31;
            this.txt_QI_houers.TextChanged += new System.EventHandler(this.checkProjectValidation);
            this.txt_QI_houers.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.onlyNumbers);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 212);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Start date";
            // 
            // txt_customer_name
            // 
            this.txt_customer_name.Location = new System.Drawing.Point(141, 77);
            this.txt_customer_name.Name = "txt_customer_name";
            this.txt_customer_name.Size = new System.Drawing.Size(100, 20);
            this.txt_customer_name.TabIndex = 30;
            this.txt_customer_name.TextChanged += new System.EventHandler(this.checkProjectValidation);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 27;
            this.label9.Text = "End date";
            // 
            // txt_projName
            // 
            this.txt_projName.Location = new System.Drawing.Point(141, 49);
            this.txt_projName.Name = "txt_projName";
            this.txt_projName.Size = new System.Drawing.Size(100, 20);
            this.txt_projName.TabIndex = 29;
            this.txt_projName.TextChanged += new System.EventHandler(this.checkProjectValidation);
            // 
            // btn_addProject
            // 
            this.btn_addProject.Location = new System.Drawing.Point(247, 275);
            this.btn_addProject.Name = "btn_addProject";
            this.btn_addProject.Size = new System.Drawing.Size(75, 23);
            this.btn_addProject.TabIndex = 28;
            this.btn_addProject.Text = "ADD";
            this.btn_addProject.UseVisualStyleBackColor = true;
            this.btn_addProject.Click += new System.EventHandler(this.btn_addProject_Click);
            // 
            // pnl_add_worker
            // 
            this.pnl_add_worker.BackColor = System.Drawing.SystemColors.Control;
            this.pnl_add_worker.Controls.Add(this.txt_password);
            this.pnl_add_worker.Controls.Add(this.txt_email);
            this.pnl_add_worker.Controls.Add(this.txt_user_name);
            this.pnl_add_worker.Controls.Add(this.txt_name);
            this.pnl_add_worker.Controls.Add(this.lblPassword);
            this.pnl_add_worker.Controls.Add(this.cmb_manager);
            this.pnl_add_worker.Controls.Add(this.cmb_job);
            this.pnl_add_worker.Controls.Add(this.btn_Action);
            this.pnl_add_worker.Controls.Add(this.label10);
            this.pnl_add_worker.Controls.Add(this.label11);
            this.pnl_add_worker.Controls.Add(this.label12);
            this.pnl_add_worker.Controls.Add(this.label14);
            this.pnl_add_worker.Controls.Add(this.label15);
            this.pnl_add_worker.Controls.Add(this.lblTitle);
            this.pnl_add_worker.Location = new System.Drawing.Point(18, 36);
            this.pnl_add_worker.Name = "pnl_add_worker";
            this.pnl_add_worker.Size = new System.Drawing.Size(1110, 511);
            this.pnl_add_worker.TabIndex = 42;
            this.pnl_add_worker.Visible = false;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(249, 291);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(100, 20);
            this.txt_password.TabIndex = 65;
            this.txt_password.TextChanged += new System.EventHandler(this.checkWorkerValidation);
            // 
            // txt_email
            // 
            this.txt_email.Location = new System.Drawing.Point(249, 208);
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(100, 20);
            this.txt_email.TabIndex = 61;
            this.txt_email.TextChanged += new System.EventHandler(this.checkWorkerValidation);
            // 
            // txt_user_name
            // 
            this.txt_user_name.Location = new System.Drawing.Point(249, 182);
            this.txt_user_name.Name = "txt_user_name";
            this.txt_user_name.Size = new System.Drawing.Size(100, 20);
            this.txt_user_name.TabIndex = 60;
            this.txt_user_name.TextChanged += new System.EventHandler(this.checkWorkerValidation);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(249, 154);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 20);
            this.txt_name.TabIndex = 59;
            this.txt_name.TextChanged += new System.EventHandler(this.checkWorkerValidation);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(124, 291);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 64;
            this.lblPassword.Text = "Password";
            // 
            // cmb_manager
            // 
            this.cmb_manager.FormattingEnabled = true;
            this.cmb_manager.Location = new System.Drawing.Point(249, 263);
            this.cmb_manager.Name = "cmb_manager";
            this.cmb_manager.Size = new System.Drawing.Size(100, 21);
            this.cmb_manager.TabIndex = 63;
            // 
            // cmb_job
            // 
            this.cmb_job.FormattingEnabled = true;
            this.cmb_job.Location = new System.Drawing.Point(249, 235);
            this.cmb_job.Name = "cmb_job";
            this.cmb_job.Size = new System.Drawing.Size(100, 21);
            this.cmb_job.TabIndex = 62;
            // 
            // btn_Action
            // 
            this.btn_Action.Location = new System.Drawing.Point(269, 336);
            this.btn_Action.Name = "btn_Action";
            this.btn_Action.Size = new System.Drawing.Size(75, 23);
            this.btn_Action.TabIndex = 58;
            this.btn_Action.UseVisualStyleBackColor = true;
            this.btn_Action.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(124, 261);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 13);
            this.label10.TabIndex = 57;
            this.label10.Text = "Manager";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(124, 234);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 13);
            this.label11.TabIndex = 56;
            this.label11.Text = "Job";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(124, 207);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 13);
            this.label12.TabIndex = 55;
            this.label12.Text = "E-mail";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(124, 182);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "User name";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(124, 154);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(35, 13);
            this.label15.TabIndex = 53;
            this.label15.Text = "Name";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(202, 120);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 13);
            this.lblTitle.TabIndex = 52;
            // 
            // ManagerHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 592);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnl_report);
            this.Controls.Add(this.pnl_add_project);
            this.Controls.Add(this.pnl_add_worker);
            this.Name = "ManagerHome";
            this.Text = "Manager";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnl_add_project.ResumeLayout(false);
            this.pnl_add_project.PerformLayout();
            this.pnl_report.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_presence)).EndInit();
            this.pnl_delete.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAddWorkers)).EndInit();
            this.pnl_add_worker.ResumeLayout(false);
            this.pnl_add_worker.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dgvAddWorkers;
        private System.Windows.Forms.Label label16;
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
        private System.Windows.Forms.Panel pnl_add_project;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem byProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userManagmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateWorkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteWorkerToolStripMenuItem;
        private System.Windows.Forms.Panel pnl_report;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel pnl_delete;
        private System.Windows.Forms.Panel panelControlls;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel pnl_add_worker;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.TextBox txt_user_name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmb_manager;
        private System.Windows.Forms.ComboBox cmb_job;
        private System.Windows.Forms.Button btn_Action;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnExportToExecl;
        private System.Windows.Forms.DataGridView dgv_presence;
    }
}