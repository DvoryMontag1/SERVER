using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CarDAL
    {

        //שליפת פרטי הרכב
        public static DAL.Car GetCar(string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Person p = DB.People.First(p1 => p1.Password == pass);
                DAL.Driver d = DB.Drivers.First(d1 => d1.PersonId == p.Id);
                return DB.Cars.First(c1 => c1.Id == d.Car);
            }
        }

                //עדכון פרטי הרכב
        public static string UpdateCar(DAL.Car car1,string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {

                DAL.Person p = DB.People.First(p1 => p1.Password == pass);
                DAL.Driver d = DB.Drivers.First(d1 => d1.PersonId == p.Id);
                DB.Cars.First(c1 => c1.Id == d.Car).Company = car1.Company;
                DB.Cars.First(c1 => c1.Id == d.Car).DateOfCreature = car1.DateOfCreature;
                DB.Cars.First(c1 => c1.Id == d.Car).NumOfChairs = car1.NumOfChairs;
                DB.Cars.First(c1 => c1.Id == d.Car).StateTheCar = car1.StateTheCar;
               
                DB.SaveChanges();

                return "succsses";
            }
        }
    }
}
