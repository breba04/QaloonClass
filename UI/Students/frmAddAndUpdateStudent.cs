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
using System.IO;
namespace UI.Students
{
    public partial class frmAddAndUpdateStudent : BaseForm
    {
        
        enum enMode { Add = 1, Update = 2 }
        private DataTable _dtCircles ;
        private DataTable _dtSurrahs;
        private DataTable _dtAyatFromSurrah;
        clsStudents _Student;
        int _StudentID;
        clsStudentProgress _StudentProgress;
        short _AyaID;
        
        string ImageName;
        enMode _Mode;
        private bool _IsLoading = true;
        public frmAddAndUpdateStudent()
        {
            InitializeComponent();
            _InitializeDefautValue();
        }
        public frmAddAndUpdateStudent(int StudentID)
        {
            InitializeComponent();
            _StudentID = StudentID;
            _Mode = enMode.Update;
        }
        private bool _LoadStudentFromDB(out string ErrorMessage)
        {
            ErrorMessage = null;
            _Student = clsStudents.Find(_StudentID);
            if (_Student == null)
            {
                ErrorMessage = $"لم يتم العثور على طالب بالمعرف {_StudentID}";
                return false;
            }
            return true;
        }
        private bool _LoadStudentProgressFromDB(out string ErrorMessage)
        {
            ErrorMessage = null;
            _StudentProgress = clsStudentProgress.Find(_StudentID);
            if (_StudentProgress == null)
            {
                ErrorMessage = $"لم يتم العثور على تقدم الطالب صاحب المعرف {_StudentID}";
                return false;
            }
            _AyaID = _StudentProgress.AyahID;
            return true;
        }
        private void _InitializeForm()
        {
            _IsLoading = true;
            _UpdateTitle();
            btn_RemoveImage.Visible = false;

            _LoadCirclesData();
            _LoadSurrahsData();
            _ConfigureDateTimePicker();


            _FillCirclesInComoboBox();
            _Fill_SurahsInComoboBox();

            _IsLoading = false;

            _UpdateSelectedCircleCapacityLabel();

        }
        private void _LoadAddMode()
        {
            _SelectNoneFullCircle();
        }
        private void _HandleLoadError(string message)
        {
            clsGlobal.ShowErrorMessgae(message, "خطأ في معرف الطالب");
            ClearAll();
        }
        private void _LoadUpdateMode()
        {
            if (!_LoadStudentFromDB(out string ErrorMessage))
            {
                _HandleLoadError(ErrorMessage);
                return;
            }

            if (!_LoadStudentProgressFromDB(out ErrorMessage))
            {
                _HandleLoadError(ErrorMessage);
                return;
            }

            _LoadStudentData();
            _LoadStudentProgressData();
        }
        private void _InitializeDefautValue()
        {
            _Student = new clsStudents();
            _StudentProgress = new clsStudentProgress();
            _StudentID = -1;
            _AyaID = -1;
            _Mode = enMode.Add;
            _UpdateTitle();
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
        private void _UpdateTitle()
        {
            this.HeaderTitle = _Mode == enMode.Add ? "إضافة طالب" : "تعديل بيانات الطالب";
        }
        private void frmAddAndUpdateStudent_Load(object sender, EventArgs e)
        {
            _InitializeForm();
            if (_Mode == enMode.Add)
            {
                _LoadAddMode();
            }
            else
            {
                _LoadUpdateMode();
            }
        }

        //private void frmAddAndUpdateStudent_Load(object sender, EventArgs e)
        //{
        //    _IsLoading = true; 
        //    _UpdateTitle();
        //    btn_RemoveImage.Visible = false;

        //    _LoadCirclesData();
        //    _LoadSurrahsData();
        //    _ConfigureDateTimePicker();

        //    _IsLoading = false; 

        //    _FillCirclesInComoboBox();
        //    _Fill_SurahsInComoboBox();
        //    _UpdateSelectedCircleCapacityLabel();

        //    if(_Mode == enMode.Add)
        //    {
        //        _SelectNoneFullCircle();
        //    }
        //    else
        //    {
        //        _Student = clsStudents.Find(_StudentID);
        //        if (_Student == null)
        //        {
        //            clsGlobal.ShowErrorMessgae($"لم يتم العثور على طالب بالمعرف {_StudentID}", "خطأ في معرف الطالب");
        //            this.Close();
        //            return;
        //        }
        //        _StudentProgress = clsStudentProgress.Find(_StudentID);
        //        if (_StudentProgress == null)
        //        {
        //            clsGlobal.ShowErrorMessgae($"لم يتم العثور على تقدم الطالب صاحب المعرف {_StudentID}", "خطأ في معرف الطالب");
        //            this.Close();
        //            return;
        //        }
        //        _LoadStudentData();
        //        _LoadStudentProgressData();
        //    }
        //}
        private void _UpdateCapacityLabel(byte currentStudents, byte maxCapacity)
        {
            lbl_Capacity.Text = $"{maxCapacity}/{currentStudents}";

            lbl_Capacity.ForeColor = (currentStudents >= maxCapacity) ? Color.Orange : Color.White;
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
           //if(_Mode == enMode.Add)
                txt_SeatingID.Clear();
            txt_Phone.Clear();
            txt_Address.Clear();
            ptb_PersonalPhoto.ImageLocation = null;
            _InitializeDefautValue();
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
        }
        private void _LoadStudentData()
        { 
            txt_FirstName.Text = _Student.FirstName;
            txt_SecondName.Text = _Student.SecodName;
            txt_ThirdName.Text = _Student.ThirdName;
            txt_LastName.Text = _Student.LastName;
            dtp_DateOfBirth.Value = _Student.BirthDate;
            txt_Phone.Text = _Student.ParentPhone;
            txt_Address.Text = _Student.Address;
            cmb_Circles.SelectedValue = _Student.CircleID;
            txt_SeatingID.Text = _Student.SeatsNumber;
            string ImageLacation = clsImageManager.GetImagePath(_Student.ImagePath,clsImageManager.enImageFolder.Student);
            if(string.IsNullOrEmpty(ImageLacation))
            {
                RemovePersonalPhoto();
                return;
            }
            ptb_PersonalPhoto.ImageLocation = ImageLacation;
            btn_RemoveImage.Visible = true;
        }
        private bool _HandleImage(out string ErrorMessage)
        {
            ErrorMessage = null;
            string PersonalPhotoImageName = Path.GetFileName(ptb_PersonalPhoto.ImageLocation);
            if (_Student.ImagePath == PersonalPhotoImageName) return true;
            
            if(clsImageManager.ReplaceImage(ptb_PersonalPhoto.ImageLocation, _Student.ImagePath,
                out string NewImageName, out ErrorMessage))
            {
                _Student.ImagePath = NewImageName;
                return true;
            }
            return false;
        }
        private void _SetStudentProgrees()
        {
            _StudentProgress.StudentID = _Student.StudentID;
            _StudentProgress.SurrahID = Convert.ToByte(cmb_Surahs.SelectedValue);
            _StudentProgress.AyahID = Convert.ToInt16(cmb_Aya.SelectedValue);
            _StudentProgress.TeacherID = clsCurrentUser.CurrentUser.UserID;
        }
        private void _LoadStudentProgressData()
        {
            cmb_Surahs.SelectedValue = _StudentProgress.SurrahID;
            cmb_Aya.SelectedValue = _StudentProgress.AyahID;
        }
        private void _CircleValdation()
        {
            DataRowView selectedRow = (DataRowView)cmb_Circles.SelectedItem;

            byte maxCapacity = Convert.ToByte(selectedRow["MaxCapacity"]);
            byte currentStudents = Convert.ToByte(selectedRow["CurrentStudentNumbers"]);

            bool _IsFull = currentStudents >= maxCapacity;

            bool _IsSameCircle = _Mode == enMode.Update && _Student != null
                && _Student.CircleID == Convert.ToInt32(cmb_Circles.SelectedValue);
            if (_IsSameCircle || !_IsFull)
            {
                errorProvider1.SetError(cmb_Circles, "");
            }
            else
            {
                errorProvider1.SetError(cmb_Circles, "الحلقة ممتلئة");
            }
        }
        private bool _IsCircleValid()
        {
            return string.IsNullOrEmpty(errorProvider1.GetError(cmb_Circles));
        }
        private void _SelectNoneFullCircle()
        {
            while(!string.IsNullOrEmpty(errorProvider1.GetError(cmb_Circles)) 
                && cmb_Circles.SelectedIndex != cmb_Circles.Items.Count -1)
            {
                cmb_Circles.SelectedIndex++;
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


            }
        }      
        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_IsLoading) return; 
            _UpdateSelectedCircleCapacityLabel();
            _CircleValdation();
        }
        private bool _SaveStudent(out string ErrorMessage)
        {
            _SetStudentData();
            if (!_Student.Save())
            {
                ErrorMessage = "لم يتم تسجيل الطالب";
                return false;
            }
            ErrorMessage = string.Empty;
            return true;
        }
        private bool _SaveStudentProgress(out string ErrorMessage)
        {
            _SetStudentProgrees();

            ErrorMessage = string.Empty;

            if (_AyaID == Convert.ToInt16(cmb_Aya.SelectedValue))
                    return true;

            if (_StudentProgress.Save())
                return true;

            ErrorMessage = "لم يتم تسجيل الطالب";
            return true;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren()) return;

            if (!_IsCircleValid())
            {
                clsGlobal.ShowErrorMessgae("!لا يمكن الحفظ، الحلقة المختارة ممتلئة حالياً", "خطأ في السعة");
                return;
            }

            if (!_HandleImage(out string ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(ErrorMessage, "خطأ في حفظ الصورة");
                return;
            }
            if (!_SaveStudent(out ErrorMessage))
            {

                clsGlobal.ShowErrorMessgae(ErrorMessage, "خطأ في حفظ الطالب");
                return;
            }
            if (!_SaveStudentProgress(out ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(ErrorMessage, "خطأ في حفظ تقدم الطالب");
                return;
            }
            clsGlobal.ShowSeccesMessgae($"تم {(_Mode == enMode.Add ? "تسجيل" : "تعديل")} الطالب بنجاح", "نجاح");
            _StudentID = _Student.StudentID;
             txt_SeatingID.Text = _Student.SeatsNumber;
            _Mode = enMode.Update;
            _AyaID = _StudentProgress.AyahID;
            _UpdateTitle();
            _UpdateSelectedCircleCapacityAfterSavingStudent();

        }
        private void _UpdateSelectedCircleCapacityAfterSavingStudent()
        {
            int currentSelectedCircleID = Convert.ToInt32(cmb_Circles.SelectedValue);
            _LoadCirclesData();
            _FillCirclesInComoboBox();
            cmb_Circles.SelectedValue = currentSelectedCircleID; 
            _UpdateSelectedCircleCapacityLabel();
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
            //if (_IsLoading) return; 
            _Load_AyatFromSurrahData();
            _Fill_AyatInComoboBox();
        }
    }
}
