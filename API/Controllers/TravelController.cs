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
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/travel")]
    public class TravelController : ApiController
    {
        //נוסע רוצה את כל הנסיעות שלו
        [Route("GetAllTravelsPassenger/{id}")]
        public List<DTO.DetailsOfTravel> GetAllTravelsPassenger(string id)
        {
            return TravelBL.GetAllTravelsPassenger(id);
        }

        //נוסע רוצה לשלוח בקשה לנהג מסוים
        //שליפת id של הנהג לאחסון המקומי
        [Route("GetIdDriver/{idTravel}")]
        public string GetIdDriver(int idTravel)
        {
            return TravelBL.GetIdDriver(idTravel);
        }


        //שליחת הודעות
        [Route("GetAddMassage/{idGive}/{idGet}/{messageText}/{num}")]
        public void GetAddMassage(string idGive,string idGet,string messageText,bool num)
        {
            TravelBL.GetAddMassage(new Messages(idGive, idGet, messageText, DateTime.Now,num));
        }

        //נהג שולף הודעות נכנסות או יוצאות
        [Route("GetAllMyMessage/{id}/{status}")]
        public List<string> GetAllMyMessage(string id,bool status)
        {
            return TravelBL.GetAllMyMessage(id, status);
        }
    }
}

