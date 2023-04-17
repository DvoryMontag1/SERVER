using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace API.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/preferences")]

    public class PreferencesController : ApiController
    {

        //שליפת פרטי העדפות לאיזור האישי
        [Route("GetDetailsPreferences/{password}")]
        public DTO.Preference GetDetailsPreferences(string password)
        {
            return PreferenceBL.GetDetailOfPreferences(password);
        }

        //עדכון העדפות
        [Route("GetAddPreferences/{Gender}/{MinAge}/{MaxAge}/{area}/{MorePreferences}/{password}")]
        public string GetAddPreferences(string Gender, int MinAge, int MaxAge, int area, string MorePreferences, string password)
        {
            return PreferenceBL.AddPreference(new Preference(Gender, MinAge, MaxAge, area, MorePreferences), password) + "you add preference";
        }
    }
}
