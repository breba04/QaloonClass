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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lbTakenAttendanceToday = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SetAllAttendance = new System.Windows.Forms.Button();
            this.cmb_Circles = new System.Windows.Forms.ComboBox();
            this.dtp_DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.txt_SearchByName = new System.Windows.Forms.TextBox();
            this.pnlTLTop = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttandenceList)).BeginInit();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.pnlTLTop.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(26, 167);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1462, 69);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.AutoSize = true;
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(1138, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel5.Size = new System.Drawing.Size(324, 69);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.2F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(67)))));
            this.label6.Location = new System.Drawing.Point(14, 38);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(296, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "إدارة حضور الطلاب لحلقة ابن القيم لهذا اليوم";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(14, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(296, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "قائمة الطلاب";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(258, 6);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 6);
            this.panel4.Size = new System.Drawing.Size(173, 65);
            this.panel4.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvAttandenceList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(26, 236);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1462, 327);
            this.panel2.TabIndex = 2;
            // 
            // dgvAttandenceList
            // 
            this.dgvAttandenceList.AllowUserToAddRows = false;
            this.dgvAttandenceList.AllowUserToDeleteRows = false;
            this.dgvAttandenceList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(228)))), ((int)(((byte)(204)))));
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
            this.dgvAttandenceList.ReadOnly = true;
            this.dgvAttandenceList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgvAttandenceList.RowHeadersWidth = 51;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.dgvAttandenceList.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAttandenceList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.dgvAttandenceList.RowTemplate.Height = 26;
            this.dgvAttandenceList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvAttandenceList.Size = new System.Drawing.Size(1462, 327);
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
            this.StudentID.ReadOnly = true;
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
            this.FullName.ReadOnly = true;
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
            this.CircleName.ReadOnly = true;
            this.CircleName.Width = 125;
            // 
            // CircleID
            // 
            this.CircleID.DataPropertyName = "CircleID";
            this.CircleID.HeaderText = "رقم الحلقة";
            this.CircleID.MinimumWidth = 6;
            this.CircleID.Name = "CircleID";
            this.CircleID.ReadOnly = true;
            this.CircleID.Visible = false;
            this.CircleID.Width = 125;
            // 
            // ParentPhone
            // 
            this.ParentPhone.DataPropertyName = "ParentPhone";
            this.ParentPhone.HeaderText = "رقم الهاتف";
            this.ParentPhone.MinimumWidth = 6;
            this.ParentPhone.Name = "ParentPhone";
            this.ParentPhone.ReadOnly = true;
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
            this.panel3.Location = new System.Drawing.Point(26, 636);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1462, 80);
            this.panel3.TabIndex = 3;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 4;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.62915F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 51.37085F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 195F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 294F));
            this.tableLayoutPanel6.Controls.Add(this.btnSave, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.lbTakenAttendanceToday, 3, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.Padding = new System.Windows.Forms.Padding(8, 11, 8, 11);
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 79.41177F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(1462, 80);
            this.tableLayoutPanel6.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(197)))), ((int)(((byte)(108)))));
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(197)))), ((int)(((byte)(108)))));
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageIndex = 1;
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(12, 14);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(457, 52);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "حفظ التغييرات";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbTakenAttendanceToday
            // 
            this.lbTakenAttendanceToday.AutoSize = true;
            this.lbTakenAttendanceToday.BackColor = System.Drawing.Color.Beige;
            this.lbTakenAttendanceToday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTakenAttendanceToday.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lbTakenAttendanceToday.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.lbTakenAttendanceToday.Location = new System.Drawing.Point(1163, 11);
            this.lbTakenAttendanceToday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTakenAttendanceToday.Name = "lbTakenAttendanceToday";
            this.lbTakenAttendanceToday.Size = new System.Drawing.Size(287, 58);
            this.lbTakenAttendanceToday.TabIndex = 17;
            this.lbTakenAttendanceToday.Text = "لم يتم تسجيل حضور الطلبة اليوم";
            this.lbTakenAttendanceToday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label5.Location = new System.Drawing.Point(129, 36);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = " اليومي";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(4, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 36);
            this.label1.TabIndex = 9;
            this.label1.Text = "سجل الحضور والغياب";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btn_SetAllAttendance
            // 
            this.btn_SetAllAttendance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(64)))), ((int)(((byte)(43)))));
            this.btn_SetAllAttendance.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_SetAllAttendance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_SetAllAttendance.FlatAppearance.BorderSize = 0;
            this.btn_SetAllAttendance.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_SetAllAttendance.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_SetAllAttendance.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SetAllAttendance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btn_SetAllAttendance.ForeColor = System.Drawing.Color.White;
            this.btn_SetAllAttendance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_SetAllAttendance.ImageIndex = 0;
            this.btn_SetAllAttendance.ImageList = this.imageList1;
            this.btn_SetAllAttendance.Location = new System.Drawing.Point(1016, 84);
            this.btn_SetAllAttendance.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_SetAllAttendance.Name = "btn_SetAllAttendance";
            this.btn_SetAllAttendance.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btn_SetAllAttendance.Size = new System.Drawing.Size(217, 38);
            this.btn_SetAllAttendance.TabIndex = 15;
            this.btn_SetAllAttendance.Text = "تحديد الكل حاضر";
            this.btn_SetAllAttendance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_SetAllAttendance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_SetAllAttendance.UseVisualStyleBackColor = false;
            this.btn_SetAllAttendance.Click += new System.EventHandler(this.btn_SetAllAttendance_Click);
            // 
            // cmb_Circles
            // 
            this.cmb_Circles.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cmb_Circles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Circles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmb_Circles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmb_Circles.FormattingEnabled = true;
            this.cmb_Circles.Items.AddRange(new object[] {
            "كل الحلقات"});
            this.cmb_Circles.Location = new System.Drawing.Point(1015, 47);
            this.cmb_Circles.Name = "cmb_Circles";
            this.cmb_Circles.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmb_Circles.Size = new System.Drawing.Size(219, 31);
            this.cmb_Circles.TabIndex = 17;
            this.cmb_Circles.SelectedIndexChanged += new System.EventHandler(this.cmb_Circles_SelectedIndexChanged);
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.CalendarMonthBackground = System.Drawing.Color.LightGoldenrodYellow;
            this.dtp_DateOfBirth.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtp_DateOfBirth.Enabled = false;
            this.dtp_DateOfBirth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(783, 48);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(226, 30);
            this.dtp_DateOfBirth.TabIndex = 6;
            // 
            // txt_SearchByName
            // 
            this.txt_SearchByName.BackColor = System.Drawing.Color.White;
            this.txt_SearchByName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SearchByName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_SearchByName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_SearchByName.Location = new System.Drawing.Point(325, 48);
            this.txt_SearchByName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txt_SearchByName.Name = "txt_SearchByName";
            this.txt_SearchByName.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txt_SearchByName.Size = new System.Drawing.Size(282, 30);
            this.txt_SearchByName.TabIndex = 2;
            this.txt_SearchByName.Tag = "اسم الأول";
            this.txt_SearchByName.TextChanged += new System.EventHandler(this.txt_SearchByName_TextChanged);
            // 
            // pnlTLTop
            // 
            this.pnlTLTop.ColumnCount = 6;
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 215F));
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlTLTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlTLTop.Controls.Add(this.dtp_DateOfBirth, 2, 0);
            this.pnlTLTop.Controls.Add(this.cmb_Circles, 1, 0);
            this.pnlTLTop.Controls.Add(this.btn_SetAllAttendance, 1, 1);
            this.pnlTLTop.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.pnlTLTop.Controls.Add(this.txt_SearchByName, 4, 0);
            this.pnlTLTop.Controls.Add(this.label7, 0, 1);
            this.pnlTLTop.Controls.Add(this.label3, 3, 0);
            this.pnlTLTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTLTop.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.pnlTLTop.Location = new System.Drawing.Point(26, 32);
            this.pnlTLTop.Name = "pnlTLTop";
            this.pnlTLTop.Padding = new System.Windows.Forms.Padding(10);
            this.pnlTLTop.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnlTLTop.RowCount = 2;
            this.pnlTLTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 62.20473F));
            this.pnlTLTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.79527F));
            this.pnlTLTop.Size = new System.Drawing.Size(1462, 135);
            this.pnlTLTop.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1240, 13);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.55556F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(209, 65);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(67)))));
            this.label7.Location = new System.Drawing.Point(1257, 81);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(191, 40);
            this.label7.TabIndex = 20;
            this.label7.Text = "إدارة حضور الطلاب لحلقة ابن القيم لهذا اليوم";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Right;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.label3.Location = new System.Drawing.Point(615, 10);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.label3.Size = new System.Drawing.Size(161, 71);
            this.label3.TabIndex = 8;
            this.label3.Text = "بحث باسم الطالب";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // US_AttendanceMangement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlTLTop);
            this.Font = new System.Drawing.Font("Segoe UI", 7.8F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "US_AttendanceMangement";
            this.Padding = new System.Windows.Forms.Padding(26, 32, 26, 5);
            this.Size = new System.Drawing.Size(1514, 721);
            this.Load += new System.EventHandler(this.US_AttendanceMangement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAttandenceList)).EndInit();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.pnlTLTop.ResumeLayout(false);
            this.pnlTLTop.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_SetAllAttendance;
        private System.Windows.Forms.ComboBox cmb_Circles;
        private System.Windows.Forms.DateTimePicker dtp_DateOfBirth;
        private System.Windows.Forms.TextBox txt_SearchByName;
        private System.Windows.Forms.TableLayoutPanel pnlTLTop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}
