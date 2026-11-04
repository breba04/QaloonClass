
using BusinessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UI.GlobalClasses;

namespace UI.Circles
{
    public partial class frmAddUpdateCircle : BaseForm
    {
        private clsCircles _Circle;
        private int _CircleID = -1;
        private clsCircles.enMode _Mode;
        private DataTable _dtTeachers;
        private readonly Color _ClickedBackColor;
        private readonly Color _NotClickedBackColor;
        private bool _IsRadioButtonUpdating;
        private bool _CanAdded;
        public frmAddUpdateCircle()
        {
            InitializeComponent();

            _ClickedBackColor = tlp_AfterPrayer.BackColor;
            _NotClickedBackColor = tlp_StaticTime.BackColor;

            _InitializeDefaultValue();
        }
        public frmAddUpdateCircle(int CircleID)
        {
            InitializeComponent();

            _ClickedBackColor = tlp_AfterPrayer.BackColor;
            _NotClickedBackColor = tlp_StaticTime.BackColor;

            _CircleID = CircleID;
            _Mode = clsCircles.enMode.Update;
        }
        private void _ClearAll()
        {
            tb_CircleName.Clear();
            _InitializeDefaultValue();
            _ConfigureDateTimePicker();
        }
        private void _InitializeDefaultValue()
        {
            _Circle = new clsCircles();

            _CircleID = -1;
            _Mode = clsCircles.enMode.Add;

            rb_AfterPrayer.Checked = true;

            nud_NumberOfSeats.Minimum = nud_NumberOfSeats.Value = 1;
            nud_NumberOfSeats.Maximum = 255;

            _UpdateTitle();
        }
        private void _UpdateTitle()
        {
            this.HeaderTitle = _Mode == clsCircles.enMode.Add
                ? "إضافة حلقة"
                : "تعديل بيانات الحلقة";
        }
        private void _ConfigureDateTimePicker()
        {
            dtp_StaticTime.Format = DateTimePickerFormat.Time;
            dtp_StaticTime.ShowUpDown = true;
            dtp_StaticTime.Value = DateTime.Today.AddHours(9);
        }
        private void _LoadTeachersData()
        {
            _dtTeachers = clsUsers.SelectAllTeachersMiniData();
        }
        private void _FillTeachersInComoboBox()
        {
            if (_dtTeachers != null && _dtTeachers.Rows.Count > 0)
            {
                cmb_Teachers.DataSource = _dtTeachers;
                cmb_Teachers.DisplayMember = "TeacherName";
                cmb_Teachers.ValueMember = "TeacherID";
            }
        }
        private void _FillPrayersInComboBox()
        {
            cmb_AfterPrayer.DataSource = clsCircles.GetAllPrayers();
            cmb_AfterPrayer.DisplayMember = "Value";
            cmb_AfterPrayer.ValueMember = "Key";
        }
        private void _InitializeForm()
        {
            _UpdateTitle();

            _ConfigureDateTimePicker();

            _LoadTeachersData();
            _FillTeachersInComoboBox();

            _FillPrayersInComboBox();

            _UpdateScheduleControls();

            _ChangeTypeOfTimeingBackground(
                rb_AfterPrayer.Checked
                    ? tlp_AfterPrayer
                    : tlp_StaticTime);
        }
        private void frmAddUpdateCircle_Load(object sender, EventArgs e)
        {
            _InitializeForm();
            if (_Mode == clsCircles.enMode.Update)
            {
                _LoadUpdateMode();
            }
        }
        private void _ChangeTypeOfTimeingBackground(TableLayoutPanel panel)
        {
            tlp_AfterPrayer.BackColor = _NotClickedBackColor;
            tlp_StaticTime.BackColor = _NotClickedBackColor;

            panel.BackColor = _ClickedBackColor;
        }
        private void _UpdateScheduleControls()
        {
            bool IsPrayer = rb_AfterPrayer.Checked;

            lb1_AfterPrayer.Enabled = IsPrayer;
            lb2_AfterPrayer.Enabled = IsPrayer;
            cmb_AfterPrayer.Enabled = IsPrayer;

            lb1_StaticTime.Enabled = !IsPrayer;
            lb2_StaticTime.Enabled = !IsPrayer;
            dtp_StaticTime.Enabled = !IsPrayer;
        }
        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton SelectedRadioButton = (RadioButton)sender;

            if (!SelectedRadioButton.Checked)
                return;

            bool IsPrayer = SelectedRadioButton == rb_AfterPrayer;

            rb_StaticTime.Checked = !IsPrayer;
            rb_AfterPrayer.Checked = IsPrayer;

            _UpdateScheduleControls();

            _ChangeTypeOfTimeingBackground(tlp_AfterPrayer);
        }
        private bool _LoadCircleFromDB(out string ErrorMessage)
        {
            try
            {
                ErrorMessage = null;

                _Circle = clsCircles.FindCircleByID(_CircleID);

                if (_Circle == null)
                {
                    ErrorMessage = $"لم يتم العثور على حلقة بالمعرف {_CircleID}";
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
        private void _LoadCircleData()
        {
            tb_CircleName.Text = _Circle.CircleName;

            cmb_Teachers.SelectedValue = _Circle.TeacherID;

            nud_NumberOfSeats.Value = _Circle.MaxCapacity;

            if (_Circle.ScheduleType == clsEntityCircle.enScheduleType.Prayer)
            {
                rb_AfterPrayer.Checked = true;

                if (_Circle.PrayerID.HasValue)
                {
                    cmb_AfterPrayer.SelectedValue = _Circle.PrayerID.Value;
                }
            }
            else
            {
                rb_StaticTime.Checked = true;

                if (_Circle.StartTime.HasValue)
                {
                    dtp_StaticTime.Value = DateTime.Today.Add(
                        _Circle.StartTime.Value.TimeOfDay);
                }
            }

            _UpdateScheduleControls();

            _ChangeTypeOfTimeingBackground(
                rb_AfterPrayer.Checked
                    ? tlp_AfterPrayer
                    : tlp_StaticTime);
            _CanAdded = true;

        }
        private void _LoadUpdateMode()
        {
            if (!_LoadCircleFromDB(out string ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(
                    ErrorMessage,
                    "خطأ في بيانات الحلقة");
                _ClearAll();
                return;
            }

            _LoadCircleData();
        }
        private void _SetCircleData()
        {
            _Circle.CircleName = tb_CircleName.Text.Trim();

            _Circle.TeacherID = Convert.ToInt32(
                cmb_Teachers.SelectedValue);

            _Circle.MaxCapacity = Convert.ToByte(
                nud_NumberOfSeats.Value);

            if (rb_AfterPrayer.Checked)
            {
                _Circle.ScheduleType =
                    clsEntityCircle.enScheduleType.Prayer;

                _Circle.PrayerID = Convert.ToByte(
                    cmb_AfterPrayer.SelectedValue);

                _Circle.StartTime = null;
            }
            else
            {
                _Circle.ScheduleType =
                    clsEntityCircle.enScheduleType.FixedTime;

                _Circle.StartTime = dtp_StaticTime.Value;

                _Circle.PrayerID = null;
            }
        }
        private bool _SaveCircle(out string ErrorMessage)
        {
            try
            {
                _SetCircleData();

                if (!_Circle.Save())
                {
                    ErrorMessage = "لم يتم حفظ بيانات الحلقة.";
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
                ErrorMessage =
                    "حدث خطأ غير متوقع أثناء حفظ بيانات الحلقة.";

                return false;
            }
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (!_CanAdded)
            {
                tb_CircleName.Focus();
                return;
            }

            if (!_SaveCircle(out string ErrorMessage))
            {
                clsGlobal.ShowErrorMessgae(
                    ErrorMessage,
                    "خطأ في حفظ الحلقة");

                return;
            }

            _CircleID = _Circle.CircleID;

            clsGlobal.ShowSeccesMessgae(
                $"تم {(_Mode == clsCircles.enMode.Add ? "تسجيل" : "تعديل")} الحلقة بنجاح",
                "نجاح");

            _Mode = clsCircles.enMode.Update;

            _UpdateTitle();
        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void tb_CircleName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _CanAdded = clsUtil.ValidateTextBoxRequired(sender, e, errorProvider1);
            e.Cancel = false;
        }
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            _ClearAll();
        }
    }
}
