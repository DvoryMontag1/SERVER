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
    [RoutePrefix("api/user")]
    public class DriverController : ApiController
    {

        //בדיקה אם הסיסמה שהמצטרף רוצה להכניס כבר קיימת
        [Route("GetCheckIfPassConsist/{password}")]
        public int GetCheckIfPassConsist( string password)
        {
            return DriverBL.checkIfPassConsist( password);
        }

        //כניסת נהג/נוסע
        [Route("GetCheckPassword/{userName}/{password}")]
        public string GetCheckPassword(string userName, string password)
        {
            return  DriverBL.CheckPass(userName, password);
        }

        //הוספת נהג
        [Route("GetAddNewDriver/{userName}/{password}/{id}/{firstName}/{lastName}/{gender}/{age}/{adress}/{city}/{phone}/{mail}/{company}/{year}/{numOfChairs}/{aboutCar}/{sexPass}/{minAge}/{maxAge}/{area}/{morePreferences}")]
        public string GetAddNewDriver(string userName, string password, string id, string firstName, string lastName, string gender, int age, string adress, string city, string phone,
        string mail, string company, int year, int numOfChairs, string aboutCar, string sexPass, int minAge,int maxAge, int area, string morePreferences)
        {
            
        
            //age = DateTime.Now.Year - age;
            return "added " + DriverBL.AddDriver(new Driver(userName, password, id, firstName, lastName, gender, age, adress, city, phone, mail), new Car(company, year, numOfChairs, aboutCar), new Preference(sexPass, minAge, maxAge, area, morePreferences));
        }

        //שליפת שם המשתמש
        [Route("GetUserName/{password}")]
        public string GetUserName(string password)
        {
            return DriverBL.GetUserName(password);
        }

        //person שליפת אובייקט מסוג 

        [Route("GetDetailsOfPerson/{password}")]
        public DTO.Person GetDetailsOfPerson(string password)
        {
            return DriverBL.GetDetailOfPerson(password);
        }

        //עדכון פרטים אישיים
        [Route("GetUpdateDetails/{userName}/{NewPassword}/{firstName}/{lastName}/{adress}/{city}/{phone}/{mail}/{password}")]
        public string GetUpdateDetails(string userName, string NewPassword, string firstName, string lastName, string adress, string city, string phone,
        string mail,string password)
        {
            return "added " + DriverBL.UpdateDetails(new Person(userName, NewPassword, firstName, lastName, adress, city, phone, mail),password);
        }

        //[Route("GetSerilaze")]
        //public void GetSerilaze()
        //{
        //    DriverBL.Serilaze();
        //}

        [Route("GetSerilazeFromXML")]
        public void GetSerilazeFromXML()
        {
            DriverBL.DeserilazeFromXML();
        }
 

       
    }
}
