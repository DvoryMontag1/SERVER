//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailsOfTravel
    {
        public DetailsOfTravel()
        {
            this.Joiners = new HashSet<Joiner>();
        }
    
        public int Id { get; set; }
        public int DriverId { get; set; }
        public string Exit { get; set; }
        public string Destination { get; set; }
        public System.DateTime startDayAndHour { get; set; }
        public Nullable<System.DateTime> endDay { get; set; }
        public int numOfChirs { get; set; }
        public long Time { get; set; }
        public Nullable<double> Price { get; set; }
    
        public virtual Driver Driver { get; set; }
        public virtual ICollection<Joiner> Joiners { get; set; }
    }
}