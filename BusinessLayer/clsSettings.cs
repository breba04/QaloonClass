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
        clsEntitySettings EntitySettings = new clsEntitySettings();
        enum enMode
        {
            Add = 1,
            Update = 2
        }
        enMode _Mode;

        public clsSettings()
        {
            EntitySettings.SettingID = -1;
            EntitySettings.SettingKey = string.Empty;
            EntitySettings.SettingValue = string.Empty;
            EntitySettings.Notes = string.Empty;
            _Mode = enMode.Add;
        }
        clsSettings(clsEntitySettings EntitySettings)
        {
            this.EntitySettings.SettingID = EntitySettings.SettingID;
            this.EntitySettings.SettingKey = EntitySettings.SettingKey;
            this.EntitySettings.SettingValue = EntitySettings.SettingValue;
            this.EntitySettings.Notes = EntitySettings.Notes;
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
