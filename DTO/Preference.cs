using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public enum Areas
    {
        North ,
        Center ,
        East 
    };

    public class Preference
    {
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public Areas Area { get; set; }
        public string MorePreference { get; set; }

        public Preference(string gender, int minAge, int maxAge, int area, string morePreference)
        {
            Gender = gender;
            MinAge = minAge;
            MaxAge = maxAge;
            Area = (Areas)area;
            MorePreference = morePreference;
        }

       

        public Preference()
        {
        }





        //convert dto ==> dal
        public static DAL.Preference ConvertPreferenceToDAL(Preference preference)
        {
            return new DAL.Preference()
            {
                Gender = preference.Gender,
                MinAge = preference.MinAge,
                MaxAge=preference.MaxAge,
                Area = (int)preference.Area,
                MorePreference = preference.MorePreference,
            };

        }


        //convert dal==>dto
        public static DTO.Preference convertPreferenceToDTO(DAL.Preference preference)
        {
            return new DTO.Preference()
            {
                Gender = preference.Gender,
                MinAge = preference.MinAge,
                MaxAge = preference.MaxAge,
                Area =(Areas) preference.Area,
                MorePreference = preference.MorePreference
            };
        }
    }
}

