using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Repository;
using Planesia.Models;

namespace Planesia.Service
{
    public class CampaignService
    {
        ICampaignRepository campaignRepository;

        public CampaignService()
        {
            campaignRepository = new CampaignRepositoryDb();
        }

        public CampaignService(ICampaignRepository repository)
        {
            campaignRepository = repository;
        }

        public List<Campaign> GetAllCampaigns()
        {
            return campaignRepository.Campaigns;
        }

        public Campaign GetCampaignById(int id)
        {
            return campaignRepository.GetCampaignById(id);
        }

        public void AddCampaign(Campaign c)
        {
            campaignRepository.AddCampaign(c);
        }

        public void UpdateCampaign(Campaign c)
        {
            campaignRepository.UpdateCampaign(c);
        }

        public void DeleteCampaign(int id)
        {
            campaignRepository.DeleteCampaign(id);
        }
    }
}