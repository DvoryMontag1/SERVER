using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
   public class TravelBL
    {
        //הוספת נסיעה
        public static int AddTravel(DTO.DetailsOfTravel detailsOfTravel, string pass)
        {
            DAL.DetailsOfTravel d = DTO.DetailsOfTravel.ConvertTravelToDAL(detailsOfTravel);
            return TravelDAL.Travel(d, pass);
        }

        //מחיקת נסיעה
        public static string DeleteTravel(int idTravel)
        {
            List<string> idPass= TravelDAL.DeleteTravel(idTravel);
            List<DAL.Message> Delete = new List<Message>();
            for(int i=0;i<idPass.Count()-2;i++)
            {
                DTO.Messages m = new DTO.Messages(idPass[idPass.Count - 2], idPass[i], idPass[idPass.Count - 1], DateTime.Now, true);
                Delete.Add(DTO.Messages.ConvertMassageToDAL(m));
            }

             return TravelDAL.addMessageToPassengers(Delete);
         
        }

        //שליפת פרטי נסיעה בשביל עדכון
        public static DTO.DetailsOfTravel GetdetailsOfTravel(int idTravel)
        {
            DAL.DetailsOfTravel t = TravelDAL.GetdetailsOfTravel(idTravel);
            DTO.DetailsOfTravel travel= DTO.DetailsOfTravel.convertTravelToDTO(t);
            return travel;
        }


        //עדכון פרטי נסיעה
        public static string UpdateDetailsOfTravel(DTO.DetailsOfTravel detailsOfTravel, int idTravel)
        {
            DAL.DetailsOfTravel d = DTO.DetailsOfTravel.ConvertTravelToDAL(detailsOfTravel);
            return TravelDAL.UpdateDetailsOfTravel(d, idTravel);
        }

        //שליפת כל הנסיעות
        public static List<DTO.DetailsOfTravel> GetAllTravels()
        {
            List<DAL.DetailsOfTravel> travel = TravelDAL.GetAllTravels();
            List<DTO.DetailsOfTravel> travelDTO = new List<DTO.DetailsOfTravel>();
            for(int i=0;i<travel.Count;i++)
            {
                travelDTO.Add(DTO.DetailsOfTravel.convertTravelToDTO(travel[i]));
            }
            return travelDTO;
        }

        //נהג רוצה מצטרפים של נסיעה מסוימת
        public static List<DTO.Person> JoinersToTravel(int idTravel)
        {
            List<DAL.Person> joiners = TravelDAL.JoinersToTravel(idTravel);
            List<DTO.Person> joinersDTO = new List<DTO.Person>();
            for (int i = 0; i < joiners.Count; i++)
            {
                joinersDTO.Add(DTO.Person.ConvertPersonToDTO(joiners[i]));
            }
            return joinersDTO;
        }

        //חיפוש נסיעות
        public static List<DTO.DetailsOfTravel> GetSearchTravels(string search,string pass)
        {
            List<DAL.DetailsOfTravel> travel = TravelDAL.GetSearchTravels(search,pass);
            List<DTO.DetailsOfTravel> travelDTO = new List<DTO.DetailsOfTravel>();
            for (int i = 0; i < travel.Count; i++)
            {
                travelDTO.Add(DTO.DetailsOfTravel.convertTravelToDTO(travel[i]));
            }
            return travelDTO;
        }

        ////שליפת שם הנהג
        public static string GetDriverName(int idTravel)
        {
            return TravelDAL.GetDriverName(idTravel);
        }

        //שליפת העדפות נהג
        //public static DTO.Driver GetPreference(int idTravel)
        //{
        //    DAL.Driver d = TravelDAL.GetPreference(idTravel);
        //    DTO.Driver d1 = DTO.Driver.ConvertDriverToDTO(d);
        //    return d1;
        //}

        public static string GetPreference(int idTravel)
        {
          return TravelDAL.GetPreference(idTravel);
            
        }

        //נוסע רוצה את כל הנסיעות שלו
        public static List<DTO.DetailsOfTravel> GetAllTravelsPassenger(string id)
        {
            List<DAL.DetailsOfTravel> travel = TravelDAL.GetAllTravelsPassenger(id);
            List<DTO.DetailsOfTravel> travelDTO = new List<DTO.DetailsOfTravel>();
            for (int i = 0; i < travel.Count; i++)
            {
                travelDTO.Add(DTO.DetailsOfTravel.convertTravelToDTO(travel[i]));
            }
            return travelDTO;
        }


        //נהג רוצה את כל הנסיעות שלו
        public static List<DTO.DetailsOfTravel> GetAllTravelsDriver(string pass)
        {
            List<DAL.DetailsOfTravel> travel = TravelDAL.GetAllTravelsDriver(pass);
            List<DTO.DetailsOfTravel> travelDTO = new List<DTO.DetailsOfTravel>();
            for (int i = 0; i < travel.Count; i++)
            {
                travelDTO.Add(DTO.DetailsOfTravel.convertTravelToDTO(travel[i]));
            }
            return travelDTO;
        }

        //נוסע רוצה לשלוח בקשה לנהג מסוים
        //שליפת id של הנהג לאחסון המקומי
        public static string GetIdDriver(int idTravel)
        {
            return TravelDAL.GetIdDriver(idTravel);
        }

        //שליחת הודעות
        public static void GetAddMassage(DTO.Messages myMassage)
        {
            DAL.Message m = DTO.Messages.ConvertMassageToDAL(myMassage);
             TravelDAL.GetAddMassage(m);
        }


        //שליפת הודעות
        public static List<string> GetAllMyMessage(string id, bool status)
        {
            return TravelDAL.GetAllMyMessage(id, status);
        }
    }
}



