namespace UI.Students.StudentControls
{
    partial class UC_Student
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbl_TotalStudent = new System.Windows.Forms.Label();
            this.pnl_SectionTotalStudent = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cmb_IsActive = new System.Windows.Forms.ComboBox();
            this.txt_Research = new System.Windows.Forms.TextBox();
            this.lbl_To = new System.Windows.Forms.Label();
            this.lbl_From = new System.Windows.Forms.Label();
            this.dtp_ToDate = new System.Windows.Forms.DateTimePicker();
            this.dtp_FormDate = new System.Windows.Forms.DateTimePicker();
            this.cmb_AllFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnl_SectionFilter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_StudentsOfDisplayed = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_SubTitle = new System.Windows.Forms.Label();
            this.pnl_SectionMainTitle = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pnl_SectionGreeting = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbl_PageNumbering = new System.Windows.Forms.Label();
            this.pnl_SectionPageNumbering = new System.Windows.Forms.Panel();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.pnl_SectionButton = new System.Windows.Forms.Panel();
            this.pnl_SectionBottomBar = new System.Windows.Forms.Panel();
            this.cms_StudentActions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.StudentDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddStudent_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.StudentSuspendedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ActivateStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.UpdateStudentProgress_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pnl_SectionListreports = new System.Windows.Forms.Panel();
            this.pnl_SectionٍListStudents = new System.Windows.Forms.Panel();
            this.dgv_ListStudents = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnl_SectionTotalStudent.SuspendLayout();
            this.pnl_SectionFilter.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.pnl_SectionMainTitle.SuspendLayout();
            this.pnl_SectionGreeting.SuspendLayout();
            this.pnl_SectionPageNumbering.SuspendLayout();
            this.pnl_SectionButton.SuspendLayout();
            this.pnl_SectionBottomBar.SuspendLayout();
            this.cms_StudentActions.SuspendLayout();
            this.pnl_SectionListreports.SuspendLayout();
            this.pnl_SectionٍListStudents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_TotalStudent
            // 
            this.lbl_TotalStudent.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_TotalStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.lbl_TotalStudent.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_TotalStudent.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TotalStudent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(214)))), ((int)(((byte)(91)))));
            this.lbl_TotalStudent.Location = new System.Drawing.Point(7, 70);
            this.lbl_TotalStudent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_TotalStudent.Name = "lbl_TotalStudent";
            this.lbl_TotalStudent.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_TotalStudent.Size = new System.Drawing.Size(178, 60);
            this.lbl_TotalStudent.TabIndex = 45;
            this.lbl_TotalStudent.Text = "34";
            this.lbl_TotalStudent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_SectionTotalStudent
            // 
            this.pnl_SectionTotalStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.pnl_SectionTotalStudent.Controls.Add(this.lbl_TotalStudent);
            this.pnl_SectionTotalStudent.Controls.Add(this.label2);
            this.pnl_SectionTotalStudent.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_SectionTotalStudent.Location = new System.Drawing.Point(360, 0);
            this.pnl_SectionTotalStudent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnl_SectionTotalStudent.Name = "pnl_SectionTotalStudent";
            this.pnl_SectionTotalStudent.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnl_SectionTotalStudent.Size = new System.Drawing.Size(302, 155);
            this.pnl_SectionTotalStudent.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(176, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(126, 46);
            this.label2.TabIndex = 44;
            this.label2.Text = ":إجمالي";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmb_IsActive
            // 
            this.cmb_IsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_IsActive.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmb_IsActive.FormattingEnabled = true;
            this.cmb_IsActive.Items.AddRange(new object[] {
            "نشط",
            "متوقف"});
            this.cmb_IsActive.Location = new System.Drawing.Point(662, 33);
            this.cmb_IsActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_IsActive.Name = "cmb_IsActive";
            this.cmb_IsActive.Size = new System.Drawing.Size(142, 36);
            this.cmb_IsActive.TabIndex = 44;
            this.cmb_IsActive.SelectedIndexChanged += new System.EventHandler(this.cmb_IsActive_SelectedIndexChanged);
            // 
            // txt_Research
            // 
            this.txt_Research.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Research.Location = new System.Drawing.Point(358, 30);
            this.txt_Research.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txt_Research.Name = "txt_Research";
            this.txt_Research.Size = new System.Drawing.Size(445, 39);
            this.txt_Research.TabIndex = 42;
            this.txt_Research.TextChanged += new System.EventHandler(this.txt_Research_TextChanged);
            this.txt_Research.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Research_KeyPress);
            // 
            // lbl_To
            // 
            this.lbl_To.AutoSize = true;
            this.lbl_To.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_To.Location = new System.Drawing.Point(472, 27);
            this.lbl_To.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_To.Name = "lbl_To";
            this.lbl_To.Size = new System.Drawing.Size(56, 37);
            this.lbl_To.TabIndex = 43;
            this.lbl_To.Text = "إلى";
            // 
            // lbl_From
            // 
            this.lbl_From.AutoSize = true;
            this.lbl_From.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lbl_From.Location = new System.Drawing.Point(757, 28);
            this.lbl_From.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_From.Name = "lbl_From";
            this.lbl_From.Size = new System.Drawing.Size(58, 37);
            this.lbl_From.TabIndex = 42;
            this.lbl_From.Text = " من";
            // 
            // dtp_ToDate
            // 
            this.dtp_ToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dtp_ToDate.Location = new System.Drawing.Point(255, 33);
            this.dtp_ToDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_ToDate.Name = "dtp_ToDate";
            this.dtp_ToDate.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dtp_ToDate.Size = new System.Drawing.Size(198, 34);
            this.dtp_ToDate.TabIndex = 34;
            this.dtp_ToDate.ValueChanged += new System.EventHandler(this.dtp_ToDate_ValueChanged);
            // 
            // dtp_FormDate
            // 
            this.dtp_FormDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.dtp_FormDate.Location = new System.Drawing.Point(539, 33);
            this.dtp_FormDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtp_FormDate.Name = "dtp_FormDate";
            this.dtp_FormDate.Size = new System.Drawing.Size(198, 34);
            this.dtp_FormDate.TabIndex = 33;
            this.dtp_FormDate.ValueChanged += new System.EventHandler(this.dtp_FormDate_ValueChanged);
            // 
            // cmb_AllFilter
            // 
            this.cmb_AllFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_AllFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmb_AllFilter.FormattingEnabled = true;
            this.cmb_AllFilter.Location = new System.Drawing.Point(838, 33);
            this.cmb_AllFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmb_AllFilter.Name = "cmb_AllFilter";
            this.cmb_AllFilter.Size = new System.Drawing.Size(219, 36);
            this.cmb_AllFilter.TabIndex = 32;
            this.cmb_AllFilter.SelectedIndexChanged += new System.EventHandler(this.cmb_AllFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.label1.Location = new System.Drawing.Point(1049, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(159, 46);
            this.label1.TabIndex = 31;
            this.label1.Text = ":تصفية حسب";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_SectionFilter
            // 
            this.pnl_SectionFilter.Controls.Add(this.txt_Research);
            this.pnl_SectionFilter.Controls.Add(this.cmb_IsActive);
            this.pnl_SectionFilter.Controls.Add(this.lbl_To);
            this.pnl_SectionFilter.Controls.Add(this.lbl_From);
            this.pnl_SectionFilter.Controls.Add(this.dtp_ToDate);
            this.pnl_SectionFilter.Controls.Add(this.dtp_FormDate);
            this.pnl_SectionFilter.Controls.Add(this.cmb_AllFilter);
            this.pnl_SectionFilter.Controls.Add(this.label1);
            this.pnl_SectionFilter.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_SectionFilter.Location = new System.Drawing.Point(1179, 0);
            this.pnl_SectionFilter.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionFilter.Name = "pnl_SectionFilter";
            this.pnl_SectionFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnl_SectionFilter.Size = new System.Drawing.Size(1217, 155);
            this.pnl_SectionFilter.TabIndex = 42;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pnl_SectionTotalStudent);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.pnl_SectionFilter);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 117);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(2396, 155);
            this.panel1.TabIndex = 41;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(332, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(28, 155);
            this.panel4.TabIndex = 1;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.panel5.Controls.Add(this.lbl_StudentsOfDisplayed);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(30, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel5.Name = "panel5";
            this.panel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel5.Size = new System.Drawing.Size(302, 155);
            this.panel5.TabIndex = 46;
            // 
            // lbl_StudentsOfDisplayed
            // 
            this.lbl_StudentsOfDisplayed.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_StudentsOfDisplayed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.lbl_StudentsOfDisplayed.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_StudentsOfDisplayed.Font = new System.Drawing.Font("Segoe UI", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StudentsOfDisplayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(214)))), ((int)(((byte)(91)))));
            this.lbl_StudentsOfDisplayed.Location = new System.Drawing.Point(4, 70);
            this.lbl_StudentsOfDisplayed.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_StudentsOfDisplayed.Name = "lbl_StudentsOfDisplayed";
            this.lbl_StudentsOfDisplayed.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_StudentsOfDisplayed.Size = new System.Drawing.Size(178, 60);
            this.lbl_StudentsOfDisplayed.TabIndex = 46;
            this.lbl_StudentsOfDisplayed.Text = "34";
            this.lbl_StudentsOfDisplayed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(142, 21);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(162, 46);
            this.label4.TabIndex = 44;
            this.label4.Text = ":المعروض";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(30, 155);
            this.panel3.TabIndex = 2;
            // 
            // lbl_SubTitle
            // 
            this.lbl_SubTitle.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_SubTitle.AutoSize = true;
            this.lbl_SubTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_SubTitle.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.lbl_SubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(113)))), ((int)(((byte)(122)))));
            this.lbl_SubTitle.Location = new System.Drawing.Point(518, 75);
            this.lbl_SubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_SubTitle.Name = "lbl_SubTitle";
            this.lbl_SubTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_SubTitle.Size = new System.Drawing.Size(737, 41);
            this.lbl_SubTitle.TabIndex = 31;
            this.lbl_SubTitle.Text = "قائمة شاملة لطلاب مركز نور ومتابعة مستوياتهم الأكاديمية";
            this.lbl_SubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_SectionMainTitle
            // 
            this.pnl_SectionMainTitle.Controls.Add(this.lbl_SubTitle);
            this.pnl_SectionMainTitle.Controls.Add(this.label5);
            this.pnl_SectionMainTitle.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_SectionMainTitle.Location = new System.Drawing.Point(1149, 0);
            this.pnl_SectionMainTitle.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionMainTitle.Name = "pnl_SectionMainTitle";
            this.pnl_SectionMainTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnl_SectionMainTitle.Size = new System.Drawing.Size(1204, 117);
            this.pnl_SectionMainTitle.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Dock = System.Windows.Forms.DockStyle.Right;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.label5.Location = new System.Drawing.Point(823, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(381, 59);
            this.label5.TabIndex = 29;
            this.label5.Text = "إدارة سجلات الطلاب";
            // 
            // pnl_SectionGreeting
            // 
            this.pnl_SectionGreeting.BackColor = System.Drawing.Color.Transparent;
            this.pnl_SectionGreeting.Controls.Add(this.pnl_SectionMainTitle);
            this.pnl_SectionGreeting.Controls.Add(this.panel6);
            this.pnl_SectionGreeting.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_SectionGreeting.Location = new System.Drawing.Point(0, 0);
            this.pnl_SectionGreeting.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionGreeting.Name = "pnl_SectionGreeting";
            this.pnl_SectionGreeting.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pnl_SectionGreeting.Size = new System.Drawing.Size(2396, 117);
            this.pnl_SectionGreeting.TabIndex = 40;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel6.Location = new System.Drawing.Point(2353, 0);
            this.panel6.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(43, 117);
            this.panel6.TabIndex = 41;
            // 
            // lbl_PageNumbering
            // 
            this.lbl_PageNumbering.AutoSize = true;
            this.lbl_PageNumbering.BackColor = System.Drawing.Color.Transparent;
            this.lbl_PageNumbering.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbl_PageNumbering.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PageNumbering.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(73)))), ((int)(((byte)(93)))));
            this.lbl_PageNumbering.Location = new System.Drawing.Point(38, 23);
            this.lbl_PageNumbering.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PageNumbering.Name = "lbl_PageNumbering";
            this.lbl_PageNumbering.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_PageNumbering.Size = new System.Drawing.Size(110, 28);
            this.lbl_PageNumbering.TabIndex = 43;
            this.lbl_PageNumbering.Text = "رقم الصفحة";
            this.lbl_PageNumbering.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_SectionPageNumbering
            // 
            this.pnl_SectionPageNumbering.BackColor = System.Drawing.Color.Transparent;
            this.pnl_SectionPageNumbering.Controls.Add(this.lbl_PageNumbering);
            this.pnl_SectionPageNumbering.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnl_SectionPageNumbering.Location = new System.Drawing.Point(0, 0);
            this.pnl_SectionPageNumbering.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionPageNumbering.Name = "pnl_SectionPageNumbering";
            this.pnl_SectionPageNumbering.Size = new System.Drawing.Size(282, 76);
            this.pnl_SectionPageNumbering.TabIndex = 41;
            // 
            // btn_Previous
            // 
            this.btn_Previous.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Previous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(190)))));
            this.btn_Previous.FlatAppearance.BorderSize = 0;
            this.btn_Previous.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.btn_Previous.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(160)))));
            this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Previous.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Previous.Location = new System.Drawing.Point(31, 14);
            this.btn_Previous.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(98, 49);
            this.btn_Previous.TabIndex = 0;
            this.btn_Previous.Text = "السابق";
            this.btn_Previous.UseVisualStyleBackColor = false;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Next.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(40)))), ((int)(((byte)(25)))));
            this.btn_Next.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(202)))));
            this.btn_Next.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_Next.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(79)))), ((int)(((byte)(63)))));
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Next.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Next.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(202)))));
            this.btn_Next.Location = new System.Drawing.Point(149, 14);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(98, 49);
            this.btn_Next.TabIndex = 1;
            this.btn_Next.Text = "التالي";
            this.btn_Next.UseVisualStyleBackColor = false;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // pnl_SectionButton
            // 
            this.pnl_SectionButton.BackColor = System.Drawing.Color.Transparent;
            this.pnl_SectionButton.Controls.Add(this.btn_Previous);
            this.pnl_SectionButton.Controls.Add(this.btn_Next);
            this.pnl_SectionButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnl_SectionButton.Location = new System.Drawing.Point(2114, 0);
            this.pnl_SectionButton.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionButton.Name = "pnl_SectionButton";
            this.pnl_SectionButton.Size = new System.Drawing.Size(282, 76);
            this.pnl_SectionButton.TabIndex = 40;
            // 
            // pnl_SectionBottomBar
            // 
            this.pnl_SectionBottomBar.Controls.Add(this.pnl_SectionPageNumbering);
            this.pnl_SectionBottomBar.Controls.Add(this.pnl_SectionButton);
            this.pnl_SectionBottomBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_SectionBottomBar.Location = new System.Drawing.Point(0, 1171);
            this.pnl_SectionBottomBar.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionBottomBar.Name = "pnl_SectionBottomBar";
            this.pnl_SectionBottomBar.Size = new System.Drawing.Size(2396, 76);
            this.pnl_SectionBottomBar.TabIndex = 39;
            // 
            // cms_StudentActions
            // 
            this.cms_StudentActions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_StudentActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StudentDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.AddStudent_ToolStripMenuItem,
            this.UpdateStudentToolStripMenuItem,
            this.toolStripMenuItem3,
            this.StudentSuspendedToolStripMenuItem,
            this.ActivateStudentToolStripMenuItem,
            this.toolStripMenuItem2,
            this.UpdateStudentProgress_ToolStripMenuItem});
            this.cms_StudentActions.Name = "contextMenuStrip1";
            this.cms_StudentActions.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cms_StudentActions.Size = new System.Drawing.Size(190, 166);
            // 
            // StudentDetailsToolStripMenuItem
            // 
            this.StudentDetailsToolStripMenuItem.Name = "StudentDetailsToolStripMenuItem";
            this.StudentDetailsToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.StudentDetailsToolStripMenuItem.Text = "تفاصيل الطالب";
            this.StudentDetailsToolStripMenuItem.Click += new System.EventHandler(this.StudentDetailsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // AddStudent_ToolStripMenuItem
            // 
            this.AddStudent_ToolStripMenuItem.Name = "AddStudent_ToolStripMenuItem";
            this.AddStudent_ToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.AddStudent_ToolStripMenuItem.Text = "إضافة طالب";
            this.AddStudent_ToolStripMenuItem.Click += new System.EventHandler(this.AddStudent_ToolStripMenuItem_Click);
            // 
            // UpdateStudentToolStripMenuItem
            // 
            this.UpdateStudentToolStripMenuItem.Name = "UpdateStudentToolStripMenuItem";
            this.UpdateStudentToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.UpdateStudentToolStripMenuItem.Text = "تعديل طالب";
            this.UpdateStudentToolStripMenuItem.Click += new System.EventHandler(this.UpdateStudentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(186, 6);
            // 
            // StudentSuspendedToolStripMenuItem
            // 
            this.StudentSuspendedToolStripMenuItem.Name = "StudentSuspendedToolStripMenuItem";
            this.StudentSuspendedToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.StudentSuspendedToolStripMenuItem.Text = "إيقاف طالب";
            this.StudentSuspendedToolStripMenuItem.Click += new System.EventHandler(this.StudentSuspendedToolStripMenuItem_Click);
            // 
            // ActivateStudentToolStripMenuItem
            // 
            this.ActivateStudentToolStripMenuItem.Name = "ActivateStudentToolStripMenuItem";
            this.ActivateStudentToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.ActivateStudentToolStripMenuItem.Text = "تفعيل طالب";
            this.ActivateStudentToolStripMenuItem.Click += new System.EventHandler(this.ActivateStudentToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(186, 6);
            // 
            // UpdateStudentProgress_ToolStripMenuItem
            // 
            this.UpdateStudentProgress_ToolStripMenuItem.Name = "UpdateStudentProgress_ToolStripMenuItem";
            this.UpdateStudentProgress_ToolStripMenuItem.Size = new System.Drawing.Size(189, 24);
            this.UpdateStudentProgress_ToolStripMenuItem.Text = "تعديل تقدم طالب";
            this.UpdateStudentProgress_ToolStripMenuItem.Click += new System.EventHandler(this.UpdateStudentProgress_ToolStripMenuItem_Click);
            // 
            // pnl_SectionListreports
            // 
            this.pnl_SectionListreports.Controls.Add(this.pnl_SectionٍListStudents);
            this.pnl_SectionListreports.Controls.Add(this.pnl_SectionBottomBar);
            this.pnl_SectionListreports.Controls.Add(this.panel2);
            this.pnl_SectionListreports.Controls.Add(this.panel1);
            this.pnl_SectionListreports.Controls.Add(this.pnl_SectionGreeting);
            this.pnl_SectionListreports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_SectionListreports.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.pnl_SectionListreports.Location = new System.Drawing.Point(0, 0);
            this.pnl_SectionListreports.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionListreports.Name = "pnl_SectionListreports";
            this.pnl_SectionListreports.Size = new System.Drawing.Size(2396, 1247);
            this.pnl_SectionListreports.TabIndex = 43;
            // 
            // pnl_SectionٍListStudents
            // 
            this.pnl_SectionٍListStudents.Controls.Add(this.dgv_ListStudents);
            this.pnl_SectionٍListStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_SectionٍListStudents.Location = new System.Drawing.Point(0, 415);
            this.pnl_SectionٍListStudents.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.pnl_SectionٍListStudents.Name = "pnl_SectionٍListStudents";
            this.pnl_SectionٍListStudents.Size = new System.Drawing.Size(2396, 756);
            this.pnl_SectionٍListStudents.TabIndex = 42;
            // 
            // dgv_ListStudents
            // 
            this.dgv_ListStudents.AllowUserToAddRows = false;
            this.dgv_ListStudents.AllowUserToDeleteRows = false;
            this.dgv_ListStudents.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_ListStudents.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_ListStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_ListStudents.ContextMenuStrip = this.cms_StudentActions;
            this.dgv_ListStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_ListStudents.Location = new System.Drawing.Point(0, 0);
            this.dgv_ListStudents.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.dgv_ListStudents.Name = "dgv_ListStudents";
            this.dgv_ListStudents.ReadOnly = true;
            this.dgv_ListStudents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgv_ListStudents.RowHeadersWidth = 51;
            this.dgv_ListStudents.RowTemplate.Height = 26;
            this.dgv_ListStudents.Size = new System.Drawing.Size(2396, 756);
            this.dgv_ListStudents.TabIndex = 39;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 272);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(2396, 143);
            this.panel2.TabIndex = 43;
            // 
            // UC_Student
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnl_SectionListreports);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "UC_Student";
            this.Size = new System.Drawing.Size(2396, 1247);
            this.Load += new System.EventHandler(this.UC_Student_Load);
            this.pnl_SectionTotalStudent.ResumeLayout(false);
            this.pnl_SectionTotalStudent.PerformLayout();
            this.pnl_SectionFilter.ResumeLayout(false);
            this.pnl_SectionFilter.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.pnl_SectionMainTitle.ResumeLayout(false);
            this.pnl_SectionMainTitle.PerformLayout();
            this.pnl_SectionGreeting.ResumeLayout(false);
            this.pnl_SectionPageNumbering.ResumeLayout(false);
            this.pnl_SectionPageNumbering.PerformLayout();
            this.pnl_SectionButton.ResumeLayout(false);
            this.pnl_SectionBottomBar.ResumeLayout(false);
            this.cms_StudentActions.ResumeLayout(false);
            this.pnl_SectionListreports.ResumeLayout(false);
            this.pnl_SectionٍListStudents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListStudents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_TotalStudent;
        private System.Windows.Forms.Panel pnl_SectionTotalStudent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_IsActive;
        private System.Windows.Forms.TextBox txt_Research;
        private System.Windows.Forms.Label lbl_To;
        private System.Windows.Forms.Label lbl_From;
        private System.Windows.Forms.DateTimePicker dtp_ToDate;
        private System.Windows.Forms.DateTimePicker dtp_FormDate;
        private System.Windows.Forms.ComboBox cmb_AllFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnl_SectionFilter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_SubTitle;
        private System.Windows.Forms.Panel pnl_SectionMainTitle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel pnl_SectionGreeting;
        private System.Windows.Forms.Label lbl_PageNumbering;
        private System.Windows.Forms.Panel pnl_SectionPageNumbering;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Panel pnl_SectionButton;
        private System.Windows.Forms.ContextMenuStrip cms_StudentActions;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel pnl_SectionListreports;
        private System.Windows.Forms.Panel pnl_SectionBottomBar;
        private System.Windows.Forms.Panel pnl_SectionٍListStudents;
        private System.Windows.Forms.DataGridView dgv_ListStudents;
        private System.Windows.Forms.ToolStripMenuItem StudentDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem UpdateStudentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StudentSuspendedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddStudent_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem UpdateStudentProgress_ToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.ToolStripMenuItem ActivateStudentToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_StudentsOfDisplayed;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
    }
}
