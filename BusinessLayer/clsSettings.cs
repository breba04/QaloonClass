using DataLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsSettings
    {
        clsEntitySettings EntitySettings;
        public int SettingID { get{ return EntitySettings.SettingID; } } 
        public string SettingKey { get{ return SettingKey; }  } 
        public string SettingValue { get { return SettingValue; } }
        public string Notes { get { return Notes; } } 
        enum enMode
        {
            Add = 1,
            Update = 2
        }
        enMode _Mode;

        public clsSettings()
        {
            EntitySettings = new clsEntitySettings();
            _Mode = enMode.Add;
        }
        clsSettings(clsEntitySettings EntitySettings)
        {
            this.EntitySettings = EntitySettings;
            _Mode = enMode.Update;
        }
        bool AddSettings()
        {
            EntitySettings.SettingID = clsSettingsDataAccess.AddSettings(EntitySettings);
            return EntitySettings.SettingID != -1;
        }
        bool UpdateSettings()
        {
            return clsSettingsDataAccess.UpdateSettings(EntitySettings);
        }
        public bool SaveSettings()
        {
            if (_Mode == enMode.Add)
            {
                return AddSettings();
            }

            return UpdateSettings();

        }
        static public string GetSettingsValue(string settingKey)
        {
            string SettingValue = clsSettingsDataAccess.GetSettingsValue(settingKey);
            if(string.IsNullOrEmpty(SettingValue))
            {
                //Get default value from app.config
            }
            return SettingValue;
        }

    }
}
