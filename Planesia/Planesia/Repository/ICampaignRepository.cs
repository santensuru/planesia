using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Planesia.Models;

namespace Planesia.Repository
{
    public interface ICampaignRepository
    {
        List<Campaign> Campaigns { get; }

        Campaign GetCampaignById(int id);

        void AddCampaign(Campaign c);

        void UpdateCampaign(Campaign c);

        void DeleteCampaign(int id);
    }
}
