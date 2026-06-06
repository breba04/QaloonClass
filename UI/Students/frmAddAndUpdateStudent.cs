using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GlobalClasses;

namespace UI.Students
{
    public partial class frmAddAndUpdateStudent : BaseForm
    {

       private DataTable _dtCircles ;
       private DataTable _dtSurrahs;
       private DataTable _dtAyatFromSurrah;
        clsStudents _Student;
        clsStudentProgress _StudentProgress;
        public frmAddAndUpdateStudent()
        {
            InitializeComponent();
            _Student = new clsStudents();
            _StudentProgress = new clsStudentProgress();
        }
        private void _LoadCirclesData()
        {
            _dtCircles =   clsCircles.SelectAllCircles(); 
        }
        private void _LoadSurrahsData()
        {
            _dtSurrahs = clsMushafQaloon.GetAllSurrah(); 
        }
        private void _Load_AyatFromSurrahData()
        {
            byte selectedSurrahID = Convert.ToByte(cmb_Surahs.SelectedValue);
            _dtAyatFromSurrah = clsMushafQaloon.GetAllAyatFromSurrah(selectedSurrahID,20);
        }
        private void frmAddAndUpdateStudent_Load(object sender, EventArgs e)
        {
            this.HeaderTitle = "إضافة وتعديل طالب";
            btn_RemoveImage.Visible = false;
            _LoadCirclesData();
            _LoadSurrahsData();
            _ConfigureDateTimePicker();
            _FillCirclesInComoboBox();
            _Fill_SurahsInComoboBox();
            _UpdateSelectedCircleCapacityLabel();
        }

        private void _UpdateCapacityLabel(byte currentStudents, byte maxCapacity)
        {
            lbl_Capacity.Text = $"{maxCapacity}/{currentStudents}";

            if (currentStudents >= maxCapacity)
            {
                lbl_Capacity.ForeColor = Color.Orange; 
            }
            else
            {
                lbl_Capacity.ForeColor = Color.White;
            }
        }
      
        private void _UploadPersonalPhoto()
        {
            openFileDialog1.Filter = "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                ptb_PersonalPhoto.ImageLocation = openFileDialog1.FileName;
                btn_RemoveImage.Visible = true;
            }
        }
        public void _FillCirclesInComoboBox()
        {
            if (_dtCircles != null && _dtCircles.Rows.Count > 0)
            {
               cmb_Circles.DataSource = _dtCircles;
               cmb_Circles.DisplayMember = "CircleName";
               cmb_Circles.ValueMember = "CircleID";
            }
        }
        private void _ConfigureDateTimePicker()
        {
            dtp_DateOfBirth.Format = DateTimePickerFormat.Custom;
            dtp_DateOfBirth.CustomFormat = "dd - MM - yyyy";
        }
        public void _Fill_SurahsInComoboBox()
        {
            if (_dtSurrahs != null && _dtSurrahs.Rows.Count > 0)
            {
                cmb_Surahs.DisplayMember = "SurraName";
                cmb_Surahs.ValueMember = "SurraID";
                cmb_Surahs.DataSource = _dtSurrahs;
            }
        }
        public void _Fill_AyatInComoboBox()
        {
            if (_dtAyatFromSurrah != null && _dtAyatFromSurrah.Rows.Count > 0)
            {
               cmb_Aya.DisplayMember = "AyahText";
               cmb_Aya.ValueMember = "MushafQaloonID";
               cmb_Aya.DataSource = _dtAyatFromSurrah;
            }
        }
        private void ClearAll()
        {
            txt_FirstName.Clear() ;
            txt_SecondName.Clear();
            txt_ThirdName.Clear();
            txt_LastName.Clear();
            txt_SeatingID.Clear();
            txt_Phone.Clear();
            txt_Address.Clear();
        }
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void btn_UploadImage_Click(object sender, EventArgs e)
        {
            _UploadPersonalPhoto();
        }
        private void RemovePersonalPhoto()
        {
            ptb_PersonalPhoto.ImageLocation = null;
            btn_RemoveImage.Visible = false;
            ptb_PersonalPhoto.Image = UI.Properties.Resources.Ic_PersonalPhoto;
        }
        private void btn_RemoveImage_Click(object sender, EventArgs e)
        {
            RemovePersonalPhoto();
        }

        private void _SetStudentData()
        {
            _Student.FirstName = txt_FirstName.Text.Trim();
            _Student.SecodName = txt_SecondName.Text.Trim();
            _Student.ThirdName = txt_ThirdName.Text.Trim();
            _Student.LastName = txt_LastName.Text.Trim();
            _Student.BirthDate = dtp_DateOfBirth.Value;
            _Student.ParentPhone = txt_Phone.Text.Trim();
            _Student.Address = txt_Address.Text.Trim();
            _Student.CircleID =Convert.ToInt32(cmb_Circles.SelectedValue);
            _Student.ImagePath = ptb_PersonalPhoto.ImageLocation;
        }
        private void _SetStudentProgrees()
        {
            _StudentProgress.StudentID = _Student.StudentID;
            _StudentProgress.SurrahID = Convert.ToByte(cmb_Surahs.SelectedValue);
            _StudentProgress.AyahID = Convert.ToInt16(cmb_Aya.SelectedValue);
            _StudentProgress.TeacherID = clsCurrentUser.CurrentUser.UserID;
        }
        private void _CircleValdation( byte currentStudents, byte maxCapacity)
        {
            if (maxCapacity <= currentStudents)
            {
                errorProvider1.SetError(cmb_Circles, "الحلقة ممتلئة");
            }
            else
            {
                errorProvider1.SetError(cmb_Circles, "");
            }
        }
        private void _UpdateSelectedCircleCapacityLabel()
        {
            if (cmb_Circles.SelectedItem != null)
            {
                DataRowView selectedRow = (DataRowView)cmb_Circles.SelectedItem;

                byte maxCapacity = Convert.ToByte(selectedRow["MaxCapacity"]);
                byte currentStudents = Convert.ToByte(selectedRow["CurrentStudentNumbers"]);

                _UpdateCapacityLabel(currentStudents, maxCapacity);

                _CircleValdation(currentStudents, maxCapacity);
            }
        }
        
        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _UpdateSelectedCircleCapacityLabel();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;
            _SetStudentData();
            if(!_Student.Save())
            {
                MessageBox.Show( "لم يتم تسجيل الطالب", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _SetStudentProgrees();
            if (!_StudentProgress.Save())
            {
                MessageBox.Show("لم يتم تسجيل تقدم الطالب","خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("تم تسجيل الطالب بنجاح","نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void txt_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
             clsUtil.ValidateTextBoxRequired(sender, e, errorProvider1);
        }
        private void frmAddAndUpdateStudent_Shown(object sender, EventArgs e)
        {
            txt_FirstName.Focus();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmb_Surahs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_AyatFromSurrahData();
            _Fill_AyatInComoboBox();
        }
    }
}
