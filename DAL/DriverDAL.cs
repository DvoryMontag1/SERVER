using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Collections.Generic;



namespace DAL
{
    public class DriverDAL
    {
        //בדיקה אם הסיסמה שהמצטרף רוצה להכניס כבר קיימת
        public static int checkIfPassConsist(string pass)
        {

            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Person p = DB.People.Where(p1 =>p1.Password == pass).FirstOrDefault();
                if (p != null)
                    return 1;
                return 0;
            }
        }

        //כניסת משתמש
        public static string pass(string username, string password)
        {

            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Driver d = DB.Drivers.Where(i => i.Person.Password == password && i.Person.UserName == username).FirstOrDefault();
                if (d != null)
                    return "driver"+"$"+d.PersonId;

                DAL.Passenger p = DB.Passengers.Where(i => i.Person.Password == password && i.Person.UserName == username).FirstOrDefault();
                if (p != null)
                    return "passenger"+"$"+p.PassengerId;

                else
                {
                    return "*שגיאה נסה שוב";
                }
            }
        }

        //הוספת נהג
        public static int addDriverDAL(DAL.Driver driDAL, DAL.Car car, DAL.Preference preference)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DB.Cars.Add(car);
                DB.Preferences.Add(preference);
                DB.SaveChanges();

            }


            using (carDBEntities DB = new carDBEntities())
            {
                driDAL.Car = DB.Cars.ToList().Last().Id;
                driDAL.PreferenceId = DB.Preferences.ToList().Last().Id;
                DB.Drivers.Add(driDAL);
                DB.SaveChanges();
                return DB.Drivers.ToList().Count;
            }

        }

        //שליפת שם המשתמש
        public static string GetUserName(string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                return DB.People.Where(p => p.Password == pass).FirstOrDefault().UserName+"$"+
                    DB.People.Where(p => p.Password == pass).FirstOrDefault().Id;
            }
        }

            //שליפת אובייקט של person
        public static DAL.Person GetPerson(string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                return DB.People.Where(p => p.Password == pass).FirstOrDefault();
            }
        }


        //עדכון פרטים אישיים
        public static string UpdateDetails(DAL.Person driDAL, string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DB.People.First(p => p.Password == pass).FirstName = driDAL.FirstName;
                DB.People.First(p => p.Password == pass).LastName = driDAL.LastName;
                DB.People.First(p => p.Password == pass).City = driDAL.City;
                DB.People.First(p => p.Password == pass).Adress = driDAL.Adress;
                DB.People.First(p => p.Password == pass).Phone = driDAL.Phone;
                DB.People.First(p => p.Password == pass).Mail = driDAL.Mail;
                DB.People.First(p => p.Password == pass).UserName = driDAL.UserName;
                DB.People.First(p => p.Password == pass).Password = driDAL.Password;
                DB.SaveChanges();

            }

            return "details";
        }
    }
}
