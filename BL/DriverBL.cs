using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Xml.Serialization;
using System.IO;
 
namespace BL
{
    public class DriverBL
    {

        //בדיקה אם הסיסמה שהמצטרף רוצה להכניס כבר קיימת
        public static int checkIfPassConsist(string pass)
        {
            return DriverDAL.checkIfPassConsist(pass);
        }

        //בדיקת סיסמת נהג/נוסע  
        public static string CheckPass(string userName, string password)
        {
            return DriverDAL.pass(userName, password);
        }

        //הוספת נהג
        public static int AddDriver(DTO.Driver driver, DTO.Car car, DTO.Preference preference)
        {
            DAL.Driver driDAL = DTO.Driver.ConvertDriverToDAL(driver);
            DAL.Car carDAL = DTO.Car.ConvertCarToDAL(car);
            DAL.Preference preferenceDAL = DTO.Preference.ConvertPreferenceToDAL(preference);
            return DriverDAL.addDriverDAL(driDAL, carDAL, preferenceDAL);
        }

        //שליפת שם המשתמש
        public static string GetUserName(string password)
        {
            return DAL.DriverDAL.GetUserName(password);
        }

        //person שליפת אובייקט מסוג 
        public static DTO.Person GetDetailOfPerson(string password)
        {
            DAL.Person pDAL = DAL.DriverDAL.GetPerson(password);
            DTO.Person p = DTO.Person.ConvertPersonToDTO(pDAL);
            return p;
        }

        //עדכון פרטים אישיים
        public static string UpdateDetails(DTO.Person person,string password)
        {
            DAL.Person peDAL =DTO.Person.ConvertPersonToDAL(person);
            return DriverDAL.UpdateDetails(peDAL, password);
        }



        //הוספת פרטי מכונית
        //public static string AddDitailOfCar(Car car,string password)
        //{
        //    int index= DB.drivers.FindIndex(i => i.Password == password);
        //    CarDAL carDal = Car.ConvertCarToDAL(car);
        //    DAL.DB.drivers[index].Car = carDal;
        //    return "sacsses";
        //}


        //public static void Serilaze()
        //{
        //    SerilazeToXML(DAL.DB.drivers);
        //}



        //כתיבה למסמך xml
        public static void SerilazeToXML(List<DriverDAL> allDrivers)
        {
            const string PATH = "F:\\שנה ב\\פרוייקט c#\\SERVER\\DAL\\XMLFile.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DriverDAL>));

            using (StreamWriter writer = File.AppendText(PATH))
            {
                xmlSerializer.Serialize(writer, allDrivers);
            }
        }

        //קריאה מהמסמך
        public static void DeserilazeFromXML()
        {
            const string PATH = "F:\\שנה ב\\פרוייקט c#\\SERVER\\DAL\\XMLFile.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<DriverDAL>));

            List<DriverDAL> allDrivers = new List<DriverDAL>();
            
            using (StreamReader reader = new StreamReader(PATH))
            {
                allDrivers = (List<DriverDAL>)xmlSerializer.Deserialize(reader);

            }
        }

       
    }
}
