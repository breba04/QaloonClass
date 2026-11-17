using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.GlobalClasses;
using UI.Students.StudentControls;

namespace UI.Users
{
    public partial class frmAddAndUpdateUser : BaseForm
    {
        DataTable _dtCircles;
        clsUsers _User;
        int _UserID;
        clsUsers.enMode _Mode;
        bool _TextBoxsIsValid;
        public frmAddAndUpdateUser()
        {
            InitializeComponent();
            _InitializeDefautValue();
        }
        public frmAddAndUpdateUser(int UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _Mode = clsUsers.enMode.Update;
            dtp_DateOfBirth.Format = DateTimePickerFormat.Time;
        }
        private void ClearAll()
        {
            txt_FirstName.Clear();
            txt_SecondName.Clear();
            txt_ThirdName.Clear();
            txt_LastName.Clear();
            txt_UserName.Clear();
            txt_Password.Clear();
            txt_Address.Clear();
            ptb_PersonalPhoto.ImageLocation = null;
            _InitializeDefautValue();
        }
        private void RemovePersonalPhoto()
        {
            ptb_PersonalPhoto.ImageLocation = null;
            btn_RemoveImage.Visible = false;
            ptb_PersonalPhoto.Image = UI.Properties.Resources.Ic_PersonalPhoto;
        }
        private void _LoadCirclesData()
        {
            _dtCircles = clsCircles.SelectAllCirclesMiniData();
            DataRow row = _dtCircles.NewRow();
            row["CircleID"] = -1;
            row["CircleName"] = "كل الحلقات";
            _dtCircles.Rows.InsertAt(row, 0);
        }
        private void _LoadUserRole()
        {
            cmb_UserRoles.DataSource = clsUsers._UsersRole;
            cmb_UserRoles.DisplayMember = "Key";
            cmb_UserRoles.ValueMember = "Value";
        }
        //public void _FillCirclesInComoboBox()
        //{
        //    if (_dtCircles != null && _dtCircles.Rows.Count > 0)
        //    {
        //        cmb_Circles.DataSource = _dtCircles;
        //        cmb_Circles.DisplayMember = "CircleName";
        //        cmb_Circles.ValueMember = "CircleID";
        //    }
        //}
        private void _UpdateTitle()
        {
            this.HeaderTitle = _Mode == clsUsers.enMode.Add ? "إضافة مستخدم" : "تعديل بيانات المستخدم";
        }
        private void _InitializeDefautValue()
        {
            _User = new clsUsers();
            _UserID = -1;
            _Mode = clsUsers.enMode.Add;
            gb_CircuitData.Visible = false;
            pnl_Password.Visible = true;
            _TextBoxsIsValid = true;
            txt_CirclesName.Clear();
            _UpdateTitle();
        }
        private void _ConfigureDateTimePicker()
        {
            dtp_DateOfBirth.Format = DateTimePickerFormat.Custom;
            dtp_DateOfBirth.CustomFormat = "dd - MM - yyyy";
        }
        private bool _LoadUserFromDB(out string ErrorMessage)
        {
            try
            {
                ErrorMessage = null;
                _User = clsUsers.Find(_UserID);
                if (_User == null)
                {
                    ErrorMessage = $"لم يتم العثور على مستخدم بالمعرف {_UserID}";
                    return false;
                }
                return true;
            }
            catch (InvalidOperationException ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
        }
        private void _LoadUserData()
        {
            txt_FirstName.Text = _User.FirstName;
            txt_SecondName.Text = _User.SecodName;
            txt_ThirdName.Text = _User.ThirdName;
            txt_LastName.Text = _User.LastName;
            dtp_DateOfBirth.Value = _User.BirthDate;
            txt_UserName.Text = _User.UserName;
            txt_Address.Text = _User.Address;
            if(_User.HasCircle)
            {
                txt_CirclesName.Text = _User.CirclesName;
            }
            txt_Password.Text = _User.Password;
            string ImageLacation = clsImageManager.GetImagePath(_User.ImagePath, clsImageManager.enImageFolder.User);
            cmb_UserRoles.SelectedValue = (clsEntityUser.enUserRole)_User.UserRole;
            if (string.IsNullOrEmpty(ImageLacation))
            {
                RemovePersonalPhoto();
                return;
            }
            ptb_PersonalPhoto.ImageLocation = ImageLacation;
            btn_RemoveImage.Visible = true;


        }
        private void _LoadUpdateMode()
        {
            if (!_LoadUserFromDB(out string ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(ErrorMessage,"خطأ في بيانات المسخدم");
                ClearAll();
                return;
            }
            //cmb_Circles.Visible = false;
            pnl_Password.Visible = false;
            gb_CircuitData.Enabled = true;
            _LoadUserData();
        }
        private void _SetUsertData()
        {
            _User.FirstName = txt_FirstName.Text.Trim();
            _User.SecodName = txt_SecondName.Text.Trim();
            _User.ThirdName = txt_ThirdName.Text.Trim();
            _User.LastName = txt_LastName.Text.Trim();
            _User.BirthDate = dtp_DateOfBirth.Value;
            _User.UserName = txt_UserName.Text.Trim();
            _User.Password = txt_Password.Text.Trim();
            _User.Address = txt_Address.Text.Trim();
            _User.UserRole = (clsEntityUser.enUserRole)cmb_UserRoles.SelectedValue;
            //_User.CircleID = Convert.ToInt32(cmb_Circles.SelectedValue);
        }
        private void _InitializeForm()
        {
            _UpdateTitle();
            btn_RemoveImage.Visible = false;

            _LoadCirclesData();
            _ConfigureDateTimePicker();

            //_FillCirclesInComoboBox();
            _LoadUserRole();
        }
        private void frmAddAndUpdateUser_Load(object sender, EventArgs e)
        {
            _InitializeForm();
            if(_Mode == clsUsers.enMode.Update)
            {
                _LoadUpdateMode();
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
        private bool _HandleImage(out string ErrorMessage)
        {
            ErrorMessage = null;
            string PersonalPhotoImageName = Path.GetFileName(ptb_PersonalPhoto.ImageLocation);
            if (_User.ImagePath == PersonalPhotoImageName) return true;

            if (clsImageManager.ReplaceImage(ptb_PersonalPhoto.ImageLocation, _User.ImagePath,
                out string NewImageName, out ErrorMessage))
            {
                _User.ImagePath = NewImageName;
                return true;
            }
            return false;
        }
        private bool _SaveUser(out string ErrorMessage)
        {
            try
            {
                _SetUsertData();

                if (!_User.Save())
                {
                    ErrorMessage = "لم يتم حفظ بيانات المستخدم.";
                    return false;
                }

                ErrorMessage = string.Empty;
                return true;
            }
            catch (InvalidOperationException ex)
            {
                ErrorMessage = ex.Message;
                return false;
            }
            catch (Exception)
            {
                ErrorMessage = "حدث خطأ غير متوقع أثناء حفظ بيانات الطالب.";
                return false;
            }
        }
        //private bool _ReferralUsertToCircle(out string ErrorMessage)
        //{
        //    try
        //    {
        //        int CircleID = Convert.ToInt32(cmb_Circles.SelectedValue);
        //        if (!_User.ReferralUsertToCircle(CircleID))
        //        {
        //            ErrorMessage = "لم يتم تنسيب المعلم إلى الحلقة.";
        //            return false;
        //        }

        //        ErrorMessage = string.Empty;
        //        return true;
        //    }
        //    catch (InvalidOperationException ex)
        //    {
        //        ErrorMessage = ex.Message;
        //        return false;
        //    }
        //    catch (Exception)
        //    {
        //        ErrorMessage = "حدث خطأ غير متوقع أثناء تنسيب المعلم إلى الحلقة.";
        //        return false;
        //    }
        //}
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren() && !_TextBoxsIsValid)
                return;
            if (!_HandleImage(out string ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(ErrorMessage, "خطأ في حفظ الصورة");
                return;
            }

            if (!_SaveUser(out ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(ErrorMessage, "خطأ في حفظ المستخدم");
                return;
            }
            _UserID = _User.UserID;
            clsGlobal.ShowSeccesMessgae($"تم {(_Mode == clsUsers.enMode.Add ? "تسجيل" : "تعديل")} المستخدم بنجاح", "نجاح");
            _Mode = clsUsers.enMode.Update;
            _UpdateTitle();
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
            if(clsUtil.ValidateTextBoxRequired(sender, e, errorProvider1))
            {
                _TextBoxsIsValid = true;
            }
            else
            {
                e.Cancel = false;
                _TextBoxsIsValid = false;
            }
        }
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void btn_UploadImage_Click(object sender, EventArgs e)
        {
            _UploadPersonalPhoto();
        }
        private void btn_RemoveImage_Click(object sender, EventArgs e)
        {
            RemovePersonalPhoto();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txt_Password_Validating(object sender, CancelEventArgs e)
        {
            if(pnl_Password.Visible)
            {
                TextBox_Validating(sender, e);
            }
        }
    }
}
