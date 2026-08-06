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
using static UI.GlobalClasses.clsUtil;

namespace UI.GlobalClasses
{
    public class clsUtil
    {
        public  struct stPagingInfo
        {
             public short pageSize { get ; set ; }
             public short currentPage { get; set; }
             public short totalPages { get; set; }
        }

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

        public static void ConfigureDateTimePicker(DateTimePicker dtp)
        {
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.CustomFormat = "dd - MM - yyyy";
        }

        public static void ShowNextPage( ref stPagingInfo PagingInfo, Action OnDisplayedCurrentPage)
        {
            if (PagingInfo.currentPage < PagingInfo.totalPages)
            {
                PagingInfo.currentPage++;
                OnDisplayedCurrentPage?.Invoke();
            }
        }

        public static void ShowPreviousPage(ref stPagingInfo PagingInfo, Action OnDisplayedCurrentPage)
        {
            if (PagingInfo.currentPage > 1)
            {
                PagingInfo.currentPage--;
                OnDisplayedCurrentPage?.Invoke();
            }
        }

        public static void UpdatePaginationStatus(Button Previous , Button Next , stPagingInfo PagingInfo)
        {
            Previous.Enabled = (PagingInfo.currentPage > 1);
            Next.Enabled = (PagingInfo.currentPage < PagingInfo.totalPages);
        }

        public static void UpdatePageNumbering(DataView ListStudents,ref stPagingInfo PagingInfo, Label PageNumbering)
        {
            PagingInfo.totalPages = (short)Math.Ceiling((double)ListStudents.Count / PagingInfo.pageSize);
            if (PagingInfo.totalPages == 0) PagingInfo.totalPages = 1;
            if (PagingInfo.currentPage > PagingInfo.totalPages) PagingInfo.currentPage = PagingInfo.totalPages;

            PageNumbering.Text = $"صفحة {PagingInfo.currentPage} من {PagingInfo.totalPages}";
        }




        public enum enTypeOfFilter
        { 
           Int ,
           String,
           Bool,
           DateTime
        }

        public static string GetFilterExpression(string ColumnFilterBy, enTypeOfFilter TypeOf,object value1 , object value2 = null )
        {
            string filterExpression = "";
            switch (TypeOf)
            {
                case enTypeOfFilter.Int : 
                    if (value1 != null && int.TryParse(value1.ToString(),out int filterValue))
                    {
                        filterExpression = $"{ColumnFilterBy} = {filterValue}";
                    }
                    break;

                case enTypeOfFilter.String : 
                    if ( !string.IsNullOrWhiteSpace(value1 as string))
                    {
                        filterExpression = $"{ColumnFilterBy} LIKE '{value1}%'";
                    }
                 
                    break;

                case enTypeOfFilter.DateTime:
                    if (value1 != null && value2 != null && value1 is DateTime dateFrom && value2 is DateTime dateTo)
                    {
                        if (dateFrom > dateTo)
                        {
                            dateTo = dateFrom;
                        }
                        
                        filterExpression = $"{ColumnFilterBy} >= #{dateFrom:yyyy-MM-dd} 00:00:00# AND {ColumnFilterBy} <= #{dateTo:yyyy-MM-dd} 23:59:59#";

                    }
                    else
                    {
                        throw new ArgumentException("The data must be of type DateTime and the value must not equal null");
                    }

                    break;

                case enTypeOfFilter.Bool:
                    if (!string.IsNullOrWhiteSpace(value1 as string))
                       
                        filterExpression = $"{ColumnFilterBy} = '{value1}'";
                    
                    break;

                default:
                    filterExpression = "";
                    break;
            }
            return filterExpression;

        }
        public static void LoadItemsInComboBox(ComboBox cmb, params object[] Items)
        {
            cmb.Items.Clear();

            if (Items != null && Items.Length > 0)
            {
                cmb.Items.AddRange(Items);
                cmb.SelectedIndex = 0;
            }
        }

        public static string EscapeRowFilterValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            StringBuilder sb = new StringBuilder();

            foreach (char c in value)
            {
                switch (c)
                {
                    case ']':
                    case '[':
                    case '%':
                    case '*':
                        sb.Append("[").Append(c).Append("]"); 
                        break;
                    case '\'':
                        sb.Append("''");
                        break;
                    default:
                        sb.Append(c);
                        break;
                }
            }

            return sb.ToString();
        }
        public static string GetHejryDate(string format)
        {

            CultureInfo arSA = new CultureInfo("ar-SA");
            arSA.DateTimeFormat.Calendar = new HijriCalendar();
            return DateTime.Today.ToString(format, arSA);
        }
    }

     
    }
