using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.GlobalClasses
{
    public class clsUtil
    {

        static public void InitializeGridViewStyle(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            using (Font headerFont = new Font("Segoe UI", 11, FontStyle.Bold))
            {
                dgv.ColumnHeadersDefaultCellStyle.Font = headerFont;
                dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#002819");
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#2E4F3F");
                dgv.RowTemplate.Height = 35;

                dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dgv.ColumnHeadersHeight = 50;

                dgv.GridColor = Color.LightGray;
            }
       
        }
        static public void ConfigureColumn(DataGridViewColumn column, string headerText, int width)
        {
            if (column != null)
            {
                column.HeaderText = headerText;
                column.Width = width;
            }
        }

        static public bool ValidateTextBoxRequired(object sender, CancelEventArgs e, ErrorProvider errorProvider)
        {
            TextBox activeTextBox = sender as TextBox;

            if (activeTextBox != null)
            {
                if (string.IsNullOrEmpty(activeTextBox.Text.Trim()))
                {
                    e.Cancel = true;
                    string fieldName = activeTextBox.Tag != null ? activeTextBox.Tag.ToString() : "هذا الحقل";

                    errorProvider.SetError(activeTextBox, $"{fieldName} مطلوب");
                    return false; 
                }
                else
                {
                    errorProvider.SetError(activeTextBox, "");
                    return true;
                }
            }

            return false;
        }
    }
}
