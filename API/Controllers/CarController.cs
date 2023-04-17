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
    [RoutePrefix("api/car")]
    public class CarController : ApiController
    {
        //שליפת פרטי רכב לאיזור האישי
        [Route("GetDetailsOfCar/{password}")]

        public DTO.Car GetDetailsOfCar(string password)
        {
            return CarBL.GetCar(password);
        }

        //עדכון רכב
        [Route("GetUpdateCar/{company}/{year}/{numOfChairs}/{aboutCar}/{password}")]
        public string GetUpdateCar(string company, int year, int numOfChairs, string aboutCar,string password)
        {
            return CarBL.UpdateCar(new Car(company, year, numOfChairs, aboutCar), password) + "you update car";
        }
    }

}

