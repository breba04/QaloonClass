namespace UI.Students
{
    partial class frmAddAndUpdateStudent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAddAndUpdateStudent));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gb_StudentPhoto = new System.Windows.Forms.GroupBox();
            this.btn_RemoveImage = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_UploadImage = new System.Windows.Forms.Button();
            this.ptb_PersonalPhoto = new System.Windows.Forms.PictureBox();
            this.gb_PersonalData = new System.Windows.Forms.GroupBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtp_DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SeatingID = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_SecondName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ThirdName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.gb_ContactInformation = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.gb_CircuitData = new System.Windows.Forms.GroupBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.cmb_Aya = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmb_Surahs = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_Circles = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_Capacity = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnl_SectionFotter = new System.Windows.Forms.Panel();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gb_StudentPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_PersonalPhoto)).BeginInit();
            this.gb_PersonalData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gb_ContactInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.gb_CircuitData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnl_SectionFotter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "close2.png");
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Ic_Upload.png");
            this.imageList1.Images.SetKeyName(1, "close2.png");
            this.imageList1.Images.SetKeyName(2, "Ic_Save.png");
            this.imageList1.Images.SetKeyName(3, "Ic_cleaning.png");
            this.imageList1.Images.SetKeyName(4, "Ic_Close.png");
            // 
            // gb_StudentPhoto
            // 
            this.gb_StudentPhoto.Controls.Add(this.btn_RemoveImage);
            this.gb_StudentPhoto.Controls.Add(this.label1);
            this.gb_StudentPhoto.Controls.Add(this.btn_UploadImage);
            this.gb_StudentPhoto.Controls.Add(this.ptb_PersonalPhoto);
            this.gb_StudentPhoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_StudentPhoto.Location = new System.Drawing.Point(675, 71);
            this.gb_StudentPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_StudentPhoto.Name = "gb_StudentPhoto";
            this.gb_StudentPhoto.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_StudentPhoto.Size = new System.Drawing.Size(291, 354);
            this.gb_StudentPhoto.TabIndex = 28;
            this.gb_StudentPhoto.TabStop = false;
            this.gb_StudentPhoto.Text = "صورة الطالب";
            // 
            // btn_RemoveImage
            // 
            this.btn_RemoveImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_RemoveImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_RemoveImage.FlatAppearance.BorderSize = 0;
            this.btn_RemoveImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_RemoveImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_RemoveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RemoveImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveImage.ForeColor = System.Drawing.Color.White;
            this.btn_RemoveImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_RemoveImage.ImageList = this.imageList1;
            this.btn_RemoveImage.Location = new System.Drawing.Point(50, 258);
            this.btn_RemoveImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_RemoveImage.Name = "btn_RemoveImage";
            this.btn_RemoveImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_RemoveImage.Size = new System.Drawing.Size(189, 39);
            this.btn_RemoveImage.TabIndex = 13;
            this.btn_RemoveImage.Text = "إزالة الصورة";
            this.btn_RemoveImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_RemoveImage.UseVisualStyleBackColor = false;
            this.btn_RemoveImage.Click += new System.EventHandler(this.btn_RemoveImage_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(26, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 38);
            this.label1.TabIndex = 29;
            this.label1.Text = "يفضل أن تكون الصورة بخلفية فاتحة\r\n وبدقة عالية (JPG, PNG)";
            // 
            // btn_UploadImage
            // 
            this.btn_UploadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(214)))), ((int)(((byte)(91)))));
            this.btn_UploadImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UploadImage.FlatAppearance.BorderSize = 0;
            this.btn_UploadImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(190)))), ((int)(((byte)(70)))));
            this.btn_UploadImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(190)))), ((int)(((byte)(70)))));
            this.btn_UploadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UploadImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UploadImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(111)))), ((int)(((byte)(14)))));
            this.btn_UploadImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_UploadImage.ImageIndex = 0;
            this.btn_UploadImage.ImageList = this.imageList1;
            this.btn_UploadImage.Location = new System.Drawing.Point(50, 210);
            this.btn_UploadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_UploadImage.Name = "btn_UploadImage";
            this.btn_UploadImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_UploadImage.Size = new System.Drawing.Size(189, 39);
            this.btn_UploadImage.TabIndex = 12;
            this.btn_UploadImage.Text = "رفع الصورة";
            this.btn_UploadImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_UploadImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_UploadImage.UseVisualStyleBackColor = false;
            this.btn_UploadImage.Click += new System.EventHandler(this.btn_UploadImage_Click);
            // 
            // ptb_PersonalPhoto
            // 
            this.ptb_PersonalPhoto.BackColor = System.Drawing.Color.Transparent;
            this.ptb_PersonalPhoto.ErrorImage = global::UI.Properties.Resources.Ic_PersonalPhoto;
            this.ptb_PersonalPhoto.Image = global::UI.Properties.Resources.Ic_PersonalPhoto;
            this.ptb_PersonalPhoto.Location = new System.Drawing.Point(50, 39);
            this.ptb_PersonalPhoto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ptb_PersonalPhoto.Name = "ptb_PersonalPhoto";
            this.ptb_PersonalPhoto.Size = new System.Drawing.Size(189, 165);
            this.ptb_PersonalPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptb_PersonalPhoto.TabIndex = 29;
            this.ptb_PersonalPhoto.TabStop = false;
            // 
            // gb_PersonalData
            // 
            this.gb_PersonalData.Controls.Add(this.pictureBox6);
            this.gb_PersonalData.Controls.Add(this.pictureBox5);
            this.gb_PersonalData.Controls.Add(this.pictureBox4);
            this.gb_PersonalData.Controls.Add(this.pictureBox3);
            this.gb_PersonalData.Controls.Add(this.pictureBox2);
            this.gb_PersonalData.Controls.Add(this.pictureBox1);
            this.gb_PersonalData.Controls.Add(this.dtp_DateOfBirth);
            this.gb_PersonalData.Controls.Add(this.label7);
            this.gb_PersonalData.Controls.Add(this.txt_SeatingID);
            this.gb_PersonalData.Controls.Add(this.label8);
            this.gb_PersonalData.Controls.Add(this.label2);
            this.gb_PersonalData.Controls.Add(this.txt_LastName);
            this.gb_PersonalData.Controls.Add(this.label5);
            this.gb_PersonalData.Controls.Add(this.txt_SecondName);
            this.gb_PersonalData.Controls.Add(this.label4);
            this.gb_PersonalData.Controls.Add(this.txt_ThirdName);
            this.gb_PersonalData.Controls.Add(this.label3);
            this.gb_PersonalData.Controls.Add(this.txt_FirstName);
            this.gb_PersonalData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_PersonalData.Location = new System.Drawing.Point(11, 71);
            this.gb_PersonalData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_PersonalData.Name = "gb_PersonalData";
            this.gb_PersonalData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_PersonalData.Size = new System.Drawing.Size(658, 248);
            this.gb_PersonalData.TabIndex = 31;
            this.gb_PersonalData.TabStop = false;
            this.gb_PersonalData.Text = "بيانات الشخصية";
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackgroundImage = global::UI.Properties.Resources.Icon_SeatNumber;
            this.pictureBox6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox6.Location = new System.Drawing.Point(248, 175);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(20, 20);
            this.pictureBox6.TabIndex = 42;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackgroundImage = global::UI.Properties.Resources.Icon_Date;
            this.pictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox5.Location = new System.Drawing.Point(605, 175);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(20, 20);
            this.pictureBox5.TabIndex = 41;
            this.pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::UI.Properties.Resources.Icon_LastName;
            this.pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox4.Location = new System.Drawing.Point(248, 107);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(20, 20);
            this.pictureBox4.TabIndex = 40;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::UI.Properties.Resources.Icon_Person;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox3.Location = new System.Drawing.Point(606, 107);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(20, 20);
            this.pictureBox3.TabIndex = 39;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::UI.Properties.Resources.Icon_Person;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(248, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::UI.Properties.Resources.Icon_Person1;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(606, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.TabIndex = 37;
            this.pictureBox1.TabStop = false;
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.CalendarMonthBackground = System.Drawing.Color.LightGoldenrodYellow;
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(408, 200);
            this.dtp_DateOfBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(218, 29);
            this.dtp_DateOfBirth.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label7.Location = new System.Drawing.Point(164, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "رقم الجلوس";
            // 
            // txt_SeatingID
            // 
            this.txt_SeatingID.BackColor = System.Drawing.Color.Beige;
            this.txt_SeatingID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SeatingID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SeatingID.Location = new System.Drawing.Point(43, 199);
            this.txt_SeatingID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SeatingID.Multiline = true;
            this.txt_SeatingID.Name = "txt_SeatingID";
            this.txt_SeatingID.ReadOnly = true;
            this.txt_SeatingID.Size = new System.Drawing.Size(225, 30);
            this.txt_SeatingID.TabIndex = 6;
            this.txt_SeatingID.Tag = "رقم الجلوس";
            this.txt_SeatingID.Text = "يتم ملئه تلقائيا عند حفظ الطالب";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label8.Location = new System.Drawing.Point(524, 174);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 21);
            this.label8.TabIndex = 15;
            this.label8.Text = "تاريخ الميلاد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(177, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "اسم الأخير";
            // 
            // txt_LastName
            // 
            this.txt_LastName.BackColor = System.Drawing.Color.Beige;
            this.txt_LastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LastName.Location = new System.Drawing.Point(43, 132);
            this.txt_LastName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_LastName.Multiline = true;
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(225, 30);
            this.txt_LastName.TabIndex = 4;
            this.txt_LastName.Tag = "اسم الأخير";
            this.txt_LastName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label5.Location = new System.Drawing.Point(175, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "اسم التاني";
            // 
            // txt_SecondName
            // 
            this.txt_SecondName.BackColor = System.Drawing.Color.Beige;
            this.txt_SecondName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SecondName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SecondName.Location = new System.Drawing.Point(43, 54);
            this.txt_SecondName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_SecondName.Multiline = true;
            this.txt_SecondName.Name = "txt_SecondName";
            this.txt_SecondName.Size = new System.Drawing.Size(225, 30);
            this.txt_SecondName.TabIndex = 2;
            this.txt_SecondName.Tag = "اسم التاني";
            this.txt_SecondName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(531, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "اسم الثالث";
            // 
            // txt_ThirdName
            // 
            this.txt_ThirdName.BackColor = System.Drawing.Color.Beige;
            this.txt_ThirdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ThirdName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ThirdName.Location = new System.Drawing.Point(408, 132);
            this.txt_ThirdName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_ThirdName.Multiline = true;
            this.txt_ThirdName.Name = "txt_ThirdName";
            this.txt_ThirdName.Size = new System.Drawing.Size(218, 30);
            this.txt_ThirdName.TabIndex = 3;
            this.txt_ThirdName.Tag = "اسم الثالث";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(537, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "اسم الأول";
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.BackColor = System.Drawing.Color.Beige;
            this.txt_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FirstName.Location = new System.Drawing.Point(408, 54);
            this.txt_FirstName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_FirstName.Multiline = true;
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(218, 30);
            this.txt_FirstName.TabIndex = 1;
            this.txt_FirstName.Tag = "اسم الأول";
            this.txt_FirstName.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // gb_ContactInformation
            // 
            this.gb_ContactInformation.Controls.Add(this.pictureBox8);
            this.gb_ContactInformation.Controls.Add(this.pictureBox7);
            this.gb_ContactInformation.Controls.Add(this.label12);
            this.gb_ContactInformation.Controls.Add(this.txt_Address);
            this.gb_ContactInformation.Controls.Add(this.label14);
            this.gb_ContactInformation.Controls.Add(this.txt_Phone);
            this.gb_ContactInformation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ContactInformation.Location = new System.Drawing.Point(10, 324);
            this.gb_ContactInformation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_ContactInformation.Name = "gb_ContactInformation";
            this.gb_ContactInformation.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_ContactInformation.Size = new System.Drawing.Size(658, 101);
            this.gb_ContactInformation.TabIndex = 32;
            this.gb_ContactInformation.TabStop = false;
            this.gb_ContactInformation.Text = "بيانات  التواصل";
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackgroundImage = global::UI.Properties.Resources.Icon_Address;
            this.pictureBox8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox8.Location = new System.Drawing.Point(247, 27);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(20, 20);
            this.pictureBox8.TabIndex = 44;
            this.pictureBox8.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackgroundImage = global::UI.Properties.Resources.Icon_Phone;
            this.pictureBox7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox7.Location = new System.Drawing.Point(604, 27);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(20, 20);
            this.pictureBox7.TabIndex = 43;
            this.pictureBox7.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label12.Location = new System.Drawing.Point(194, 23);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 21);
            this.label12.TabIndex = 11;
            this.label12.Text = "العنوان";
            // 
            // txt_Address
            // 
            this.txt_Address.BackColor = System.Drawing.Color.Beige;
            this.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(42, 51);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(225, 30);
            this.txt_Address.TabIndex = 8;
            this.txt_Address.Tag = "العنوان";
            this.txt_Address.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label14.Location = new System.Drawing.Point(513, 25);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(96, 21);
            this.label14.TabIndex = 7;
            this.label14.Text = "رقم ولي الأمر";
            // 
            // txt_Phone
            // 
            this.txt_Phone.BackColor = System.Drawing.Color.Beige;
            this.txt_Phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Phone.Location = new System.Drawing.Point(407, 51);
            this.txt_Phone.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Phone.Multiline = true;
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(218, 30);
            this.txt_Phone.TabIndex = 7;
            this.txt_Phone.Tag = "رقم ولي الأمر";
            this.txt_Phone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Phone_KeyPress);
            this.txt_Phone.Validating += new System.ComponentModel.CancelEventHandler(this.TextBox_Validating);
            // 
            // gb_CircuitData
            // 
            this.gb_CircuitData.Controls.Add(this.pictureBox11);
            this.gb_CircuitData.Controls.Add(this.pictureBox10);
            this.gb_CircuitData.Controls.Add(this.pictureBox9);
            this.gb_CircuitData.Controls.Add(this.cmb_Aya);
            this.gb_CircuitData.Controls.Add(this.label9);
            this.gb_CircuitData.Controls.Add(this.cmb_Surahs);
            this.gb_CircuitData.Controls.Add(this.label11);
            this.gb_CircuitData.Controls.Add(this.cmb_Circles);
            this.gb_CircuitData.Controls.Add(this.label10);
            this.gb_CircuitData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_CircuitData.Location = new System.Drawing.Point(10, 429);
            this.gb_CircuitData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_CircuitData.Name = "gb_CircuitData";
            this.gb_CircuitData.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gb_CircuitData.Size = new System.Drawing.Size(658, 112);
            this.gb_CircuitData.TabIndex = 34;
            this.gb_CircuitData.TabStop = false;
            this.gb_CircuitData.Text = "بيانات الحلقة";
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackgroundImage = global::UI.Properties.Resources.Icon_Aya;
            this.pictureBox11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox11.Location = new System.Drawing.Point(226, 31);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(20, 20);
            this.pictureBox11.TabIndex = 47;
            this.pictureBox11.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackgroundImage = global::UI.Properties.Resources.Icon_Sora;
            this.pictureBox10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox10.Location = new System.Drawing.Point(424, 33);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(20, 20);
            this.pictureBox10.TabIndex = 46;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackgroundImage = global::UI.Properties.Resources.Icon_Episode;
            this.pictureBox9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox9.Location = new System.Drawing.Point(614, 31);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(20, 20);
            this.pictureBox9.TabIndex = 45;
            this.pictureBox9.TabStop = false;
            // 
            // cmb_Aya
            // 
            this.cmb_Aya.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Aya.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Aya.FormattingEnabled = true;
            this.cmb_Aya.Location = new System.Drawing.Point(6, 55);
            this.cmb_Aya.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Aya.Name = "cmb_Aya";
            this.cmb_Aya.Size = new System.Drawing.Size(241, 29);
            this.cmb_Aya.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label9.Location = new System.Drawing.Point(194, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 21);
            this.label9.TabIndex = 37;
            this.label9.Text = "الآية";
            // 
            // cmb_Surahs
            // 
            this.cmb_Surahs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Surahs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Surahs.FormattingEnabled = true;
            this.cmb_Surahs.Location = new System.Drawing.Point(287, 55);
            this.cmb_Surahs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Surahs.Name = "cmb_Surahs";
            this.cmb_Surahs.Size = new System.Drawing.Size(157, 29);
            this.cmb_Surahs.TabIndex = 10;
            this.cmb_Surahs.SelectedIndexChanged += new System.EventHandler(this.cmb_Surahs_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label11.Location = new System.Drawing.Point(374, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 21);
            this.label11.TabIndex = 35;
            this.label11.Text = "السورة";
            // 
            // cmb_Circles
            // 
            this.cmb_Circles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Circles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Circles.FormattingEnabled = true;
            this.cmb_Circles.Location = new System.Drawing.Point(477, 55);
            this.cmb_Circles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmb_Circles.Name = "cmb_Circles";
            this.cmb_Circles.Size = new System.Drawing.Size(157, 29);
            this.cmb_Circles.TabIndex = 9;
            this.cmb_Circles.SelectedIndexChanged += new System.EventHandler(this.cmb_Circles_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label10.Location = new System.Drawing.Point(570, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 21);
            this.label10.TabIndex = 7;
            this.label10.Text = "الحلقة";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lbl_Capacity);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(675, 438);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(291, 103);
            this.panel1.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(50, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(212, 38);
            this.label15.TabIndex = 31;
            this.label15.Text = "يتم تحديث البيانات تلقائياً عند حفظ\r\n الطالب الجديد";
            // 
            // lbl_Capacity
            // 
            this.lbl_Capacity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_Capacity.AutoSize = true;
            this.lbl_Capacity.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_Capacity.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Capacity.ForeColor = System.Drawing.Color.White;
            this.lbl_Capacity.Location = new System.Drawing.Point(12, 13);
            this.lbl_Capacity.Name = "lbl_Capacity";
            this.lbl_Capacity.Size = new System.Drawing.Size(53, 25);
            this.lbl_Capacity.TabIndex = 30;
            this.lbl_Capacity.Text = "15/5";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(124, 17);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 21);
            this.label13.TabIndex = 29;
            this.label13.Text = "سعة الحلقة المتبقية";
            // 
            // pnl_SectionFotter
            // 
            this.pnl_SectionFotter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(245)))), ((int)(((byte)(214)))));
            this.pnl_SectionFotter.Controls.Add(this.btn_Cancel);
            this.pnl_SectionFotter.Controls.Add(this.btn_Clean);
            this.pnl_SectionFotter.Controls.Add(this.btn_Save);
            this.pnl_SectionFotter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_SectionFotter.Location = new System.Drawing.Point(0, 582);
            this.pnl_SectionFotter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnl_SectionFotter.Name = "pnl_SectionFotter";
            this.pnl_SectionFotter.Size = new System.Drawing.Size(987, 68);
            this.pnl_SectionFotter.TabIndex = 36;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btn_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.btn_Cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Cancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Cancel.ImageIndex = 4;
            this.btn_Cancel.ImageList = this.imageList1;
            this.btn_Cancel.Location = new System.Drawing.Point(21, 14);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Cancel.Size = new System.Drawing.Size(197, 39);
            this.btn_Cancel.TabIndex = 16;
            this.btn_Cancel.Text = "إلغاء العملية";
            this.btn_Cancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btn_Clean.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(239)))), ((int)(((byte)(208)))));
            this.btn_Clean.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Clean.FlatAppearance.BorderSize = 0;
            this.btn_Clean.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(239)))), ((int)(((byte)(208)))));
            this.btn_Clean.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(239)))), ((int)(((byte)(208)))));
            this.btn_Clean.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Clean.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Clean.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(67)))));
            this.btn_Clean.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Clean.ImageIndex = 3;
            this.btn_Clean.ImageList = this.imageList1;
            this.btn_Clean.Location = new System.Drawing.Point(566, 14);
            this.btn_Clean.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Clean.Size = new System.Drawing.Size(197, 39);
            this.btn_Clean.TabIndex = 15;
            this.btn_Clean.Text = "تنظيف الحقول";
            this.btn_Clean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Clean.UseVisualStyleBackColor = false;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Save.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.FlatAppearance.BorderSize = 0;
            this.btn_Save.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_Save.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_Save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Save.ImageIndex = 2;
            this.btn_Save.ImageList = this.imageList1;
            this.btn_Save.Location = new System.Drawing.Point(770, 14);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Save.Size = new System.Drawing.Size(197, 39);
            this.btn_Save.TabIndex = 14;
            this.btn_Save.Text = "حفظ الطالب";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Close.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.btn_Close.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Close.ImageIndex = 4;
            this.btn_Close.ImageList = this.imageList1;
            this.btn_Close.Location = new System.Drawing.Point(916, 20);
            this.btn_Close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Close.Size = new System.Drawing.Size(201, 55);
            this.btn_Close.TabIndex = 10;
            this.btn_Close.Text = "إلغاء العملية";
            this.btn_Close.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Close.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Close.UseVisualStyleBackColor = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // frmAddAndUpdateStudent
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.CancelButton = this.btn_Cancel;
            this.ClientSize = new System.Drawing.Size(987, 650);
            this.Controls.Add(this.pnl_SectionFotter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_CircuitData);
            this.Controls.Add(this.gb_ContactInformation);
            this.Controls.Add(this.gb_PersonalData);
            this.Controls.Add(this.gb_StudentPhoto);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmAddAndUpdateStudent";
            this.Text = "frmAddAndUpdateStudent";
            this.Load += new System.EventHandler(this.frmAddAndUpdateStudent_Load);
            this.Shown += new System.EventHandler(this.frmAddAndUpdateStudent_Shown);
            this.Controls.SetChildIndex(this.gb_StudentPhoto, 0);
            this.Controls.SetChildIndex(this.gb_PersonalData, 0);
            this.Controls.SetChildIndex(this.gb_ContactInformation, 0);
            this.Controls.SetChildIndex(this.gb_CircuitData, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.pnl_SectionFotter, 0);
            this.gb_StudentPhoto.ResumeLayout(false);
            this.gb_StudentPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_PersonalPhoto)).EndInit();
            this.gb_PersonalData.ResumeLayout(false);
            this.gb_PersonalData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gb_ContactInformation.ResumeLayout(false);
            this.gb_ContactInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.gb_CircuitData.ResumeLayout(false);
            this.gb_CircuitData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_SectionFotter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gb_StudentPhoto;
        private System.Windows.Forms.PictureBox ptb_PersonalPhoto;
        private System.Windows.Forms.Button btn_UploadImage;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gb_PersonalData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ThirdName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_SecondName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SeatingID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtp_DateOfBirth;
        private System.Windows.Forms.GroupBox gb_ContactInformation;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.GroupBox gb_CircuitData;
        private System.Windows.Forms.ComboBox cmb_Surahs;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_Circles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_Capacity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnl_SectionFotter;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_RemoveImage;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox cmb_Aya;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox9;
    }
}