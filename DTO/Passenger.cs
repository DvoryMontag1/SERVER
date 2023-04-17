using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
   public class Passenger:Person
    {
       
        public Passenger(string userName, string password, string id, string firstName, string lastName, string sex, int age, string adress, 
        string city,string phone,string mail) : base(userName, password, id, firstName, lastName, sex, age, adress,
       city,phone, mail)
        {
           
        }


        

        public Passenger()
        {

        }




        //convert dto ==> dal
        public static DAL.Passenger ConvertPassengerToDAL(Passenger passenger)
        {
            DAL.Person user = new DAL.Person()
            {
                UserName = passenger.UserName,
                Password = passenger.Password,
                Id = passenger.Id,
                FirstName = passenger.FirstName,
                LastName = passenger.LastName,
                Gender = passenger.Gender,
                Age = passenger.Age,
                Adress = passenger.Adress,
                City = passenger.City,
                Phone = passenger.Phone,
                Mail = passenger.Mail
            };

            DAL.Passenger passengers = new DAL.Passenger()
            {
                Person = user,
            };

            return passengers;
        }

    }


        ////convert dal==>dto
        //public static Passenger convertDriverToDTO(PassengerDAL passengerDAL)
        //{
        //    return new Passenger()
        //    {
        //        UserName = passengerDAL.UserName,
        //        Password = passengerDAL.Password,
        //        Id = passengerDAL.Id,
        //        FirstName = passengerDAL.FirstName,
        //        LastName = passengerDAL.LastName,
        //        Sex = passengerDAL.Sex,
        //        Age = passengerDAL.Age,
        //        Adress = passengerDAL.Adress,
        //        City = passengerDAL.City,
        //        Phone = passengerDAL.Phone,
        //        Mail = passengerDAL.Mail,
        //        Forever = passengerDAL.Forever
        //    };
        //}
    }

