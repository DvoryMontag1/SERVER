using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BL
{
    
   public class CarBL
    {

        //שליפת פרטי הרכב
        public static DTO.Car GetCar(string password)
        {
            DAL.Car c = DAL.CarDAL.GetCar(password);
            return DTO.Car.ConvertCarToDTO(c);
        }


        //עדכון פרטי רכב
        public static string UpdateCar(DTO.Car car1, string password)
        {
            DAL.Car cDAL = DTO.Car.ConvertCarToDAL(car1);

            return CarDAL.UpdateCar(cDAL,password);
        }
    }
}

