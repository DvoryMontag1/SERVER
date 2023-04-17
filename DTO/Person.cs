using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class Person
    {
        public string UserName { get; set; }
        private string password;

        public string Password
        {
            get { return password; }
            set {
                if (value.Length == 7)
                    password = value;
                }
        }

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }

        public Person(string userName, string password,  string id, string firstName, string lastName, string gender, int age, 
        string adress, string city, string phone, string mail)
        {
            UserName = userName;
            Password = password;
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            Age = age;
            Adress = adress;
            City = city;
            Phone = phone;
            Mail = mail;
        }

        public Person(string userName, string password,  string firstName, string lastName,
        string adress, string city, string phone, string mail)
        {
            UserName = userName;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            Adress = adress;
            City = city;
            Phone = phone;
            Mail = mail;
        }

        public Person(string userName, string password)
        {
            UserName = userName;
            this.password = password;
        }

        public Person()
        {
            Id = "null";
            FirstName = "guest";
        }

        //convert dto ==> dal
        public static DAL.Person ConvertPersonToDAL(Person person)
        {
            DAL.Person user = new DAL.Person()
            {
                UserName = person.UserName,
                Password = person.Password,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Adress = person.Adress,
                City = person.City,
                Phone = person.Phone,
                Mail = person.Mail
            };

            return user;
        }



        //convert dal ==> dto
        public static DTO.Person ConvertPersonToDTO(DAL.Person person)
        {
            DTO.Person user = new DTO.Person()
            {
                UserName = person.UserName,
                Password = person.Password,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Age=person.Age,
                Adress = person.Adress,
                City = person.City,
                Phone = person.Phone,
                Mail = person.Mail
            };



            return user;
        }
    }
}
