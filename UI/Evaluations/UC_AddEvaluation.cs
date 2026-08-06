using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using EntityLayer;
using UI.GlobalClasses;
using static EntityLayer.clsEntityEvaluation;
namespace UI.Evaluations
{
    
    public partial class UC_AddEvaluation : UserControl
    {
        Dictionary<enRate, Color> _ListOfColor;
        enRate? _Rate;
        public enum enMode { Add ,Update,TakeResult}
        enMode _Mode;
        private DataTable _dtCircles;
        private DataTable _dtStudents;
        private DataTable _dtSurrahs;
        private DataTable _dtAyatSurrahFrom;
        private DataTable _dtAyatSurrahTo;
        private bool _IsLoading;
        private clsEvaluations _Evaluation;
        private clsStudents _Student;
        private bool _IsEvaluationTaken;
        private int _EvaluationID;
        public UC_AddEvaluation(enMode Mode, int EvaluationID = -1)
        {
            InitializeComponent();
            _ListOfColor = new Dictionary<enRate, Color>()
            {
                {enRate.Exllant,ColorTranslator.FromHtml("#BFC5EBD5") },
                {enRate.VeryGood,ColorTranslator.FromHtml("#40C5EBD5") },
                {enRate.Good,ColorTranslator.FromHtml("#40E1E5C6") },
                {enRate.Weak,ColorTranslator.FromHtml("#40FFDAD6") },
            };
            _Rate = null;
            _Evaluation = new clsEvaluations();
            _Student = new clsStudents();
            _IsEvaluationTaken = false;
            _Mode = Mode;
            _EvaluationID = EvaluationID;
        }
        Color _ChangeColorAlpha(Color color,int Alpha)
        {
            return Color.FromArgb(Alpha, color.R, color.G, color.B);
        }
        void _ChangeBackColorPanels(Panel panel)
        {
            Color color = ColorTranslator.FromHtml("#80062A1C");
            pnl_Exlant.BackColor = _ListOfColor[enRate.Exllant];
            pnl_VeryGood.BackColor = _ListOfColor[enRate.VeryGood];
            pnl_Good.BackColor = _ListOfColor[enRate.Good];
            pnl_Weak.BackColor = _ListOfColor[enRate.Weak];
            if(panel != null)
                panel.BackColor = color;
        }
        void _HandleDisplayMemberToSurrahComboBox()
        {
            string ValueMember = rd_Ayah.Checked ? "SurraID" : "MushafQaloonID";
            cmb_FromSurrah.ValueMember = ValueMember;
            cmb_ToSurrah.ValueMember = ValueMember;
        }
        private void _LoadCirclesData()
        {
            _dtCircles = clsCircles.SelectAllCircles();
        }
        private void _LoadStudentData()
        {
            byte selectedID = Convert.ToByte(cmb_Circles.SelectedValue);
            _dtStudents = clsStudents.SelectAllStudentsMiniData(selectedID);
        }
        private void _LoadSurrahsData()
        {
            _dtSurrahs = clsMushafQaloon.GetAllSurrah();
        }
        private void _Load_AyatSurrahFromData()
        {
            byte selectedSurrahIDFrom = Convert.ToByte(cmb_FromSurrah.SelectedValue);
            _dtAyatSurrahFrom = clsMushafQaloon.GetAllAyatFromSurrah(selectedSurrahIDFrom, 30);

        }
        private void _Load_AyatSurrahToData()
        {
            byte selectedSurrahIDTo = Convert.ToByte(cmb_ToSurrah.SelectedValue);
            _dtAyatSurrahTo = clsMushafQaloon.GetAllAyatFromSurrah(selectedSurrahIDTo, 30);
        }
        private void _FillCirclesInComoboBox()
        {
            if (_dtCircles != null && _dtCircles.Rows.Count > 0)
            {
                cmb_Circles.DataSource = _dtCircles;
            }
        }
        private void _FillStudentsInComoboBox()
        {
            if (_dtStudents != null && _dtStudents.Rows.Count > 0)
            {
                cmb_Students.DataSource = _dtStudents;
            }
        }
        private void _Fill_SurahsInComoboBox()
        {
            if (_dtSurrahs != null && _dtSurrahs.Rows.Count > 0)
            {
                cmb_FromSurrah.DataSource = new BindingSource(_dtSurrahs,null); // لفصل الكونترول عم الاخر عند الربط بنفس المصدر
                cmb_ToSurrah.DataSource = new BindingSource(_dtSurrahs, null);
            }
        }
        private void _Fill_AyatFromInComoboBox()
        {
            if (_dtAyatSurrahFrom != null && _dtAyatSurrahFrom.Rows.Count > 0)
            {
                cmb_FromAya.DisplayMember = "AyahText";
                cmb_FromAya.ValueMember = "MushafQaloonID";
                cmb_FromAya.DataSource = _dtAyatSurrahFrom;
            }
        }
        private void _Fill_AyatToInComoboBox()
        {
            if (_dtAyatSurrahTo != null && _dtAyatSurrahTo.Rows.Count > 0)
            {
                cmb_ToAyah.DisplayMember = "AyahText";
                cmb_ToAyah.ValueMember = "MushafQaloonID";
                cmb_ToAyah.DataSource = _dtAyatSurrahTo;
            }
        }
        private void _FillEvaluationData()
        {


            _Evaluation.IsEvaluationTaken = _IsEvaluationTaken;
            if (_IsEvaluationTaken)
            {
                _Evaluation.Rate = _Rate;
                string Notes = txt_Notes.Text.Trim();
                _Evaluation.Notes = Notes.Length > 0? Notes :null;
            }
            
            if (_Mode == enMode.TakeResult) return;

            _Evaluation.EvalDate = dtp_DateOfEvaluation.Value;
            _Evaluation.EvalType = rd_Suraah.Checked? enEvaluationType.Surrah: enEvaluationType.Aya;
            var SelectedFromAyaID = rd_Suraah.Checked ? cmb_FromSurrah.SelectedValue : cmb_FromAya.SelectedValue;
            var SelectedToAyaID = rd_Suraah.Checked ? cmb_ToSurrah.SelectedValue : cmb_ToAyah.SelectedValue;
            _Evaluation.FromAyahID = Convert.ToInt16(SelectedFromAyaID);
            _Evaluation.ToAyahID = Convert.ToInt16(SelectedToAyaID);
            
            if (_Mode == enMode.Update) return;

            _Evaluation.StudentID = Convert.ToInt32(cmb_Students.SelectedValue);
        }
        private void _ConfigureDateTimePicker()
        {
            dtp_DateOfEvaluation.Format = DateTimePickerFormat.Custom;
            dtp_DateOfEvaluation.CustomFormat = "dd - MM - yyyy";
            dtp_DateOfEvaluation.Value = DateTime.Today;
            dtp_DateOfEvaluation.MinDate = DateTime.Today;
        }
        private void pnl_Exlant_MouseClick(object sender, MouseEventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl == null) return;
            _ChangeBackColorPanels(pnl);
            _Rate = pnl.Tag == null ?null:(enRate?)Convert.ToByte(pnl.Tag);
            _IsEvaluationTaken = _Rate != null;
        }
        private void pnl_VeryGood_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_VeryGood, null);

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_Exlant, null);
        }
        private void label11_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_Exlant, null);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_VeryGood, null);
        }
        private void label12_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_VeryGood, null);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_Good, null);
        }
        private void label13_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_Good, null);
        }
        private void label14_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_Weak, null);
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pnl_Exlant_MouseClick(pnl_Weak, null);
        }
        private void _HandleAyaText(bool visible)
        {
            lbFromAya.Visible = visible;
            lbToAya.Visible = visible;
            pb_FromAya.Visible = visible;
            pb_ToAya.Visible = visible;
            cmb_FromAya.Visible = visible;
            cmb_ToAyah.Visible = visible;
            //
            
        }
        private void _InitializeAddMode()
        {
            _ConfigureDateTimePicker();
            _HandleAyaText(false);

            _IsLoading = true;
            _LoadCirclesData();
            _LoadSurrahsData();


            _FillCirclesInComoboBox();
            _Fill_SurahsInComoboBox();
            _IsLoading = false;

            //lb_Date.Text = lb_Date.Text = clsUtil.GetHejryDate(@"ddd dd-MMMM-yyyy \هـ");
            pnl_Exlant_MouseClick(pnl_Exlant,null);
            rd_Suraah.Checked = true;

        }
        private void _InitializeUpdateOrTakeReultMode()
        {
            cmb_Circles.Items.Add(_Student.CircleInfo.CircleName);
            cmb_Circles.SelectedIndex = 0;
            tlpnl_Circles.Enabled = false;
            
            cmb_Students.Items.Add(_Student.FullName);
            cmb_Students.SelectedIndex = 0;
            cmb_Students.SelectedValue = _Student.StudentID;
            tlpnl_Students.Enabled = false;

            dtp_DateOfEvaluation.Value = _Evaluation.EvalDate;

            rd_Suraah.Checked = _Evaluation.EvalType == enEvaluationType.Surrah;
            rd_Ayah.Checked = _Evaluation.EvalType == enEvaluationType.Aya;

            string FromSurrahName = _Evaluation.EvalType == enEvaluationType.Surrah
                ? clsMushafQaloon.GetSurrahNameByFirstAyaID(_Evaluation.FromAyahID)
                : clsMushafQaloon.GetSurrahNameByAyaID(_Evaluation.FromAyahID);

            string ToSurrahName = _Evaluation.EvalType == enEvaluationType.Surrah
                ? clsMushafQaloon.GetSurrahNameByFirstAyaID(_Evaluation.ToAyahID)
                : clsMushafQaloon.GetSurrahNameByAyaID(_Evaluation.ToAyahID);

            if (_Mode == enMode.Update)
            {
                _LoadSurrahsData();
                _Fill_SurahsInComoboBox();
                cmb_FromSurrah.Text = FromSurrahName;
                cmb_ToSurrah.Text = ToSurrahName;
                if(_Evaluation.EvalType == enEvaluationType.Aya)
                {
                    cmb_FromAya.SelectedValue = _Evaluation.FromAyahID;
                    cmb_ToAyah.SelectedValue = _Evaluation.ToAyahID;
                }
                return;
            }
            tlpnl_EvaluationType.Enabled = false;

            dtp_DateOfEvaluation.Enabled = false;

            cmb_FromSurrah.Items.Add(FromSurrahName);
            cmb_FromSurrah.SelectedIndex = 0;
            cmb_ToSurrah.Items.Add(ToSurrahName);
            cmb_ToSurrah.SelectedIndex = 0;
            tlpnl_FromAyaAndSurrah.Enabled = false;
            tlpnl_ToAyaAndSurrah.Enabled = false;
            if(_Evaluation.EvalType == enEvaluationType.Aya)
            {
                string FromAyaText = clsMushafQaloon.GetAyaText(_Evaluation.FromAyahID,30);
                string ToAyaText = clsMushafQaloon.GetAyaText(_Evaluation.ToAyahID, 30);


                cmb_FromAya.Items.Add(FromAyaText);
                cmb_FromAya.SelectedIndex = 0;

                cmb_ToAyah.Items.Add(ToAyaText);
                cmb_ToAyah.SelectedIndex = 0;
            }
            else
            {
                _HandleAyaText(false);
            }
        }
        private void UC_AddEvaluation_Load(object sender, EventArgs e)
        {
            if(_Mode == enMode.Add)
                _InitializeAddMode();
            else
            {
                _Evaluation = clsEvaluations.FindEvaluation(_EvaluationID);
                if(_Evaluation == null)
                {
                    MessageBox.Show($"لم يتم العثور على الاختبار رقم {_Evaluation.EvaluationID} يرجى اعادة المحاولة", "الاختبار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _InitializeAddMode();
                    return;
                }
                _Student = clsStudents.Find(_Evaluation.StudentID);
                if(_Student == null)
                {
                    MessageBox.Show($"لم يتم العثور على الطالب صاحب الاختبار رقم {_Evaluation.EvaluationID} يرجى اعادة المحاولة", "الاختبار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _InitializeAddMode();
                    return;
                }
                _InitializeUpdateOrTakeReultMode();
            }
        }
        private void cmb_FromSurrah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
                //_IsLoading ||
                _Mode== enMode.TakeResult||
                rd_Suraah.Checked) return;

            _Load_AyatSurrahFromData();
            _Fill_AyatFromInComoboBox();
            
        }
        private void rd_Ayah_CheckedChanged(object sender, EventArgs e)
        {
            _HandleAyaText(rd_Ayah.Checked);
            _HandleDisplayMemberToSurrahComboBox();
        }
        private void cmb_ToSurrah_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (
                //_IsLoading ||
            rd_Suraah.Checked||
            _Mode == enMode.TakeResult) return;
            _Load_AyatSurrahToData();
            _Fill_AyatToInComoboBox();

        }
        private void cmb_Circles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_Mode != enMode.Add) return;
            _LoadStudentData();
            _FillStudentsInComoboBox();
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            _FillEvaluationData();
            if(!_IsEvaluationTaken)
            {
                if (MessageBox.Show("سيتم تسجيل اختبار جديد دون رصد الدرجة\nسيتم إرسال اشعار في حالة قدوم موعد الامتحان ولم يتم رصد الدرجة", 
                    "تسجيل اختبار جديد",MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.Cancel)
                    return;
            }
            string Message = _Mode == enMode.Add ? "تسجيل الاختبار" : _Mode == enMode.Update ? "تعديل الاختبار" : "رصد نتيجة الإختبار";
            if(_Evaluation.Save())
            {
                MessageBox.Show($"تم {Message} بنجاح",Message, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"حدث خطأ أثناء {Message}",Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            _Rate = null;
            _IsEvaluationTaken = false;
            _ChangeBackColorPanels(null);
        }
    }
}
