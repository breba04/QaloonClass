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
            this.label1 = new System.Windows.Forms.Label();
            this.btn_UploadTheImage = new System.Windows.Forms.Button();
            this.ptb_PersonalPhoto = new System.Windows.Forms.PictureBox();
            this.gb_PersonalData = new System.Windows.Forms.GroupBox();
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
            this.label12 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.gb_CircuitData = new System.Windows.Forms.GroupBox();
            this.cmb_StartingPart = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmb_Circles = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.lbl_CompleteTheRemainingLoop = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.pnl_SectionFotter = new System.Windows.Forms.Panel();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.gb_StudentPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptb_PersonalPhoto)).BeginInit();
            this.gb_PersonalData.SuspendLayout();
            this.gb_ContactInformation.SuspendLayout();
            this.gb_CircuitData.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnl_SectionFotter.SuspendLayout();
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
            this.gb_StudentPhoto.Controls.Add(this.label1);
            this.gb_StudentPhoto.Controls.Add(this.btn_UploadTheImage);
            this.gb_StudentPhoto.Controls.Add(this.ptb_PersonalPhoto);
            this.gb_StudentPhoto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_StudentPhoto.Location = new System.Drawing.Point(787, 101);
            this.gb_StudentPhoto.Name = "gb_StudentPhoto";
            this.gb_StudentPhoto.Size = new System.Drawing.Size(340, 501);
            this.gb_StudentPhoto.TabIndex = 28;
            this.gb_StudentPhoto.TabStop = false;
            this.gb_StudentPhoto.Text = "صورة الطالب";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(32, 419);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 46);
            this.label1.TabIndex = 29;
            this.label1.Text = "يفضل أن تكون الصورة بخلفية فاتحة\r\n وبدقة عالية (JPG, PNG)";
            // 
            // btn_UploadTheImage
            // 
            this.btn_UploadTheImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(214)))), ((int)(((byte)(91)))));
            this.btn_UploadTheImage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_UploadTheImage.FlatAppearance.BorderSize = 0;
            this.btn_UploadTheImage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(190)))), ((int)(((byte)(70)))));
            this.btn_UploadTheImage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(190)))), ((int)(((byte)(70)))));
            this.btn_UploadTheImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_UploadTheImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UploadTheImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(111)))), ((int)(((byte)(14)))));
            this.btn_UploadTheImage.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_UploadTheImage.ImageIndex = 0;
            this.btn_UploadTheImage.ImageList = this.imageList1;
            this.btn_UploadTheImage.Location = new System.Drawing.Point(58, 320);
            this.btn_UploadTheImage.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_UploadTheImage.Name = "btn_UploadTheImage";
            this.btn_UploadTheImage.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_UploadTheImage.Size = new System.Drawing.Size(220, 55);
            this.btn_UploadTheImage.TabIndex = 30;
            this.btn_UploadTheImage.Text = "رفع الصورة";
            this.btn_UploadTheImage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_UploadTheImage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_UploadTheImage.UseVisualStyleBackColor = false;
            // 
            // ptb_PersonalPhoto
            // 
            this.ptb_PersonalPhoto.BackColor = System.Drawing.Color.Transparent;
            this.ptb_PersonalPhoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ptb_PersonalPhoto.Image = global::UI.Properties.Resources.Ic_PersonalPhoto;
            this.ptb_PersonalPhoto.Location = new System.Drawing.Point(58, 55);
            this.ptb_PersonalPhoto.Name = "ptb_PersonalPhoto";
            this.ptb_PersonalPhoto.Size = new System.Drawing.Size(220, 198);
            this.ptb_PersonalPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ptb_PersonalPhoto.TabIndex = 29;
            this.ptb_PersonalPhoto.TabStop = false;
            // 
            // gb_PersonalData
            // 
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
            this.gb_PersonalData.Location = new System.Drawing.Point(13, 101);
            this.gb_PersonalData.Name = "gb_PersonalData";
            this.gb_PersonalData.Size = new System.Drawing.Size(768, 352);
            this.gb_PersonalData.TabIndex = 31;
            this.gb_PersonalData.TabStop = false;
            this.gb_PersonalData.Text = "بيانات الشخصية";
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.CalendarMonthBackground = System.Drawing.Color.LightGoldenrodYellow;
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(476, 284);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(254, 34);
            this.dtp_DateOfBirth.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label7.Location = new System.Drawing.Point(201, 246);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 28);
            this.label7.TabIndex = 17;
            this.label7.Text = "رقم الجلوس";
            // 
            // txt_SeatingID
            // 
            this.txt_SeatingID.BackColor = System.Drawing.Color.Beige;
            this.txt_SeatingID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SeatingID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SeatingID.Location = new System.Drawing.Point(50, 277);
            this.txt_SeatingID.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SeatingID.Multiline = true;
            this.txt_SeatingID.Name = "txt_SeatingID";
            this.txt_SeatingID.Size = new System.Drawing.Size(262, 41);
            this.txt_SeatingID.TabIndex = 18;
            this.txt_SeatingID.Tag = "";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label8.Location = new System.Drawing.Point(622, 246);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(111, 28);
            this.label8.TabIndex = 15;
            this.label8.Text = "تاريخ الميلاد";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label2.Location = new System.Drawing.Point(214, 142);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "اسم الأخير";
            // 
            // txt_LastName
            // 
            this.txt_LastName.BackColor = System.Drawing.Color.Beige;
            this.txt_LastName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LastName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_LastName.Location = new System.Drawing.Point(50, 173);
            this.txt_LastName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_LastName.Multiline = true;
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(262, 41);
            this.txt_LastName.TabIndex = 14;
            this.txt_LastName.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label5.Location = new System.Drawing.Point(218, 45);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "اسم التاني";
            // 
            // txt_SecondName
            // 
            this.txt_SecondName.BackColor = System.Drawing.Color.Beige;
            this.txt_SecondName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SecondName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SecondName.Location = new System.Drawing.Point(50, 76);
            this.txt_SecondName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SecondName.Multiline = true;
            this.txt_SecondName.Name = "txt_SecondName";
            this.txt_SecondName.Size = new System.Drawing.Size(262, 41);
            this.txt_SecondName.TabIndex = 12;
            this.txt_SecondName.Tag = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(633, 142);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "اسم الثالث";
            // 
            // txt_ThirdName
            // 
            this.txt_ThirdName.BackColor = System.Drawing.Color.Beige;
            this.txt_ThirdName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_ThirdName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ThirdName.Location = new System.Drawing.Point(476, 173);
            this.txt_ThirdName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_ThirdName.Multiline = true;
            this.txt_ThirdName.Name = "txt_ThirdName";
            this.txt_ThirdName.Size = new System.Drawing.Size(254, 41);
            this.txt_ThirdName.TabIndex = 10;
            this.txt_ThirdName.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(644, 45);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 28);
            this.label3.TabIndex = 7;
            this.label3.Text = "اسم الأول";
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.BackColor = System.Drawing.Color.Beige;
            this.txt_FirstName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_FirstName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_FirstName.Location = new System.Drawing.Point(476, 76);
            this.txt_FirstName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_FirstName.Multiline = true;
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(254, 41);
            this.txt_FirstName.TabIndex = 8;
            this.txt_FirstName.Tag = "";
            // 
            // gb_ContactInformation
            // 
            this.gb_ContactInformation.Controls.Add(this.label12);
            this.gb_ContactInformation.Controls.Add(this.txt_Address);
            this.gb_ContactInformation.Controls.Add(this.label14);
            this.gb_ContactInformation.Controls.Add(this.txt_Phone);
            this.gb_ContactInformation.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_ContactInformation.Location = new System.Drawing.Point(12, 459);
            this.gb_ContactInformation.Name = "gb_ContactInformation";
            this.gb_ContactInformation.Size = new System.Drawing.Size(768, 143);
            this.gb_ContactInformation.TabIndex = 32;
            this.gb_ContactInformation.TabStop = false;
            this.gb_ContactInformation.Text = "بيانات  التواصل";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label12.Location = new System.Drawing.Point(237, 35);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 28);
            this.label12.TabIndex = 11;
            this.label12.Text = "العنوان";
            // 
            // txt_Address
            // 
            this.txt_Address.BackColor = System.Drawing.Color.Beige;
            this.txt_Address.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Address.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Address.Location = new System.Drawing.Point(49, 66);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(262, 41);
            this.txt_Address.TabIndex = 12;
            this.txt_Address.Tag = "";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label14.Location = new System.Drawing.Point(599, 35);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 28);
            this.label14.TabIndex = 7;
            this.label14.Text = "رقم ولي الأمر";
            // 
            // txt_Phone
            // 
            this.txt_Phone.BackColor = System.Drawing.Color.Beige;
            this.txt_Phone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Phone.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Phone.Location = new System.Drawing.Point(475, 66);
            this.txt_Phone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_Phone.Multiline = true;
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(254, 41);
            this.txt_Phone.TabIndex = 8;
            this.txt_Phone.Tag = "";
            // 
            // gb_CircuitData
            // 
            this.gb_CircuitData.Controls.Add(this.cmb_StartingPart);
            this.gb_CircuitData.Controls.Add(this.label11);
            this.gb_CircuitData.Controls.Add(this.cmb_Circles);
            this.gb_CircuitData.Controls.Add(this.label10);
            this.gb_CircuitData.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_CircuitData.Location = new System.Drawing.Point(12, 608);
            this.gb_CircuitData.Name = "gb_CircuitData";
            this.gb_CircuitData.Size = new System.Drawing.Size(768, 143);
            this.gb_CircuitData.TabIndex = 34;
            this.gb_CircuitData.TabStop = false;
            this.gb_CircuitData.Text = "بيانات الحلقة";
            // 
            // cmb_StartingPart
            // 
            this.cmb_StartingPart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_StartingPart.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_StartingPart.FormattingEnabled = true;
            this.cmb_StartingPart.Items.AddRange(new object[] {
            " جزء عمَّ",
            "",
            " جزء تبارك",
            "",
            " جزء قد سمع",
            "",
            " جزء الذاريات",
            "",
            " جزء حم (الأحقاف)",
            "",
            " جزء فُصلت",
            ""});
            this.cmb_StartingPart.Location = new System.Drawing.Point(335, 66);
            this.cmb_StartingPart.Name = "cmb_StartingPart";
            this.cmb_StartingPart.Size = new System.Drawing.Size(183, 36);
            this.cmb_StartingPart.TabIndex = 36;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label11.Location = new System.Drawing.Point(429, 36);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(94, 28);
            this.label11.TabIndex = 35;
            this.label11.Text = "جزء البداية";
            // 
            // cmb_Circles
            // 
            this.cmb_Circles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Circles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Circles.FormattingEnabled = true;
            this.cmb_Circles.Items.AddRange(new object[] {
            "حلقة النصر",
            "حلقة الكهف",
            "حلقة الملك",
            "حلقة الإحسان"});
            this.cmb_Circles.Location = new System.Drawing.Point(562, 66);
            this.cmb_Circles.Name = "cmb_Circles";
            this.cmb_Circles.Size = new System.Drawing.Size(183, 36);
            this.cmb_Circles.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label10.Location = new System.Drawing.Point(687, 36);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 28);
            this.label10.TabIndex = 7;
            this.label10.Text = "الحلقة";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.lbl_CompleteTheRemainingLoop);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Location = new System.Drawing.Point(787, 620);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 131);
            this.panel1.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label15.AutoSize = true;
            this.label15.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(71, 72);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(255, 46);
            this.label15.TabIndex = 31;
            this.label15.Text = "يتم تحديث البيانات تلقائياً عند حفظ\r\n الطالب الجديد";
            // 
            // lbl_CompleteTheRemainingLoop
            // 
            this.lbl_CompleteTheRemainingLoop.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lbl_CompleteTheRemainingLoop.AutoSize = true;
            this.lbl_CompleteTheRemainingLoop.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_CompleteTheRemainingLoop.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CompleteTheRemainingLoop.ForeColor = System.Drawing.Color.White;
            this.lbl_CompleteTheRemainingLoop.Location = new System.Drawing.Point(15, 22);
            this.lbl_CompleteTheRemainingLoop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CompleteTheRemainingLoop.Name = "lbl_CompleteTheRemainingLoop";
            this.lbl_CompleteTheRemainingLoop.Size = new System.Drawing.Size(63, 31);
            this.lbl_CompleteTheRemainingLoop.TabIndex = 30;
            this.lbl_CompleteTheRemainingLoop.Text = "15/5";
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label13.AutoSize = true;
            this.label13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(150, 24);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 28);
            this.label13.TabIndex = 29;
            this.label13.Text = "سعة الحلقة المتبقية";
            // 
            // pnl_SectionFotter
            // 
            this.pnl_SectionFotter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(245)))), ((int)(((byte)(214)))));
            this.pnl_SectionFotter.Controls.Add(this.btn_Clean);
            this.pnl_SectionFotter.Controls.Add(this.btn_Save);
            this.pnl_SectionFotter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_SectionFotter.Location = new System.Drawing.Point(0, 858);
            this.pnl_SectionFotter.Name = "pnl_SectionFotter";
            this.pnl_SectionFotter.Size = new System.Drawing.Size(1152, 96);
            this.pnl_SectionFotter.TabIndex = 36;
            this.pnl_SectionFotter.Controls.SetChildIndex(this.btn_Save, 0);
            this.pnl_SectionFotter.Controls.SetChildIndex(this.btn_Clean, 0);
            // 
            // btn_Clean
            // 
            this.btn_Clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
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
            this.btn_Clean.Location = new System.Drawing.Point(295, 20);
            this.btn_Clean.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Clean.Size = new System.Drawing.Size(230, 55);
            this.btn_Clean.TabIndex = 9;
            this.btn_Clean.Text = "تنظيف الحقول";
            this.btn_Clean.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Clean.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Clean.UseVisualStyleBackColor = false;
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
            this.btn_Save.Location = new System.Drawing.Point(40, 20);
            this.btn_Save.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_Save.Size = new System.Drawing.Size(230, 55);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "حفظ الطالب";
            this.btn_Save.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Save.UseVisualStyleBackColor = false;
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
            // frmAddAndUpdateStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1152, 954);
            this.Controls.Add(this.pnl_SectionFotter);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gb_CircuitData);
            this.Controls.Add(this.gb_ContactInformation);
            this.Controls.Add(this.gb_PersonalData);
            this.Controls.Add(this.gb_StudentPhoto);
            this.Name = "frmAddAndUpdateStudent";
            this.Text = "frmAddAndUpdateStudent";
            this.Load += new System.EventHandler(this.frmAddAndUpdateStudent_Load);
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
            this.gb_ContactInformation.ResumeLayout(false);
            this.gb_ContactInformation.PerformLayout();
            this.gb_CircuitData.ResumeLayout(false);
            this.gb_CircuitData.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnl_SectionFotter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gb_StudentPhoto;
        private System.Windows.Forms.PictureBox ptb_PersonalPhoto;
        private System.Windows.Forms.Button btn_UploadTheImage;
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
        private System.Windows.Forms.ComboBox cmb_StartingPart;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmb_Circles;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_CompleteTheRemainingLoop;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel pnl_SectionFotter;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.Button btn_Close;
    }
}