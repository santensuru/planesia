//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Planesia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Fauna
    {
        public int FaunaId { get; set; }
        public string FaunaName { get; set; }
        public string FaunaLatinName { get; set; }
        public Nullable<System.DateTime> FaunaDate { get; set; }
        public string FaunaOtherDescription { get; set; }
        public string FaunaPhoto { get; set; }
        public Nullable<int> UserId { get; set; }
        public string FaunaStatus { get; set; }
        public Nullable<double> FaunaLongitude { get; set; }
        public Nullable<double> FaunaLatitude { get; set; }
        public string FaunaReference { get; set; }
        public string KomentarFauna { get; set; }
    
        public virtual User User { get; set; }
    }
}
