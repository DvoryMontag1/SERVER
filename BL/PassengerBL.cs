using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

  namespace BL
{
    public class PassengerBL
    {

        //הוספת נוסע
        public static int AddPassenger(DTO.Passenger passenger)
        {
            DAL.Passenger pasDAL =DTO.Passenger.ConvertPassengerToDAL(passenger);
            return PassengerDAL.AddPassenger(pasDAL);
            
        }

        //נוסע מצטרף לנסיעה
        public static void GetJoinToTravel(string pasPassenger, int idTravel)
        {
            PassengerDAL.GetJoinToTravel(pasPassenger, idTravel);
        }

        //נוסע מבטל הצטרפות לנסיעה
        public static void GetCancelGoiner(string idPassenger,int idTravel)
        {
            PassengerDAL.GetCancelGoiner(idPassenger, idTravel);
        }

        //בדיקה אם הנוסע כבר הצטרף לנסיעה זו
        public static int GetIfJoin(int idTravel, string idPassenger)
        {
            return PassengerDAL.GetIfJoin(idTravel, idPassenger);
        }
    }
}

