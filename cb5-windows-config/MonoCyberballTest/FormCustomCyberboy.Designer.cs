namespace MonoCyberball
{
    partial class FormCustomCyberboy
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
            this.btnChangeBallImage = new System.Windows.Forms.Button();
            this.ballImageDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ballPicBox = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSelectCyberguyFolder = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbThrow4 = new System.Windows.Forms.PictureBox();
            this.pbThrow3 = new System.Windows.Forms.PictureBox();
            this.pbThrow2 = new System.Windows.Forms.PictureBox();
            this.pbThrow1 = new System.Windows.Forms.PictureBox();
            this.pbCatch = new System.Windows.Forms.PictureBox();
            this.pbIdle = new System.Windows.Forms.PictureBox();
            this.cyberguyDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ballPicBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCatch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChangeBallImage
            // 
            this.btnChangeBallImage.Location = new System.Drawing.Point(90, 19);
            this.btnChangeBallImage.Name = "btnChangeBallImage";
            this.btnChangeBallImage.Size = new System.Drawing.Size(204, 78);
            this.btnChangeBallImage.TabIndex = 1;
            this.btnChangeBallImage.Text = "Select Ball Image";
            this.btnChangeBallImage.UseVisualStyleBackColor = true;
            this.btnChangeBallImage.Click += new System.EventHandler(this.btnChangeBallImage_Click);
            // 
            // ballImageDialog
            // 
            this.ballImageDialog.Filter = "png images|*.png";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangeBallImage);
            this.groupBox1.Controls.Add(this.ballPicBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(303, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ball";
            // 
            // ballPicBox
            // 
            this.ballPicBox.Image = global::MonoCyberball.Properties.Resources.Ball;
            this.ballPicBox.Location = new System.Drawing.Point(6, 19);
            this.ballPicBox.Name = "ballPicBox";
            this.ballPicBox.Size = new System.Drawing.Size(78, 78);
            this.ballPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ballPicBox.TabIndex = 0;
            this.ballPicBox.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnOK);
            this.groupBox2.Controls.Add(this.btnSelectCyberguyFolder);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.pbThrow4);
            this.groupBox2.Controls.Add(this.pbThrow3);
            this.groupBox2.Controls.Add(this.pbThrow2);
            this.groupBox2.Controls.Add(this.pbThrow1);
            this.groupBox2.Controls.Add(this.pbCatch);
            this.groupBox2.Controls.Add(this.pbIdle);
            this.groupBox2.Location = new System.Drawing.Point(12, 127);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(303, 372);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CyberGuy";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(199, 320);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 46);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(114, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 46);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSelectCyberguyFolder
            // 
            this.btnSelectCyberguyFolder.Location = new System.Drawing.Point(28, 320);
            this.btnSelectCyberguyFolder.Name = "btnSelectCyberguyFolder";
            this.btnSelectCyberguyFolder.Size = new System.Drawing.Size(78, 46);
            this.btnSelectCyberguyFolder.TabIndex = 13;
            this.btnSelectCyberguyFolder.Text = "Select Folder";
            this.btnSelectCyberguyFolder.UseVisualStyleBackColor = true;
            this.btnSelectCyberguyFolder.Click += new System.EventHandler(this.btnSelectCyberguyFolder_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(291, 32);
            this.label7.TabIndex = 12;
            this.label7.Text = "Plese select a folder which contains the following images to be used for the cybe" +
    "rguy animation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 272);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "throw-4.png";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(119, 272);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "throw-3.png";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 272);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "throw-2.png";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(203, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "throw-1.png";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "catch.png";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "idle.png";
            // 
            // pbThrow4
            // 
            this.pbThrow4.Image = global::MonoCyberball.Properties.Resources.throw_4;
            this.pbThrow4.Location = new System.Drawing.Point(196, 187);
            this.pbThrow4.Name = "pbThrow4";
            this.pbThrow4.Size = new System.Drawing.Size(78, 82);
            this.pbThrow4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThrow4.TabIndex = 5;
            this.pbThrow4.TabStop = false;
            // 
            // pbThrow3
            // 
            this.pbThrow3.Image = global::MonoCyberball.Properties.Resources.throw_3;
            this.pbThrow3.Location = new System.Drawing.Point(112, 187);
            this.pbThrow3.Name = "pbThrow3";
            this.pbThrow3.Size = new System.Drawing.Size(78, 82);
            this.pbThrow3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThrow3.TabIndex = 4;
            this.pbThrow3.TabStop = false;
            // 
            // pbThrow2
            // 
            this.pbThrow2.Image = global::MonoCyberball.Properties.Resources.throw_2;
            this.pbThrow2.Location = new System.Drawing.Point(28, 187);
            this.pbThrow2.Name = "pbThrow2";
            this.pbThrow2.Size = new System.Drawing.Size(78, 82);
            this.pbThrow2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThrow2.TabIndex = 3;
            this.pbThrow2.TabStop = false;
            // 
            // pbThrow1
            // 
            this.pbThrow1.Image = global::MonoCyberball.Properties.Resources.throw_1;
            this.pbThrow1.Location = new System.Drawing.Point(196, 76);
            this.pbThrow1.Name = "pbThrow1";
            this.pbThrow1.Size = new System.Drawing.Size(78, 82);
            this.pbThrow1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThrow1.TabIndex = 2;
            this.pbThrow1.TabStop = false;
            // 
            // pbCatch
            // 
            this.pbCatch.Image = global::MonoCyberball.Properties.Resources._catch;
            this.pbCatch.Location = new System.Drawing.Point(112, 76);
            this.pbCatch.Name = "pbCatch";
            this.pbCatch.Size = new System.Drawing.Size(78, 82);
            this.pbCatch.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCatch.TabIndex = 1;
            this.pbCatch.TabStop = false;
            // 
            // pbIdle
            // 
            this.pbIdle.Image = global::MonoCyberball.Properties.Resources.idle_right;
            this.pbIdle.Location = new System.Drawing.Point(28, 76);
            this.pbIdle.Name = "pbIdle";
            this.pbIdle.Size = new System.Drawing.Size(78, 82);
            this.pbIdle.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbIdle.TabIndex = 0;
            this.pbIdle.TabStop = false;
            // 
            // FormCustomCyberboy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 511);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormCustomCyberboy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Ball & Cyberguy";
            this.Load += new System.EventHandler(this.FormCustomCyberboy_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ballPicBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbThrow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCatch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbIdle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ballPicBox;
        private System.Windows.Forms.Button btnChangeBallImage;
        private System.Windows.Forms.OpenFileDialog ballImageDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pbIdle;
        private System.Windows.Forms.PictureBox pbThrow4;
        private System.Windows.Forms.PictureBox pbThrow3;
        private System.Windows.Forms.PictureBox pbThrow2;
        private System.Windows.Forms.PictureBox pbThrow1;
        private System.Windows.Forms.PictureBox pbCatch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelectCyberguyFolder;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.FolderBrowserDialog cyberguyDialog;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
    }
}