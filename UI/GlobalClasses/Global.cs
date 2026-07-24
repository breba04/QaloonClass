using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
namespace UI.GlobalClasses
{
    public class clsGlobal
    {
        static public string CenterName = "نور";

        static public string KeyPath = @"HKEY_CURRENT_USER\SOFTWARE\ABDULBASITAndIbrahim\TahfezCenter_System";
        static public string ImageFolder = Path.Combine(Application.StartupPath,"Student_Image");
        
        static public  void StoreUserNameAndPassWordInRegistry(string UserName ,string Password)
        {
            try
            {
                 Registry.SetValue(clsGlobal.KeyPath, "UserName", UserName);
                 Registry.SetValue(clsGlobal.KeyPath, "Password", Password);
            }
            catch (Exception ex)
            {
                // Errors will be recorded in the LOG file later.

            }
        }
        static public  void ShowSeccesMessgae(string message,string title)
        {
            MessageBox.Show(message,title,MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        static public  void ShowErrorMessgae(string message,string title)
        {
            MessageBox.Show(message,title,MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
        
        static public T CovertFromGridViewRowToGenericObject<T>(DataRow Row) where T: new()  
        {
            T obj = new T();
            foreach(DataColumn col in Row.Table.Columns)
            {
                var Property = typeof(T).GetProperty(col.ColumnName);
                if (Property == null) 
                    continue;
                try
                {
                    var value = Convert.ChangeType(Row[col], Property.PropertyType);
                    Property.SetValue(obj, value);

                }
                catch(Exception)
                {

                }
            }
            return obj;
        }
        static public List<T> CovertFromGridViewToGenericListObject<T>(DataTable Table) where T: new()  
        {
            if (Table == null) return null;
            List<T> ListObjects = new List<T>();
            foreach(DataRow Row in Table.Rows)
            {
                T obj = CovertFromGridViewRowToGenericObject<T>(Row);
                if (obj != null)
                    ListObjects.Add(obj);
            }
            return ListObjects;
        }
        
    }
}
