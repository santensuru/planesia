using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Models;
using System.Data.Entity;

namespace Planesia.Repository
{
    public class CampaignRepositoryDb : ICampaignRepository
    {
        private PlanesiaDBsEntities context = new PlanesiaDBsEntities();

        public List<Campaign> Campaigns
        {
            get
            {
                List<Campaign> result;

                result = context.Campaigns.ToList();
                
                return result;
            }
        }

        public Campaign GetCampaignById(int id)
        {
            Campaign campaign;

            campaign = (from c in context.Campaigns
                        where c.CampaignId == id
                        select c).FirstOrDefault<Campaign>();

            return campaign;
        }

        public void AddCampaign(Campaign c)
        {
            context.Campaigns.Add(c);
            context.SaveChanges();
        }

        public void UpdateCampaign(Campaign c)
        {
            context.Entry(c).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteCampaign(int id)
        {
            Campaign campaign;
            campaign = context.Campaigns.Find(id);
            context.Campaigns.Remove(campaign);
            context.SaveChanges();
        }
    }
}