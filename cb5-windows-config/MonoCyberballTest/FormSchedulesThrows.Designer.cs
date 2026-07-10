namespace MonoCyberball
{
    partial class FormSchedulesThrows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSchedulesThrows));
            this.btnNewMessage = new System.Windows.Forms.Button();
            this.btnMoveThrowDown = new System.Windows.Forms.Button();
            this.btnMoveThrowUp = new System.Windows.Forms.Button();
            this.gbScheduleGeneration = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.ddlVictim = new System.Windows.Forms.ComboBox();
            this.lblVictim = new System.Windows.Forms.Label();
            this.txtGenSchedThrowCount = new System.Windows.Forms.NumericUpDown();
            this.ddlGenSchedType = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnGenerateSchedule = new System.Windows.Forms.Button();
            this.btnSaveSchedule = new System.Windows.Forms.Button();
            this.btnThrow = new System.Windows.Forms.Button();
            this.btnNewThrow = new System.Windows.Forms.Button();
            this.btnNewSchedule = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.lbThrows = new System.Windows.Forms.ListBox();
            this.cmThrows = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNewThrow = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNewMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEditThrowMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDeleteThrowMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.cmMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.lbSchedules = new System.Windows.Forms.ListBox();
            this.cmSchedules = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmNewSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmEditSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.cmDeleteSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pbPlayerPositions = new System.Windows.Forms.PictureBox();
            this.btnDeleteSchedule = new System.Windows.Forms.Button();
            this.btnEditSchedule = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.schedulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteSchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.throwsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewThrowParent = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewThrow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNewMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditThrowMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDeleteThrowMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenSchedule = new System.Windows.Forms.Button();
            this.btnDeleteThrowMessage = new System.Windows.Forms.Button();
            this.dialogSaveSched = new System.Windows.Forms.SaveFileDialog();
            this.dialogOpenSched = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMaxThrows = new System.Windows.Forms.Label();
            this.lblSchedThrows = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDeprecatedThrows = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblIdealThrowCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.gbScheduleGeneration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenSchedThrowCount)).BeginInit();
            this.cmThrows.SuspendLayout();
            this.cmSchedules.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPositions)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNewMessage
            // 
            this.btnNewMessage.Location = new System.Drawing.Point(517, 300);
            this.btnNewMessage.Name = "btnNewMessage";
            this.btnNewMessage.Size = new System.Drawing.Size(68, 37);
            this.btnNewMessage.TabIndex = 23;
            this.btnNewMessage.Text = "New Message";
            this.btnNewMessage.UseVisualStyleBackColor = true;
            this.btnNewMessage.Click += new System.EventHandler(this.btnNewMessage_Click);
            // 
            // btnMoveThrowDown
            // 
            this.btnMoveThrowDown.Location = new System.Drawing.Point(591, 68);
            this.btnMoveThrowDown.Name = "btnMoveThrowDown";
            this.btnMoveThrowDown.Size = new System.Drawing.Size(96, 32);
            this.btnMoveThrowDown.TabIndex = 22;
            this.btnMoveThrowDown.Text = "Move Down";
            this.btnMoveThrowDown.UseVisualStyleBackColor = true;
            this.btnMoveThrowDown.Click += new System.EventHandler(this.btnMoveThrowDown_Click);
            // 
            // btnMoveThrowUp
            // 
            this.btnMoveThrowUp.Location = new System.Drawing.Point(591, 30);
            this.btnMoveThrowUp.Name = "btnMoveThrowUp";
            this.btnMoveThrowUp.Size = new System.Drawing.Size(96, 32);
            this.btnMoveThrowUp.TabIndex = 21;
            this.btnMoveThrowUp.Text = "Move Up";
            this.btnMoveThrowUp.UseVisualStyleBackColor = true;
            this.btnMoveThrowUp.Click += new System.EventHandler(this.btnMoveThrowUp_Click);
            // 
            // gbScheduleGeneration
            // 
            this.gbScheduleGeneration.Controls.Add(this.label18);
            this.gbScheduleGeneration.Controls.Add(this.ddlVictim);
            this.gbScheduleGeneration.Controls.Add(this.lblVictim);
            this.gbScheduleGeneration.Controls.Add(this.txtGenSchedThrowCount);
            this.gbScheduleGeneration.Controls.Add(this.ddlGenSchedType);
            this.gbScheduleGeneration.Controls.Add(this.label17);
            this.gbScheduleGeneration.Controls.Add(this.label16);
            this.gbScheduleGeneration.Controls.Add(this.btnGenerateSchedule);
            this.gbScheduleGeneration.Location = new System.Drawing.Point(273, 42);
            this.gbScheduleGeneration.Name = "gbScheduleGeneration";
            this.gbScheduleGeneration.Size = new System.Drawing.Size(437, 155);
            this.gbScheduleGeneration.TabIndex = 20;
            this.gbScheduleGeneration.TabStop = false;
            this.gbScheduleGeneration.Text = "Generate Schedule";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(175, 91);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(203, 12);
            this.label18.TabIndex = 8;
            this.label18.Text = "The ball will be thrown at most once to the Target";
            // 
            // ddlVictim
            // 
            this.ddlVictim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlVictim.Enabled = false;
            this.ddlVictim.FormattingEnabled = true;
            this.ddlVictim.Location = new System.Drawing.Point(47, 84);
            this.ddlVictim.Name = "ddlVictim";
            this.ddlVictim.Size = new System.Drawing.Size(121, 21);
            this.ddlVictim.TabIndex = 7;
            // 
            // lblVictim
            // 
            this.lblVictim.AutoSize = true;
            this.lblVictim.Enabled = false;
            this.lblVictim.Location = new System.Drawing.Point(7, 87);
            this.lblVictim.Name = "lblVictim";
            this.lblVictim.Size = new System.Drawing.Size(41, 13);
            this.lblVictim.TabIndex = 6;
            this.lblVictim.Text = "Target:";
            // 
            // txtGenSchedThrowCount
            // 
            this.txtGenSchedThrowCount.Location = new System.Drawing.Point(301, 38);
            this.txtGenSchedThrowCount.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.txtGenSchedThrowCount.Name = "txtGenSchedThrowCount";
            this.txtGenSchedThrowCount.Size = new System.Drawing.Size(120, 20);
            this.txtGenSchedThrowCount.TabIndex = 5;
            this.txtGenSchedThrowCount.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // ddlGenSchedType
            // 
            this.ddlGenSchedType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlGenSchedType.FormattingEnabled = true;
            this.ddlGenSchedType.Location = new System.Drawing.Point(47, 37);
            this.ddlGenSchedType.Name = "ddlGenSchedType";
            this.ddlGenSchedType.Size = new System.Drawing.Size(121, 21);
            this.ddlGenSchedType.TabIndex = 4;
            this.ddlGenSchedType.SelectedIndexChanged += new System.EventHandler(this.ddlGenSchedType_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(218, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(77, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "No. of Throws:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "Type:";
            // 
            // btnGenerateSchedule
            // 
            this.btnGenerateSchedule.Location = new System.Drawing.Point(181, 117);
            this.btnGenerateSchedule.Name = "btnGenerateSchedule";
            this.btnGenerateSchedule.Size = new System.Drawing.Size(75, 32);
            this.btnGenerateSchedule.TabIndex = 0;
            this.btnGenerateSchedule.Text = "Generate";
            this.btnGenerateSchedule.UseVisualStyleBackColor = true;
            this.btnGenerateSchedule.Click += new System.EventHandler(this.btnGenerateSchedule_Click);
            // 
            // btnSaveSchedule
            // 
            this.btnSaveSchedule.Location = new System.Drawing.Point(195, 68);
            this.btnSaveSchedule.Name = "btnSaveSchedule";
            this.btnSaveSchedule.Size = new System.Drawing.Size(96, 32);
            this.btnSaveSchedule.TabIndex = 19;
            this.btnSaveSchedule.Text = "Save Schedule";
            this.btnSaveSchedule.UseVisualStyleBackColor = true;
            this.btnSaveSchedule.Click += new System.EventHandler(this.btnSaveSchedule_Click);
            // 
            // btnThrow
            // 
            this.btnThrow.Location = new System.Drawing.Point(591, 224);
            this.btnThrow.Name = "btnThrow";
            this.btnThrow.Size = new System.Drawing.Size(96, 32);
            this.btnThrow.TabIndex = 18;
            this.btnThrow.Text = "Edit";
            this.btnThrow.UseVisualStyleBackColor = true;
            this.btnThrow.Click += new System.EventHandler(this.btnThrow_Click);
            // 
            // btnNewThrow
            // 
            this.btnNewThrow.Location = new System.Drawing.Point(431, 300);
            this.btnNewThrow.Name = "btnNewThrow";
            this.btnNewThrow.Size = new System.Drawing.Size(68, 37);
            this.btnNewThrow.TabIndex = 17;
            this.btnNewThrow.Text = "New Throw";
            this.btnNewThrow.UseVisualStyleBackColor = true;
            this.btnNewThrow.Click += new System.EventHandler(this.btnNewThrow_Click);
            // 
            // btnNewSchedule
            // 
            this.btnNewSchedule.Location = new System.Drawing.Point(34, 305);
            this.btnNewSchedule.Name = "btnNewSchedule";
            this.btnNewSchedule.Size = new System.Drawing.Size(155, 32);
            this.btnNewSchedule.TabIndex = 16;
            this.btnNewSchedule.Text = "New Schedule";
            this.btnNewSchedule.UseVisualStyleBackColor = true;
            this.btnNewSchedule.Click += new System.EventHandler(this.btnNewSchedule_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(265, -120);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 15);
            this.label13.TabIndex = 15;
            this.label13.Text = "Throws";
            // 
            // lbThrows
            // 
            this.lbThrows.ContextMenuStrip = this.cmThrows;
            this.lbThrows.FormattingEnabled = true;
            this.lbThrows.Location = new System.Drawing.Point(431, 30);
            this.lbThrows.Name = "lbThrows";
            this.lbThrows.Size = new System.Drawing.Size(154, 264);
            this.lbThrows.TabIndex = 13;
            this.lbThrows.SelectedIndexChanged += new System.EventHandler(this.lbThrows_SelectedIndexChanged);
            this.lbThrows.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbThrows_MouseDoubleClick);
            // 
            // cmThrows
            // 
            this.cmThrows.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem1,
            this.cmEditThrowMessage,
            this.cmDeleteThrowMessage,
            this.toolStripSeparator1,
            this.cmMoveUp,
            this.cmMoveDown});
            this.cmThrows.Name = "cmThrows";
            this.cmThrows.Size = new System.Drawing.Size(236, 120);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNewThrow,
            this.cmNewMessage});
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(235, 22);
            this.newToolStripMenuItem1.Text = "New";
            // 
            // cmNewThrow
            // 
            this.cmNewThrow.Name = "cmNewThrow";
            this.cmNewThrow.Size = new System.Drawing.Size(120, 22);
            this.cmNewThrow.Text = "Throw";
            this.cmNewThrow.Click += new System.EventHandler(this.throwToolStripMenuItem_Click);
            // 
            // cmNewMessage
            // 
            this.cmNewMessage.Name = "cmNewMessage";
            this.cmNewMessage.Size = new System.Drawing.Size(120, 22);
            this.cmNewMessage.Text = "Message";
            this.cmNewMessage.Click += new System.EventHandler(this.cmNewMessage_Click);
            // 
            // cmEditThrowMessage
            // 
            this.cmEditThrowMessage.Name = "cmEditThrowMessage";
            this.cmEditThrowMessage.Size = new System.Drawing.Size(235, 22);
            this.cmEditThrowMessage.Text = "Edit";
            this.cmEditThrowMessage.Click += new System.EventHandler(this.cmEditThrowMessage_Click);
            // 
            // cmDeleteThrowMessage
            // 
            this.cmDeleteThrowMessage.Name = "cmDeleteThrowMessage";
            this.cmDeleteThrowMessage.Size = new System.Drawing.Size(235, 22);
            this.cmDeleteThrowMessage.Text = "Delete";
            this.cmDeleteThrowMessage.Click += new System.EventHandler(this.cmDeleteThrowMessage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(232, 6);
            // 
            // cmMoveUp
            // 
            this.cmMoveUp.Name = "cmMoveUp";
            this.cmMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Up)));
            this.cmMoveUp.Size = new System.Drawing.Size(235, 22);
            this.cmMoveUp.Text = "Move Up";
            this.cmMoveUp.Click += new System.EventHandler(this.cmMoveUp_Click);
            // 
            // cmMoveDown
            // 
            this.cmMoveDown.Name = "cmMoveDown";
            this.cmMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.cmMoveDown.Size = new System.Drawing.Size(235, 22);
            this.cmMoveDown.Text = "Move Down";
            this.cmMoveDown.Click += new System.EventHandler(this.cmMoveDown_Click);
            // 
            // lbSchedules
            // 
            this.lbSchedules.ContextMenuStrip = this.cmSchedules;
            this.lbSchedules.FormattingEnabled = true;
            this.lbSchedules.Location = new System.Drawing.Point(35, 30);
            this.lbSchedules.Name = "lbSchedules";
            this.lbSchedules.Size = new System.Drawing.Size(154, 264);
            this.lbSchedules.TabIndex = 12;
            this.lbSchedules.SelectedIndexChanged += new System.EventHandler(this.lbSchedules_SelectedIndexChanged);
            // 
            // cmSchedules
            // 
            this.cmSchedules.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNewSchedule,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.cmEditSchedule,
            this.cmDeleteSchedule});
            this.cmSchedules.Name = "cmSchedules";
            this.cmSchedules.Size = new System.Drawing.Size(108, 114);
            // 
            // cmNewSchedule
            // 
            this.cmNewSchedule.Name = "cmNewSchedule";
            this.cmNewSchedule.Size = new System.Drawing.Size(107, 22);
            this.cmNewSchedule.Text = "New";
            this.cmNewSchedule.Click += new System.EventHandler(this.cmNewSchedule_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // cmEditSchedule
            // 
            this.cmEditSchedule.Name = "cmEditSchedule";
            this.cmEditSchedule.Size = new System.Drawing.Size(107, 22);
            this.cmEditSchedule.Text = "Edit";
            this.cmEditSchedule.Click += new System.EventHandler(this.cmEditSchedule_Click);
            // 
            // cmDeleteSchedule
            // 
            this.cmDeleteSchedule.Name = "cmDeleteSchedule";
            this.cmDeleteSchedule.Size = new System.Drawing.Size(107, 22);
            this.cmDeleteSchedule.Text = "Delete";
            this.cmDeleteSchedule.Click += new System.EventHandler(this.cmDeleteSchedule_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pbPlayerPositions);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 155);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player Positions";
            // 
            // pbPlayerPositions
            // 
            this.pbPlayerPositions.Image = ((System.Drawing.Image)(resources.GetObject("pbPlayerPositions.Image")));
            this.pbPlayerPositions.Location = new System.Drawing.Point(7, 20);
            this.pbPlayerPositions.Name = "pbPlayerPositions";
            this.pbPlayerPositions.Size = new System.Drawing.Size(226, 129);
            this.pbPlayerPositions.TabIndex = 0;
            this.pbPlayerPositions.TabStop = false;
            // 
            // btnDeleteSchedule
            // 
            this.btnDeleteSchedule.Location = new System.Drawing.Point(195, 262);
            this.btnDeleteSchedule.Name = "btnDeleteSchedule";
            this.btnDeleteSchedule.Size = new System.Drawing.Size(96, 32);
            this.btnDeleteSchedule.TabIndex = 25;
            this.btnDeleteSchedule.Text = "Delete Schedule";
            this.btnDeleteSchedule.UseVisualStyleBackColor = true;
            this.btnDeleteSchedule.Click += new System.EventHandler(this.btnDeleteSchedule_Click);
            // 
            // btnEditSchedule
            // 
            this.btnEditSchedule.Location = new System.Drawing.Point(195, 224);
            this.btnEditSchedule.Name = "btnEditSchedule";
            this.btnEditSchedule.Size = new System.Drawing.Size(96, 32);
            this.btnEditSchedule.TabIndex = 26;
            this.btnEditSchedule.Text = "Edit Schedule";
            this.btnEditSchedule.UseVisualStyleBackColor = true;
            this.btnEditSchedule.Click += new System.EventHandler(this.btnEditSchedule_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.schedulesToolStripMenuItem,
            this.throwsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(724, 24);
            this.menuStrip1.TabIndex = 27;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // schedulesToolStripMenuItem
            // 
            this.schedulesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewSchedule,
            this.openToolStripMenuItem1,
            this.saveToolStripMenuItem1,
            this.mnuEditSchedule,
            this.mnuDeleteSchedule});
            this.schedulesToolStripMenuItem.Name = "schedulesToolStripMenuItem";
            this.schedulesToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.schedulesToolStripMenuItem.Text = "Schedule";
            // 
            // mnuNewSchedule
            // 
            this.mnuNewSchedule.Name = "mnuNewSchedule";
            this.mnuNewSchedule.Size = new System.Drawing.Size(107, 22);
            this.mnuNewSchedule.Text = "New";
            this.mnuNewSchedule.Click += new System.EventHandler(this.mnuNewSchedule_Click);
            // 
            // openToolStripMenuItem1
            // 
            this.openToolStripMenuItem1.Name = "openToolStripMenuItem1";
            this.openToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.openToolStripMenuItem1.Text = "Open";
            this.openToolStripMenuItem1.Click += new System.EventHandler(this.openToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // mnuEditSchedule
            // 
            this.mnuEditSchedule.Name = "mnuEditSchedule";
            this.mnuEditSchedule.Size = new System.Drawing.Size(107, 22);
            this.mnuEditSchedule.Text = "Edit";
            this.mnuEditSchedule.Click += new System.EventHandler(this.mnuEditSchedule_Click);
            // 
            // mnuDeleteSchedule
            // 
            this.mnuDeleteSchedule.Name = "mnuDeleteSchedule";
            this.mnuDeleteSchedule.Size = new System.Drawing.Size(107, 22);
            this.mnuDeleteSchedule.Text = "Delete";
            this.mnuDeleteSchedule.Click += new System.EventHandler(this.mnuDeleteSchedule_Click);
            // 
            // throwsToolStripMenuItem
            // 
            this.throwsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewThrowParent,
            this.mnuEditThrowMessage,
            this.mnuDeleteThrowMessage,
            this.toolStripSeparator2,
            this.mnuMoveUp,
            this.mnuMoveDown});
            this.throwsToolStripMenuItem.Name = "throwsToolStripMenuItem";
            this.throwsToolStripMenuItem.Size = new System.Drawing.Size(110, 20);
            this.throwsToolStripMenuItem.Text = "Throw / Message";
            // 
            // mnuNewThrowParent
            // 
            this.mnuNewThrowParent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNewThrow,
            this.mnuNewMessage});
            this.mnuNewThrowParent.Name = "mnuNewThrowParent";
            this.mnuNewThrowParent.Size = new System.Drawing.Size(235, 22);
            this.mnuNewThrowParent.Text = "New";
            // 
            // mnuNewThrow
            // 
            this.mnuNewThrow.Name = "mnuNewThrow";
            this.mnuNewThrow.Size = new System.Drawing.Size(120, 22);
            this.mnuNewThrow.Text = "Throw";
            this.mnuNewThrow.Click += new System.EventHandler(this.mnuNewThrow_Click_1);
            // 
            // mnuNewMessage
            // 
            this.mnuNewMessage.Name = "mnuNewMessage";
            this.mnuNewMessage.Size = new System.Drawing.Size(120, 22);
            this.mnuNewMessage.Text = "Message";
            this.mnuNewMessage.Click += new System.EventHandler(this.mnuNewMessage_Click);
            // 
            // mnuEditThrowMessage
            // 
            this.mnuEditThrowMessage.Name = "mnuEditThrowMessage";
            this.mnuEditThrowMessage.Size = new System.Drawing.Size(235, 22);
            this.mnuEditThrowMessage.Text = "Edit";
            this.mnuEditThrowMessage.Click += new System.EventHandler(this.mnuEditThrowMessage_Click);
            // 
            // mnuDeleteThrowMessage
            // 
            this.mnuDeleteThrowMessage.Name = "mnuDeleteThrowMessage";
            this.mnuDeleteThrowMessage.Size = new System.Drawing.Size(235, 22);
            this.mnuDeleteThrowMessage.Text = "Delete";
            this.mnuDeleteThrowMessage.Click += new System.EventHandler(this.mnuDeleteThrowMessage_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(232, 6);
            // 
            // mnuMoveUp
            // 
            this.mnuMoveUp.Name = "mnuMoveUp";
            this.mnuMoveUp.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Up)));
            this.mnuMoveUp.Size = new System.Drawing.Size(235, 22);
            this.mnuMoveUp.Text = "Move Up";
            this.mnuMoveUp.Click += new System.EventHandler(this.mnuMoveUp_Click);
            // 
            // mnuMoveDown
            // 
            this.mnuMoveDown.Name = "mnuMoveDown";
            this.mnuMoveDown.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Down)));
            this.mnuMoveDown.Size = new System.Drawing.Size(235, 22);
            this.mnuMoveDown.Text = "Move Down";
            this.mnuMoveDown.Click += new System.EventHandler(this.mnuMoveDown_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btnOpenSchedule);
            this.groupBox2.Controls.Add(this.btnDeleteThrowMessage);
            this.groupBox2.Controls.Add(this.lbSchedules);
            this.groupBox2.Controls.Add(this.lbThrows);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btnEditSchedule);
            this.groupBox2.Controls.Add(this.btnNewSchedule);
            this.groupBox2.Controls.Add(this.btnDeleteSchedule);
            this.groupBox2.Controls.Add(this.btnNewThrow);
            this.groupBox2.Controls.Add(this.btnThrow);
            this.groupBox2.Controls.Add(this.btnNewMessage);
            this.groupBox2.Controls.Add(this.btnSaveSchedule);
            this.groupBox2.Controls.Add(this.btnMoveThrowDown);
            this.groupBox2.Controls.Add(this.btnMoveThrowUp);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(698, 343);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Schedules && Throws";
            // 
            // btnOpenSchedule
            // 
            this.btnOpenSchedule.Location = new System.Drawing.Point(195, 30);
            this.btnOpenSchedule.Name = "btnOpenSchedule";
            this.btnOpenSchedule.Size = new System.Drawing.Size(96, 32);
            this.btnOpenSchedule.TabIndex = 28;
            this.btnOpenSchedule.Text = "Open Schedule";
            this.btnOpenSchedule.UseVisualStyleBackColor = true;
            this.btnOpenSchedule.Click += new System.EventHandler(this.btnOpenSchedule_Click);
            // 
            // btnDeleteThrowMessage
            // 
            this.btnDeleteThrowMessage.Location = new System.Drawing.Point(591, 262);
            this.btnDeleteThrowMessage.Name = "btnDeleteThrowMessage";
            this.btnDeleteThrowMessage.Size = new System.Drawing.Size(96, 32);
            this.btnDeleteThrowMessage.TabIndex = 27;
            this.btnDeleteThrowMessage.Text = "Delete";
            this.btnDeleteThrowMessage.UseVisualStyleBackColor = true;
            this.btnDeleteThrowMessage.Click += new System.EventHandler(this.btnDeleteThrowMessage_Click);
            // 
            // dialogSaveSched
            // 
            this.dialogSaveSched.DefaultExt = "cbs";
            this.dialogSaveSched.Filter = "Cyberball Schedule | *.cbs";
            // 
            // dialogOpenSched
            // 
            this.dialogOpenSched.DefaultExt = "cbs";
            this.dialogOpenSched.Filter = "Cyberball Schedule | *.cbs";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblIdealThrowCount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblDeprecatedThrows);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblSchedThrows);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblMaxThrows);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(297, 30);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 226);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Info";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Max throws";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaxThrows
            // 
            this.lblMaxThrows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaxThrows.AutoSize = true;
            this.lblMaxThrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxThrows.Location = new System.Drawing.Point(56, 41);
            this.lblMaxThrows.Name = "lblMaxThrows";
            this.lblMaxThrows.Size = new System.Drawing.Size(16, 17);
            this.lblMaxThrows.TabIndex = 1;
            this.lblMaxThrows.Text = "0";
            this.lblMaxThrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSchedThrows
            // 
            this.lblSchedThrows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSchedThrows.AutoSize = true;
            this.lblSchedThrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchedThrows.Location = new System.Drawing.Point(56, 90);
            this.lblSchedThrows.Name = "lblSchedThrows";
            this.lblSchedThrows.Size = new System.Drawing.Size(16, 17);
            this.lblSchedThrows.TabIndex = 3;
            this.lblSchedThrows.Text = "0";
            this.lblSchedThrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Throws in schedule";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDeprecatedThrows
            // 
            this.lblDeprecatedThrows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDeprecatedThrows.AutoSize = true;
            this.lblDeprecatedThrows.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeprecatedThrows.Location = new System.Drawing.Point(56, 139);
            this.lblDeprecatedThrows.Name = "lblDeprecatedThrows";
            this.lblDeprecatedThrows.Size = new System.Drawing.Size(16, 17);
            this.lblDeprecatedThrows.TabIndex = 5;
            this.lblDeprecatedThrows.Text = "0";
            this.lblDeprecatedThrows.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Deprecated throws";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblIdealThrowCount
            // 
            this.lblIdealThrowCount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblIdealThrowCount.AutoSize = true;
            this.lblIdealThrowCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdealThrowCount.Location = new System.Drawing.Point(56, 194);
            this.lblIdealThrowCount.Name = "lblIdealThrowCount";
            this.lblIdealThrowCount.Size = new System.Drawing.Size(16, 17);
            this.lblIdealThrowCount.TabIndex = 7;
            this.lblIdealThrowCount.Text = "0";
            this.lblIdealThrowCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Ideal throw count";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSchedulesThrows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 572);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbScheduleGeneration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormSchedulesThrows";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedules & Throws";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSchedulesThrows_FormClosing);
            this.Load += new System.EventHandler(this.FormSchedulesThrows_Load);
            this.gbScheduleGeneration.ResumeLayout(false);
            this.gbScheduleGeneration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGenSchedThrowCount)).EndInit();
            this.cmThrows.ResumeLayout(false);
            this.cmSchedules.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPlayerPositions)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNewMessage;
        private System.Windows.Forms.Button btnMoveThrowDown;
        private System.Windows.Forms.Button btnMoveThrowUp;
        private System.Windows.Forms.GroupBox gbScheduleGeneration;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox ddlVictim;
        private System.Windows.Forms.Label lblVictim;
        private System.Windows.Forms.NumericUpDown txtGenSchedThrowCount;
        private System.Windows.Forms.ComboBox ddlGenSchedType;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnGenerateSchedule;
        private System.Windows.Forms.Button btnSaveSchedule;
        private System.Windows.Forms.Button btnThrow;
        private System.Windows.Forms.Button btnNewThrow;
        private System.Windows.Forms.Button btnNewSchedule;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lbThrows;
        private System.Windows.Forms.ListBox lbSchedules;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pbPlayerPositions;
        private System.Windows.Forms.Button btnDeleteSchedule;
        private System.Windows.Forms.Button btnEditSchedule;
        private System.Windows.Forms.ContextMenuStrip cmSchedules;
        private System.Windows.Forms.ContextMenuStrip cmThrows;
        private System.Windows.Forms.ToolStripMenuItem cmNewSchedule;
        private System.Windows.Forms.ToolStripMenuItem cmEditSchedule;
        private System.Windows.Forms.ToolStripMenuItem cmDeleteSchedule;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cmNewThrow;
        private System.Windows.Forms.ToolStripMenuItem cmNewMessage;
        private System.Windows.Forms.ToolStripMenuItem cmEditThrowMessage;
        private System.Windows.Forms.ToolStripMenuItem cmDeleteThrowMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmMoveUp;
        private System.Windows.Forms.ToolStripMenuItem cmMoveDown;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem schedulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuEditSchedule;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteSchedule;
        private System.Windows.Forms.ToolStripMenuItem throwsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuNewThrowParent;
        private System.Windows.Forms.ToolStripMenuItem mnuEditThrowMessage;
        private System.Windows.Forms.ToolStripMenuItem mnuDeleteThrowMessage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem mnuNewThrow;
        private System.Windows.Forms.ToolStripMenuItem mnuNewMessage;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnDeleteThrowMessage;
        private System.Windows.Forms.SaveFileDialog dialogSaveSched;
        private System.Windows.Forms.OpenFileDialog dialogOpenSched;
        private System.Windows.Forms.Button btnOpenSchedule;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblMaxThrows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSchedThrows;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDeprecatedThrows;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblIdealThrowCount;
        private System.Windows.Forms.Label label5;
    }
}