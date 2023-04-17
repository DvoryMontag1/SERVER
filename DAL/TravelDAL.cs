using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class TravelDAL
    {

        //הוספת נסיעה
        public static int Travel(DetailsOfTravel detailsOfTravel,string pass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Person p = DB.People.Where(p1 => p1.Password == pass).FirstOrDefault();
                DAL.Driver d = DB.Drivers.Where(i => i.Person.Id == p.Id).FirstOrDefault();
                detailsOfTravel.DriverId = d.Id;
                DB.DetailsOfTravels.Add(detailsOfTravel);
                DB.SaveChanges();
                return DB.DetailsOfTravels.Count();
            }
        }

        //מחיקת נסיעה
        public static List<string> DeleteTravel(int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {

                DAL.DetailsOfTravel travel = DB.DetailsOfTravels.First(t => t.Id == idTravel);
                DateTime date = travel.startDayAndHour;
                string text = "הנסיעה מ" + travel.Exit + " ל" + travel.Destination + " בתאריך " + date.Day+"/"+date.Month+"/"+date.Year + " התבטלה ";

                List<string> idPassengers = new List<string>();

                foreach (DAL.Joiner join in DB.Joiners)
                {
                    if (join.TravelId == idTravel)
                    {
                        idPassengers.Add(join.PassengerId);
                    //DB.Messages.Add(travel.DriverId, join.PassengerId, text,DateTime.Now, true);
                        DB.Joiners.Remove(join);
                    }
                          
                       
                }
                DB.DetailsOfTravels.Remove(DB.DetailsOfTravels.First(t => t.Id == idTravel));
                DB.SaveChanges();

                idPassengers.Add(DB.Drivers.First(d=>d.Id==travel.DriverId).PersonId);
                idPassengers.Add(text);
                return idPassengers;
            }
        }

        //הודע השלחת אוטומטית לנוסעים על מחיקת נסיעה
        public static string addMessageToPassengers(List<DAL.Message> m)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                for(int i=0;i<m.Count();i++)
                {
                    DB.Messages.Add(m[i]);
                    DB.SaveChanges();
                }
            }
            return "";
        }

        //שליפת פרטי נסיעה בשביל עדכון
        public static DAL.DetailsOfTravel GetdetailsOfTravel(int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                return DB.DetailsOfTravels.First(t => t.Id == idTravel);
            }
        }

        //עדכון פרטי נסיעה
        public static string UpdateDetailsOfTravel(DAL.DetailsOfTravel detailsOfTravel,int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DB.DetailsOfTravels.First(t => t.Id == idTravel).Exit = detailsOfTravel.Exit;
                DB.DetailsOfTravels.First(t => t.Id == idTravel).Destination = detailsOfTravel.Destination;
                DB.DetailsOfTravels.First(t => t.Id == idTravel).startDayAndHour = detailsOfTravel.startDayAndHour;
                DB.DetailsOfTravels.First(t => t.Id == idTravel).endDay = detailsOfTravel.endDay;
                DB.DetailsOfTravels.First(t => t.Id == idTravel).Time = detailsOfTravel.Time;
                DB.DetailsOfTravels.First(t => t.Id == idTravel).numOfChirs = detailsOfTravel.numOfChirs;
                DB.DetailsOfTravels.First(t => t.Id == idTravel).Price = detailsOfTravel.Price;
                DB.SaveChanges();
                return "@@";
            }
        }

        //שליפת כל הנסיעות העתידיות
        public static List<DAL.DetailsOfTravel> GetAllTravels()
        {
            using (carDBEntities DB = new carDBEntities())
            {
               List <DAL.DetailsOfTravel> travels=  DB.DetailsOfTravels.Where(t => (DateTime.Now < t.startDayAndHour) || (DateTime.Now < t.endDay)).ToList();
                return travels;
            }

        }

        //חיפוש נסיעות לפי יציאה , יעד או תאריך
        public static List<DAL.DetailsOfTravel> GetSearchTravels(string search,string pass)
        {
           
                string[] allSearch = search.Split(',');
                string exit = allSearch[0];
                string destination = allSearch[1];
                DateTime date1 = new DateTime();
                DateTime date = new DateTime();
                if (allSearch[2] != "")
                    date = DateTime.Parse(allSearch[2]);
                using (carDBEntities DB = new carDBEntities())
                {
                DAL.Person passenger= DB.People.First(p => p.Password == pass);

                    List<DAL.DetailsOfTravel> travels = DB.DetailsOfTravels.Where(t => t.Exit.Contains(exit) && t.Destination.Contains(destination) && (((date >= t.startDayAndHour) && (date <= t.endDay)) || date == date1)).ToList();
                    List<DAL.DetailsOfTravel> travels1 = new List<DetailsOfTravel>();
                       for(int i=0;i<travels.Count();i++ )
                       {
                           int idDriver = travels[i].DriverId;
                           DAL.Driver pr = DB.Drivers.Include("Preference").Where(p => p.Id == idDriver).FirstOrDefault();
                           if ((passenger.Gender == pr.Preference.Gender|| pr.Preference.Gender.Equals("כל אחד")) && DateTime.Now.Year- passenger.Age >= pr.Preference.MinAge && DateTime.Now.Year - passenger.Age <= pr.Preference.MaxAge)
                           travels1.Add(travels[i]);
                       }
                return travels1;
                }
        }

        //שליפת נהג של נסיעה
        public static string GetDriverName(int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.DetailsOfTravel t = DB.DetailsOfTravels.First(t1 => t1.Id == idTravel);
                DAL.Driver d = DB.Drivers.First(d1 => d1.Id == t.DriverId);
                return DB.People.First(p => p.Id == d.PersonId).UserName;
            }
        }


        //שליפת  נהג
        //public static DAL.Driver GetPreference(int idTravel)
        //{
        //    using (carDBEntities DB = new carDBEntities())
        //    {
        //        int idDriver = DB.DetailsOfTravels.First(t => t.Id == idTravel).DriverId;
        //        DAL.Driver d = DB.Drivers.Include("Preference").Where(p => p.Id == idDriver).FirstOrDefault();
        //        return d;
        //    }
        //}

        public static string GetPreference(int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                int idDriver = DB.DetailsOfTravels.First(t => t.Id == idTravel).DriverId;
                DAL.Driver d = DB.Drivers.Include("Preference").Where(p => p.Id == idDriver).FirstOrDefault();
                return d.Preference.MorePreference;
            }
        }


        //נוסע רוצה את כל הנסיעות שלו
        public static List<DAL.DetailsOfTravel> GetAllTravelsPassenger(string idPass)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                return DB.DetailsOfTravels.Where(t => t.Joiners.Any(p => p.PassengerId == idPass)).ToList();
            }
        }

        //נהג רוצה את כל הנסיעות שלו
        public static List<DAL.DetailsOfTravel> GetAllTravelsDriver(string passDriver)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                DAL.Person p = DB.People.First(p1 => p1.Password == passDriver);
                int identity = DB.Drivers.First(d => d.PersonId == p.Id).Id;
                return DB.DetailsOfTravels.Where(t => t.DriverId==identity).ToList();
            }
        }

        //נהג רוצה מצרפים של נסיעה מסוימת
        public static List<DAL.Person> JoinersToTravel(int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                List<DAL.Joiner> joiners = DB.Joiners.Where(j => j.TravelId == idTravel).ToList();
                List<DAL.Person> passengers = new List<DAL.Person>();
                for (int i = 0; i < joiners.Count(); i++)
                {
                    string id = joiners[i].PassengerId;
                    passengers.Add(DB.People.First(p => p.Id == id));
                }

                //  DB.People.Where(p1=>p1.Passenger.)

                return passengers;
            }

        }

        //נוסע רוצה לשלוח בקשה לנהג מסוים
        //שליפת id של הנהג לאחסון המקומי
        public static string GetIdDriver(int idTravel)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                int id = DB.DetailsOfTravels.First(t => t.Id == idTravel).DriverId;
                return DB.Drivers.First(d => d.Id == id).PersonId;
            }
        }

        //שליחת הודעות
        public static void GetAddMassage(DAL.Message myMassage)
        {
            using (carDBEntities DB = new carDBEntities())
            {
                //myMassage.Person = DB.People.Where(i => i.Id==myMassage.idDriver).FirstOrDefault();
                //myMassage.Passenger = DB.Passengers.Where(i => i.PassengerId == myMassage.idPassenger).FirstOrDefault();
                foreach (Person p in DB.People)
                    if (p.Id == myMassage.idDriver)
                        myMassage.Person = p;
                foreach (Passenger p in DB.Passengers)
                    if (p.PassengerId == myMassage.idPassenger)
                        myMassage.Passenger = p;
                DB.Messages.Add(myMassage);
                DB.SaveChanges();
            }
        }

        //שליפת הודעות
        public static List<string> GetAllMyMessage(string id, bool status)
        {
           
            using (carDBEntities DB = new carDBEntities())
            {
               
                List<string> messages = new List<string>();
                foreach (Message m in DB.Messages)
                {
                    if (m.idDriver == id&&m.driverToPassenger==status)
                    messages.Add(DB.People.First(p => p.Id.Equals(m.idPassenger)).UserName + "^" + m.MessageText + "^" + m.Time);


                    if (m.idPassenger == id && m.driverToPassenger == status)
                        messages.Add(DB.People.First(p => p.Id.Equals(m.idDriver)).UserName + "^" + m.MessageText + "^" + m.Time);

                }
                return messages;
            }
        }

    }

      
}
