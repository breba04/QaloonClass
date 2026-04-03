namespace UI.BasedUserControl
{
    partial class ctrlBaseCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnTop = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnFullName = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnLine = new System.Windows.Forms.Panel();
            this.pnBaseInfo = new System.Windows.Forms.Panel();
            this.btnIsActive = new System.Windows.Forms.Button();
            this.pnTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnFullName.SuspendLayout();
            this.pnBaseInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnTop
            // 
            this.pnTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(33)))), ((int)(((byte)(59)))));
            this.pnTop.Controls.Add(this.pnBaseInfo);
            this.pnTop.Controls.Add(this.pnLine);
            this.pnTop.Controls.Add(this.pnFullName);
            this.pnTop.Controls.Add(this.pictureBox1);
            this.pnTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnTop.Location = new System.Drawing.Point(11, 11);
            this.pnTop.Name = "pnTop";
            this.pnTop.Size = new System.Drawing.Size(868, 152);
            this.pnTop.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::UI.Properties.Resources.Male_512;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(184, 152);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnFullName
            // 
            this.pnFullName.Controls.Add(this.label1);
            this.pnFullName.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFullName.Location = new System.Drawing.Point(184, 0);
            this.pnFullName.Name = "pnFullName";
            this.pnFullName.Size = new System.Drawing.Size(684, 71);
            this.pnFullName.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(222, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 28);
            this.label1.TabIndex = 3;
            this.label1.Text = "إبراهيم عبدالكريم عبدالحميد";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnLine
            // 
            this.pnLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnLine.Location = new System.Drawing.Point(184, 71);
            this.pnLine.Name = "pnLine";
            this.pnLine.Size = new System.Drawing.Size(684, 1);
            this.pnLine.TabIndex = 4;
            // 
            // pnBaseInfo
            // 
            this.pnBaseInfo.Controls.Add(this.btnIsActive);
            this.pnBaseInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBaseInfo.Location = new System.Drawing.Point(184, 72);
            this.pnBaseInfo.Name = "pnBaseInfo";
            this.pnBaseInfo.Size = new System.Drawing.Size(684, 80);
            this.pnBaseInfo.TabIndex = 5;
            // 
            // btnIsActive
            // 
            this.btnIsActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(130)))), ((int)(((byte)(57)))));
            this.btnIsActive.FlatAppearance.BorderSize = 0;
            this.btnIsActive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIsActive.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnIsActive.Location = new System.Drawing.Point(340, 32);
            this.btnIsActive.Name = "btnIsActive";
            this.btnIsActive.Size = new System.Drawing.Size(117, 31);
            this.btnIsActive.TabIndex = 0;
            this.btnIsActive.Text = "فعال";
            this.btnIsActive.UseVisualStyleBackColor = false;
            // 
            // ctrlBaseCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(30)))), ((int)(((byte)(52)))));
            this.Controls.Add(this.pnTop);
            this.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.Name = "ctrlBaseCard";
            this.Padding = new System.Windows.Forms.Padding(11, 11, 11, 11);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(890, 542);
            this.pnTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnFullName.ResumeLayout(false);
            this.pnFullName.PerformLayout();
            this.pnBaseInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnTop;
        private System.Windows.Forms.Panel pnBaseInfo;
        private System.Windows.Forms.Button btnIsActive;
        private System.Windows.Forms.Panel pnLine;
        private System.Windows.Forms.Panel pnFullName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
