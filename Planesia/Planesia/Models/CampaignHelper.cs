using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Planesia.Models
{
    public class CampaignHelper
    {
        PlanesiaDBsEntities context = new PlanesiaDBsEntities();

        public IEnumerable<Campaign> GetAllData()
        {
            IEnumerable<Campaign> result = from c in context.Campaigns
                                           select c;
            return result;
        }
    }
}