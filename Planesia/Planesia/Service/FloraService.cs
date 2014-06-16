using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Planesia.Repository;
using Planesia.Models;

namespace Planesia.Service
{
    public class FloraService
    {
        IFloraRepository floraRepository;

        public FloraService()
        {
            floraRepository = new FloraRepositoryDb();
        }

        public FloraService(IFloraRepository repository)
        {
            floraRepository = repository;
        }

        public List<Flora> GetAllFloras()
        {
            return floraRepository.Floras;
        }

        public Flora GetFloraById(int id)
        {
            return floraRepository.GetFloraById(id);
        }

        public void AddFlora(Flora f)
        {
            floraRepository.AddFlora(f);
        }

        public void UpdateFlora(Flora f)
        {
            floraRepository.UpdateFlora(f);
        }

        public void DeleteFlora(int id)
        {
            floraRepository.DeleteFlora(id);
        }
    }
}