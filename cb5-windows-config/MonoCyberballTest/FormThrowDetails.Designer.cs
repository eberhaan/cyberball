namespace MonoCyberball
{
    partial class FormThrowDetails
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
            this.ddlThrowTo = new System.Windows.Forms.ComboBox();
            this.txtThrowDelay = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnUpdateThrow = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThrowFrom = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtThrowName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbThrowDelayed = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtThrowDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // ddlThrowTo
            // 
            this.ddlThrowTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlThrowTo.FormattingEnabled = true;
            this.ddlThrowTo.Location = new System.Drawing.Point(116, 101);
            this.ddlThrowTo.Name = "ddlThrowTo";
            this.ddlThrowTo.Size = new System.Drawing.Size(121, 21);
            this.ddlThrowTo.TabIndex = 10;
            this.ddlThrowTo.SelectedIndexChanged += new System.EventHandler(this.ddlThrowTo_SelectedIndexChanged);
            // 
            // txtThrowDelay
            // 
            this.txtThrowDelay.Enabled = false;
            this.txtThrowDelay.Location = new System.Drawing.Point(116, 168);
            this.txtThrowDelay.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.txtThrowDelay.Name = "txtThrowDelay";
            this.txtThrowDelay.Size = new System.Drawing.Size(44, 20);
            this.txtThrowDelay.TabIndex = 11;
            this.txtThrowDelay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtThrowDelay.ValueChanged += new System.EventHandler(this.txtThrowDelay_ValueChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(66, 170);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Delay:";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 104);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Throw To:";
            this.label14.Click += new System.EventHandler(this.label14_Click);
            // 
            // btnUpdateThrow
            // 
            this.btnUpdateThrow.Location = new System.Drawing.Point(40, 212);
            this.btnUpdateThrow.Name = "btnUpdateThrow";
            this.btnUpdateThrow.Size = new System.Drawing.Size(212, 23);
            this.btnUpdateThrow.TabIndex = 12;
            this.btnUpdateThrow.Text = "Update Throw";
            this.btnUpdateThrow.UseVisualStyleBackColor = true;
            this.btnUpdateThrow.Click += new System.EventHandler(this.btnUpdateThrow_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Throw From:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblThrowFrom
            // 
            this.lblThrowFrom.AutoSize = true;
            this.lblThrowFrom.Location = new System.Drawing.Point(116, 66);
            this.lblThrowFrom.Name = "lblThrowFrom";
            this.lblThrowFrom.Size = new System.Drawing.Size(0, 13);
            this.lblThrowFrom.TabIndex = 14;
            this.lblThrowFrom.Click += new System.EventHandler(this.lblThrowFrom_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Name:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtThrowName
            // 
            this.txtThrowName.Location = new System.Drawing.Point(116, 35);
            this.txtThrowName.Name = "txtThrowName";
            this.txtThrowName.Size = new System.Drawing.Size(100, 20);
            this.txtThrowName.TabIndex = 16;
            this.txtThrowName.TextChanged += new System.EventHandler(this.txtThrowName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Throw Delayed:";
            // 
            // cbThrowDelayed
            // 
            this.cbThrowDelayed.AutoSize = true;
            this.cbThrowDelayed.Location = new System.Drawing.Point(116, 140);
            this.cbThrowDelayed.Name = "cbThrowDelayed";
            this.cbThrowDelayed.Size = new System.Drawing.Size(15, 14);
            this.cbThrowDelayed.TabIndex = 18;
            this.cbThrowDelayed.UseVisualStyleBackColor = true;
            this.cbThrowDelayed.CheckedChanged += new System.EventHandler(this.cbThrowDelayed_CheckedChanged);
            // 
            // FormThrowDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 247);
            this.Controls.Add(this.cbThrowDelayed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtThrowName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblThrowFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlThrowTo);
            this.Controls.Add(this.txtThrowDelay);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnUpdateThrow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThrowDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Throw";
            this.Load += new System.EventHandler(this.FormThrowDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtThrowDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ddlThrowTo;
        private System.Windows.Forms.NumericUpDown txtThrowDelay;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnUpdateThrow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThrowFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtThrowName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbThrowDelayed;
    }
}