using BusinessLayer;
using Microsoft.Win32;
using System;
using System.Data;
using System.Windows.Forms;
using UI.GlobalClasses;

namespace UI.Students.StudentControls
{
    public partial class UC_Student : UserControl
    {
        enum enFilterMode { None, StudentID, FullName, Address, ParentPhone, JoinDate, CircleName, IsActive }

        private enFilterMode _FilterMode;
        private clsUtil.stPagingInfo _PagingInfo;
        private DataTable _allData;
        private DataView _ListStudents;

        public UC_Student()
        {
            InitializeComponent();
            clsAppEvents.StudentAdded += AppEvents_StudentAdded;
        }
        private void AppEvents_StudentAdded(object sender, EventArgs e)
        {
            _RefreshStudentList(); 
        }
        private void _DisplayTotalStudentsCount()
        {
            lbl_TotalStudent.Text = _allData?.Rows?.Count.ToString() ?? "0";
        }
        private void _DisplayfilteredCount()
        {
            lbl_StudentsOfDisplayed.Text = _ListStudents?.Count.ToString() ?? "0";
        }
        private void _SetDefaultPaging()
        {
            _PagingInfo.pageSize = 10;
            _PagingInfo.currentPage = 1;
            _PagingInfo.totalPages = 1;
        }
        private void _InitializeFilterComboBox()
        {
            clsUtil.LoadItemsInComboBox(cmb_AllFilter, 
                "لا أحد",
                "رقم الطالب",
                "اسم الطالب بالكامل",
                "العنوان",
                "رقم هاتف ولي الأمر",
                "تاريخ الالتحاق بالحلقة",
                "اسم الحلقة",
                "حالة الطالب"
            );
        }
        private void _InitializeIsActiveComboBox()
        {
            clsUtil.LoadItemsInComboBox(cmb_IsActive, "كل", "نشط", "متوقف") ;
        }
        
        private void _UpdateFilterState()
        {
            _FilterMode = (enFilterMode)cmb_AllFilter.SelectedIndex;

            switch (_FilterMode)
            {
                case enFilterMode.None:
                    _SetFilterControlsVisibility(searchVisible: false, activeVisible: false, dateFromVisible: false, dateToVisible: false);
                    break;

                case enFilterMode.IsActive:
                    _SetFilterControlsVisibility(searchVisible: false, activeVisible: true, dateFromVisible: false, dateToVisible: false);
                    break;

                case enFilterMode.JoinDate:
                    _SetFilterControlsVisibility(searchVisible: false, activeVisible: false, dateFromVisible: true, dateToVisible: true);
                    break;

                default:
                    _SetFilterControlsVisibility(searchVisible: true, activeVisible: false, dateFromVisible: false, dateToVisible: false);
                    break;
            }


            txt_Research.Clear();
            dtp_FormDate.Value = DateTime.Now;
            dtp_ToDate.Value = DateTime.Now;
            _FilterResult();
        }
        private void _SetFilterControlsVisibility(bool searchVisible, bool activeVisible, bool dateFromVisible, bool dateToVisible)
        {
            txt_Research.Visible = searchVisible;
            cmb_IsActive.Visible = activeVisible;

            dtp_FormDate.Visible = dateFromVisible;
            lbl_From.Visible = dateFromVisible;
            dtp_ToDate.Visible = dateToVisible;
            lbl_To.Visible = dateToVisible;
        }
        private void cmb_AllFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdateFilterState();
        }
        private void _RefreshStudentList()
        {
            _allData = clsStudents.SelectAllStudents();
            _ListStudents = new DataView(_allData);
            dgv_ListStudents.DataSource = _ListStudents;
            _FormatDataGridView();
        }
        private void _FilterResult()
        {
            if (_ListStudents == null) return;
            
            string filterExpression = "";
            string filterValue = clsUtil.EscapeRowFilterValue(txt_Research.Text.Trim()); 
            bool hasText = txt_Research.Visible && !string.IsNullOrWhiteSpace(txt_Research.Text);
            _PagingInfo.currentPage = 1;

            switch (_FilterMode)
            {
                case enFilterMode.StudentID:
                    if (hasText)
                    {
                        filterExpression = clsUtil.GetFilterExpression(_FilterMode.ToString(), clsUtil.enTypeOfFilter.Int, filterValue);
                    }
                    break;

                case enFilterMode.FullName:
                case enFilterMode.CircleName:
                case enFilterMode.Address:
                case enFilterMode.ParentPhone:
                    if (hasText)
                    {
                        filterExpression = clsUtil.GetFilterExpression(_FilterMode.ToString(), clsUtil.enTypeOfFilter.String, filterValue);

                    }
                    break;

                case enFilterMode.JoinDate:

                    filterExpression = clsUtil.GetFilterExpression(_FilterMode.ToString(), clsUtil.enTypeOfFilter.DateTime, dtp_FormDate.Value, dtp_ToDate.Value);
                    break;

                case enFilterMode.IsActive:
                    if (cmb_IsActive.Visible && cmb_IsActive.Text != "كل")
                    {
                        filterExpression = clsUtil.GetFilterExpression(_FilterMode.ToString(), clsUtil.enTypeOfFilter.Bool, filterValue);

                    }
                    break;

                case enFilterMode.None:
                default:
                    filterExpression = "";
                    break;
            }

            _ListStudents.RowFilter = filterExpression;

            _DisplayCurrentPage();
        }
        private void _DisplayCurrentPage()
        {
            DataTable pagedTable = _allData?.Clone() ?? new DataTable();

            if (_ListStudents != null && _ListStudents.Count > 0)
            {
                int startIndex = (_PagingInfo.currentPage - 1) * _PagingInfo.pageSize;
                int endIndex = Math.Min(startIndex + _PagingInfo.pageSize, _ListStudents.Count);

                for (int i = startIndex; i < endIndex; i++)
                {
                    pagedTable.ImportRow(_ListStudents[i].Row);
                }
            }

            dgv_ListStudents.DataSource = pagedTable;

            _FormatDataGridView();
            clsUtil.UpdatePageNumbering(_ListStudents, ref _PagingInfo, lbl_PageNumbering);
            clsUtil.UpdatePaginationStatus(btn_Previous, btn_Next, _PagingInfo);
            _DisplayfilteredCount();
        }
        private void _HideAllFilterControls()
        {
            cmb_IsActive.Visible = false;
            dtp_FormDate.Visible = false;
            dtp_ToDate.Visible = false;
            lbl_From.Visible = false;
            lbl_To.Visible = false;
            txt_Research.Visible = false;
        }
        private void _ApplyDateTimePickerFormatting()
        {
            clsUtil.ConfigureDateTimePicker(dtp_FormDate);
            clsUtil.ConfigureDateTimePicker(dtp_ToDate);
          
        }
        private void UC_Student_Load(object sender, EventArgs e)
        {
            _SetDefaultPaging();
            _InitializeFilterComboBox();
            _InitializeIsActiveComboBox();
            _HideAllFilterControls();
            _ApplyDateTimePickerFormatting();
            _RefreshStudentList();
            _DisplayTotalStudentsCount();
            _DisplayCurrentPage();
        }
        private void _FormatDataGridViewColumn()
        {
            if (dgv_ListStudents.Columns.Count > 0)
            {
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["StudentID"], "رقم الطالب", 100);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["SeatsNumber"], "رقم الجلوس", 120);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["FullName"], "اسم الطالب الكامل", 240);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["BirthDate"], "تاريخ الميلاد", 110);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["Address"], "العنوان", 160);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["ParentPhone"], "هاتف ولي الأمر", 140);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["JoinDate"], "تاريخ الانضمام", 130);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["CircleID"], "رقم الحلقة", 0);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["CircleName"], "اسم الحلقة", 150);
                clsUtil.ConfigureColumn(dgv_ListStudents.Columns["IsActive"], "الحالة", 130);
                dgv_ListStudents.Columns["CircleID"].Visible = false;
            }
        }
        private void _FormatDataGridView()
        {
            clsUtil.InitializeGridViewStyle(dgv_ListStudents);
            _FormatDataGridViewColumn();
        }
        private void btn_Next_Click(object sender, EventArgs e)
        {
            clsUtil.ShowNextPage(ref _PagingInfo, _DisplayCurrentPage);
        }
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            clsUtil.ShowPreviousPage(ref _PagingInfo, _DisplayCurrentPage);
        }
        private void cmb_IsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterResult();
        }
        private void txt_Research_TextChanged(object sender, EventArgs e)
        {
            _FilterResult();
        }
        private void dtp_ToDate_ValueChanged(object sender, EventArgs e)
        {
            _FilterResult();
        }
        private void dtp_FormDate_ValueChanged(object sender, EventArgs e)
        {
            _FilterResult();
        }
        private void txt_Research_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_FilterMode == enFilterMode.StudentID || _FilterMode == enFilterMode.ParentPhone)
            {
                    e.Handled = (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back);return;
            }

            char[] restrictedChars = { '\'', '[', ']', '%', '*' };
            e.Handled = Array.IndexOf(restrictedChars, e.KeyChar) >= 0; 
       
        }
        private void _ClearTextSearch()
        {
            txt_Research.Clear();
        }

        private void AddStudent_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             frmAddAndUpdateStudent frmAddAndUpdateStudent = new frmAddAndUpdateStudent();
            frmAddAndUpdateStudent.ShowDialog();
            _RefreshStudentList();
            _DisplayCurrentPage();
            _ClearTextSearch();
        }



        private void UpdateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgv_ListStudents.Rows.Count > 0 && dgv_ListStudents.CurrentRow != null)
            {
                int StudentID = Convert.ToInt32(dgv_ListStudents.CurrentRow.Cells["StudentID"].Value);

                frmAddAndUpdateStudent frmAddAndUpdateStudent = new frmAddAndUpdateStudent(StudentID);
                frmAddAndUpdateStudent.ShowDialog();
                _RefreshStudentList();
                _DisplayCurrentPage();
                _ClearTextSearch();

            }
            else
            {
                clsGlobal.ShowErrorMessgae("Please select a Student first!", "No Data");

            }
        }

        private void StudentDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
             MessageBox.Show("Student Details");
        }

        private void StudentSuspendedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Student Suspended");
        }

        private void ActivateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Activate Student");
        }

        private void UpdateStudentProgress_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Update Student Progress");
        }
    }
}