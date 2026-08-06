namespace UI.Attendance.UserControls
{
    partial class US_AttendanceMangement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(US_AttendanceMangement));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvAttandenceList = new System.Windows.Forms.DataGridView();
            this.StudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SeatsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberAbsentThisMonth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CircleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CircleID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParentPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.lbTakenAttendanceToday = new System.Windows.Forms.Label();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cmb_Circles = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dtp_DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txt_SearchByName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTLTop = new System.Windows.Forms.TableLayoutPanel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btn_SetAllAttendance = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttandenceList)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlTLTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Cheacked.png");
            this.imageList1.Images.SetKeyName(1, "save.png");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(34, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 91);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.18919F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.81081F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 54F));
            this.tableLayoutPanel5.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.label4, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(933, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.58974F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.41026F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(370, 91);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.2F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(67)))));
            this.label6.Location = new System.Drawing.Point(64, 44);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(247, 47);
            this.label6.TabIndex = 11;
            this.label6.Text = "إدارة حضور الطلاب لحلقة ابن القيم لهذا اليوم";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label4.Location = new System.Drawing.Point(64, 8);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "قائمة الطلاب";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAttandenceList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(34, 303);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1303, 308);
            this.panel2.TabIndex = 2;
            // 
            // dgvAttandenceList
            // 
            this.dgvAttandenceList.AllowUserToAddRows = false;
            this.dgvAttandenceList.AllowUserToDeleteRows = false;
            this.dgvAttandenceList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAttandenceList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentID,
            this.SeatsNumber,
            this.FullName,
            this.NumberAbsentThisMonth,
            this.CircleName,
            this.CircleID,
            this.ParentPhone,
            this.Status});
            this.dgvAttandenceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAttandenceList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAttandenceList.Location = new System.Drawing.Point(0, 0);
            this.dgvAttandenceList.Name = "dgvAttandenceList";
            this.dgvAttandenceList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAttandenceList.RowHeadersWidth = 51;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.dgvAttandenceList.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAttandenceList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.dgvAttandenceList.RowTemplate.Height = 26;
            this.dgvAttandenceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAttandenceList.Size = new System.Drawing.Size(1303, 308);
            this.dgvAttandenceList.TabIndex = 1;
            this.dgvAttandenceList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAttandenceList_CellClick);
            this.dgvAttandenceList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvAttandenceList_CellMouseClick);
            this.dgvAttandenceList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvAttandenceList_CellPainting);
            this.dgvAttandenceList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvAttandenceList_DataBindingComplete);
            // 
            // StudentID
            // 
            this.StudentID.DataPropertyName = "StudentID";
            this.StudentID.HeaderText = "معرف الطالب";
            this.StudentID.MinimumWidth = 6;
            this.StudentID.Name = "StudentID";
            this.StudentID.Width = 125;
            // 
            // SeatsNumber
            // 
            this.SeatsNumber.DataPropertyName = "SeatsNumber";
            this.SeatsNumber.HeaderText = "رقم الجلوس";
            this.SeatsNumber.MinimumWidth = 6;
            this.SeatsNumber.Name = "SeatsNumber";
            this.SeatsNumber.ReadOnly = true;
            this.SeatsNumber.Width = 125;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "اسم الطالب";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.Width = 125;
            // 
            // NumberAbsentThisMonth
            // 
            this.NumberAbsentThisMonth.DataPropertyName = "NumberAbsentThisMonth";
            this.NumberAbsentThisMonth.HeaderText = "عدد مرات الغياب هذا الشهر";
            this.NumberAbsentThisMonth.MinimumWidth = 6;
            this.NumberAbsentThisMonth.Name = "NumberAbsentThisMonth";
            this.NumberAbsentThisMonth.ReadOnly = true;
            this.NumberAbsentThisMonth.Width = 125;
            // 
            // CircleName
            // 
            this.CircleName.DataPropertyName = "CircleName";
            this.CircleName.HeaderText = "اسم الحلقة";
            this.CircleName.MinimumWidth = 6;
            this.CircleName.Name = "CircleName";
            this.CircleName.Width = 125;
            // 
            // CircleID
            // 
            this.CircleID.DataPropertyName = "CircleID";
            this.CircleID.HeaderText = "رقم الحلقة";
            this.CircleID.MinimumWidth = 6;
            this.CircleID.Name = "CircleID";
            this.CircleID.Visible = false;
            this.CircleID.Width = 125;
            // 
            // ParentPhone
            // 
            this.ParentPhone.DataPropertyName = "ParentPhone";
            this.ParentPhone.HeaderText = "رقم الهاتف";
            this.ParentPhone.MinimumWidth = 6;
            this.ParentPhone.Name = "ParentPhone";
            this.ParentPhone.Width = 125;
            // 
            // Status
            // 
            this.Status.HeaderText = "تسجيل الحضور";
            this.Status.MinimumWidth = 6;
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 125;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(204)))));
            this.panel3.Controls.Add(this.tableLayoutPanel6);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(34, 617);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1303, 68);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.62915F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.37085F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 289F));
            this.tableLayoutPanel6.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbTakenAttendanceToday, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.41177F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1303, 68);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // lbTakenAttendanceToday
            // 
            this.lbTakenAttendanceToday.AutoSize = true;
            this.lbTakenAttendanceToday.BackColor = System.Drawing.Color.Beige;
            this.lbTakenAttendanceToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTakenAttendanceToday.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbTakenAttendanceToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbTakenAttendanceToday.Location = new System.Drawing.Point(1007, 10);
            this.lbTakenAttendanceToday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTakenAttendanceToday.Name = "lbTakenAttendanceToday";
            this.lbTakenAttendanceToday.Size = new System.Drawing.Size(282, 48);
            this.lbTakenAttendanceToday.TabIndex = 17;
            this.lbTakenAttendanceToday.Text = "لم يتم تسجيل حضور الطلبة اليوم";
            this.lbTakenAttendanceToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.12195F));
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(983, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82.92683F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(278, 125);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label1.Location = new System.Drawing.Point(36, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(238, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "سجل الحضور والغياب";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label5.Location = new System.Drawing.Point(181, 69);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 36);
            this.label5.TabIndex = 11;
            this.label5.Text = " اليومي";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.2F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(67)))));
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "إدارة حضور الطلاب لحلقة ابن القيم لهذا اليوم";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 95.20295F));
            this.tableLayoutPanel3.Controls.Add(this.btn_SetAllAttendance, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.cmb_Circles, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(704, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.02702F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(273, 125);
            this.tableLayoutPanel3.TabIndex = 8;
            // 
            // cmb_Circles
            // 
            this.cmb_Circles.Dock = System.Windows.Forms.DockStyle.Left;
            this.cmb_Circles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Circles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Circles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_Circles.FormattingEnabled = true;
            this.cmb_Circles.Items.AddRange(new object[] {
            "كل الحلقات"});
            this.cmb_Circles.Location = new System.Drawing.Point(26, 39);
            this.cmb_Circles.Name = "cmb_Circles";
            this.cmb_Circles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_Circles.Size = new System.Drawing.Size(244, 36);
            this.cmb_Circles.TabIndex = 17;
            this.cmb_Circles.SelectedIndexChanged += new System.EventHandler(this.cmb_Circles_SelectedIndexChanged);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.72727F));
            this.tableLayoutPanel2.Controls.Add(this.dtp_DateOfBirth, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(398, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(300, 125);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.CalendarMonthBackground = System.Drawing.Color.LightGoldenrodYellow;
            this.dtp_DateOfBirth.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(44, 42);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(253, 30);
            this.dtp_DateOfBirth.TabIndex = 6;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75.91241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txt_SearchByName, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.68421F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.31579F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(389, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txt_SearchByName
            // 
            this.txt_SearchByName.BackColor = System.Drawing.Color.White;
            this.txt_SearchByName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SearchByName.Dock = System.Windows.Forms.DockStyle.Left;
            this.txt_SearchByName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_SearchByName.Location = new System.Drawing.Point(149, 40);
            this.txt_SearchByName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SearchByName.Name = "txt_SearchByName";
            this.txt_SearchByName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_SearchByName.Size = new System.Drawing.Size(236, 34);
            this.txt_SearchByName.TabIndex = 2;
            this.txt_SearchByName.Tag = "اسم الأول";
            this.txt_SearchByName.TextChanged += new System.EventHandler(this.txt_SearchByName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label3.Location = new System.Drawing.Point(45, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 39);
            this.label3.TabIndex = 8;
            this.label3.Text = "بحث باسم الطالب";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlTLTop
            // 
            this.pnlTLTop.ColumnCount = 4;
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.78895F));
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 21.48887F));
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.48427F));
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.23791F));
            this.pnlTLTop.Controls.Add(this.tableLayoutPanel1, 3, 0);
            this.pnlTLTop.Controls.Add(this.tableLayoutPanel2, 2, 0);
            this.pnlTLTop.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.pnlTLTop.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.pnlTLTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTLTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.pnlTLTop.Location = new System.Drawing.Point(34, 30);
            this.pnlTLTop.Name = "pnlTLTop";
            this.pnlTLTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlTLTop.RowCount = 2;
            this.pnlTLTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.97802F));
            this.pnlTLTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.02198F));
            this.pnlTLTop.Size = new System.Drawing.Size(1303, 182);
            this.pnlTLTop.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(214)))), ((int)(((byte)(91)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(197)))), ((int)(((byte)(108)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(197)))), ((int)(((byte)(108)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 1;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(14, 13);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(314, 42);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "حفظ التغييرات";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btn_SetAllAttendance
            // 
            this.btn_SetAllAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.btn_SetAllAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SetAllAttendance.Dock = System.Windows.Forms.DockStyle.Left;
            this.btn_SetAllAttendance.FlatAppearance.BorderSize = 0;
            this.btn_SetAllAttendance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_SetAllAttendance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_SetAllAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetAllAttendance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SetAllAttendance.ForeColor = System.Drawing.Color.White;
            this.btn_SetAllAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SetAllAttendance.ImageIndex = 0;
            this.btn_SetAllAttendance.ImageList = this.imageList1;
            this.btn_SetAllAttendance.Location = new System.Drawing.Point(27, 78);
            this.btn_SetAllAttendance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_SetAllAttendance.Name = "btn_SetAllAttendance";
            this.btn_SetAllAttendance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_SetAllAttendance.Size = new System.Drawing.Size(242, 44);
            this.btn_SetAllAttendance.TabIndex = 15;
            this.btn_SetAllAttendance.Text = "تحديد الكل حاضر";
            this.btn_SetAllAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SetAllAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SetAllAttendance.UseVisualStyleBackColor = false;
            this.btn_SetAllAttendance.Click += new System.EventHandler(this.btn_SetAllAttendance_Click);
            // 
            // US_AttendanceMangement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTLTop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.Name = "US_AttendanceMangement";
            this.Padding = new System.Windows.Forms.Padding(34, 30, 34, 5);
            this.Size = new System.Drawing.Size(1371, 690);
            this.Load += new System.EventHandler(this.US_AttendanceMangement_Load);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttandenceList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.pnlTLTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvAttandenceList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbTakenAttendanceToday;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SeatsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberAbsentThisMonth;
        private System.Windows.Forms.DataGridViewTextBoxColumn CircleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CircleID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParentPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_SetAllAttendance;
        private System.Windows.Forms.ComboBox cmb_Circles;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DateTimePicker dtp_DateOfBirth;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_SearchByName;
        private System.Windows.Forms.TableLayoutPanel pnlTLTop;
    }
}
