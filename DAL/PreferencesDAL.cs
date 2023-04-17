using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PreferencesDAL
    {

        //עדכון פרטי העדפות
        public static string UpdatePreferences(DAL.Preference preference1,string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Person p = DB.People.First(p1 => p1.Password == pass);
                DAL.Driver d = DB.Drivers.First(d1 => d1.PersonId == p.Id);
                DB.Preferences.First(f1 => f1.Id == d.PreferenceId).Gender = preference1.Gender;
                DB.Preferences.First(f1 => f1.Id == d.PreferenceId).MinAge = preference1.MinAge;
                DB.Preferences.First(f1 => f1.Id == d.PreferenceId).MaxAge = preference1.MaxAge;
                DB.Preferences.First(f1 => f1.Id == d.PreferenceId).Area = preference1.Area;
                DB.Preferences.First(f1 => f1.Id == d.PreferenceId).MorePreference = preference1.MorePreference;

                DB.SaveChanges();

                return "succsses";
            }
        }

        //שליפת פרטי העדפות לאיזור האישי
        public static DAL.Preference GetPreferences(string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Person p = DB.People.First(p1 => p1.Password == pass);
                DAL.Driver d = DB.Drivers.First(d1 => d1.PersonId == p.Id);
                return DB.Preferences.First(f1 => f1.Id == d.PreferenceId);
            }
        }
    }
}
