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
    
    public partial class Car
    {
        public Car()
        {
            this.Drivers = new HashSet<Driver>();
        }
    
        public int Id { get; set; }
        public string Company { get; set; }
        public Nullable<int> DateOfCreature { get; set; }
        public int NumOfChairs { get; set; }
        public string StateTheCar { get; set; }
        public string Image { get; set; }
    
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}