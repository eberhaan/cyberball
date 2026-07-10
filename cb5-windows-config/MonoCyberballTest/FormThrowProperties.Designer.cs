namespace MonoCyberball
{
    partial class FormThrowProperties
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
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblThrowFrom = new System.Windows.Forms.Label();
            this.lblThrowTo = new System.Windows.Forms.Label();
            this.lblDelay = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(66, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Delay:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(47, 79);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Throw To:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(100, 157);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnCloseThrowClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Throw From:";
            // 
            // lblThrowFrom
            // 
            this.lblThrowFrom.AutoSize = true;
            this.lblThrowFrom.Location = new System.Drawing.Point(116, 41);
            this.lblThrowFrom.Name = "lblThrowFrom";
            this.lblThrowFrom.Size = new System.Drawing.Size(13, 13);
            this.lblThrowFrom.TabIndex = 14;
            this.lblThrowFrom.Text = "1";
            // 
            // lblThrowTo
            // 
            this.lblThrowTo.AutoSize = true;
            this.lblThrowTo.Location = new System.Drawing.Point(116, 79);
            this.lblThrowTo.Name = "lblThrowTo";
            this.lblThrowTo.Size = new System.Drawing.Size(13, 13);
            this.lblThrowTo.TabIndex = 15;
            this.lblThrowTo.Text = "1";
            // 
            // lblDelay
            // 
            this.lblDelay.AutoSize = true;
            this.lblDelay.Location = new System.Drawing.Point(116, 117);
            this.lblDelay.Name = "lblDelay";
            this.lblDelay.Size = new System.Drawing.Size(13, 13);
            this.lblDelay.TabIndex = 16;
            this.lblDelay.Text = "1";
            // 
            // FormThrowProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 192);
            this.Controls.Add(this.lblDelay);
            this.Controls.Add(this.lblThrowTo);
            this.Controls.Add(this.lblThrowFrom);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormThrowProperties";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblThrowFrom;
        private System.Windows.Forms.Label lblThrowTo;
        private System.Windows.Forms.Label lblDelay;
    }
}