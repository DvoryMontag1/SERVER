using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Messages
        {
        public string idDriver { get; set; }
        public string idPassenger { get; set; }
        public string Message { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool DriverToPassenger { get; set; }

        public Messages()
        {
      
        }

        public Messages(string idGiveMassage, string idGetMassage, string message,DateTime dateAndTime,bool DtoP)
        {
           idDriver = idGiveMassage;
            idPassenger = idGetMassage;
            Message = message;
            DateAndTime = dateAndTime;
            DriverToPassenger = DtoP;
        }

        //convert dto ==> dal
        public static DAL.Message ConvertMassageToDAL(DTO.Messages myMessage)
        {
            return new DAL.Message()
            {
                idDriver = myMessage.idDriver,
                idPassenger = myMessage.idPassenger,
                MessageText = myMessage.Message,
                Time=myMessage.DateAndTime,
                driverToPassenger=myMessage.DriverToPassenger
            };
        }

        //convert dal==>dto
        public static DTO.Messages convertMassageToDTO(DAL.Message myMessage)
        {
            return new DTO.Messages()
            {
                idDriver = myMessage.idDriver,
                idPassenger = myMessage.idPassenger,
                Message = myMessage.MessageText,
                DateAndTime = myMessage.Time,
                DriverToPassenger=myMessage.driverToPassenger
                
            };
        }
    }
}


