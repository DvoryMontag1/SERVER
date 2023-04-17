using BL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;


namespace API.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/travel")]
    public class DriversTravelsController : ApiController
    {

        //הוספת נסיעה
        [Route("GetAddNewTravel/{exit}/{Destination}/{startDayAndHour}/{endDay}/{hours}/{minutes}/{seconds}/{numOfChairs}/{price}/{pass}/")]
        public string GetAddNewTravel(string exit, string Destination, string startDayAndHour, string endDay, int hours, int minutes, int seconds, int numOfChairs, double price, string pass)
        {
            DateTime d1 = DateTime.Parse(startDayAndHour);
            DateTime d2 = DateTime.Parse(endDay);
            TimeSpan t = new TimeSpan(hours, minutes, seconds);

            return "sacsses" + TravelBL.AddTravel(new DetailsOfTravel(exit, Destination, d1, d2, t, numOfChairs, price), pass);
        }

        //מחיקת נסיעה
        [Route("GetDeleteTravel/{idTravel}")]
        public string GetDeleteTravel(int idTravel)
        {
            return TravelBL.DeleteTravel(idTravel);
        }

        //שליפת פרטי נסיעה בשביל עדכון
        [Route("GetdetailsOfTravel/{idTravel}")]
        public DTO.DetailsOfTravel GetdetailsOfTravel(int idTravel)
        {
            return TravelBL.GetdetailsOfTravel(idTravel);
        }

        //עדכון פרטי נסיעה
        [Route("GetUpdateDetailsOfTravel/{exit}/{Destination}/{startDayAndHour}/{endDay}/{hours}/{minutes}/{seconds}/{numOfChairs}/{price}/{idTravel}")]
        public string GetUpdateDetailsOfTravel(string exit, string Destination, string startDayAndHour, string endDay, int hours, int minutes, int seconds, int numOfChairs, double price, int idTravel)
        {
            DateTime d1 = DateTime.Parse(startDayAndHour);
            DateTime d2 = DateTime.Parse(endDay);
            TimeSpan t = new TimeSpan(hours, minutes, seconds);

            return TravelBL.UpdateDetailsOfTravel(new DetailsOfTravel(exit, Destination, d1, d2, t, numOfChairs, price), idTravel);
        }

        //שליפת כל הנסיעות העתידיות של כל הנהגים
        [Route("GetAllTravels")]
        public List<DTO.DetailsOfTravel> GetAllTravels()
        {
            return TravelBL.GetAllTravels();
        }


        //חיפוש נסיעות לפי מוצא,יעד,או תאריך 
        [Route("GetSearchTravels/{search}/{pass}")]
        public List<DTO.DetailsOfTravel> GetSearchTravels(string search, string pass)
        {
            return TravelBL.GetSearchTravels(search, pass);
        }

        //שליפת שם הנהג
        [Route("GetDriverName/{idTravel}")]
        public string GetDriverName(int idTravel)
        {
            return TravelBL.GetDriverName(idTravel);
        }

        //שליפת העדפות נהג
        //[Route("GetPreference/{idTravel}")]
        //public DTO.Driver GetPreference(int idTravel)
        //{
        //    return TravelBL.GetPreference(idTravel);
        //}

        //שליפת משפט העדפות נהג
        [Route("GetPreference/{idTravel}")]
        public string GetPreference(int idTravel)
        {
            return TravelBL.GetPreference(idTravel);
        }

        //נהג רוצה את כל הנסיעות שלו
        [Route("GetAllTravelsDriver/{pass}")]
        public List<DTO.DetailsOfTravel> GetAllTravelsDriver(string pass)
        {
            return TravelBL.GetAllTravelsDriver(pass);
        }

        //נהג רוצה מצטרפים של נסיעה מסוימת
        [Route("GetJoinersToTravel/{idTravel}")]
        public List<DTO.Person> GetJoinersToTravel(int idTravel)
        {
            return TravelBL.JoinersToTravel(idTravel);
        }
    }
}


