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
    
    public partial class Preference
    {
        public Preference()
        {
            this.Drivers = new HashSet<Driver>();
        }
    
        public int Id { get; set; }
        public string Gender { get; set; }
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public int Area { get; set; }
        public string MorePreference { get; set; }
    
        public virtual ICollection<Driver> Drivers { get; set; }
    }
}