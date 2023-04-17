using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using BL;
using DTO;

namespace API.Controllers
{
    [EnableCors("*","*","*")]
    [RoutePrefix("api/user")]
    public class PassengerController : ApiController
    {

        ////כניסת נהג
        //[Route("GetCheckPassword/{password}")]
        //public string GetCheckPassword(string password)
        //{
        //   return " " + DriverBL.CheckPass(password);
        //}

       // הוספת נוסע
        [Route("GetAddNewPassenger/{userName}/{password}/{id}/{firstName}/{lastName}/{sex}/{age}/{adress}/{city}/{phone}/{mail}")]
        public string GetAddNewPassenger(string userName, string password, string id, string firstName, string lastName, string sex, int age, string adress, string city, string phone,
        string mail)
        {
            return "new passenger " +PassengerBL.AddPassenger(new Passenger(userName, password, id, firstName, lastName, sex, age, adress, city, phone, mail));
        }

        //נוסע מצטרף לנסיעה
        [Route("GetJoinToTravel/{pasPassenger}/{idTravel}")]
        public void GetJoinToTravel(string pasPassenger, int idTravel)
        {
            PassengerBL.GetJoinToTravel(pasPassenger, idTravel);
        }


        //נוסע מבטל הצטרפות לנסיעה
        [Route("GetCancelGoiner/{idPassenger}/{idTravel}")]
        public void GetCancelGoiner(string idPassenger, int idTravel)
        {
            PassengerBL.GetCancelGoiner(idPassenger, idTravel);
        }

        //בדיקה אם הנוסע כבר הצטרף לנסיעה זו
        [Route("GetIfJoin/{idTravel}/{idPassenger}")]
        public int GetIfJoin(int idTravel,string idPassenger)
        {
            return PassengerBL.GetIfJoin(idTravel, idPassenger);
        }
    }
}
