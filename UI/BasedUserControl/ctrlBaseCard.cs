using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.BasedUserControl
{
    public partial class ctrlBaseCard : UserControl
    {
        public enum enCardType
        {
            Student,
            Teacher,
            Circle
        }
        private int _ID = -1;
        private enCardType _CardType = enCardType.Student; // قيمة افتراضية
        private bool _IsActive = false; 
        public ctrlBaseCard()
        {
            InitializeComponent();
            _ID = -1;
        }
        [Category("Custom Proparty")]
        [Description("يحدد نوع البطاقة: طالب، معلم، أو دائرة.")]
        [DefaultValue(enCardType.Student)]
        public enCardType CardType
        {
            get
            {
                return _CardType;
            }
            set
            {
                _CardType = value;
            }

        }
        [Category("Custom Proparty")]
        [Description("يحدد ما إذا كانت البطاقة نشطة (باللون الأخضر) أم غير نشطة (أحمر).")]
        [DefaultValue(false)]
        public bool IsActive
        {
            get
            {
                return this.BackColor == ColorTranslator.FromHtml("#6f8a43");
            }
            set
            {
                if (value)
                {
                    btnIsActive.BackColor = Color.FromArgb(38, 130, 57);

                }
                else
                {

                    btnIsActive.BackColor = Color.Red;
                }
            }
        }

        protected virtual void LoadData(int ID)
        {
            _ID = ID;
        }
    }
}
