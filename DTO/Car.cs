using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class Car
    {
        public string Company { get; set; }
        public int DateOfCreature { get; set; } //שנת יצור
        public int NumOfChairs { get; set; }
        public string StateTheCar { get; set; }
        public string Image { get; set; }


        //todo:
        //אני רוצה להוסיף אפשרות צירוף תמונה

        public Car(string company, int dateOfCreature, int numOfChairs, string stateTheCar, string image)
        {
            Company = company;
            DateOfCreature = dateOfCreature;
            NumOfChairs = numOfChairs;
            StateTheCar = stateTheCar;
            Image = image;
        }

        public Car(string company, int dateOfCreature, int numOfChairs, string stateTheCar)
        {
            Company = company;
            DateOfCreature = dateOfCreature;
            NumOfChairs = numOfChairs;
            StateTheCar = stateTheCar;
           
        }

        public Car()
        {
        }

        //convert dto ==> dal
        public static DAL.Car ConvertCarToDAL(Car car)
        {

            //Car cars = new Car()
            //{
            //    Company = car.Company,
            //    DateOfCreature = car.DateOfCreature,
            //    NumOfChairs = car.NumOfChairs,
            //    StateTheCar = car.StateTheCar,
            //    //תמונה
            //};

            return new DAL.Car()
            {
                Company = car.Company,
                DateOfCreature = car.DateOfCreature,
                NumOfChairs = car.NumOfChairs,
                StateTheCar = car.StateTheCar,

            };
        }

        //convert dal==>dto

        public static DTO.Car ConvertCarToDTO(DAL.Car car)
        {
            return new DTO.Car()
            {
                Company = car.Company,
                DateOfCreature =(int) car.DateOfCreature,
                NumOfChairs = car.NumOfChairs,
                StateTheCar = car.StateTheCar,
                
            };
        }
    }
}
