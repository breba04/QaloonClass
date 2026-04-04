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
        int _ID;
        enum enCardType
        {
            Student,
            Teacher,
            Circle
        }
        enCardType _CardType;
        public ctrlBaseCard()
        {
            InitializeComponent();
            _ID = -1;
        }
        enCardType CardType
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
        bool IsActive
        {
            get
            {
                return this.BackColor == Color.FromArgb(38 ,130, 57);
            }
            set
            {
                if (value)
                    this.BackColor = Color.FromArgb(38, 130, 57);
                else
                    this.BackColor = Color.Red;
            }
        }

        protected virtual void LoadData(int ID)
        {
            _ID = ID;
        }
    }
}
