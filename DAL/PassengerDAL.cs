using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class PassengerDAL
    {
        //הוספת נוסע
        public static int AddPassenger(DAL.Passenger passenger)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                passenger.PassengerId = passenger.PassengerId;
                DB.Passengers.Add(passenger);
                DB.SaveChanges();
                return DB.Passengers.Count();
            }
        }

        //נוסע מצטרף לנסיעה
        public static void GetJoinToTravel(string pasPassenger, int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DB.DetailsOfTravels.First(t => t.Id == idTravel).numOfChirs -= 1;
                string idPassenger = DB.People.First(p => p.Password == pasPassenger).Id;
                DAL.Joiner j = new Joiner(idPassenger, idTravel);
                DB.Joiners.Add(j);
                DB.SaveChanges();
            }
        }

        //נוסע מבטל הצטרפות לנסיעה
        public static void GetCancelGoiner(string idPassenger, int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DB.DetailsOfTravels.First(t => t.Id == idTravel).numOfChirs += 1;
                DB.Joiners.Remove(DB.Joiners.First(j1 => j1.PassengerId == idPassenger&&j1.TravelId==idTravel));
                DB.SaveChanges();

            }
        }

        //בדיקה אם הנוסע כבר הצטרף לנסיעה זו
        public static int GetIfJoin(int idTravel, string idPassenger)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Joiner j = DB.Joiners.Where(j1 => j1.PassengerId == idPassenger && j1.TravelId == idTravel).FirstOrDefault();
                if (j == null)
                    return 0;
                return 1;
            }
        }
    }
}






