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
    
    public partial class Campaign
    {
        public int CampaignId { get; set; }
        public string CampaignName { get; set; }
        public Nullable<System.DateTime> CampaignDate { get; set; }
        public Nullable<int> UserId { get; set; }
        public string CampaignStatus { get; set; }
        public string CampaignDescription { get; set; }
    
        public virtual User User { get; set; }
    }
}
