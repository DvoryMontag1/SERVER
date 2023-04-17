using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DTO
{
    public class Driver : Person
    {
        public Car Car { get; set; }
        
        public Preference Preference { get; set; }


        //בנאי מלא
        public Driver(string userName, string password, string id, string firstName, string lastName, string gender, int age, string adress, string city, string phone,
        string mail, Car car,  Preference preference) : base(userName, password, id, firstName, lastName,
        gender, age, adress, city, phone, mail)
        {
            Car = car;
            Preference = preference;
        }

        

        //בנאי ריק
        public Driver()
        {

        }

        //בנאי חלקי אולי זמני 
        public Driver(string userName, string password, string id, string firstName, string lastName, string gender, int age, string adress, string city, string phone,
        string mail) : base(userName, password, id, firstName, lastName,
        gender, age, adress, city, phone, mail)
        {

        }


        //convert dto ==> dul
        public static DAL.Driver ConvertDriverToDAL(Driver driver)
        {
            DAL.Person user = new DAL.Person()
            {
                UserName = driver.UserName,
                Password = driver.Password,
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Gender = driver.Gender,
                Age = driver.Age,
                Adress = driver.Adress,
                City = driver.City,
                Phone = driver.Phone,
                Mail = driver.Mail
            };

            DAL.Driver drivers = new DAL.Driver()
            {
                Person = user,
            };

            return drivers;
        }

        //convert dul==>dto
        //public static DTO.Driver ConvertDriverToDTO(DAL.Driver driverDAL)
        //{

          
        //   return new DTO.Driver()
        //    {
        //       UserName = driverDAL.Person.UserName,
        //       Password = driverDAL.Person.Password,
        //       Id = driverDAL.Person.Id,
        //       FirstName = driverDAL.Person.FirstName,
        //       LastName = driverDAL.Person.LastName,
        //       Gender = driverDAL.Person.Gender,
        //       Age = driverDAL.Person.Age,
        //       Adress = driverDAL.Person.Adress,
        //       City = driverDAL.Person.City,
        //       Phone = driverDAL.Person.Phone,
        //       Mail = driverDAL.Person.Mail,

        //       Preference = DTO.Preference.convertPreferenceToDTO(driverDAL.Preference)

        //   };
        //}
    } 
} 
