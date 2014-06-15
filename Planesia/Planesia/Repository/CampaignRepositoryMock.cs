using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;

namespace Planesia.Repository
{
    public class CampaignRepositoryMock : ICampaignRepository
    {
        List<Campaign> campaigns;

        public CampaignRepositoryMock(){
            campaigns = new List<Campaign>();

            campaigns.Add(new Campaign() { CampaignId = 1, CampaignName = "Mock1" });
            campaigns.Add(new Campaign() { CampaignId = 2, CampaignName = "Mock2" });
            campaigns.Add(new Campaign() { CampaignId = 3, CampaignName = "Mock3" });
            campaigns.Add(new Campaign() { CampaignId = 4, CampaignName = "Mock4" });
            campaigns.Add(new Campaign() { CampaignId = 5, CampaignName = "Mock5" });
        }
        
        public List<Campaign> Campaigns
        {
            get { return campaigns; }
        }

        public Campaign GetCampaignById(int id)
        {
            Campaign result = (from c in campaigns
                               where c.CampaignId == id
                               select c).FirstOrDefault<Campaign>();

            return result;
        }

        public void AddCampaign(Campaign c)
        {
            campaigns.Add(c);
        }

        public void UpdateCampaign(Campaign c)
        {
            int index = campaigns.FindIndex(p => p.CampaignId == c.CampaignId);
            if (index < 0)
            {
                campaigns.Add(c);
            }
            else
            {
                campaigns[index] = c;
            }
        }

        public void DeleteCampaign(int id)
        {
            Campaign result = (from c in campaigns
                               where c.CampaignId == id
                               select c).FirstOrDefault<Campaign>();

            campaigns.Remove(result);
        }
    }
}