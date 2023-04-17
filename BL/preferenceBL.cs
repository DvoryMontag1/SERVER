using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PreferenceBL
    {

        //שליפת פרטי העדפות לאיזור האישי
        public static DTO.Preference GetDetailOfPreferences(string password)
        {
            DAL.Preference p = DAL.PreferencesDAL.GetPreferences(password);
            return DTO.Preference.convertPreferenceToDTO(p);
        }


        //עדכון פרטי העדפות
        public static string AddPreference(DTO.Preference preference, string password)
        {
            DAL.Preference pDAL = DTO.Preference.ConvertPreferenceToDAL(preference);

            return PreferencesDAL.UpdatePreferences(pDAL,password);
        }
    }
}


