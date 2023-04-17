using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class DetailsOfTravel
    {
        public int Id { get; set; }
        public Driver driver { get; set; }
        public string Exit { get; set; }
        public string Destination { get; set; } //יעד
        public DateTime startDayAndHour { get; set; }
        public DateTime endDay { get; set; }
        public int numOfChirs { get; set; }
        public TimeSpan Time { get; set; }
        public double Price { get; set; }

        public DetailsOfTravel(string exit, string destination, DateTime startDayAndHour, DateTime endDay, TimeSpan time , int numOfChirs, double price)
        {
            Exit = exit;
            Destination = destination;
            this.startDayAndHour = startDayAndHour;
            this.endDay = endDay;
            Time = time;
            this.numOfChirs = numOfChirs;
            Price = price;
        }



        public DetailsOfTravel()
        {
        }



        //convert dto ==> dal
        public static DAL.DetailsOfTravel ConvertTravelToDAL(DTO.DetailsOfTravel detailsOfTravel)
        {
            return new DAL.DetailsOfTravel()
            {
                Exit = detailsOfTravel.Exit,
                Destination = detailsOfTravel.Destination,
                startDayAndHour = detailsOfTravel.startDayAndHour,
                endDay = detailsOfTravel.endDay,
                Time = detailsOfTravel.Time.Ticks,
                numOfChirs = detailsOfTravel.numOfChirs,
                Price = detailsOfTravel.Price
            };


        }

        //convert dal==>dto
        public static DTO.DetailsOfTravel convertTravelToDTO(DAL.DetailsOfTravel DetailsOfTravelDAL)
        {
            return new DTO.DetailsOfTravel()
            {
                Id = DetailsOfTravelDAL.Id,
                Exit = DetailsOfTravelDAL.Exit,
                Destination = DetailsOfTravelDAL.Destination,
                startDayAndHour = DetailsOfTravelDAL.startDayAndHour,
                endDay =(DateTime)DetailsOfTravelDAL.endDay,
                Time =TimeSpan.FromTicks( DetailsOfTravelDAL.Time),
                numOfChirs = DetailsOfTravelDAL.numOfChirs,
                Price =(Double) DetailsOfTravelDAL.Price
            };
        }
    }
}

